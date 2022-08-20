namespace GovHack22API.Models {

using GovHack22API.Models.Enums;

public class Space {
        public int Id { get; set; }

        public SpaceTypeEnum Type { get; set; }

        public int Capacity { get; set; }

        public float DailyPrice { get; set; }

        public Availability Availability { get; set; }
    }
}