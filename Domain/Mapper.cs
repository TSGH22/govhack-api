namespace GovHack22API.Domain {

    using GovHack22API.Models;
    using GovHack22API.Models.Enums;
    using GovHack22API.Models.Response;
    
    public class Mapper
    {
        public PropertyResponse MapPropertyResponse(Property property){
            return new PropertyResponse(){
                Id = property.Id.ToString(),
                Description = property.Description,
                DressCode = MapDressCode(property.DressCode),
                GreenRating = property.GreenRating,
                HouseRules = property.HouseRules,
                FloorPlan = property.FloorPlan.URI,
                Images = MapImageURIs(property.Images),
                Facilities = MapFacilities(property.Facilities),
                Owner = MapOwner(property.Owner),
                Spaces = MapSpaceResponse(property.Spaces),
                SpaceRating = RandomSpaceRating(),
                Price = property.Price,
                Location = MapLoction(property.Location)
            };
        }

        private string MapDressCode(DressCodeEnum dressCodeEnum){
            var dressCode = "";
        
            switch(dressCodeEnum) 
                {
                case DressCodeEnum.Casual:
                    dressCode = "Casual";
                    break;
                case DressCodeEnum.SmartCasual:
                    dressCode = "Smart Casual";
                    break;
                case DressCodeEnum.Formal:
                    dressCode = "Formal";
                    break;
                default:
                    dressCode = "Casual";
                    break;
                }
                return dressCode;
        }

         private string MapSpaceTypes(SpaceTypeEnum spaceTypeEnum){
            var spaceType = "";
        
            switch(spaceTypeEnum) 
                {
                case SpaceTypeEnum.Desk:
                    spaceType = "Desk";
                    break;
                case SpaceTypeEnum.Boardroom:
                    spaceType = "Boardroom";
                    break;
                case SpaceTypeEnum.MeetingRoom :
                    spaceType = "Meeting Room";
                    break;
                default:
                    spaceType = "Office";
                    break;
                }

                return spaceType;
        }

        private IEnumerable<string> MapImageURIs(List<Image> imagesURIs) {
            return imagesURIs.Select(x => x.URI);
        }

        private FacilitiesResponse  MapFacilities(Facilities facilities) {
            return new FacilitiesResponse() {
                Lift = facilities.Lift,
                Shower = facilities.Shower,
                Monitors = facilities.Monitors,
                Stairs = facilities.Stairs,
                AccessibleAccess = facilities.AccessibleAccess,
                Parking = facilities.Parking,
                ContactlessAccess = facilities.ContactlessAccess
            };
        }

        private OwnerResponse  MapOwner(Owner owner) {
            return new OwnerResponse() {
                Company = owner.Company,
                ContactEmail = owner.ContactEmail,
                ContactName = owner.ContactName
            };
        }

        private LocationResponse  MapLoction(Location location) {
            return new LocationResponse() {
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                StreetAddress = location.StreetAddress,
                Suburb = location.Suburb
            };
        }

        private IEnumerable<AvailabilityResponse> MapAvailabilityResponse(List<Availability> availabilities) {
            var response = new List<AvailabilityResponse>();

            availabilities.ForEach(a => 
                response.Add(
                    new AvailabilityResponse {
                            StartDate = ConvertToUnixTime(a.StartDate),
                            EndDate = ConvertToUnixTime(a.EndDate)
                        }) 
            ); 

            return response;
         }

        private IEnumerable<SpaceResponse> MapSpaceResponse(List<Space> spaces) {
            var response = new List<SpaceResponse>();

            spaces.ForEach(s =>
                response.Add(
                    new SpaceResponse(){
                        Type = MapSpaceTypes(s.Type),
                        Capacity = s.Capacity,
                        DailyPrice = s.DailyPrice,
                        Availability = MapAvailabilityResponse(s.Availability)
                    }
                )
            );

            return response;
        }

        private long ConvertToUnixTime(DateTime date)
        {
            var timeSpan = (date - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }

        private SpaceRating RandomSpaceRating() {
            Random rnd = new Random(); 

            return new SpaceRating() {
             Cleanliness = rnd.Next(1, 5),
             NoiseLevel = rnd.Next(1, 5),
             Facilities = rnd.Next(1, 5),
            };

        }
    }
}