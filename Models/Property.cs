namespace GovHack22API.Models {

    using GovHack22API.Models.Enums;

public class Property {
        public int Id { get; set; }

        public List<Image> Images { get; set; }

        public Image FloorPlan { get; set; }

        public string Description { get; set; }

        public Facilities Facilities { get; set; }
        
        public Owner Owner { get; set; }

        public Location Location { get; set; }

        public int GreenRating { get; set; }

        public string HouseRules  { get; set; }

        public DressCodeEnum DressCode { get; set; }

        public List<Space> Spaces { get; set; }

        public float Price { get; set; }
    }
}