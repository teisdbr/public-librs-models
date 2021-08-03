using System;

namespace LibrsModels.Extensions
{
    public static class RootValidationObjectExt
    {
        /// <summary>
        /// Combines both the IncidentDate (DateTime) and the ReportingDate indicator (Bool) into a literal
        /// string representation of MMDDYYYYXHH as it is expected and indicated by the Librs data element #3
        /// from the admin segment.
        ///
        /// Should only be used when serializing to the Flat file format for validations. The JSON format specifies the two
        /// different properties that are expected as parameters.
        /// </summary>
        /// <param name="incidentDate">Incident Date or Reporting Date</param>
        /// <param name="isReportingDate">Indicates whether or not a reporting date was specified</param>
        /// <returns>Datetime string according to format of MMDDYYYYXHH</returns>
        public static string ToIncidentDateString(this DateTime? incidentDate, bool isReportingDate = false)
        {
            var dateTypeIndicator = isReportingDate == false ? " " : "R";
            // ReSharper disable once StringLiteralTypo
            return incidentDate?.ToString($"MMddyyyy{dateTypeIndicator}HH") ?? "           ";
        }
    }
}