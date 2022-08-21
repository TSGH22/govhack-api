namespace GovHack22API.Models.Request {

public class SearchRequest {
        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public int? Radius { get; set; }

        public float MaxPrice { get; set; }

        public FacilitiesRequest Facilities { get; set; }

        public List<string> Spaces { get; set; }

        public int? Capacity { get; set; }
    }
}
