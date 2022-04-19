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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace APICore.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IAppUserRepository _appUserRepo;
        private readonly IMapper _mapper;

        public CartRepository(ApplicationDbContext context, IAppUserRepository appUserRepo, IMapper mapper)
        {
            _context = context;
            _appUserRepo = appUserRepo;
            _mapper = mapper;
        }

        public async Task<IList<Cart>> GetCartList()
        {
            return await _context.Carts.ToListAsync();
        }

        public async Task<Cart> GetCart(string id)
        {
            var cartDb = await _context.Carts.Include(c => c.CourseCarts).ThenInclude(x => x.Course).FirstOrDefaultAsync(c => c.ApplicationUserId == id);

            if (cartDb != null)
            {
                return cartDb;
            }

            return new Cart();
        }

        public async Task<IEnumerable<Course>> GetStoreItems(string id)
        {
            var cart = await GetCart(id);
            if (cart != null)
            {
                return cart.CourseCarts.Select(x => x.Course);
            }

            return new List<Course>();
        }


        public async Task<int> GetCartId(string id)
        {
            Cart cartDb = await _context.Carts.FirstOrDefaultAsync(c => c.ApplicationUserId == id);

            if (cartDb != null)
            {
                return cartDb.Id;
            }

            return await CreateCart(id);
        }

        public async Task<int> CreateCart(string id)
        {
            var cart = new Cart()
            {
                ApplicationUserId = id,
                DateCreated = DateTime.Now.ToString("F")
            };
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            return cart.Id;
        }

        public async Task UpdateCart(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCart(Cart cart)
        {
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<ResponseModel> AddProdToCart(AddItemModel req)
        {
            int cartId = await GetCartId(req.Id);
            var itemCount = await GetStoreItems(req.Id);
            int counter = itemCount.Count();

            CourseCart courseCart = await _context.CourseCarts.FirstOrDefaultAsync(x => x.CartId == cartId && x.CourseId == req.CourseId);

            if (courseCart != null)
            {
                return new ResponseModel()
                {
                    Message = "Item already exist",
                    AddedCourseId = req.CourseId,
                    RemovedCourseId = "Removal not applicable",
                    AlreadyAdded = true,
                    NewlyAdded = false,
                    IsDoneAdded = true,
                    IsDoneRemoved = false,
                    ItemCounter = 0
                };
            }

            if (courseCart == null)
            {

                CourseCart courseStore = new CourseCart()
                {
                    CourseCartId = Guid.NewGuid().ToString(),
                    CartId = cartId,
                    CourseId = req.CourseId
                };

                await _context.CourseCarts.AddAsync(courseStore);
                await _context.SaveChangesAsync();
                counter++;

                return new ResponseModel()
                {
                    Message = "Item newly added",
                    AddedCourseId = req.CourseId,
                    RemovedCourseId = "Removal not applicable",
                    NewlyAdded = true,
                    AlreadyAdded = false,
                    IsDoneAdded = true,
                    IsDoneRemoved = false,
                    ItemCounter = counter

                };
            }
            else
            {
                return new ResponseModel() { Message = "Request to add course failed" };
            }
        }

        public async Task<ResponseModel> RemoveProdFromCart(RemoveItemModel req)
        {
            int cartId = await GetCartId(req.Id);
            var itemCount = await GetStoreItems(req.Id);
            int counter = itemCount.Count();

            CourseCart cartItem = await _context.CourseCarts.FirstOrDefaultAsync(x => x.CartId == cartId && x.CourseId == req.CourseId);

            if (cartItem != null)
            {
                _context.CourseCarts.Remove(cartItem);
                await _context.SaveChangesAsync();
                counter--;

                return new ResponseModel()
                {
                    Message = "Removed",
                    RemovedCourseId = req.CourseId,
                    AddedCourseId = "Added not applicable",
                    NewlyAdded = false,
                    AlreadyAdded = true,
                    IsDoneRemoved = true,
                    IsDoneAdded = false,
                    ItemCounter = counter
                };
            }

            return new ResponseModel()
            {
                Message = "Request to remove course failed"
            };
        }

    }
}

