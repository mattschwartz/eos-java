package com.eos.user;

/**
 * Imports
 */
import com.eos.crud.CrudManagerBean;
import com.eos.crud.QueryParameters;
import com.eos.utilities.Utility;
import java.util.*;
import java.util.Map.Entry;
import javax.ejb.EJB;
import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;

/**
 * UserManager
 */
@Stateless
@LocalBean
public class UserManagerBean
{

    /**
     * Data
     */
    @EJB
    CrudManagerBean crudService;

    /**
     * Methods
     */
    /**
     * Authenticate the user with the specified password.
     *
     * @param username The user id to authenticate.
     * @param password The user's encrypted password.
     * @return True if the user is found and the password matches, false
     * otherwise.
     */
    public UserTO authenticateUser(String username, String password)
    {
        User user = crudService.find(getUserIdByUsername(username), User.class);

        if (Arrays.equals(Utility.fromHex(password), Utility.fromHex(user.getPassword().split(":")[1]))) {
            return getUserTO(user);
        } else {
            return null;
        }
    }

    public UserTO authenticateByEmail(String email, String password)
    {
        User user = crudService.findSingleResultByNamedQuery(User.GET_BY_EMAIL, QueryParameters.with("email", email));

        return authenticateUser(user.getUserName(), password);
    }

    public UserTO getUserTO(int userId)
    {
        User user = crudService.find(userId, User.class);

        return getUserTO(user);
    }

    public String convertIfNullString(String string)
    {
        if (string != null) {
            return string;
        }
        return "";
    }

    /**
     * Saves the transfer object representation of a User object
     * @param data
     * @return 
     */
    public UserTO saveUser(UserTO data)
    {
        User result = new User();
        if (data == null) {
            return null;
        }
        if (data.getId() > 0) {
            result = crudService.find(data.getId(), User.class);
        }

        result.setUserName(convertIfNullString(data.getUserName()));
        result.setEmail(convertIfNullString(data.getEmail()));
        result.setPassword(data.getPassword());
        result.setEmailVerified(data.getEmailVerified());
        result.setRecoveryNeeded(data.isRecoveryNeeded());
        result.setRecoveryLink(data.getRecoveryLink());
        

        List<User> friends = new ArrayList<User>();
        for (Integer friend : data.getFriends()) {
            friends.add(crudService.find(User.class, friend));
        }
        result.setFriends(friends);

        result = crudService.save(result);

        data.setId(result.getId());

        return data;
    }

    /**
     * Gets the transfer object representation of a User object
     * @param data 
     * @return 
     */
    public UserTO getUserTO(User data)
    {
        if (data == null) {
            throw new IllegalArgumentException("User cannot be null");
        }

        UserTO result = new UserTO();
        result.setId(data.getId());
        result.setUserName(data.getUserName());
        result.setPassword(data.getPassword());
        result.setEmail(data.getEmail());
        result.setRecoveryLink(data.getRecoveryLink());
        result.setRecoveryNeeded(data.isRecoveryNeeded());

        List<Integer> friends = new ArrayList<Integer>();
        for (User u : data.getFriends()) {
            friends.add(u.getId());
        }

        result.setFriends(friends);
        return result;
    }
    
    public List<UserTO> getUsers(List<Integer> ids) 
    {
        List<UserTO> friends = new ArrayList<UserTO>();
        for(Integer id : ids) {
            friends.add(getUserTO(id));
        }
        return friends;
    }

    /**
     * Returns a User's Id given their username. 
     * @param username
     * @return A pos # if user exists, -1 otherwise
     */
    public int getUserIdByUsername(String username)
    {
        QueryParameters params = new QueryParameters();
        params.add("username", username);
        List<User> users = crudService.findByNamedQuery(User.GET_BY_NAME, params);
        if (users.size() < 1) {
            return -1;
        }
        return users.get(0).getId();
    }

    /**
     * Deletes a user from EOS, cannot be undone!
     * @param id 
     */
    public void deleteUser(int id)
    {
        crudService.delete(id, User.class);
    }

    public void addNewUser(UserTO user)
    {
        saveUser(user);
        String to = user.getEmail();
        final String from = "project.eos.devteam@gmail.com";

        final String username = "project.eos.devteam@gmail.com";
        final String password = "Longhorns123";

        String link = "<a href=\"http://localhost:8080/eos-web/confirmation?id=" + user.getId() + "\">Confirmation Link!</a>";

        Properties props = new Properties();
        props.put("mail.smtp.auth", "true");
        props.put("mail.smtp.starttls.enable", "true");
        props.put("mail.smtp.host", "smtp.gmail.com");
        props.put("mail.smtp.port", "587");

        Session session = Session.getInstance(props, new javax.mail.Authenticator()
        {
            protected PasswordAuthentication getPasswordAuthentication()
            {
                return new PasswordAuthentication(username, password);
            }
        });

        try {

            Message message = new MimeMessage(session);
            message.setFrom(new InternetAddress(from));
            message.setRecipients(Message.RecipientType.TO, InternetAddress.parse(user.getEmail()));
            message.setSubject("Welcome to Project Eos!");
            message.setContent("<p>Dear " + user.getUserName() + ",<br></br>"
                    + "<br> Welcome to Project Eos! To finish your registration please confirm your email by clicking the following link. </br>"
                    + "<br>" + link + "</br><br></br>"
                    + "<br> yours truly, </br>"
                    + "<br>     Project Eos Dev. team </br>"
                    + "<br></br><br> Sent on " + Calendar.getInstance().getTime().toString() + ".</br> </p>", "text/html");

            Transport.send(message);
        } catch (MessagingException e) {
            throw new RuntimeException(e);
        }
    }

