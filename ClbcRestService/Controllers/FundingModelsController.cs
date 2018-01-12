
using System.Collections.Generic;
using ClbcRestService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClbcRestService.Controllers
{
    [Route("api/[controller]")]
    public class FundingModelsController : Controller
    {
        private const int NumberFundingModels = 9;

        [HttpGet("{serviceCategoryId:int}")]
        public IActionResult Get(int serviceCategoryId)
        {
            return CreateFundingModels(serviceCategoryId);
        }

        private IActionResult CreateFundingModels(int serviceCategoryId)
        {
            if (serviceCategoryId < 1 || serviceCategoryId > NumberFundingModels)
            {
                return BadRequest($"Index is out of range: {serviceCategoryId}");
            }

            List<FundingModel> fundingModels = new List<FundingModel>();

            for (int n = 1; n <= NumberFundingModels; n++)
            {
                FundingModel fundingModel = new FundingModel
                {
                    FundingModelId = n,
                    Name = $"Funding Model {n} for Service Subcategory {serviceCategoryId}"
                };

                fundingModels.Add(fundingModel);
            }

            return Ok(fundingModels);
        }
    }
}
