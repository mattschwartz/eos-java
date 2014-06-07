package com.eos.user;

/**
 * Imports
 */
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlType;

/**
 * UserTO
 */
@XmlType( name="UserTO", namespace="com.eos" )
public class UserTO implements Serializable 
{
    private static final long serialVersionUID = 1L;

    /**
     * Private
     */
    private int id;
    private String userName;
    private String email;
    private String password;
    private boolean emailVerified;
    private List<Integer> friends = new ArrayList<Integer>();
    private String recoveryLink;
    private boolean recoveryNeeded;
    
    /**
     * Properties
     */
    public int getId() { return id; }
    public void setId( int value ) { this.id = value; }
    
    public String getUserName() { return userName; }
    public void setUserName( String value ) { this.userName = value; }

    public String getEmail() { return email; }
    public void setEmail( String value ) { this.email = value; }
    
    public String getPassword() { return password; }
    public void setPassword( String value ) { this.password = value; }
    
    public boolean getEmailVerified() { return emailVerified; }
    public void setEmailVerified( boolean value ) { this.emailVerified = value; }
    
    public List<Integer> getFriends() { return friends; }
    public void setFriends( List<Integer> value ) { this.friends = value; }
    
    public String getRecoveryLink() { return recoveryLink; }
    public void setRecoveryLink( String value ) { this.recoveryLink = value; }
    
    public boolean isRecoveryNeeded() { return recoveryNeeded; }
    public void setRecoveryNeeded( boolean value ) { this.recoveryNeeded = value; }
    
}
