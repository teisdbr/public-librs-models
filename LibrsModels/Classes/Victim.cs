using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TeUtil.Extensions;

namespace LibrsModels.Classes
{
    public class Victim: LegacyLibrsValues, IPaddingFixer
    {
        [JsonIgnore]
        public int GetAllPossibleAggravatedFlags { get; set; }
        
        [JsonIgnore]
        public int GetAll09aAggravatedFlags { get; set; }
        
        [JsonIgnore]
        public int GetAll09bAggravatedFlags { get; set; }
        
        [JsonIgnore]
        public int GetAll09cAggravatedFlags { get; set; }
        
        [JsonIgnore]
        public int GetProvidedAggravatedFlags { get; set; }
        
        [JsonIgnore]
        public bool AreAllDataElement31ProvidedChoicesValid { get; set; }
        
        [JsonIgnore]
        public List<object> GetInvalidDataElement31Choices { get; set; }

        [JsonProperty("officerActivity")] public int? OfficerActivity { get; set; }

        [JsonProperty("victimSeqNum")] public string VictimSeqNum { get; set; } = "   ";

        [JsonProperty("victimType")] public string VictimType { get; set; } = " ";

        [JsonProperty("age")] public string Age { get; set; } = "   ";

        [JsonProperty("dob")] public DateTime? DOB { get; set; }

        [JsonProperty("sex")] public string Sex { get; set; } = " ";

        [JsonProperty("gender")] public string Gender { get; set; } = "   ";
        
        [JsonProperty("race")] public string Race { get; set; } = " ";

        [JsonProperty("ethnicity")] public string Ethnicity { get; set; } = " ";

        [JsonProperty("residentStatus")] public string ResidentStatus { get; set; } = " ";

        [JsonProperty("aggravatedAssault")] public List<string> AggravatedAssault { get; set; } = new List<string>();

        [JsonProperty("additionalHomicide")] public string AdditionalHomicide { get; set; } = " ";

        [JsonProperty("precipitatingOffense")] public string PrecipitatingOffense { get; set; } = "   ";
        
        [JsonProperty("officerActivityCircumstance")] public string OfficerActivityCircumstance { get; set; } = "  ";

        [JsonProperty("officerAssignmentType")] public string OfficerAssignmentType { get; set; } = " ";

        [JsonProperty("officerOri")] public string OfficerOri { get; set; } = "         ";

        [JsonProperty("injuryType")] public string InjuryType { get; set; } = " ";
        
        [JsonProperty("relatedOffenders")] public List<VicOff> RelatedOffenders { get; set; }
        
        public Victim()
        {
            SegmentDescriptor = "50";
            ExpansionBuffer = string.Concat(Enumerable.Repeat(" ", 6));
            Padding = string.Concat(Enumerable.Repeat(" ", 81));
        }

        public void FixPaddings()
        {
            VictimSeqNum = VictimSeqNum.PadL(3, '0');;
            VictimType = VictimType.PadR(1);
            Age = PadVictimAge(Age);
            Ethnicity = Ethnicity.PadR(1);
            Gender = Gender.PadR(3);
            ResidentStatus = ResidentStatus.PadR(1);
            AdditionalHomicide = AdditionalHomicide.PadR(1);
            AggravatedAssault.ForEach(val => val.PadR(2));
            OfficerActivityCircumstance = OfficerActivityCircumstance.PadL(2, '0');
            OfficerAssignmentType = OfficerAssignmentType.PadR(1);
            PrecipitatingOffense = PrecipitatingOffense.PadR(3);
            OfficerOri = OfficerOri.PadL(9);
        }

        private string PadVictimAge(string age)
        {
            if (age.IsNullBlankOrEmpty()) return "".PadR(3);
            // If estimated, pad 3 characters
            if (age.Contains('E'))
            {
                return age.PadL(3, '0');
            } 
            else if (int.TryParse(age, out var parsedAge))
            {
                return parsedAge.ToString().PadL(2, '0') + ' ';
            }

            // If all else fails, pad to 3 spaces. This helps against 'NB ' for instance.
            return age.PadR(3);
        }
    }
}