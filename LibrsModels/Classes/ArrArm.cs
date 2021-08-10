using System.Collections.Generic;
using System.Linq;
using LibrsModels.Classes;
using Newtonsoft.Json;

namespace LibrsModels.Classes
{
    public class ArrArm : LegacyLibrsValues, IPaddingFixer
    {

        [JsonProperty("arrestArmedWith")] public List<Weapon> ArrestArmedWith { get; set; } = new List<Weapon>();
        public ArrArm()
        {
            SegmentDescriptor = "61";
            ExpansionBuffer = string.Concat(Enumerable.Repeat(" ", 20));
            Padding = string.Concat(Enumerable.Repeat(" ", 52));
        }

        public void FixPaddings()
        {
            //ArrestSeqNum = ArrestSeqNum.PadL(3, '0');;
            //ArrestArmedWith = ArrestArmedWith.PadR(3);
        }
    }
}
