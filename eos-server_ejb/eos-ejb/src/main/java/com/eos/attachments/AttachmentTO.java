package com.eos.attachments;

import com.eos.utilities.BinaryTO;
import java.io.Serializable;
import javax.xml.bind.annotation.XmlType;
/**
 *  Attachment
 */
@XmlType( name="AttachmentTO", namespace="com.eos" )
public class AttachmentTO implements Serializable {
    
    /**
     * Data
     */
    private int id;
    private String fileName;
    private String fileDescription;
    private long fileSize;
    private BinaryTO fileData;
    private boolean deleted;
    
    /**
     * Properties
     */
    public int getId() { return id; }
    public void setId(int value) { this.id = value; }
    
    public String getFileName() { return fileName; }
    public void setFileName( String value ) { this.fileName = value; }

    public String getFileDescription() { return fileDescription; }
    public void setFileDescription( String value ) { this.fileDescription = value; }

    public long getFileSize() { return fileSize; }
    public void setFileSize( long value ) { this.fileSize = value; }

    public boolean isDeleted() { return deleted; }
    public void setDeleted( boolean value ) { this.deleted = value; }   

    public BinaryTO getFileData() { return fileData; }
    public void setFileData( BinaryTO value ) { this.fileData = value; }  
}
