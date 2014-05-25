package com.eos.task;

import com.eos.attachments.Attachment;
import com.eos.attachments.AttachmentManagerBean;
import com.eos.attachments.AttachmentTO;
import com.eos.crud.CrudManagerBean;
import com.eos.event.Event;
import com.eos.event.EventManager;
import com.eos.subject.SubjectManagerBean;
import com.eos.user.User;
import com.eos.user.UserManagerBean;
import java.util.ArrayList;
import java.util.List;
import javax.ejb.EJB;
import javax.ejb.LocalBean;
import javax.ejb.Stateless;

/**
 *  TaskManagerBean
 */
@Stateless
@LocalBean
public class TaskManagerBean
{

    /**
     * Data
     */
    @EJB
    CrudManagerBean crudService;
    @EJB
    UserManagerBean userService;
    @EJB
    SubjectManagerBean subjectService;
    @EJB
    AttachmentManagerBean attachmentService;
    @EJB
    EventManager eventService;

    public TaskTO getTaskTO(Task data)
    {
        if (data == null) {
            throw new IllegalStateException("Task cannot be null");
        }
        if (data.getId() < 1) {
            throw new IllegalArgumentException("Task id cannot be less than 1");
        }

        TaskTO task = new TaskTO();
        task.setId(data.getId());
        task.setColor(data.getColor());
        task.setTitle(data.getTitle());
        task.setComments(data.getComments());
        task.setXPos(data.getXPos());
        task.setYPos(data.getYPos());
        task.setOwner(userService.getUserTO(data.getOwner()));
        task.setDeleted(data.isDeleted());
        task.setEvent(eventService.getEventTO(data.getEvent()));

        List<AttachmentTO> attachments = new ArrayList<AttachmentTO>();
        for (Attachment at : data.getAttachments()) {
            attachments.add(attachmentService.getAttachmentTO(at));
        }
        task.setAttachments(attachments);

        return task;
    }

    public TaskTO getTaskTO(int taskId)
    {
        Task task = crudService.find(taskId, Task.class);

        return getTaskTO(task);
    }

    public TaskTO saveTask(TaskTO data)
    {
        Task task = new Task();
        if (data == null) {
            throw new IllegalStateException("Task cannot be null");
        }
        if (data.getId() > 0) {
            task = crudService.find(Task.class, data.getId());
        }

        task.setColor(data.getColor());
        task.setTitle(data.getTitle());
        task.setComments(data.getComments());
        int eid = eventService.saveEvent(data.getEvent()).getId();
        task.setEvent(crudService.find(Event.class, eid));
        task.setOwner(crudService.find(User.class, data.getOwner().getId()));
        task.setXPos(data.getXPos());
        task.setYPos(data.getYPos());
        task.setDeleted(data.isDeleted());


        if (data.getAttachments() != null) {
            List<Attachment> attachments = new ArrayList<Attachment>();
            for (AttachmentTO at : data.getAttachments()) {
                at = attachmentService.saveAttachment(at);
                attachments.add(crudService.find(Attachment.class, at.getId()));
            }
            task.setAttachments(attachments);
        }


        task = crudService.save(task);
        return getTaskTO(task);
    }

    public void deleteTask(Task data)
    {
        data.setDeleted(true);
        data.getEvent().setDeleted(true);
        crudService.save(data);
    }

    public void deleteTask(int taskId)
    {
        deleteTask(crudService.find(Task.class, taskId));
    }

}