    public void recoverUserAccount(UserTO user)
    {
        saveUser(user);
        String to = user.getEmail();
        final String from = "project.eos.devteam@gmail.com";

        final String username = "project.eos.devteam@gmail.com";
        final String password = "Longhorns123";

        String hash = String.valueOf(Utility.generateSalt());
        user.setRecoveryLink(hash);
        user.setRecoveryNeeded(true);
        saveUser(user);

        String link = "<a href=\"http://localhost:8080/eos-web/recovery?id=" + user.getId() + "&val=" + hash + "\">Account Recovery Link!</a>";

        Properties props = new Properties();
        props.put("mail.smtp.auth", "true");
        props.put("mail.smtp.starttls.enable", "true");
        props.put("mail.smtp.host", "smtp.gmail.com");
        props.put("mail.smtp.port", "587");

        Session session = Session.getInstance(props, new javax.mail.Authenticator()
        {
            protected PasswordAuthentication getPasswordAuthentication()
            {
                return new PasswordAuthentication(username, password);
            }
        });

        try {

            Message message = new MimeMessage(session);
            message.setFrom(new InternetAddress(from));
            message.setRecipients(Message.RecipientType.TO, InternetAddress.parse(user.getEmail()));
            message.setSubject("Account Recovery");
            message.setContent("<p>Dear " + user.getUserName() + ",<br></br>"
                    + "<br> It appears you've lost your password! No fear, click the following link to set a new one. </br>"
                    + "<br>" + link + "</br><br></br>"
                    + "<br> yours truly, </br>"
                    + "<br>     Project Eos Dev. team </br>"
                    + "<br></br><br> Sent on " + Calendar.getInstance().getTime().toString() + ".</br> </p>", "text/html");

            Transport.send(message);
        } catch (MessagingException e) {
            throw new RuntimeException(e);
        }
    }

    /**
     * Returns the salt for the given user's password for password encryption
     * @param userId The user's id for the salt to get
     * @return A String containing the salt
     */
    public String getUserSalt(int userId)
    {
        User user = crudService.find(User.class, userId);

        return user.getPassword().split(":")[0];
    }

    /**
     * Adds two users to each other's friends list
     * @param user1 The first user
     * @param user2 The second user
     */
    public void addFriends(UserTO user1, UserTO user2)
    {
        if (areFriends(user1, user2)) {
            return;
        }
        user1.getFriends().add(user2.getId());
        user2.getFriends().add(user1.getId());
        saveUser(user1);
        saveUser(user2);
    }

    /**
     * Removes two friends from each other's friend's list
     * @param user1 The first user
     * @param user2 The second user
     */
    public void deleteFriends(UserTO user1, UserTO user2)
    {
        for (int ctr = 0; ctr < user1.getFriends().size(); ctr++) {
            if (user1.getFriends().get(ctr) == user2.getId()) {
                user1.getFriends().remove(ctr);
                saveUser(user1);
                return;
            }
        }
        for (int ctr = 0; ctr < user2.getFriends().size(); ctr++) {
            if (user2.getFriends().get(ctr) == user1.getId()) {
                user2.getFriends().remove(ctr);
                saveUser(user2);
                return;
            }
        }
    }

    /**
     * Returns true if two users are friends, false otherwise.
     * @param user1 The first user
     * @param user2 The second user
     * @return 
     */
    public boolean areFriends(UserTO user1, UserTO user2)
    {
        for (Integer friend : user1.getFriends()) {
            if (friend == user2.getId()) {
                return true;
            }
        }
        for (Integer friend : user2.getFriends()) {
            if (friend == user1.getId()) {
                return true;
            }
        }
        return false;
    }

    /**
     * Returns any result that is within 6 edits from the username searched for.
     * If the number of users is less than 20 it returns all of them for debugging.
     * 
     * @param username The username to search for
     * @return A list of UserTO's containing similar usernames
     */
    public List<UserTO> searchForUsers(String username, UserTO user)
    {
        Map<User, Integer> matches = new HashMap<User, Integer>();
        List<User> allUsers = crudService.findByNamedQuery(User.GET_ALL);
        for (User u : allUsers) {
            if (!areFriends(getUserTO(u), user)) {
                matches.put(u, editDistance(username, u.getUserName()));
            }
        }

        List<UserTO> results = new ArrayList<UserTO>();
        for (Entry<User, Integer> entry : matches.entrySet()) {
            if (matches.size() < 20) {
                results.add(getUserTO(entry.getKey()));
            } else if (entry.getValue() <= 5) {
                results.add(getUserTO(entry.getKey()));
            }
        }

        return results;
    }

    /**
     * Computes the edit distance of two strings. (The lower the more similar)
     * 
     * @param s string 1 to compare
     * @param t string 2 to compare
     * @return Returns an integer containing the edit distance of the two strings
     */
    public static int editDistance(String s, String t)
    {
        int m = s.length();
        int n = t.length();
        int[][] d = new int[m + 1][n + 1];
        for (int i = 0; i <= m; i++) {
            d[i][0] = i;
        }
        for (int j = 0; j <= n; j++) {
            d[0][j] = j;
        }
        for (int j = 1; j <= n; j++) {
            for (int i = 1; i <= m; i++) {
                if (s.charAt(i - 1) == t.charAt(j - 1)) {
                    d[i][j] = d[i - 1][j - 1];
                } else {
                    d[i][j] = min((d[i - 1][j] + 1), (d[i][j - 1] + 1), (d[i - 1][j - 1] + 1));
                }
            }
        }
        return (d[m][n]);
    }

    public static int min(int a, int b, int c)
    {
        return (Math.min(Math.min(a, b), c));
    }

}
