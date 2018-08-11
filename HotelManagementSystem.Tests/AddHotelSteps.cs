using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        private Hotel addHotelResponse;
        private List<Hotel> hotels = new List<Hotel>();


        [Given(@"User provided valid Id '(.*)'  and '(.*)'for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
        }

        [Given(@"User has added required details for hotel")]
        public void GivenUseHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();
        }

        [When(@"User calls AddHotel api")]
        [Given(@"User called AddHotel api")]
        public void WhenUserCallsAddHotelApi()
        {
            hotels = HotelsApiCaller.AddHotel(hotel);
        }

        [Then(@"Hotel with name '(.*)' should be present in the response")]
        public void ThenHotelWithNameShouldBePresentInTheResponse(string name)
        {
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name.ToLower()));
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response",name));
        }
        [When(@"User calls GetHotelById api by Id '(.*)'")]
        public void WhenUserCallsGetHotelByIdApiById(int id)
        {
            hotel= HotelsApiCaller.GetHotelById(id);
            
        }


        [Then(@"Hotel with given name '(.*)' should be present in the response")]
        public void ThenHotelWithGivenNameShouldBePresentInTheResponse(string name)
        {
            hotel.Name.Should().Be(name);
        }

        [When(@"User calls GetAllHotels api")]
        public void WhenUserCallsGetAllHotelsApi()
        {
            hotels = HotelsApiCaller.GetAllHotels();
        }

        [Then(@"Hotel with given names '(.*)' and '(.*)' and '(.*)' should be present in the response")]
        public void ThenHotelWithGivenNamesAndAndShouldBePresentInTheResponse(string name, string name1, string name2)
        {
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name.ToLower()));
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response", name));
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name1.ToLower()));
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response", name1));
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name2.ToLower()));
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response", name2));
        }




        private void SetHotelBasicDetails()
        {
            hotel.ImageURLs = new List<string>() { "image1", "image2" };
            hotel.LocationCode = "Location";
            hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 10, RoomType = "delux" } };
            hotel.Address = "Address1";
            hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
        }
    }
}













