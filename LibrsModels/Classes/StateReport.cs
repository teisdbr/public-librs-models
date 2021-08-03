using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using NibrsModels.NibrsReport;
using NibrsModels.NibrsReport.Misc;
using NibrsModels.NibrsReport.ReportHeader;

namespace LibrsModels.Classes
{
    public interface IStateReport
    {
        /// <summary>
        ///     Nibrs Report as defined in NIEM
        ///     This is not necessarily used with the limitations set by the FBI, at a later step
        ///     it can be limited to send to FBI.
        /// </summary>
        Report NibrsReport { get; set; }

        /// <summary>
        ///     Precinct Identifier
        /// </summary>
        string PrecinctIdentifier { get; set; }

        /// <summary>
        ///     This is a much more extended location that allows full set of GPS coordinates if desired.
        /// </summary>
        Location ExpandedIncidentLocation { get; set; }

        /// <summary>
        ///     Establishes the Birth Date for all persons in incident
        /// </summary>
        ConcurrentDictionary<string, DateTime?> PersonBirthDates { get; set; }

        /// <summary>
        ///     The key of this dictionary refers to an *offense seq num* and the value contains a dictionary
        ///     of items (non-drug properties) which key is the *property seq num*
        /// </summary>
        ConcurrentDictionary<string, List<string>> OffenseItemRelationships { get; set; }
    }

    public class StateReport : IStateReport
    {
        public StateReport(Report nibrsReport, ConcurrentDictionary<string, List<string>> offenseItemRelationships,
            ConcurrentDictionary<string, List<string>> offenseSubstanceRelationships)
        {
            NibrsReport = nibrsReport;
            OffenseItemRelationships = offenseItemRelationships;
        }

        public StateReport(StateReport report)
        {
            NibrsReport = report.NibrsReport;
            OffenseItemRelationships = report.OffenseItemRelationships;
        }

        public StateReport()
        {
        }

        public StateReport(string actionType, string reportingPeriodYm, string ori)
        {
            NibrsReport = new Report
            {
                Header =
                {
                    ReportingAgency =
                        new ReportingAgency(new OrganizationAugmentation(new OrganizationORIIdentification(ori))),
                    ReportDate = new ReportDate(reportingPeriodYm),
                    ReportActionCategoryCode = actionType.Substring(0, 1)
                }
            };

            ExpandedIncidentLocation = new Location();
            PersonBirthDates = new ConcurrentDictionary<string, DateTime?>();
            OffenseItemRelationships = new ConcurrentDictionary<string, List<string>>();
            OffenderUsing = new ConcurrentDictionary<string, List<string>>();
            ArrestOffenseRelationship = new ConcurrentDictionary<string, List<string>>();
            OffenseToStateRelationship = new ConcurrentDictionary<string, string>();
        }

        #region StateReport Exclusive Implementation

        /// <summary>
        ///     Nibrs Report as defined in NIEM, but it is not limited to the business rules
        /// </summary>
        public Report NibrsReport { get; set; }

        /// <summary>
        ///     Precinct Identifier
        /// </summary>
        public string PrecinctIdentifier { get; set; }

        /// <summary>
        ///     This is a much more extended location that allows full set of GPS coordinates if desired.
        /// </summary>
        public Location ExpandedIncidentLocation { get; set; }

        /// <summary>
        ///     Establishes the Birth Date for all persons in incident. The key represents the computed nibrs id for each person.
        /// </summary>
        public ConcurrentDictionary<string, DateTime?> PersonBirthDates { get; set; } = new ConcurrentDictionary<string, DateTime?>();

        // Offense Substance Relationships
        /// <summary>
        ///     The key of this dictionary refers to an *offense seq num* and the value contains a dictionary
        ///     of items (non-drug properties) which key is the *property seq num*
        /// </summary>
        public ConcurrentDictionary<string, List<string>> OffenseItemRelationships { get; set; } =
            new ConcurrentDictionary<string, List<string>>();

        /// <summary>
        ///     Maintains a relationship between an offender seq number (key as in both TC and LIBRS) and a list of Offender Using
        ///     strings (factor)
        /// </summary>
        public ConcurrentDictionary<string, List<string>> OffenderUsing { get; set; } = new ConcurrentDictionary<string, List<string>>();

        /// <summary>
        /// Allows association between one arrest record (arrest trans number) to many offenses (seq num)
        /// </summary>
        public ConcurrentDictionary<string, List<string>> ArrestOffenseRelationship { get; set; } =
            new ConcurrentDictionary<string, List<string>>();
        
        /// <summary>
        /// Associates Nibrs Offenses (off seq num) to State Offenses (state revised statutes such as 14:67) which created Nibrs Offenses
        /// </summary>
        public ConcurrentDictionary<string, string> OffenseToStateRelationship { get; set; } =
            new ConcurrentDictionary<string, string>();
        
        /// <summary>
        /// Keeps track of a list of counterfeit substances ( item seq num) 
        /// </summary>
        public ConcurrentBag<string> CounterfeitSubstances { get; set; }

        #endregion
    }
}