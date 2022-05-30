using System.Net;
using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class BasketController : ControllerBase
	{
		private readonly IBasketRepository _repository;

		public BasketController(IBasketRepository repository)
		{
			_repository = repository;
		}

		[HttpGet("{userName}", Name ="GetBasket")]
        [ProducesResponseType (typeof(ShoppingCart), (int) HttpStatusCode.OK)]

		public async Task<ActionResult<ShoppingCart>> GetShoppingCart(string userName)
        {
			var result = await _repository.GetBasket(userName);
			return Ok(result ?? new ShoppingCart(userName));
        }
        [HttpPost]

		public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {
			return Ok(await _repository.UpdateBasket(basket));
        }

        [HttpDelete]

		public async Task DeleteBasket(string userName)
        {
			await _repository.DeleteBasket(userName);
        }

		
	}
}

