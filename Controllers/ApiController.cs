using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetFullStack.Entities;
using NetFullStack.Models;
using NetFullStack.Services;

namespace NetFullStack.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {

        public IAicommerceRepository _repository;
        public IMapper _mapper;
        public ApiController(IAicommerceRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("products")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _repository.GetProductsAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpPost]
        [Route("addProduct")]
        public async Task<ActionResult> AddProduct(ProductDto product)
        {
            var productEntity = _mapper.Map<Product>(product);
            _repository.AddProductsAsync(productEntity);
            await _repository.SaveChangesAsync();
            return Created("", new
            {
                message = "Product Created"
            });
        }
    }
}