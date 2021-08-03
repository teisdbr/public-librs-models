using System.Collections.Generic;
using Newtonsoft.Json;

namespace LibrsModels.Classes
{
    public class AssociatedProperty : LegacyLibrsValues
    {
        
        [JsonProperty("propertyLossType")]
        public string PropertyLossType { get; set; }
        
        [JsonProperty("propertyDescription")]
        public string PropertyDescription { get; set; }
        
        [JsonProperty("propertyValue")]
        public string PropertyValue { get; set; }
        
        [JsonProperty("dateRecovered")]
        public string DateRecovered { get; set; }
        
        [JsonProperty("suspectedDrugType")]
        public string SuspectedDrugType { get; set; }
        
        [JsonProperty("estimatedDrugQty")]
        public string EstimatedDrugQty { get; set; }
        
        [JsonProperty("typeDrugMeas")]
        public string TypeDrugMeas { get; set; }
        
        [JsonProperty("tyNum")]
        public object ty_num { get; set; }
        
        [JsonProperty("lars")]
        public object la_rs { get; set; }
        
        [JsonProperty("nibr")]
        public object nibr { get; set; }
        
        [JsonProperty("nValProp")]
        public int n_val_prop { get; set; }

        [JsonIgnore]
        public List<RelationshipsToOffenses> RelationshipsToOffenses { get; set; }
        
        [JsonIgnore]
        public List<RelatedOffenses> RelatedOffenses { get; set; }
        
    }
}