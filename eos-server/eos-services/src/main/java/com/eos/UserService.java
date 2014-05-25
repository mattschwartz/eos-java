package com.eos;

/**
 * Imports
 */
import com.eos.user.UserManagerBean;
import com.eos.user.UserTO;
import java.util.List;
import javax.ejb.EJB;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;

/**
 * UserManager session bean.
 */
@WebService(serviceName = "UserService")
public class UserService
{

    /**
     * Data
     */
    @EJB
    UserManagerBean userManager;

    /**
     * Methods
     */
    /**
     * Authenticate the user with the specified password.
     *
     * @param userId The user id to authenticate.
     * @param password The user's password.
     * @return True if the user is found and the password matches, false
     * otherwise.
     */
    @WebMethod(action = "authenticateUser")
    public UserTO authenticateUser(
            @WebParam(name = "username") String username,
            @WebParam(name = "password") String password)
    {
        return userManager.authenticateUser(username, password);
    }

    @WebMethod(action = "authenticateByEmail")
    public UserTO authenticateByEmail(
            @WebParam(name = "email") String email,
            @WebParam(name = "password") String password)
    {
        return userManager.authenticateByEmail(email, password);
    }

    @WebMethod(action = "getUserTO")
    public UserTO getUserTO(
            @WebParam(name = "userId") int userId)
    {
        return userManager.getUserTO(userId);
    }

    @WebMethod(action = "saveUser")
    public UserTO saveUser(UserTO data)
    {
        return userManager.saveUser(data);
    }

    @WebMethod(action = "deleteUser")
    public void deleteUser(int userId)
    {
        userManager.deleteUser(userId);
    }

    @WebMethod(action = "getUserIdByUsername")
    public int getUserIdByUsername(
            @WebParam(name = "username") String username)
    {
        return userManager.getUserIdByUsername(username);
    }

    @WebMethod(action = "addNewUser")
    public void addNewUser(
            @WebParam(name = "user") UserTO user)
    {
        userManager.addNewUser(user);
    }

    @WebMethod(action = "getUserSalt")
    public String getUserSalt(
            @WebParam(name = "userId") int userId)
    {
        return userManager.getUserSalt(userId);
    }

    @WebMethod(action = "addFriends")
    public void addFriends(
            @WebParam(name = "user1") UserTO user1,
            @WebParam(name = "user2") UserTO user2)
    {
        userManager.addFriends(user1, user2);
    }

    @WebMethod(action = "deleteFriends")
    public void deleteFriends(
            @WebParam(name = "user1") UserTO user1,
            @WebParam(name = "user2") UserTO user2)
    {
        userManager.deleteFriends(user1, user2);
    }

    @WebMethod(action = "searchForUsers")
    public List<UserTO> searchForUsers(
            @WebParam(name = "username") String username,
            @WebParam(name = "user") UserTO user)
    {
        return userManager.searchForUsers(username, user);
    }
    
    @WebMethod(action = "recoverUserAccount")
    public void recoverUserAccount(
            @WebParam(name = "user") UserTO user)
    {
        userManager.recoverUserAccount(user);
    }
    
    @WebMethod(action = "getUsers")
    public List<UserTO> getUsers(
            @WebParam(name = "ids") List<Integer> ids) 
    {
        return userManager.getUsers(ids);
    }
}