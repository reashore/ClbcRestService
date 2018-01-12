
using System.Collections.Generic;
using ClbcRestService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClbcRestService.Controllers
{
    [Route("api/[controller]")]
    public class CpdAreasController : Controller
    {
        private readonly List<CpdArea> _cpdAreas;
        private const int NumberCpdAreas = 9;

        public CpdAreasController()
        {
            _cpdAreas = CreateCpdAreas(NumberCpdAreas);
        }

        [HttpGet]
        public IEnumerable<CpdArea> Get()
        {
            return _cpdAreas;
        }

        [HttpGet("{id:int}")]
        public CpdArea Get(int id)
        {
            if (id < 1 || id > NumberCpdAreas)
            {
                BadRequest($"Index is out of range: {id}");
            }

            return _cpdAreas[id];
        }

        private static List<CpdArea> CreateCpdAreas(int numberCpdAreas)
        {
            List<CpdArea> cpdAreas = new List<CpdArea>();

            for (int n = 1; n <= numberCpdAreas; n++)
            {
                CpdArea cpdArea = new CpdArea
                {
                    CpdAreaId = n,
                    Name = $"CPD Area {n}"
                };

                cpdAreas.Add(cpdArea);
            }

            return cpdAreas;
        }
    }
}
