
using System.Collections.Generic;
using ClbcRestService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClbcRestService.Controllers
{
    [Route("api/[controller]")]
    public class PlaceOfServicesController : Controller
    {
        private readonly List<PlaceOfService> _placeOfServices;
        private const int NumberPlaceOfServices = 9;

        public PlaceOfServicesController()
        {
            _placeOfServices = CreatePlaceOfServices(NumberPlaceOfServices);
        }

        [HttpGet]
        public IEnumerable<PlaceOfService> Get()
        {
            return _placeOfServices;
        }

        [HttpGet("{id:int}")]
        public PlaceOfService Get(int id)
        {
            if (id < 1 || id > NumberPlaceOfServices)
            {
                BadRequest($"Index is out of range: {id}");
            }

            return _placeOfServices[id];
        }

        private static List<PlaceOfService> CreatePlaceOfServices(int numberPlaceofServices)
        {
            List<PlaceOfService> placeOfServices = new List<PlaceOfService>();

            for (int n = 1; n <= numberPlaceofServices; n++)
            {
                PlaceOfService cpdArea = new PlaceOfService
                {
                    PlaceOfServiceId = n,
                    Name = $"Place of Service {n}"
                };

                placeOfServices.Add(cpdArea);
            }

            return placeOfServices;
        }
    }
}
