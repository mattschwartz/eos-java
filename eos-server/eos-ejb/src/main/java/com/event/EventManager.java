package com.eos.event;

import com.eos.crud.CrudManagerBean;
import javax.ejb.EJB;
import javax.ejb.LocalBean;
import javax.ejb.Stateless;

/**
 *  EventManager
 */
@Stateless
@LocalBean
public class EventManager {
    
    @EJB
    CrudManagerBean crudService;
    
    public EventTO getEventTO(Event data) 
    {
        EventTO result = new EventTO();
        
        result.setId(data.getId());
        result.setEndTime(data.getEndTime());
        result.setLocation(data.getLocation());
        result.setReminderTime(data.getReminderTime());
        result.setRepeats(data.isRepeats());
        result.setStartTime(data.getStartTime());
        result.setDeleted(data.isDeleted());
        
        return result;
    }
    
    public EventTO getEventTO(int id)
    {
        Event result = crudService.find(Event.class, id);
        
        return getEventTO(result);
    }
    
    public EventTO saveEvent(EventTO data)
    {
        Event result = new Event();
        
        if(data.getId() > 0) {
            result = crudService.find(data.getId(), Event.class);
        } else {
            crudService.persist(result);
        }
        
        result.setEndTime(data.getEndTime());
        result.setLocation(data.getLocation());
        result.setReminderTime(data.getReminderTime());
        result.setRepeats(data.isRepeats());
        result.setStartTime(data.getStartTime());
        result.setDeleted(data.isDeleted());
        
        result = crudService.save(result);
        
        return getEventTO(result);
    }
    
    public void deleteEvent(Event data)
    {
        data.setDeleted(true);
        crudService.save(data);
    }

    public void deleteEvent(int eventId)
    {
        deleteEvent(crudService.find(Event.class, eventId));
    }
}
