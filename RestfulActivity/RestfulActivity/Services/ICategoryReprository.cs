using RestfulActivity.Entities;
using System;
using System.Collections.Generic;

namespace RestfulActivity.Services
{
    public interface ICategoryReprository
    {
        IEnumerable<Category> GetCategories();
    }
}
