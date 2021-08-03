using System.Linq;

namespace LibrsModels.Classes
{
    public class ZeroReport : LegacyLibrsValues
    {
        public ZeroReport()
        {
            SegmentDescriptor = "01";
            ExpansionBuffer = "".PadL(12, '0');
            Padding = "".PadL(134);
            SegmentEnd = "ZZ";
        }
    }
}