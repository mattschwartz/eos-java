package com.eos.email;

import com.eos.attachments.AttachmentTO;
import com.eos.user.UserTO;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import javax.xml.bind.annotation.XmlType;

/**
 *  EmailTO
 */
@XmlType( name="EmailTO", namespace="com.eos" )
public class EmailTO implements Serializable{
    private static final long serialVersionUID = 1L;
    
    /**
     * Data
     */
    private int id;
    private Date created;
    private UserTO sender;
    private List<UserTO> receivers = new ArrayList<UserTO>();
    private String subject;
    private String body;
    private boolean deleted;
    private List<AttachmentTO> attachments = new ArrayList<AttachmentTO>();
    private boolean html = false;
    private List<UserTO> cc = new ArrayList<UserTO>();
    private List<UserTO> bcc = new ArrayList<UserTO>();
    
    /**
     * Properties
     */
    public int getId() { return id; }
    public void setId(int value) { this.id = value; }
    
    public Date getDateCreated() { return created; }
    public void setDateCreated(Date value) { this.created = value; }
    
    public UserTO getSender() { return sender; }
    public void setSender(UserTO value) { this.sender = value; }
     
    public List<UserTO> getReceivers() { return receivers; }
    public void setReceivers(List<UserTO> value) { this.receivers = value; }
    
    public String getSubject() { return subject; }
    public void setSubject(String value) { this.subject = value; }
    
    public String getBody() { return body; }
    public void setBody(String value) { this.body = value; }
    
    public boolean isDeleted() { return deleted; }
    public void setDeleted(boolean value) { this.deleted = value; }
    
    public List<AttachmentTO> getAttachments() { return attachments; }
    public void setAttachments(List<AttachmentTO> value) { this.attachments = value; }
    
    public boolean isHTML() { return html; }
    public void setHTML(boolean value) { this.html = value; }
    
    public List<UserTO> getCC() { return cc; }
    public void setCC(List<UserTO> value) { this.cc = value; }
    
    public List<UserTO> getBCC() { return bcc; }
    public void setBCC(List<UserTO> value) { this.bcc = value; }
}
