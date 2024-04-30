using Microsoft.AspNetCore.Mvc;
using TAG.Inventory.Entities;
using TAG.Inventory.Repository.Interface;

namespace TAG.Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _repository;

        public ProductController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _repository.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await _repository.GetById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            await _repository.Add(product);
            return Ok();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Product product, int id)
        {
            if (id > 0)
            {
                var resultProduct = await _repository.GetById(id);
                if (resultProduct != null)
                {
                    resultProduct.Name = product.Name;
                    resultProduct.Price = product.Price;
                    resultProduct.IsActive = product.IsActive;

                    await _repository.Update(resultProduct);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
               
            }
            else
            {
                return BadRequest();
            }


        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Product product,int id)
        {
            if (id > 0)
            {
                var resultProduct = await _repository.GetById(id);
                if (resultProduct != null)
                {
                    await _repository.Delete(resultProduct);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return BadRequest();
            }
        }
    }
}
