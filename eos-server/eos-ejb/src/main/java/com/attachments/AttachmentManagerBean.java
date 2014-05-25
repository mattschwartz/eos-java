package com.eos.attachments;

import com.eos.crud.CrudManagerBean;
import com.eos.utilities.BinaryTO;
import javax.ejb.EJB;
import javax.ejb.LocalBean;
import javax.ejb.Stateless;

/**
 *  AttachmentManagerBean
 */
@Stateless
@LocalBean
public class AttachmentManagerBean
{
   @EJB
   CrudManagerBean crudService;
    
    public AttachmentTO getAttachmentTO(Attachment data)
    {
        if(data == null) {
            throw new IllegalStateException("Attachment cannot be null");
        }
        if(data.getId() < 1) {
            throw new IllegalArgumentException("Attachment id cannot be less than 1");
        }
        AttachmentTO attachment = new AttachmentTO();
        attachment.setId(data.getId());
        attachment.setFileSize(data.getFileSize());
        attachment.setFileName(data.getFileName());
        attachment.setFileDescription(data.getFileDescription());
        attachment.setDeleted(data.isDeleted());

        BinaryTO fileDataBinaryTO = new BinaryTO();
        fileDataBinaryTO.setData(data.getFileData());
        attachment.setFileData(fileDataBinaryTO);

        return attachment;
    }

    public AttachmentTO getAttachmentTO(int attachmentId)
    {
        Attachment attachment = crudService.find(Attachment.class, attachmentId);
        
        return getAttachmentTO(attachment);
    }
    
    public AttachmentTO saveAttachment(AttachmentTO data)
    {
        Attachment result = new Attachment();
        if (data.getId() > 0) {
            result = crudService.find(Attachment.class, data.getId());
        }
        
        result.setFileSize(data.getFileSize());
        result.setFileName(data.getFileName());
        result.setFileDescription(data.getFileDescription());
        result.setDeleted(data.isDeleted());
        result.setFileData(data.getFileData().getData());
                
        result = crudService.save(result);
        
        return getAttachmentTO(result);
    }
    
    public void deleteAttachment(Attachment data)
    {
        data.setDeleted(true);
        crudService.save(data);
    }

    public void deleteAttachment(int AttachmentId)
    {
        deleteAttachment(crudService.find(Attachment.class, AttachmentId));
    }
}
