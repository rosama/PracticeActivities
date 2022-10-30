using RestfulActivity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RestfulActivity.Services
{
    public interface IProductReprository
    {
        IEnumerable<Products> GetProducts(Guid CategoryId);
        Products GetProduct(Guid productId);
        IEnumerable<Products> GetProducts();
        void AddProducts(Products products);
        bool Save();
        void UpdateProduct(Products product);
        bool ProductExists(Guid productId);
        void DeleteProduct(Products product);
    }
}
