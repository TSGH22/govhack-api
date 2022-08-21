namespace GovHack22API.Models.Response {

    using GovHack22API.Models.Enums;

public class PropertyResponse {
        public string Id { get; set; }

        public IEnumerable<string> Images { get; set; }

        public string FloorPlan { get; set; }

        public string Description { get; set; }

        public FacilitiesResponse Facilities { get; set; }
        
        public OwnerResponse Owner { get; set; }

        public LocationResponse Location { get; set; }

        public int GreenRating { get; set; }

        public string HouseRules  { get; set; }

        public string DressCode { get; set; }

        public IEnumerable<SpaceResponse> Spaces { get; set; }

        public float Price { get; set; }
    }
}