using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using APICore.DataInterfaces;
using APICore.DataModelService;
using APICore.DataService;
using APICore.ModelService;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartStoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAppUserRepository _appUserRepo;
        private readonly ICartRepository _cartRepo;
        private readonly IMapper _mapper;

        public CartStoreController(ApplicationDbContext context, IAppUserRepository appUserRepo, ICartRepository cartRepo, IMapper mapper)
        {
            _context = context;
            _appUserRepo = appUserRepo;
            _cartRepo = cartRepo;
            _mapper = mapper;
        }


        [Authorize]
        [HttpGet("cart/{id}")]
        public async Task<IActionResult> GetCartFromDb([FromRoute] string id)
        {
            var cartItems = new List<CourseModel>();
            var cartCourses = await _cartRepo.GetStoreItems(id);
            foreach (var course in cartCourses)
            {
                var courseDb = new CourseModel()
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    PriceId = course.PriceId,
                    Price = course.Price,
                    Description = course.Description,
                    Image = course.Image
                };

                cartItems.Add(courseDb);
            }

            var model = new CartModel();
            if (cartItems != null)
            {
                model.ItemCount = cartItems.Count();
                model.Courses = cartItems;
                return Ok(model);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpPost("addToCart")]
        public async Task<IActionResult> AddToCart([FromBody] AddItemModel req)
        {
            var result = await _cartRepo.AddProdToCart(req);
            return Ok(new { Result = result });
        }


        [Authorize]
        [HttpPost("removeFromCart")]
        public async Task<IActionResult> RemoveFromCart([FromBody] RemoveItemModel req)
        {
            var result = await _cartRepo.RemoveProdFromCart(req);
            return Ok(new { Result = result });
        }
    }
}
