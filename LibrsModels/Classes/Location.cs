using MongoDB.Bson.Serialization.Attributes;

namespace LibrsModels.Classes
{
    public class Location
    {
        [BsonElement("address")] public Address Address { get; set; }

        [BsonElement("parish")] public string Parish { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("region")]
        public string Region { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("description")]
        public string Description { get; set; }

        /// <summary>
        ///     A project's location will always be a "Point" type
        ///     This will be used when querying MongoDB GeoJSON
        /// </summary>
        [BsonElement("type")]
        [BsonIgnoreIfNull]
        public string Type { get; set; } = "Point";

        /// <summary>
        ///     The (latitude, longitude) coordinates of this location
        ///     The array should only have 2 values, where latitude is referenced by the 0th index and longitude is
        ///     referenced by the 1st index
        /// </summary>
        [BsonElement("coordinates")]
        [BsonIgnoreIfNull]
        public double[] Coordinates { get; set; }

        /// <summary>
        ///     A 2D array defining the northwest and southeast corners of a viewport.
        ///     The value of this property should follow the following format:
        ///     [ [ northwest.latitude, northwest.longitude ], [ southeast.latitude, southeast.longitude ] ]
        /// </summary>
        [BsonElement("viewport")]
        [BsonIgnoreIfNull]
        public double[][] Viewport { get; set; }

        /// <summary>
        ///     Google placeId reference
        ///     Stored just in case we need to use this ID in the future with any Google APIs that use this field
        /// </summary>
        [BsonElement("googlePlaceId")]
        [BsonIgnoreIfNull]
        public string GooglePlaceId { get; set; }

        /// <summary>
        ///     The normalized address of this locationf
        ///     Usually equivalent to the postal address of the location
        /// </summary>
        [BsonElement("formattedAddress")]
        [BsonIgnoreIfNull]
        public string FormattedAddress { get; set; }
    }
}