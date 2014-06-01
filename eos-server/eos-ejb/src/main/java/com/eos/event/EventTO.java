package com.eos.event;

import java.io.Serializable;
import java.util.Date;
import javax.xml.bind.annotation.XmlType;

/**
 *  EventTO
 */
@XmlType( name="EventTO", namespace="com.eos" )
public class EventTO implements Serializable {
    
    private static final long serialVersionUID = 1L;
    
    /**
     * Data
     */
    private int id;
    private Date startTime;
    private Date endTime;
    private String location;
    private boolean repeats;
    private Date reminderTime;
    private boolean deleted;
    
    /**
     * Properties
     */
    public int getId() { return id; }
    public void setId(int value) { this.id = value; }

    public Date getStartTime() { return startTime; }
    public void setStartTime(Date value) { this.startTime = value; }

    public Date getEndTime() { return endTime; }
    public void setEndTime(Date value) { this.endTime = value; }

    public String getLocation() { return location; }
    public void setLocation(String value) { this.location = value; }

    public boolean isRepeats() { return repeats; }
    public void setRepeats(boolean value) { this.repeats = value; }

    public Date getReminderTime() { return reminderTime; }
    public void setReminderTime(Date value) { this.reminderTime = value; }
    
    public boolean isDeleted() { return deleted; }
    public void setDeleted( boolean value ) { this.deleted = value; } 
    
}
