using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mmarab.CqsExample.Application.Queries;
using Mmarab.CqsExample.Application.Validation;

namespace Mmarab.CqsExample.Api
{
    [EnableCors("AllowAll")]
    [Route("v1/api/baskets/")]
    public class BasketController : BaseController
    {
        public BasketController(IQueryExecutor query, IModelValidationExecutor modelValidation) : base(query, modelValidation){}

        [HttpPost]
        [Route("")]
        public async System.Threading.Tasks.Task<IActionResult> CreateBasket()
        {

            return Ok(null);
        }

        [HttpGet]
        [Route("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> GetBasket()
        {
           return Ok(null);
        }

        [HttpPost]
        [Route("{id}/items/")]
        public async System.Threading.Tasks.Task<IActionResult> CreateBasketItem()
        {
        
            return Ok(null);
        }

        [HttpDelete]
        [Route("{id}/items/{itemId}")]
        public async System.Threading.Tasks.Task<IActionResult> DeleteBasketItem()
        {
          
            return Ok(null);
        }

        [HttpPut]
        [Route("{id}/items/itemId")]
        public async System.Threading.Tasks.Task<IActionResult> UpdateBasketItem()
        {
            return Ok(null);
        }
    }
}
