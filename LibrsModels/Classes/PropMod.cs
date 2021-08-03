using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LibrsModels.Classes
{
    //This one is a work in progress... Don't really know what goes in here. 
    public class PropMod : LegacyLibrsValues
    {
        [JsonProperty("lrsNumber")]
        public string LRSNumber { get; set; }
        
        public PropMod()
        {
            SegmentDescriptor = "32";
            ExpansionBuffer = string.Concat(Enumerable.Repeat(" ", 20));
            Padding = string.Concat(Enumerable.Repeat(" ", 92));
        }
    }
}