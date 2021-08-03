using System;
using System.Linq;
using Newtonsoft.Json;
using TeUtil.Extensions;

namespace LibrsModels.Classes
{
    public class Arrestee: LegacyLibrsValues, IPaddingFixer
    {

        [JsonProperty("arrestSeqNum")] public string ArrestSeqNum { get; set; } = "   ";

        [JsonProperty("arrestNumber")] public string ArrestNumber { get; set; } = "            ";

        [JsonProperty("arrTransactionNumber")] public string ArrTransactionNumber { get; set; } = "               ";

        [JsonProperty("arresteeName")] public string ArresteeName { get; set; } = "                    ";

        [JsonProperty("arrestDate")] public DateTime? ArrestDate { get; set; }

        [JsonProperty("arrestType")] public string ArrestType { get; set; } = " ";

        [JsonProperty("multipleArresteeIndicator")]
        public string MultipleArresteeIndicator { get; set; } = "N";

        [JsonProperty("age")] public string Age { get; set; } = "   ";

        [JsonProperty("dob")] public DateTime? DOB { get; set; }

        [JsonProperty("sex")] public string Sex { get; set; } = " ";
        [JsonProperty("gender")] public string Gender { get; set; } = "   ";
        
        [JsonProperty("race")] public string Race { get; set; } = " ";

        [JsonProperty("ethnicity")] public string Ethnicity { get; set; } = " ";

        [JsonProperty("residentStatus")] public string ResidentStatus { get; set; } = " ";

        [JsonProperty("dispositionUnder17")] public string DispositionUnder17 { get; set; } = " ";

        [JsonProperty("clearanceIndicator")] public string ClearanceIndicator { get; set; } = " ";

        public Arrestee()
        {
            SegmentDescriptor = "60";
            ExpansionBuffer = string.Concat(Enumerable.Repeat(" ", 17));
            Padding = string.Concat(Enumerable.Repeat(" ", 30));
        }

        public void FixPaddings()
        {
            ArrestSeqNum = ArrestSeqNum.PadL(3, '0');;
            ArrestNumber = ArrestNumber.PadL(12);
            ArrTransactionNumber = ArrTransactionNumber.PadL(15);
            ArresteeName = ArresteeName.PadR(20);
            ArrestType = ArrestType.PadR(1);
            MultipleArresteeIndicator = MultipleArresteeIndicator.PadR(1);
            Age = PadArresteeAge(Age);
            Sex = Sex.PadR(1);
            Gender = Gender.PadR(3);
            Race = Race.PadR(1);
            Ethnicity = Ethnicity.PadR(1);
            ResidentStatus = ResidentStatus.PadR(1);
            DispositionUnder17 = DispositionUnder17.PadR(1);
            ClearanceIndicator = ClearanceIndicator.PadR(1);
        }
        private string PadArresteeAge(string age)
        {
            if (age.IsNullBlankOrEmpty()) return "".PadR(3);
            if (age.Contains('E'))
            {
                return age.PadL(3, '0');
            }

            // Leave the third space with whitespace, but pad with 0, the leftmost 2 chars
            return age.PadL(2, '0') + ' ';

        }
    }
}