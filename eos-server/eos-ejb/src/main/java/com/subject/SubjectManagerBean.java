package com.eos.subject;

import com.eos.crud.CrudManagerBean;
import com.eos.event.Event;
import com.eos.event.EventManager;
import com.eos.task.Task;
import com.eos.task.TaskManagerBean;
import com.eos.task.TaskTO;
import com.eos.user.User;
import com.eos.user.UserManagerBean;
import com.eos.user.UserTO;
import java.util.ArrayList;
import java.util.List;
import javax.ejb.EJB;
import javax.ejb.LocalBean;
import javax.ejb.Stateless;

/**
 *  SubjectManagerBean
 */
@Stateless
@LocalBean
public class SubjectManagerBean
{

    /**
     * Data
     */
    @EJB
    CrudManagerBean crudService;
    @EJB
    UserManagerBean userService;
    @EJB
    TaskManagerBean taskService;
    @EJB
    EventManager eventService;

    /**
     * Creates a SubjectTO given a Subject object
     * @param data The Subject to be transferred
     * @return The SubjectTO representation of Subject
     */
    public SubjectTO getSubjectTO(Subject data)
    {
        if (data == null) {
            throw new IllegalStateException("Subject cannot be null");
        }
        if (data.getId() < 1) {
            throw new IllegalArgumentException("Subject id cannot be less than 1");
        }

        SubjectTO result = new SubjectTO();
        result.setId(data.getId());
        result.setColor(data.getColor());
        result.setXPos(data.getXPos());
        result.setYPos(data.getYPos());
        result.setEvent(eventService.getEventTO(data.getEvent()));
        result.setOwner(userService.getUserTO(data.getOwner()));
        result.setDeleted(data.isDeleted());
        result.setTitle(data.getTitle());
        result.setDetails(data.getDetails());
        result.setShared(data.isShared());
        result.setRadius(data.getRadius());

        List<TaskTO> tasks = new ArrayList<TaskTO>();
        for (Task task : data.getTasks()) {
            tasks.add(taskService.getTaskTO(task));
        }
        result.setTasks(tasks);

        List<UserTO> users = new ArrayList<UserTO>();
        for (User user : data.getSharedUsers()) {
            users.add(userService.getUserTO(user));
        }
        result.setSharedUsers(users);

        return result;
    }

    /**
     * Gets a SubjectTO given a subject id
     * @param subjectId the subject id
     * @return A SubjectTO
     */
    public SubjectTO getSubjectTO(int subjectId)
    {
        Subject subject = crudService.find(subjectId, Subject.class);

        return getSubjectTO(subject);
    }

    /**
     * Saves/updates all the data associated with a SubjectTO
     * @param data The SubjectTO to save/update
     * @return The SubjectTO with updated values and id number
     */
    public SubjectTO saveSubject(SubjectTO data)
    {
        Subject subject = new Subject();
        if (data == null) {
            throw new IllegalStateException("Subject cannot be null");
        }
        if (data.getId() > 0) {
            subject = crudService.find(data.getId(), Subject.class);
        }

        subject.setId(data.getId());
        subject.setColor(data.getColor());
        subject.setXPos(data.getXPos());
        subject.setYPos(data.getYPos());
        int eid = eventService.saveEvent(data.getEvent()).getId();
        subject.setEvent(crudService.find(Event.class, eid));
        subject.setOwner(crudService.find(User.class, data.getOwner().getId()));
        subject.setShared(data.isShared());
        subject.setDeleted(data.isDeleted());
        subject.setTitle(data.getTitle());
        subject.setDetails(data.getDetails());
        subject.setRadius(data.getRadius());

        List<Task> tasks = new ArrayList<Task>();
        for (TaskTO task : data.getTasks()) {
            task = taskService.saveTask(task);
            tasks.add(crudService.find(Task.class, task.getId()));
        }
        subject.setTasks(tasks);

        List<User> users = new ArrayList<User>();
        for (UserTO user : data.getSharedUsers()) {
            users.add(crudService.find(User.class, user.getId()));
        }
        subject.setSharedUsers(users);

        subject = crudService.save(subject);

        return getSubjectTO(subject);
    }

    /**
     * Deletes the given Subject
     * @param subject The Subject object to be deleted.
     */
    public void deleteSubject(Subject subject)
    {
        subject.setDeleted(true);
        crudService.save(subject);
    }

    /**
     * Deletes the given Subject
     * @param id The id of the Subject
     */
    public void deleteSubject(int subjectId)
    {
        deleteSubject(crudService.find(Subject.class, subjectId));
    }

    /**
     * Gets all the Subjects associated with a user that are not deleted
     * @param userId The user's id
     * @return A list of SubjectTO's
     */
    public List<SubjectTO> getAllSubjectsByUser(int userId)
    {
        List<Subject> subjects = crudService.findByNamedQuery(Subject.GET_ALL);
        List<SubjectTO> subjectTOs = new ArrayList<SubjectTO>();

        for (Subject subject : subjects) {
            if (!subject.isDeleted()) {
                subjectTOs.add(getSubjectTO(subject));
            }
        }

        return subjectTOs;
    }

    /**
     * Adds a given Task to the given Subject
     * @param task The Task to be added.
     * @param subject The Subject to add it to.
     * @return The SubjectTO that the task got added to.
     */
    public SubjectTO addTaskToSubject(TaskTO task, SubjectTO subject)
    {
        subject.getTasks().add(task);

        return saveSubject(subject);
    }

}
