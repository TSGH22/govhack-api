using GovHack22API.Models;

namespace GovHack22API.Domain; 

public class SeedData {
        
    public static Property SingleProperty()
    {
        return new Property() {
            Images = MultipleImages(),
            FloorPlan = SingleImage(),
            Description = "Hello World",
            Facilities = SingleFacilities(),
            Owner = SingleOwner(),
            Location = SingleLocation(),
            GreenRating = 5,
            HouseRules = "Lots of rules",
            DressCode = Models.Enums.DressCodeEnum.Formal,
            Spaces = MultipleSpaces(),
            Price = 100.10f
        };
    }

    public static Image SingleImage()
    {
        return new Image() {
            URI = "https://images.pexels.com/photos/13248509/pexels-photo-13248509.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
        };
    }

    public static List<Image> MultipleImages()
    {
        return new List<Image>(){
            new Image() {
                URI = "https://images.pexels.com/photos/13248509/pexels-photo-13248509.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            },
            new Image() {
                URI = "https://images.pexels.com/photos/13248509/pexels-photo-13248509.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            },
            new Image() {
                URI = "https://images.pexels.com/photos/13248509/pexels-photo-13248509.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            }
        };
    }

    public static Facilities SingleFacilities()
    {
        return new Facilities {
            Lift = true,
            Shower = true ,
            Monitors = false,
            Stairs = false,
            AccessibleAccess = true,
            Parking = true,
            ContactlessAccess = false
        };
    }

    public static Owner SingleOwner()
    {
        return new Owner() {
            Company = "ABC Company",
            ContactName = "Stephen",
            ContactEmail = "mail@mail.com"
        };
    }

    public static Location SingleLocation() {
        return new Location() {
            Latitude = -33.885f,
            Longitude = 151.208f,
            Suburb = "Surry Hills",
            StreetAddress = "123 Surry Hills Street, Surry Hills"
        };
    }

    public static List<Space> MultipleSpaces() {
        return new List<Space>() {
            new Space(){
                Type = Models.Enums.SpaceTypeEnum.Boardroom,
                Capacity = 1,
                DailyPrice = 100F,
                Availability = MultipleAvailablitly() 
            },
            new Space(){
                Type = Models.Enums.SpaceTypeEnum.Desk,
                Capacity = 1,
                DailyPrice = 120F,
                Availability = MultipleAvailablitly2() 
            }
        };
    }

    public static List<Availability> MultipleAvailablitly(){
        return new List<Availability>() {
            new Availability(){
                StartDate = new DateTime(2023, 04, 03),
                EndDate = new DateTime(2023, 05, 03),
            },
            new Availability(){
                StartDate = new DateTime(2023, 06, 03),
                EndDate = new DateTime(2023, 07, 03)
            }
        };
    }

    public static List<Availability> MultipleAvailablitly2(){
        return new List<Availability>() {
            new Availability(){
                StartDate = new DateTime(2023, 08, 03),
                EndDate = new DateTime(2023, 09, 03)
            },
            new Availability(){
                StartDate = new DateTime(2023, 10, 03),
                EndDate = new DateTime(2023, 11, 03),
            }
        };
    }
}

