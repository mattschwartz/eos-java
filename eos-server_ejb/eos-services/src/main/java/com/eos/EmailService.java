package com.eos;

import com.eos.email.EmailManagerBean;
import com.eos.email.EmailTO;
import javax.ejb.EJB;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;

/**
 *  EmailService
 */
@WebService(serviceName = "EmailService")
public class EmailService
{

    /**
     * Data
     */
    @EJB
    EmailManagerBean emailManager;

    @WebMethod( action = "sendEmail")
    public void sendEmail(
            @WebParam( name = "data") EmailTO data) 
    {
        emailManager.sendEmail(data);
    }
}
