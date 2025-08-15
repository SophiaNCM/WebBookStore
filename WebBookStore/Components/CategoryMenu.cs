using Microsoft.AspNetCore.Mvc;
using WebBookStore.Repositories.Interfaces;

namespace WebBookStore.Components
{
    //"Model" da view Component CategoryMenu(A model e a view precisam ter o mesmo nome)
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke() 
        {
            var categories = _categoryRepository.Categories.OrderBy(p => p.CategoryName);
            return View(categories);
        }
    }
}
