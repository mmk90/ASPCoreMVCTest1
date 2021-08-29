using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Data;
using Website.Data.Repositories;
using Website.Models;

namespace Website.ViewComponents
{
    public class CategoriesComponent : ViewComponent
    {
        private ICategoryRepository _categoryRepository;
        public CategoriesComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _categoryRepository.GetCategories();

            return View("/Views/Categories/GetCategories.cshtml", model);
        }
    }
}
