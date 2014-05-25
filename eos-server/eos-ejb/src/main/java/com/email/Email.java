package com.eos.email;

import com.eos.attachments.Attachment;
import com.eos.data.BaseEntity;
import com.eos.user.User;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import javax.persistence.*;

/**
 *  Email
 */
@Entity
@Table(name = "Email")
public class Email extends BaseEntity {    
    /**
     * Data
     */
    private Date created;
    private User sender;
    private List<User> receivers = new ArrayList<User>();
    private String subject;
    private String body;
    private boolean deleted = false;
    private List<Attachment> attachments = new ArrayList<Attachment>();
    private boolean html = false;
    private List<User> cc = new ArrayList<User>();
    private List<User> bcc = new ArrayList<User>();
    
    /**
     * Properties
     */
    @Id
    @GeneratedValue( strategy=GenerationType.IDENTITY )
    public int getId() { return id; }
    public void setId(int value) { this.id = value; }
    
    @Column( name = "created")
    @Temporal(javax.persistence.TemporalType.DATE)
    public Date getDateCreated() { return created; }
    public void setDateCreated(Date value) { this.created = value; }
    
    @JoinColumn( name = "from")
    public User getSender() { return sender; }
    public void setSender(User value) { this.sender = value; }
     
    @JoinColumn( name = "receivers")
    public List<User> getReceivers() { return receivers; }
    public void setReceivers(List<User> value) { this.receivers = value; }
    
    @Column( name = "subject")
    public String getSubject() { return subject; }
    public void setSubject(String value) { this.subject = value; }
    
    @Column( name = "body")
    public String getBody() { return body; }
    public void setBody(String value) { this.body = value; }
    
    @Column( name = "deleted")
    public boolean isDeleted() { return deleted; }
    public void setDeleted(boolean value) { this.deleted = value; }
    
    @JoinColumn( name = "attachments")
    public List<Attachment> getAttachments() { return attachments; }
    public void setAttachments(List<Attachment> value) { this.attachments = value; }
    
    @Column( name = "html")
    public boolean isHTML() { return html; }
    public void setHTML(boolean value) { this.html = value; }
    
    @JoinColumn( name = "cc")
    public List<User> getCC() { return cc; }
    public void setCC(List<User> value) { this.cc = value; }
    
    @JoinColumn( name = "bcc")
    public List<User> getBCC() { return bcc; }
    public void setBCC(List<User> value) { this.bcc = value; }
}
