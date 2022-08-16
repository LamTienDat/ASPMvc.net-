using System.Collections.Generic;
using hello_asp.Models;

namespace hello_asp.Service
{
    public class ProductService : List<ProductModel> 
    {
        public ProductService ()
        {
            this.AddRange(new ProductModel [] {
                new ProductModel() { Id = 1, Name = "IP X", Price = 1000},
                new ProductModel() { Id = 2, Name = "IP XI", Price = 1300},
                new ProductModel() { Id = 3, Name = "IP XII", Price = 1400},
                new ProductModel() { Id = 4, Name = "SS s20", Price = 900},
            });
        }
    }
    
}