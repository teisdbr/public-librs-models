using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace LibrsModels.Classes
{
    public class ArrStatute: LegacyLibrsValues, IPaddingFixer
    {

        [JsonProperty("arrestSeqNum")] public string ArrestSeqNum { get; set; } = "   ";

        [JsonProperty("arrestConToOffense")] public string ArrestConToOffense { get; set; } = "               ";

        [JsonProperty("arresteInchoate")] public string ArresteInchoate { get; set; } = " ";

        [JsonProperty("agencyAssignedNibrs")] public string AgencyAssignedNibrs { get; set; } = "   ";

        [JsonIgnore]
        public List<ValidateLars> ValidateLars { get; set; }

        [JsonIgnore]
        public List<FbiValidate> FbiValidates { get; set; }

        [JsonProperty("lrsNumber")] public string LrsNumber { get; set; } = "            ";

        [JsonIgnore]
        public bool? OfficerDidAssignNibrs { get; set; }

        [JsonProperty("inchoate")] public string Inchoate { get; set; } = " ";

        [JsonProperty("offenseGroup")] public string OffenseGroup { get; set; } = " ";
        
        public ArrStatute()
        {
            SegmentDescriptor = "62";
            ExpansionBuffer = string.Concat(Enumerable.Repeat(" ", 16));
            Padding = string.Concat(Enumerable.Repeat(" ", 74));
        }

        public void FixPaddings()
        {
            ArrestSeqNum = ArrestSeqNum?.PadL(3, '0');;
            ArrestConToOffense = ArrestConToOffense?.PadL(15);
            ArresteInchoate = ArresteInchoate?.PadR(2);
            AgencyAssignedNibrs = AgencyAssignedNibrs?.PadL(3);
            LrsNumber = LrsNumber?.PadL(12);
        }
    }
}