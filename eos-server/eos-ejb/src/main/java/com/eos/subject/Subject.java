package com.eos.subject;

/**
 * Imports
 */
import com.eos.data.BaseEntity;
import com.eos.event.Event;
import com.eos.task.Task;
import com.eos.user.User;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import javax.persistence.*;

/**
 *  Subject
 */
@NamedQueries({
    @NamedQuery(name = Subject.GET_ALL, query = "SELECT a FROM Subject a")
})
@Entity
@Table(name = "subjects")
public class Subject extends BaseEntity{
    private static final long serialVersionUID = 1L;
    private static final String PREFIX = "Subject.";
    public static final String GET_ALL = PREFIX + "getAllSubjects";
    
    /**
     * Data
     */
    private int xPos;
    private int yPos;
    private String title;
    private String color;
    private Event event;
    private String details;
    private User owner;
    private List<Task> tasks = new ArrayList<Task>();
    private boolean isShared = false;
    private List<User> sharedUsers = new ArrayList<User>();
    private boolean deleted = false;
    private int radius;
    
    //future data needs
    //private List<Attachments> attachments
    //private int importance

    /**
     * Properties
     */
    
    @Id
    @GeneratedValue( strategy=GenerationType.IDENTITY )
    public int getId() { return id; }
    public void setId(int value) { this.id = value; }
    
    @Column( name = "xpos")
    public int getXPos() { return xPos; }
    public void setXPos(int value) { this.xPos = value; }
    
    @Column( name = "ypos")
    public int getYPos() { return yPos; }
    public void setYPos(int value) { this.yPos = value; }
    
    @Column( name = "name")
    public String getTitle() { return title; }
    public void setTitle(String value) { this.title = value; }
    
    @Column( name = "color")
    public String getColor() { return color; }
    public void setColor(String value) { this.color = value; }
    
    @JoinColumn( name = "event")
    public Event getEvent() { return event; }
    public void setEvent(Event value) { this.event = value; }
    
    @Column( name = "details")
    public String getDetails() { return details; }
    public void setDetails(String value) { this.details = value; }
    
    @JoinColumn( name = "owner")
    public User getOwner() { return owner; }
    public void setOwner(User value) { this.owner = value; }
    
    @JoinColumn( name = "tasks")
    public List<Task> getTasks() { return tasks; }
    public void setTasks(List<Task> value) { this.tasks = value; }
    
    @Column( name = "isShared")
    public boolean isShared() { return isShared; }
    public void setShared(boolean value) { this.isShared = value; }
    
    @JoinColumn( name = "users")
    public List<User> getSharedUsers() { return sharedUsers; }
    public void setSharedUsers(List<User> value) { this.sharedUsers = value; }
    
    @Column( name = "deleted")
    public boolean isDeleted() { return deleted; }
    public void setDeleted(boolean value) { this.deleted = value; }
    
    @Column( name = "radius")
    public int getRadius() { return radius; }
    public void setRadius(int value) { this.radius = value; }
}
