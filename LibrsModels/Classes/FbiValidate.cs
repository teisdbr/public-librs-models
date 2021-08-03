using Newtonsoft.Json;

namespace LibrsModels.Classes
{
    public class FbiValidate
    {
        
        [JsonProperty("mandatory")]
        public string Mandatory { get; set; }
        
        [JsonProperty("dataElement")]
        public string DataElement { get; set; }
        
        [JsonProperty("requirement")]
        public string Requirement { get; set; }
        
        [JsonProperty("subgroup")]
        public string Subgroup { get; set; }
        
        [JsonProperty("crimeAgainst")]
        public string CrimeAgainst { get; set; }
        
        [JsonProperty("expirationDate")]
        public string ExpirationDate { get; set; }
    }
}