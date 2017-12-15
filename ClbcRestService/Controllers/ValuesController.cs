
using System.Collections.Generic;
using ClbcRestService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClbcRestService.Controllers
{
    [Route("api/[controller]")]
    public class VendorsController : Controller
    {
        private readonly List<Vendor> _vendors;

        public VendorsController()
        {
            const int numberVendors = 10;
            _vendors = CreateVendors(numberVendors);
        }

        [HttpGet]
        public IEnumerable<Vendor> Get()
        {
            return _vendors;
        }

        [HttpGet("{id}")]
        public Vendor Get(int id)
        {
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
