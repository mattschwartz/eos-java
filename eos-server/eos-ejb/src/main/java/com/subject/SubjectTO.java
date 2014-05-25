package com.eos.subject;

import com.eos.event.EventTO;
import com.eos.task.TaskTO;
import com.eos.user.UserTO;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import javax.xml.bind.annotation.XmlType;

/**
 *  SubjectTO
 */
@XmlType( name="SubjectTO", namespace="com.eos" )
public class SubjectTO implements Serializable {

    /**
     * Data
     */
    private int id;
    private int xPos;
    private int yPos;
    private int radius;
    private UserTO owner;
    private String title;
    private String color;
    private EventTO event;
    private String details;
    private List<TaskTO> tasks = new ArrayList<TaskTO>();
    private boolean isShared = false;
    private List<UserTO> sharedUsers = new ArrayList<UserTO>();
    private boolean deleted;
    
    //future data needs
    //private List<Attachments> attachments
    //private int importance

    /**
     * Properties
     */
    
    public int getId() { return id; }
    public void setId(int value) { this.id = value; }
    
    public int getXPos() { return xPos; }
    public void setXPos(int value) { this.xPos = value; }
    
    public int getYPos() { return yPos; }
    public void setYPos(int value) { this.yPos = value; }
    
    public String getTitle() { return title; }
    public void setTitle(String value) { this.title = value; }
    
    public String getColor() { return color; }
    public void setColor(String value) { this.color = value; }
    
    public EventTO getEvent() { return event; }
    public void setEvent(EventTO value) { this.event = value; }
    
    public String getDetails() { return details; }
    public void setDetails(String value) { this.details = value; }
    
    public UserTO getOwner() { return owner; }
    public void setOwner(UserTO value) { this.owner = value; }
    
    public List<TaskTO> getTasks() { return tasks; }
    public void setTasks(List<TaskTO> value) { this.tasks = value; } 
    
    public boolean isShared() { return isShared; }
    public void setShared(boolean value) { this.isShared = value; }
    
    public List<UserTO> getSharedUsers() { return sharedUsers; }
    public void setSharedUsers(List<UserTO> value) { this.sharedUsers = value; }
    
    public boolean isDeleted() { return deleted; }
    public void setDeleted(boolean value) { this.deleted = value; }
    
    public int getRadius() { return radius; }
    public void setRadius(int value) { this.radius = value; }
}
