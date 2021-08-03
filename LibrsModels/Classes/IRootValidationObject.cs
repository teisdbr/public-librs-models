using System.Collections.Generic;

namespace LibrsModels.Classes
{
    public interface IRootValidationObject<T> where T: ILibrsIncident
    {
        string Spec { get; set; }
        string Ori { get; set;}
        int ReportYear { get; set;}
        int ReportMonth { get; set;}
        string AgencyName { get; set;}
        string SoftwareID { get; set;}
        string SoftwareVersion { get; set;}
        bool ForSubmission { get; set;}
        List<T> IncidentList { get; set;}
        bool ZeroReport { get; set;}
    }
}