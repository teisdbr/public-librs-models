using Newtonsoft.Json;

namespace LibrsModels.Classes
{
    public class Address
    {
        [JsonProperty("street")] public string Street { get; set; }

        [JsonProperty("city")] public string City { get; set; }

        [JsonProperty("state")] public string State { get; set; }

        [JsonProperty("zip")] public int? Zip { get; set; }

        [JsonProperty("zipExt")] public int? ZipExt { get; set; }

        public override string ToString()
        {
            var addressString = "";
            if (!string.IsNullOrWhiteSpace(Street))
                addressString += Street;
            if (!string.IsNullOrWhiteSpace(City))
                addressString += ", " + City;
            if (!string.IsNullOrWhiteSpace(State))
                addressString += " " + State;
            if (Zip.HasValue)
                addressString += " " + Zip.Value;
            return addressString;
        }
    }
}