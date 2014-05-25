package com.eos.reports.subject;

import com.eos.crud.CrudManagerBean;
import com.eos.subject.SubjectManagerBean;
import com.eos.subject.SubjectTO;
import com.eos.user.UserManagerBean;
import com.eos.user.UserTO;
import com.eos.utilities.BinaryTO;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import javax.ejb.EJB;
import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import net.sf.jasperreports.engine.*;
import net.sf.jasperreports.engine.data.JRBeanCollectionDataSource;
import net.sf.jasperreports.engine.util.JRLoader;

@Stateless
@LocalBean
public class SubjectReportManagerBean
{

    @EJB
    CrudManagerBean crudService;
    @EJB
    SubjectManagerBean subjectManager;
    @EJB
    UserManagerBean userManager;

    public BinaryTO getOrderReport(int userId)
    {
        UserTO user = userManager.getUserTO(userId);
        List<SubjectTO> subjects = subjectManager.getAllSubjectsByUser(userId);

        try {
            Map taskMap = new HashMap();
            for (SubjectTO subject : subjects) {
                taskMap.put(subject.getId(), new JRBeanCollectionDataSource(subject.getTasks()));
            }

            Map<String, Object> params = new HashMap<String, Object>();
            params.put("SUBJECT", getSubjectReportTO(user, subjects));
            params.put("TASKS", taskMap);

            JasperReport jasperReport = (JasperReport) JRLoader.loadObject(getClass().getResource("SubjectReport.jasper").getFile());
            JasperPrint jasperPrint = JasperFillManager.fillReport(jasperReport, params, new JREmptyDataSource());

            BinaryTO bin = new BinaryTO();
            bin.setData(JasperExportManager.exportReportToPdf(jasperPrint));

            return bin;
        } catch (JRException ex) {
        }

        return null;
    }

    public SubjectReportTO getSubjectReportTO(UserTO user, List<SubjectTO> subject)
    {
        SubjectReportTO report = new SubjectReportTO();
        report.setSubjects(subject);
        report.setUser(user);

        return report;
    }

}
