using Newtonsoft.Json;

namespace LibrsModels.Classes
{
    public class Error
    {
        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; }
        
        [JsonProperty("errorMsg")]
        public string ErrorMsg { get; set; }
        
        [JsonProperty("contents")]
        public string Contents { get; set; }
        
        [JsonProperty("dataElem")]
        public string DataElem { get; set; }
        
        [JsonProperty("incidentNumber")]
        public string IncidentNumber { get; set; }
        
        [JsonProperty("segmentNumber")]
        public string SegmentNumber { get; set; }
    }
}