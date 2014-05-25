package com.eos.task;

/**
 * Imports
 */
import com.eos.attachments.Attachment;
import com.eos.data.BaseEntity;
import com.eos.event.Event;
import com.eos.user.User;
import java.util.ArrayList;
import java.util.List;
import javax.persistence.*;

/**
 *  Subject
 */
@NamedQueries({
    @NamedQuery(name = Task.GET_ALL, query = "SELECT a FROM Task a"),
    @NamedQuery(name = Task.GET_BY_USER_ID, query = "SELECT a FROM User a WHERE a.id = :id"),
})
@Entity
@Table(name = "tasks")
public class Task extends BaseEntity {
    
    private static final long serialVersionUID = 1L;
    private static final String PREFIX = "Task.";
    public static final String GET_ALL = PREFIX + "getAllTasks";
    public static final String GET_BY_USER_ID = PREFIX + "getAllTasksByUserId";
    
    /**
     * Data
     */
    private int xPos;
    private int yPos;
    private String title;
    private String color;
    private String comments;
    private User owner;
    private Event event;
    private boolean deleted;
    private List<Attachment> attachments = new ArrayList<Attachment>();
    
    /**
     * Properties
     */
    
    @Id
    @GeneratedValue( strategy=GenerationType.IDENTITY )
    public int getId() { return id; }
    public void setId(int value) { this.id = value; }
    
    @Column( name = "xPos")
    public int getXPos() { return xPos; }
    public void setXPos(int value) { this.xPos = value; }
    
    @Column( name = "yPos")
    public int getYPos() { return yPos; }
    public void setYPos(int value) { this.yPos = value; }
    
    @Column( name = "name")
    public String getTitle() { return title; }
    public void setTitle(String value) { this.title = value; }
    
    @Column( name = "comments")
    public String getComments() { return comments; }
    public void setComments(String value) { this.comments = value; }
    
    @Column( name = "color")
    public String getColor() { return color; }
    public void setColor(String value) { this.color = value; }
    
    @JoinColumn( name = "owner")
    public User getOwner() { return owner; }
    public void setOwner(User value) { this.owner = value; }
    
    @JoinColumn( name = "event")
    public Event getEvent() { return event; }
    public void setEvent(Event value) { this.event = value; }
    
    @Column( name= "deleted" )
    public boolean isDeleted() { return deleted; }
    public void setDeleted( boolean value ) { this.deleted = value; } 
    
    @JoinColumn( name = "attachments")
    public List<Attachment> getAttachments() { return attachments; }
    public void setAttachments(List<Attachment> value) { this.attachments = value; }
}
