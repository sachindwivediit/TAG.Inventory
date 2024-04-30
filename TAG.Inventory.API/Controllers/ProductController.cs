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
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var result =  await _repository.GetAll();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("GetByid/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _repository.GetById(id);
            if (result!=null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<ProductController>
        [HttpPost("Add")]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (product != null)
            {
                await _repository.Add(product);
                return Ok();
            }
            return BadRequest();
          
        }

        // PUT api/<ProductController>/5
        [HttpPut("Update/{id}")]
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
        [HttpDelete("Remove/{id}")]
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
