using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.DataInterfaces;
using APICore.DataModelService;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;
        private readonly ICartRepository _cartRepo;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepo, ICartRepository cartRepo, IMapper mapper)
        {
            _courseRepo = courseRepo;
            _cartRepo = cartRepo;
            _mapper = mapper;
        }

        [HttpGet("items/products")]
        public IActionResult ProductList()
        {
            var options = new ProductListOptions
            {
                Limit = 20,
            };
            var service = new ProductService();
            StripeList<Product> products = service.List(
              options
            );

            return Ok(products);
        }

        //[HttpGet("itemList")]
        //public async Task<IActionResult> GetProducts()
        //{
        //    var items = await _prodRepo.GetProductList();
        //    var prodList = _mapper.Map<List<ProductModel>>(items);
        //    return Ok(prodList);
        //}

        [HttpGet("getById/{courseId}")]
        public async Task<IActionResult> GetProduct(string courseId)
        {
            var course = await _courseRepo.GetCourseById(courseId);
            var courseModel = new CourseModel()
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                PriceId = course.PriceId,
                Price = course.Price,
                Description = course.Description,
                Image = course.Image
            };
            return Ok(courseModel);
        }

    }
}
