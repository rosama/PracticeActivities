using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RestfulActivity.Models;
using RestfulActivity.Services;
using System;
using System.Collections.Generic;

namespace RestfulActivity.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [ApiController]
    [Route("api/Categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryReprository _categoryReprository;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryReprository categoryReprository,IMapper mapper)
        {
            _categoryReprository = categoryReprository ?? throw new ArgumentNullException(nameof(categoryReprository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories()
        {

            var or = new OperationResponse<IEnumerable<CategoryDto>>();
            
            var categories = _categoryReprository.GetCategories();
            var categoriesToReturn = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            or.message = string.Empty;
            or.result = categoriesToReturn;
            or.success = true;
            return Ok(or);

        }

    }
}
