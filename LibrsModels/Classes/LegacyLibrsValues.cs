using Newtonsoft.Json;
namespace LibrsModels.Classes
{
    public class LegacyLibrsValues
    {
        [JsonProperty("entireLineSegment")]
        public string EntireLineSegment { get; set; }

        [JsonProperty("segmentDescriptor")]
        public string SegmentDescriptor { get; set; }

        [JsonProperty("actionType")]
        public string ActionType { get; set; }

        [JsonProperty("oriNumber")]
        public string ORINumber { get; set; }

        [JsonProperty("incidentNumber")]
        public string IncidentNumber { get; set; }

        [JsonProperty("expansionBuffer")]
        public string ExpansionBuffer { get; set; }

        [JsonProperty("segmentEnd")]
        public string SegmentEnd = "ZZ";

        [JsonProperty("padding")]
        public string Padding { get; set; }
    }
}