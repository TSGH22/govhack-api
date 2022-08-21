namespace GovHack22API.Models.Response {
   
using GovHack22API.Models.Enums;

public class SpaceResponse {
        public string Type { get; set; }

        public int Capacity { get; set; }

        public float DailyPrice { get; set; }

        public IEnumerable <AvailabilityResponse> Availability { get; set; }
    }
}