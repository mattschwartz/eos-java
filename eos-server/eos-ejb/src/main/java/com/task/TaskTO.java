package com.eos.task;

import com.eos.attachments.AttachmentTO;
import com.eos.event.EventTO;
import com.eos.user.UserTO;
import java.io.Serializable;
import java.util.List;
import javax.xml.bind.annotation.XmlType;

/**
 *  TaskTO
 */
@XmlType( name="TaskTO", namespace="com.eos" )
public class TaskTO implements Serializable{
    /**
     * Data
     */
    private int id;
    private int xPos;
    private int yPos;
    private String title;
    private String color;
    private String comments;
    private UserTO owner;
    private EventTO event;
    private boolean deleted;
    private List<AttachmentTO> attachments;

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
    
    public String getComments() { return comments; }
    public void setComments(String value) { this.comments = value; }
    
    public String getColor() { return color; }
    public void setColor(String value) { this.color = value; }
    
    public UserTO getOwner() { return owner; }
    public void setOwner(UserTO value) { this.owner = value; }
    
    public EventTO getEvent() { return event; }
    public void setEvent(EventTO value) { this.event = value; }
    
    public boolean isDeleted() { return deleted; }
    public void setDeleted( boolean value ) { this.deleted = value; } 
    
    public List<AttachmentTO> getAttachments() { return attachments; }
    public void setAttachments(List<AttachmentTO> value) { this.attachments = value; }
}
