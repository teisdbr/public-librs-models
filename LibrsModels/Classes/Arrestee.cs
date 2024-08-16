using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NibrsModels.Extensions;

namespace LibrsModels.Classes
{
    public class Arrestee: LegacyLibrsValues, IPaddingFixer
    {

        [JsonProperty("arrestSeqNum")] public int? ArrestSeqNum { get; set; }

        [JsonProperty("arrestNumber")] public string ArrestNumber { get; set; } = "            ";

        [JsonProperty("arrTransactionNumber")] public string ArrTransactionNumber { get; set; } = "               ";

        [JsonProperty("arresteeName")] public string ArresteeName { get; set; } = "                    ";

        [JsonProperty("arrestDate")] public DateTime? ArrestDate { get; set; }

        [JsonProperty("arrestType")] public string ArrestType { get; set; } = " ";

        [JsonProperty("multipleArresteeIndicator")]
        public string MultipleArresteeIndicator { get; set; } = "N";

        [JsonProperty("age")] public string Age { get; set; }
        [JsonProperty("estimatedAge")] public bool? EstimatedAge { get; set; }

        [JsonProperty("dob")] public DateTime? DOB { get; set; }

        [JsonProperty("sex")] public string Sex { get; set; } = " ";
        [JsonProperty("gender")] public string Gender { get; set; } = "   ";
        
        [JsonProperty("race")] public string Race { get; set; } = " ";

        [JsonProperty("ethnicity")] public string Ethnicity { get; set; } = " ";

        [JsonProperty("residentStatus")] public string ResidentStatus { get; set; } = " ";

        [JsonProperty("dispositionUnder18")] public string DispositionUnder18 { get; set; } = " ";

        [JsonProperty("clearanceIndicator")] public string ClearanceIndicator { get; set; } = " ";

        [JsonProperty("arrestArmed")] public List<Weapon> ArrestArmed { get; set; } = new List<Weapon>();

        [JsonProperty("arrestStatute")] public List<ArrStatute> ArrestStatute { get; set; } = new List<ArrStatute>();

        public Arrestee()
        {
            SegmentDescriptor = "60";
            ExpansionBuffer = string.Concat(Enumerable.Repeat(" ", 17));
            Padding = string.Concat(Enumerable.Repeat(" ", 30));
        }

        public void FixPaddings()
        {
            //ArrestSeqNum = ArrestSeqNum.PadL(3, '0');;
            ArrestNumber = ArrestNumber.PadL(12);
            ArrTransactionNumber = ArrTransactionNumber.PadL(15);
            ArresteeName = ArresteeName.PadR(20);
            ArrestType = ArrestType.PadR(1);
            MultipleArresteeIndicator = MultipleArresteeIndicator.PadR(1);
            //Age = PadArresteeAge(Age);
            Sex = Sex.PadR(1);
            Gender = Gender.PadR(3);
            Race = Race.PadR(1);
            Ethnicity = Ethnicity.PadR(1);
            ResidentStatus = ResidentStatus.PadR(1);
            DispositionUnder18 = DispositionUnder18.PadR(1);
            ClearanceIndicator = ClearanceIndicator.PadR(1);
        }
        public string PadArresteeAge(string age)
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