﻿using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mmarab.CqsExample.Application;
using Mmarab.CqsExample.Application.Commands.Contracts;
using Mmarab.CqsExample.Application.Commands.Executor;
using Mmarab.CqsExample.Application.Queries.Contracts;
using Mmarab.CqsExample.Application.Queries.Executor;
using Mmarab.CqsExample.Application.Validation;


namespace Mmarab.CqsExample.Api
{
    [EnableCors("AllowAll")]
    [Route("v1/api/baskets/")]
    public class BasketController : BaseController
    {
        private readonly IGenerateIdentifier _generateIdentifier;
        public BasketController(IQueryExecutor query, ICommandExecutor command, 
            IModelValidationExecutor modelValidation, IGenerateIdentifier generateIdentifier)
            : base(query, command, modelValidation)
        {
            _generateIdentifier = generateIdentifier;
        }

        [HttpPost]
        [Route("")]
        public async System.Threading.Tasks.Task<IActionResult> CreateBasket()
        {
            var guid = _generateIdentifier.Generate();
            await Command.Execute(new CreateBasketCommand(guid));

            return Created("http://localhost:41475/v1/api/baskets/"+guid, null);
        }

        [HttpGet]
        [Route("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> GetBasket(string id)
        {
            var basket = await Query.Execute<GetBasketQueryCriteria, GetBasketQueryResult>(new GetBasketQueryCriteria(Guid.Parse(id)));
            return Ok(basket);
        }

        [HttpPost]
        [Route("{id}/items/")]
        public async System.Threading.Tasks.Task<IActionResult> CreateBasketItem(string id, [FromBody] int productId, [FromBody]int quantity)
        {
            await Command.Execute(new CreateBasketItem(Guid.Parse(id), productId, quantity));
            return Created("http://localhost:41475/v1/api/baskets/" + id, null);
        }

        [HttpDelete]
        [Route("{id}/items/{itemId}")]
        public async System.Threading.Tasks.Task<IActionResult> DeleteBasketItem(string id, string itemId)
        {
            await Command.Execute(new DeleteBasketItem(Guid.Parse(id), Guid.Parse(itemId)));
            return Ok(null);
        }

        [HttpPut]
        [Route("{id}/items/itemId")]
        public async System.Threading.Tasks.Task<IActionResult> UpdateBasketItem(string id, string itemId, [FromBody]int quantity)
        {
            await Command.Execute(new UpdateBasketItem(Guid.Parse(id), Guid.Parse(itemId), quantity));
            return Ok(null);
        }
    }
}
