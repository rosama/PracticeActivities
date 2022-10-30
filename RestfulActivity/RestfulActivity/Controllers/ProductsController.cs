using Microsoft.AspNetCore.Mvc;
using RestfulActivity.DBContexts;
using RestfulActivity.Entities;
using RestfulActivity.Models;
using RestfulActivity.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace RestfulActivity.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [ApiController]
    [Route("api/Products")]
    public class ProductsController : ControllerBase
    {

        private readonly IProductReprository _productReprository;
        private readonly IMapper _mapper;
        
        public ProductsController(IProductReprository productReprository,IMapper mapper)
        {
            _productReprository = productReprository ?? throw new ArgumentNullException(nameof(productReprository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));   
        }

        [HttpGet("{categoryId}")]
        public ActionResult<IEnumerable<ProductsDto>> GetProducts(Guid categoryId)
        {
          
            var or = new OperationResponse<IEnumerable<ProductsDto>>();
            if (categoryId == null)
            {
                or.success = false;
                or.message = "No category was found";
                or.result = null;
                return NotFound(or); 
            }
            var products = _productReprository.GetProducts(categoryId);
            var productsToReturn = _mapper.Map<IEnumerable<ProductsDto>>(products);
                 or.message = string.Empty;
            or.result = productsToReturn;
            or.success = true;
            return Ok(or);

        }

        [HttpGet()]

        [Route("{action}")]
        public ActionResult<IEnumerable<ProductsDto>> GetProductsWithQuery([FromQuery]Guid categoryId)
        {
            var or = new OperationResponse<IEnumerable<ProductsDto>>();
            if (categoryId == null)
            {
                or.success = false;
                or.message = "No category was found";
                or.result = null;
                return NotFound(or);
            }
            var products = _productReprository.GetProducts(categoryId);
            var productsToReturn = _mapper.Map<IEnumerable<ProductsDto>>(products);
            or.message = string.Empty;
            or.result = productsToReturn;
            or.success = true;
            return Ok(or);

        }
        [HttpGet()]
        public ActionResult<IEnumerable<ProductsDto>> GetProducts()
        {
            var or = new OperationResponse<IEnumerable<ProductsDto>>();
            var products = _productReprository.GetProducts();
            var productsToReturn = _mapper.Map<IEnumerable<ProductsDto>>(products);
            or.message = string.Empty;
            or.result = productsToReturn;
            or.success = true;
            return Ok(or);

        }
        [HttpPost]
        public ActionResult<ProductsDto> AddProduct(ProductForCreationDto product) {
            var or = new OperationResponse<ProductsDto>();

            var productEntity = _mapper.Map < Entities.Products >( product);
            _productReprository.AddProducts(productEntity);
            _productReprository.Save();
            var productToReturn = _mapper.Map<ProductsDto>(productEntity);
            or.success = true;
            or.result = productToReturn;
            or.message = string.Empty;
            return Ok(or);

                
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(ProductForUpdateDto product, Guid productId)
        {
            var or = new OperationResponse<ProductsDto>();
            if (productId == Guid.Empty)
            { 
                or.message = "product ID cannot be empty";
                or.success = true;
                return NotFound(or);
            }
            if (!_productReprository.ProductExists(productId))
            {
                or.message = "product ID doesn't exist";
                or.success = true;
                return NotFound(or);
            }
            var productFromRepo = _productReprository.GetProduct(productId);
            if (productFromRepo == null)
            {
             var newProduct=  _mapper.Map<Products>(product);
                newProduct.Id = productId;
                _productReprository.AddProducts(newProduct);
                _productReprository.Save();
                var AddedProduct = _mapper.Map<ProductsDto>(product);
                or.success = true;
                or.result = AddedProduct;
                return CreatedAtAction("UpdateProduct", or);
            }
           _mapper.Map(product,productFromRepo);
            _productReprository.UpdateProduct(productFromRepo);
            _productReprository.Save();
            var productToReturn = _mapper.Map<ProductsDto>(productFromRepo);
            or.success = true;
            or.result = productToReturn;
            or.message = string.Empty;
            return Ok(or);


        }
        [HttpDelete("{productId}")]
        public ActionResult DeleteProduct(Guid productId)
        {
            var or = new OperationResponse<string>();

            var productFromRepo = _productReprository.GetProduct(productId);

            if (productFromRepo == null)
            {
                or.success = true;
                or.result = null;
                or.message = "there is no products available with this id";
                return NotFound(or);
            }

            _productReprository.DeleteProduct(productFromRepo);

            _productReprository.Save();

            or.success = true;
            or.result = "delete operation is done";
            or.message = string.Empty;
            return Ok(or);
        }


    }
}
