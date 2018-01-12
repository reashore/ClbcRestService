
using System.Collections.Generic;
using ClbcRestService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClbcRestService.Controllers
{
    [Route("api/[controller]")]
    public class ProgramTypesController : Controller
    {
        private readonly List<ProgramType> _programTypes;
        private const int NumberProgramTypes = 2;

        public ProgramTypesController()
        {
            _programTypes = CreateCpdAreas();
        }

        [HttpGet]
        public IEnumerable<ProgramType> Get()
        {
            return _programTypes;
        }

        [HttpGet("{id:int}")]
        public ProgramType Get(int id)
        {
            if (id < 1 || id > NumberProgramTypes)
            {
                BadRequest($"Index is out of range: {id}");
            }

            return _programTypes[id];
        }

        private static List<ProgramType> CreateCpdAreas()
        {
            List<ProgramType> programTypes = new List<ProgramType>
            {
                new ProgramType
                {
                    ProgramTypeId = 1,
                    Name = "Community"
                },
                new ProgramType
                {
                    ProgramTypeId = 2,
                    Name = "Place of Service"
                }
            };

            return programTypes;
        }
    }
}
