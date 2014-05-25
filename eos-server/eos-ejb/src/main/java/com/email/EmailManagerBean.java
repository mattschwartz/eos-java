package com.eos.email;

import com.eos.attachments.Attachment;
import com.eos.attachments.AttachmentManagerBean;
import com.eos.attachments.AttachmentTO;
import com.eos.crud.CrudManagerBean;
import com.eos.user.User;
import com.eos.user.UserManagerBean;
import com.eos.user.UserTO;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;
import java.util.Properties;
import javax.activation.DataHandler;
import javax.annotation.Resource;
import javax.ejb.EJB;
import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.mail.*;
import javax.mail.Message.RecipientType;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeBodyPart;
import javax.mail.internet.MimeMessage;
import javax.mail.internet.MimeMultipart;
import javax.mail.util.ByteArrayDataSource;

/**
 *  EmailManagerBean
 */
@Stateless
@LocalBean
public class EmailManagerBean
{

    @EJB
    CrudManagerBean crudService;
    @EJB
    UserManagerBean userManager;
    @EJB
    AttachmentManagerBean attachmentManager;
    @Resource(name = "mail/eos")
    private Session mailSession;

    public EmailTO getEmailTO(Email data)
    {
        EmailTO result = new EmailTO();
        result.setBody(data.getBody());
        result.setDateCreated(data.getDateCreated());
        result.setId(data.getId());
        result.setSubject(data.getSubject());
        result.setSender(userManager.getUserTO(data.getSender()));
        result.setDeleted(data.isDeleted());
        result.setHTML(data.isHTML());

        List<UserTO> recs = new ArrayList<UserTO>();
        for (User u : data.getReceivers()) {
            recs.add(userManager.getUserTO(u));
        }
        result.setReceivers(recs);

        List<UserTO> cc = new ArrayList<UserTO>();
        for (User u : data.getCC()) {
            cc.add(userManager.getUserTO(u));
        }
        result.setCC(cc);

        List<UserTO> bcc = new ArrayList<UserTO>();
        for (User u : data.getBCC()) {
            bcc.add(userManager.getUserTO(u));
        }
        result.setBCC(bcc);

        List<AttachmentTO> attachments = new ArrayList<AttachmentTO>();
        for (Attachment u : data.getAttachments()) {
            attachments.add(attachmentManager.getAttachmentTO(u));
        }
        result.setAttachments(attachments);

        return result;
    }

    public EmailTO getEmailTO(int emailId)
    {
        Email email = crudService.find(Email.class, emailId);

        return getEmailTO(email);
    }

    public EmailTO saveEmail(EmailTO data)
    {
        Email result = new Email();
        if (data.getId() > 0) {
            result = crudService.find(Email.class, data.getId());
        }
        result.setBody(data.getBody());
        result.setDateCreated(data.getDateCreated());
        result.setId(data.getId());
        result.setSubject(data.getSubject());
        UserTO sender = userManager.saveUser(data.getSender());
        result.setSender(crudService.find(User.class, sender.getId()));
        result.setDeleted(data.isDeleted());

        List<User> recs = new ArrayList<User>();
        for (UserTO u : data.getReceivers()) {
            recs.add(crudService.find(User.class, u.getId()));
        }
        result.setReceivers(recs);

        List<User> cc = new ArrayList<User>();
        for (UserTO u : data.getCC()) {
            cc.add(crudService.find(User.class, u.getId()));
        }
        result.setCC(cc);

        List<User> bcc = new ArrayList<User>();
        for (UserTO u : data.getBCC()) {
            bcc.add(crudService.find(User.class, u.getId()));
        }
        result.setBCC(bcc);

        List<Attachment> attachments = new ArrayList<Attachment>();
        for (AttachmentTO u : data.getAttachments()) {
            attachments.add(crudService.find(Attachment.class, u.getId()));
        }
        result.setAttachments(attachments);
        
        result = crudService.save(result);
        return getEmailTO(result);
    }

