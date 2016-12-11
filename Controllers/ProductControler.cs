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
        private InventoryContext context;
        public ProductController(IProductRepository productRepository, InventoryContext context)
        {
            this.productRepository = productRepository;
            this.context = context;
        }
        // GET api/product
        [HttpGet]
        public IEnumerable<ProductDto> Get()
        {
            return this.productRepository.GetAll();
        }

                // GET api/product
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Product product = this.context.Products.FirstOrDefault(i => i.Id == id);
            if(product != null){
                return new OkObjectResult(new ProductDto(){
                    Id = product.Id,
                    Name = product.Name,
                    SellingPrice = product.SellingPrice,
                    CostPrice = product.CostPrice
                });
            }
            else
                return new NotFoundResult();
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductDto product)
        {
            return new OkObjectResult(this.productRepository.Add(product));
        }

        [HttpDelete("all")]
        public void Delete()
        {

            foreach (var entity in context.Products)
                context.Products.Remove(entity);
            context.SaveChanges();

            this.context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleteById(Guid id)
        {
                                Console.WriteLine(id);

            Product product = this.context.Products
            .FirstOrDefault(i=>i.Id == id);
            if (product != null)
            {
                Console.WriteLine(product.Id);
                this.context.Products.Remove(product);

                this.context.SaveChanges();
            }
            else{
                throw new Exception("Not Found");
            }
        

        }
    }
}
