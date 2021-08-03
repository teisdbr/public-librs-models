using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TeUtil.Extensions;

namespace LibrsModels.Classes
{
    public class Offender : LegacyLibrsValues, IPaddingFixer
    {

        [JsonProperty("offenderSeqNum")] public string OffenderSeqNum { get; set; } = "   ";

        [JsonProperty("age")] public string Age { get; set; } = "   ";

        [JsonProperty("dob")] public DateTime? Dob { get; set; }

        [JsonProperty("sex")] public string Sex { get; set; } = " ";

        [JsonProperty("race")] public string Race { get; set; } = " ";
        
        [JsonProperty("gender")] public string Gender { get; set; } = "   ";
        [JsonProperty("biasMotivation")] public string BiasMotivation { get; set; } = "  ";

        [JsonProperty("ethnicity")] public string Ethnicity { get; set; } = " ";
        
        [JsonProperty("usingGaming")] public List<string> UsingGaming { get; set; }
        public Offender()
        {
            SegmentDescriptor = "40";
            ExpansionBuffer = string.Concat(Enumerable.Repeat(" ", 19));
            Padding = string.Concat(Enumerable.Repeat(" ", 86));
        }

        public void FixPaddings()
        {
            OffenderSeqNum = OffenderSeqNum.PadL(3, '0');;
            Age = PadOffenderAge(Age);
            Sex = Sex.PadR(1);
            Gender = Gender.PadR(3);
            Race = Race.PadR(1);
            BiasMotivation = BiasMotivation.PadL(2);
            Ethnicity = Ethnicity.PadR(1);
        }

        private string PadOffenderAge(string age)
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