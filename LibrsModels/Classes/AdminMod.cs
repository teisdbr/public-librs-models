using System.Linq;
using Newtonsoft.Json;

namespace LibrsModels.Classes
{
    
    //This one is a work in progress... Don't really know what goes in here. 
    public class AdminMod : LegacyLibrsValues
    {
        [JsonProperty("lrsNumber")]
        public string LRSNumber { get; set; }
    
        public AdminMod()
        {
            SegmentDescriptor = "11";
            ExpansionBuffer = string.Concat(Enumerable.Repeat(" ", 20));
            Padding = string.Concat(Enumerable.Repeat(" ", 58));
        }
    }
}