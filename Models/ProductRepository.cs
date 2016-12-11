using System;
using System.Collections.Generic;

namespace inventory_api.Models{
    public class ProductRepository : IProductRepository
    {
        public ProductDto Add(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return new List<ProductDto>() {
                new ProductDto(){
                    Name = "Apple",
                    SellingPrice = 56.00
                }
            };
        }
    }
}