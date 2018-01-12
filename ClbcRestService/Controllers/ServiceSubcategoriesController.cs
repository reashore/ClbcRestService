
using System.Collections.Generic;
using ClbcRestService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClbcRestService.Controllers
{
    [Route("api/[controller]")]
    public class ServiceSubcategoriesController : Controller
    {
        private readonly List<ServiceSubcategory> _serviceSubcategories;
        const int NumberServiceSubcategories = 9;

        public ServiceSubcategoriesController()
        {
            _serviceSubcategories = CreateServiceSubcategories(NumberServiceSubcategories);
        }

        [HttpGet]
        public IEnumerable<ServiceSubcategory> Get()
        {
            return _serviceSubcategories;
        }

        [HttpGet("{id:int}")]
        public ServiceSubcategory Get(int id)
        {
            if (id < 1 || id > NumberServiceSubcategories)
            {
                BadRequest($"Index is out of range: {id}");
            }

            return _serviceSubcategories[id];
        }

        private static List<ServiceSubcategory> CreateServiceSubcategories(int numberServiceSubcategories)
        {
            List<ServiceSubcategory> serviceSubcategories = new List<ServiceSubcategory>();

            for (int n = 1; n <= numberServiceSubcategories; n++)
            {
                ServiceSubcategory serviceSubcategory = new ServiceSubcategory
                {
                    ServiceSubcategoryId = n,
                    Name = $"Service Subcategory { n}"
                };

                serviceSubcategories.Add(serviceSubcategory);
            }

            return serviceSubcategories;
        }
    }
}
