package com.eos.reports.subject;

import com.eos.subject.SubjectTO;
import com.eos.user.UserTO;
import java.io.Serializable;
import java.util.List;
import javax.xml.bind.annotation.XmlType;

@XmlType( name="SubjectReportTO", namespace="com.eos" )
public class SubjectReportTO implements Serializable {
    
    private UserTO user;
    private List<SubjectTO> subjects;
    
    public UserTO getUser() { return user; }
    public void setUser(UserTO value) { this.user = value; }
    
    public List<SubjectTO> getSubjects() { return subjects; }
    public void setSubjects(List<SubjectTO> value) { this.subjects = value; }
    
}
