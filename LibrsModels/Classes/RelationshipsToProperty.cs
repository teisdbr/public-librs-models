using Newtonsoft.Json;
using System.Collections.Generic;


namespace LibrsModels.Classes
{
    public class RelationshipsToProperty : LegacyLibrsValues
        {

        
        [JsonProperty("propertySequenceNumber")]
        public string PropertySequenceNumber { get; set; }
        
        [JsonProperty("offenseSequenceNumber")]
        public string OffenseSequenceNumber { get; set; }

        [JsonIgnore]
        public List<AssociatedProperty> AssociatedProperties { get; set; }

        [JsonIgnore]
        public List<AssociatedOffenses> AssociatedOffenses { get; set; }

        [JsonIgnore]
        public bool IsDuplicate { get; set; }
    }
}