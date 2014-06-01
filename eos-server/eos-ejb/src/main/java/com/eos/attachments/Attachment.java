package com.eos.attachments;

import com.eos.data.BaseEntity;
import javax.persistence.*;
/**
 *  Attachment
 */
@Entity
@Table(name = "Attachments")
public class Attachment extends BaseEntity {
    private static final long serialVersionUID = 1L;
    /**
     * Data
     */
    private String fileName;
    private String fileDescription;
    private long fileSize;
    private byte[] fileData;
    private boolean deleted;
    
    /**
     * Properties
     */
    @Id
    @GeneratedValue( strategy=GenerationType.IDENTITY )
    public int getId() { return id; }
    public void setId(int value) { this.id = value; }
    
    @Column( name="FileName" )
    public String getFileName() { return fileName; }
    public void setFileName( String value ) { this.fileName = value; }

    @Column( name="FileDescription", length=1024 )
    public String getFileDescription() { return fileDescription; }
    public void setFileDescription( String value ) { this.fileDescription = value; }

    @Column( name="FileSize" )
    public long getFileSize() { return fileSize; }
    public void setFileSize( long value ) { this.fileSize = value; }

    @Column( name="Deleted" )
    public boolean isDeleted() { return deleted; }
    public void setDeleted( boolean value ) { this.deleted = value; }   

    @Column( name="FileData" )
    public byte[] getFileData() { return fileData; }
    public void setFileData( byte[] value ) { this.fileData = value; }  
}
