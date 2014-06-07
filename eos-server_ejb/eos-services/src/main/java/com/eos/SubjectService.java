package com.eos;

import com.eos.subject.SubjectManagerBean;
import com.eos.subject.SubjectTO;
import com.eos.task.TaskTO;
import java.util.List;
import javax.ejb.EJB;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;

/**
 *  SubjectService
 */
@WebService(serviceName = "SubjectService")
public class SubjectService
{

    /**
     * Data
     */
    @EJB
    SubjectManagerBean subjectManager;

    @WebMethod(action = "getSubject")
    public SubjectTO getSubject(
            @WebParam(name = "subjectId") int subjectId)
    {
        return subjectManager.getSubjectTO(subjectId);
    }

    @WebMethod(action = "getAllSubjectsByUser")
    public List<SubjectTO> getAllSubjectsByUser(
            @WebParam(name = "userId") int userId)
    {
        return subjectManager.getAllSubjectsByUser(userId);
    }

    @WebMethod(action = "deleteSubject")
    public void deleteSubject(
            @WebParam(name = "id") int id)
    {
        subjectManager.deleteSubject(id);
    }

    @WebMethod(action = "saveSubject")
    public SubjectTO saveSubject(SubjectTO data)
    {
        return subjectManager.saveSubject(data);
    }

    @WebMethod(action = "addTaskToSubject")
    public SubjectTO addTaskToSubject(
            @WebParam(name = "task") TaskTO task,
            @WebParam(name = "subject") SubjectTO subject)
    {
        return subjectManager.addTaskToSubject(task, subject);
    }

}
