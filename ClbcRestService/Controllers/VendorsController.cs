
using System.Collections.Generic;
using ClbcRestService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClbcRestService.Controllers
{
    [Route("api/[controller]")]
    public class VendorsController : Controller
    {
        private readonly List<Vendor> _vendors;
        private const int NumberVendors = 9;

        public VendorsController()
        {
            _vendors = CreateVendors(NumberVendors);
        }

        [HttpGet]
        public IEnumerable<Vendor> Get()
        {
            return _vendors;
        }

        [HttpGet("{id:int}")]
        public Vendor Get(int id)
        {
            if (id < 1 || id > NumberVendors)
            {
                BadRequest($"Index is out of range: {id}");
            }

            return _vendors[id];
        }

        private static List<Vendor> CreateVendors(int numberVendors)
        {
            List<Vendor> vendors = new List<Vendor>();

            for (int n = 1; n <= numberVendors; n++)
            {
                Vendor vendor = new Vendor
                {
                    VendorId = n,
                    Name = $"Vendor Name { n}",
                    OcgNumber = $"OCG Number { n} ",
                    ManagingQsArea = $"Managing QS Area { n}",
                    PrimaryAddress = $"Primary Address { n}"
                };

                vendors.Add(vendor);
            }

            return vendors;
        }
    }
}
