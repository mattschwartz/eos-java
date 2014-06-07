package com.eos;

import com.eos.reports.subject.SubjectReportManagerBean;
import com.eos.utilities.BinaryTO;
import javax.ejb.EJB;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;

@WebService(serviceName = "SubjectReportService")
public class SubjectReportService {
    
    @EJB
    SubjectReportManagerBean subjectReportManager;
    
    @WebMethod( action = "" )
    public BinaryTO createSubjectReport(
            @WebParam( name = "userId" ) int userId)
    {
        return subjectReportManager.getOrderReport(userId);
    }
}
