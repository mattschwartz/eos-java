package com.eos;

import com.eos.task.TaskManagerBean;
import com.eos.task.TaskTO;
import java.util.List;
import javax.ejb.EJB;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;

/**
 *  TaskService
 */
@WebService(serviceName = "TaskService")
public class TaskService {
    /**
     * Data
     */
    @EJB
    TaskManagerBean taskManager;
    
    @WebMethod(action = "deleteTask")
    public void deleteTask(
            @WebParam(name = "id") int id)
    {
        taskManager.deleteTask(id);
    }
    
    @WebMethod(action = "saveTask")
    public TaskTO saveTask(TaskTO data)
    {
        return taskManager.saveTask(data);
    }
}
