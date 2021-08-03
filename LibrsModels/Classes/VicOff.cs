using System.Linq;
using Newtonsoft.Json;

namespace LibrsModels.Classes
{
    public class VicOff : LegacyLibrsValues, IPaddingFixer
    {

        [JsonProperty("victimSeqNum")] public string VictimSeqNum { get; set; }

        [JsonProperty("offenderNumber")]
        public string OffenderNumberRelated { get; set; } = "   ";

        [JsonProperty("relationship")]
        public string VictimOffenderRelation { get; set; } = "  ";
        
        public VicOff()
        {
            SegmentDescriptor = "52";
            ExpansionBuffer = string.Concat(Enumerable.Repeat(" ", 20));
            Padding = string.Concat(Enumerable.Repeat(" ", 100));
        }

        public void FixPaddings()
        {
            //VictimSeqNum = VictimSeqNum.PadL(3, '0');;
            OffenderNumberRelated = OffenderNumberRelated.PadL(3, '0');;
            VictimOffenderRelation = VictimOffenderRelation.PadR(2);
        }
    }
}