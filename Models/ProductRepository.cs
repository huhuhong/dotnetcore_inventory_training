using System;
using System.Collections.Generic;
using System.Linq;

namespace inventory_api.Models
{
    public class ProductRepository : IProductRepository
    {
        private InventoryContext context;
        public ProductRepository(InventoryContext context)
        {
            this.context = context;
        }
        public ProductDto Add(ProductDto productDto)
        {            
            productDto.Id = Guid.NewGuid();
            this.context.Products.Add(new Product(){
                Id = productDto.Id,
                Name = productDto.Name,
                CostPrice = productDto.CostPrice,
                SellingPrice = productDto.SellingPrice
            });
            this.context.SaveChanges();
            
            return productDto;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return this.context.Products.Select(
                product => new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    SellingPrice = product.SellingPrice,
                    CostPrice = product.CostPrice
                }
            ).
            ToList();
        }
    }
}