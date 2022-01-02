using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Web.DTOs;
using UdemyNLayerProject.Web.Filters;

namespace UdemyNLayerProject.Web.Controllers
{
    public class Categories : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public Categories(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task <IActionResult> Index()
        {
            var categories =await _categoryService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            //Ekrana Doldurur
            var category = await _categoryService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(category);

            return RedirectToAction("Index");
        }

    }
}
