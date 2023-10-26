using Microsoft.AspNetCore.Mvc;
using ModelClass;
using Repository;

namespace PwCCrudMongo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IRepository _iRepositiry;
        public ProductController(IRepository iRepositiry)
        {
            _iRepositiry = iRepositiry;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _iRepositiry.GetAllAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var people = await _iRepositiry.GetByIdAsync(id);
            if (people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product newProduct)
        {
            await _iRepositiry.CreateNewProductAsync(newProduct);
            return CreatedAtAction(nameof(Get), new { id = newProduct.ProductId }, newProduct);
        }
    }
}
