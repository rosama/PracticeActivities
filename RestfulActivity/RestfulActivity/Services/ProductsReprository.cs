using RestfulActivity.DBContexts;
using RestfulActivity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestfulActivity.Services
{
    public class ProductsReprository : IProductReprository
    {
        private readonly ProductsContext _context;

        public ProductsReprository(ProductsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddProducts(Products product)
        {
            if(product==null)
            throw new ArgumentNullException(nameof(product));
            product.Id = Guid.NewGuid();
            _context.Products.Add(product);
        }

        public IEnumerable<Products> GetProducts(Guid CategoryId)
        {
            if (CategoryId == Guid.Empty)
               throw new ArgumentNullException(nameof(CategoryId));
            return _context.Products.Where(x => x.CategoryId == CategoryId);
        }
        public IEnumerable<Products> GetProducts()
        {
           
            return _context.Products;
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
        public void UpdateProduct(Products product) {
           /* var entity = _context.Products.FirstOrDefault(i => i.Id == product.Id);
            if (entity != null)
            {
                entity.Price = product.Price;
                entity.CategoryId = product.CategoryId;
                entity.Name = product.Name;
                entity.ImgURL = product.ImgURL;
                _context.SaveChanges();
            }*/
        }
        public Products GetProduct(Guid productId)
        {
            return _context.Products.Where(x => x.Id == productId).FirstOrDefault();
        }
        public bool ProductExists(Guid productId)
        { 
            if(productId==Guid.Empty)
                throw new ArgumentNullException(nameof(productId));
           return  _context.Products.Any(a => a.Id == productId);
        }
        public void DeleteProduct(Products product)
        {
            _context.Products.Remove(product);
        }
    }
}
