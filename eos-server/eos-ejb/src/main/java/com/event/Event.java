package com.eos.event;

import com.eos.data.BaseEntity;
import java.util.Date;
import javax.persistence.*;

/**
 *  Event
 */
@Entity
@Table(name = "Events")
public class Event extends BaseEntity {
    
    /**
     * Data
     */
    private Date startTime;
    private Date endTime;
    private String location;
    private boolean repeats;
    private Date reminderTime;
    private boolean deleted;
    
    /**
     * Properties
     */
    @Id
    @GeneratedValue( strategy=GenerationType.IDENTITY )
    public int getId() { return id; }
    public void setId(int value) { this.id = value; }

    @Temporal(javax.persistence.TemporalType.DATE)
    @Column( name = "startTime")
    public Date getStartTime() { return startTime; }
    public void setStartTime(Date value) { this.startTime = value; }

    @Column( name = "endTime")
    @Temporal(javax.persistence.TemporalType.DATE)
    public Date getEndTime() { return endTime; }
    public void setEndTime(Date value) { this.endTime = value; }

    @Column( name = "location")
    public String getLocation() { return location; }
    public void setLocation(String value) { this.location = value; }

    @Column( name = "repeats")
    public boolean isRepeats() { return repeats; }
    public void setRepeats(boolean value) { this.repeats = value; }

    @Column( name = "reminderTime")
    @Temporal(javax.persistence.TemporalType.DATE)
    public Date getReminderTime() { return reminderTime; }
    public void setReminderTime(Date value) { this.reminderTime = value; }
    
    @Column( name= "deleted" )
    public boolean isDeleted() { return deleted; }
    public void setDeleted( boolean value ) { this.deleted = value; } 
    
}
