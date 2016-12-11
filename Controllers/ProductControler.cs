using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using inventory_api.Models;

namespace inventory_api.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        public ProductController(IProductRepository productRepository){
            this.productRepository = productRepository;
        }
        // GET api/product
        [HttpGet]
        public IEnumerable<ProductDto> Get()
        {
           return this.productRepository.GetAll();
        }

        [HttpPost]
        public void Add([FromBody] ProductDto product){
            this.productRepository.Add(product);
        }
    }
}
