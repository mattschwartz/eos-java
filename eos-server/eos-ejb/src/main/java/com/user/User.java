package com.eos.user;

/**
 * Imports
 */
import com.eos.data.BaseEntity;
import java.util.ArrayList;
import java.util.List;
import javax.persistence.*;

@Entity
@Table(name = "users")
@NamedQueries({
    @NamedQuery(name = User.GET_BY_EMAIL, query = "SELECT a FROM User a WHERE a.email = :email"),
    @NamedQuery(name = User.GET_ALL, query = "SELECT a FROM User a"),
    @NamedQuery(name = User.GET_BY_NAME, query = "SELECT a FROM User a WHERE a.userName = :username")
})
public class User extends BaseEntity
{
    private static final long serialVersionUID = 1L;
    
    private static final String PREFIX = "User.";
    public static final String GET_BY_EMAIL = PREFIX + "getUserByEmail";
    public static final String GET_ALL = PREFIX + "getAllUsers";
    public static final String GET_BY_NAME = PREFIX + "getUserByName";
    
    /**
     * Data
     */
    
    private String userName;
    private String email;
    private String password;
    private boolean emailVerified;
    private List<User> friends = new ArrayList<User>();
    private String recoveryLink;
    private boolean recoveryNeeded;

    /**
     * Properties
     */
    @Id
    @GeneratedValue( strategy=GenerationType.IDENTITY )
    public int getId() { return id; }
    public void setId( int value ) { this.id = value; }

    @Column( name="Username" )
    public String getUserName() { return userName; }
    public void setUserName( String value ) { this.userName = value; }
    
    @Column( name="Email" )
    public String getEmail() { return email; }
    public void setEmail( String value ) { this.email = value; }
    
    @Column( name="Password" )
    public String getPassword() { return password; }
    public void setPassword( String value ) { this.password = value; }
    
    @Column( name="EmailVerified" )
    public boolean getEmailVerified() { return emailVerified; }
    public void setEmailVerified( boolean value ) { this.emailVerified = value; }
    
    @ManyToMany
    @JoinColumn( name="users" )
    public List<User> getFriends() { return friends; }
    public void setFriends( List<User> value ) { this.friends = value; }
    
    @Column( name="RecoveryLink")
    public String getRecoveryLink() { return recoveryLink; }
    public void setRecoveryLink( String value ) { this.recoveryLink = value; }
    
    @Column( name="RecoveryNeeded")
    public boolean isRecoveryNeeded() { return recoveryNeeded; }
    public void setRecoveryNeeded( boolean value ) { this.recoveryNeeded = value; }

}