    public void deleteEmail(EmailTO data)
    {
        data.setDeleted(true);
        saveEmail(data);
    }

    public void deleteEmail(int emailId)
    {
        Email result = crudService.find(Email.class, emailId);
        deleteEmail(getEmailTO(result));
    }

    /**
     * 
     * @param sender The sender of the message
     * @param receivers The recipients of the message
     * @param subject The subject of the email
     * @param body The body of the email
     * @param attachments The Attachments of the email
     * @param cc The CC recipients of the email
     * @param bcc The BCC recipients of the email
     * @param html True if email is HTML format, false otherwise
     */
    public void sendEmail(UserTO sender, List<UserTO> receivers, String subject, String body, List<AttachmentTO> attachments, List<UserTO> cc, List<UserTO> bcc, boolean html)
    {
        EmailTO email = new EmailTO();
        email.setSender(sender);
        email.setReceivers(receivers);
        email.setSubject(subject);
        email.setBody(body);
        email.setAttachments(attachments);
        email.setCC(cc);
        email.setBCC(bcc);
        email.setHTML(html);
        email.setDateCreated(Calendar.getInstance().getTime());
        email.setDeleted(false);
        saveEmail(email);
        
        try {
            Message msg = new MimeMessage(mailSession);

            for (UserTO recipient : receivers) {
                msg.addRecipient(RecipientType.TO, new InternetAddress(recipient.getEmail()));
            }

            if (cc != null) {
                for (UserTO recipient : cc) {
                    msg.addRecipient(RecipientType.CC, new InternetAddress(recipient.getEmail()));
                }
            }

            if (bcc != null) {
                for (UserTO recipient : bcc) {
                    msg.addRecipient(RecipientType.CC, new InternetAddress(recipient.getEmail()));
                }
            }

            msg.setFrom(new InternetAddress(sender.getEmail()));
            Address[] reply = new Address[1];
            reply[0] = new InternetAddress(sender.getEmail());
            msg.setReplyTo(reply);
            msg.setSubject(subject);

            // Create the multi-part..
            Multipart multiPart = new MimeMultipart();

            // Create the body text..
            MimeBodyPart messageBodyPart = new MimeBodyPart();

            if (html) {
                messageBodyPart.setContent(body, "text/html");
            } else {
                messageBodyPart.setText(body);
            }

            multiPart.addBodyPart(messageBodyPart);

            // Create attachment parts..
            if (attachments != null) {
                for (AttachmentTO attachment : attachments) {
                    MimeBodyPart attachmentPart = new MimeBodyPart();
                    attachmentPart.setFileName(attachment.getFileName());

                    String mimeType = "application/octet-stream";

                    attachmentPart.setDataHandler(new DataHandler(new ByteArrayDataSource(attachment.getFileData().getData(), mimeType)));

                    multiPart.addBodyPart(attachmentPart);
                }
            }

            msg.setContent(multiPart);

            sendEmailMessage(msg);
        } catch (MessagingException ex) {
            System.out.println(ex);
        }
    }
    
    public void sendEmail(EmailTO email) 
    {
        sendEmail(email.getSender(), email.getReceivers(), email.getSubject(), email.getBody(), email.getAttachments(), email.getCC(), email.getBCC(), email.isHTML());
    }

    private void sendEmailMessage(Message message)
    {
        final String fromEmail = "project.eos.devteam@gmail.com";
        final String password = "Longhorns!";
        Properties props = new Properties();
        props.put("mail.smtp.starttls.enable", "true");
        props.put("mail.smtp.auth", "true");
        props.put("mail.smtp.host", "smtp.gmail.com");
        props.put("mail.smtp.port", "587");

        Session session = Session.getInstance(props,
                new javax.mail.Authenticator() {
            protected PasswordAuthentication getPasswordAuthentication() {
                return new PasswordAuthentication(fromEmail, password);
            }
        });
        
        try {
            Transport.send(message);
        } catch(Exception e) {
            System.out.println(e);
        }
    }

}
