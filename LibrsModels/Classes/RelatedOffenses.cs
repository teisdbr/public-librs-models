using Newtonsoft.Json;
using System.Collections.Generic;

namespace LibrsModels.Classes
{
    public class RelatedOffenses : LegacyLibrsValues
        {
        
        [JsonProperty("offenseSeqNum")]
        public string OffenseSeqNum { get; set; }
        
        [JsonProperty("attemptedCompleted")]
        public string AttemptedCompleted { get; set; }
        
        [JsonProperty("offConnecttoVic")]
        public string OffConnecttoVic { get; set; }
        
        [JsonProperty("locationType")]
        public string LocationType { get; set; }
        
        [JsonProperty("premises")]
        public string Premises { get; set; }
        
        [JsonProperty("methodOfEntry")]
        public string MethodOfEntry { get; set; }
        
        [JsonProperty("criminalActivity1")]
        public string CriminalActivity1 { get; set; }
        
        [JsonProperty("criminalActivity2")]
        public string CriminalActivity2 { get; set; }
        
        [JsonProperty("criminalActivity3")]
        public string CriminalActivity3 { get; set; }
        
        [JsonProperty("weaponForce1")]
        public string WeaponForce1 { get; set; }
        
        [JsonProperty("weaponForce2")]
        public string WeaponForce2 { get; set; }
        
        [JsonProperty("weaponForce3")]
        public string WeaponForce3 { get; set; }
        
        [JsonProperty("agencyAssignedNibrs")]
        public string AgencyAssignedNibrs { get; set; }
        
        [JsonIgnore]
        public List<RelationshipsToProperty> RelationshipsToProperties { get; set; }

        [JsonIgnore]
        public List<RelatedProperty> RelatedProperties { get; set; }

        [JsonIgnore]
        public int PropertyLossTypeFlags { get; set; }

        [JsonIgnore]
        public List<ValidateLars> ValidateLars { get; set; }

        [JsonIgnore]
        public List<FbiValidate> FbiValidates { get; set; }
        
        [JsonProperty("lrsNumber")]
        public string LrsNumber { get; set; }

        [JsonIgnore]
        public bool OfficerDidAssignNibrs { get; set; }
        
        [JsonProperty("inchoate")]
        public string Inchoate { get; set; }
        
        [JsonProperty("offenseGroup")]
        public string OffenseGroup { get; set; }
    }
}