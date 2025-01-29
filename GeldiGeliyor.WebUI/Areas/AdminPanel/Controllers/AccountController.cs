using AutoMapper;
using AutoMapper.Configuration;
using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Business.Concrete.Dtos.CategoryDtos;
using GeldiGeliyor.Business.Concrete.Dtos.UserDtos;
using GeldiGeliyor.Entities.Concrete;
using GeldiGeliyor.Entities.Concrete.Enum;
using Microsoft.AspNetCore.Mvc;

namespace GeldiGeliyor.WebUI.Areas.AdminPanel.Controllers
{
    public class AccountController(IAuthService authService, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<AppUser> appUsers = await authService.SellerAndCustomerGetAll();
            return View(appUsers);
        }

        public async Task<IActionResult> Detail(int id)
        {
            List<AppUser> appUsers = new List<AppUser>();
            CustomerGetDto customer = await authService.CustomerGetDtoByIdAsync(id);
            if (customer != null)
            {
                AppUser userCustomer = mapper.Map<AppUser>(customer);
                appUsers.Add(userCustomer);
            }
            SellerGetDto seller = await authService.SellerGetDtoByIdAsync(id);
            if (seller != null)
            {
                AppUser userSeller = mapper.Map<AppUser>(seller);
                appUsers.Add(userSeller);
            }
            return View(appUsers);
        }

        [HttpGet]
        public async Task<IActionResult> CustomerUpdate(int id)
        {
            List<AppUser> appUsers = new List<AppUser>();
            CustomerGetDto customer = await authService.CustomerGetDtoByIdAsync(id);
            if (customer != null)
            {
                AppUser userCustomer = mapper.Map<AppUser>(customer);
                appUsers.Add(userCustomer);
            }
            SellerGetDto seller = await authService.SellerGetDtoByIdAsync(id);
            if (seller != null)
            {
                AppUser userSeller = mapper.Map<AppUser>(seller);
                appUsers.Add(userSeller);
            }
            return View(appUsers);
        }
        [HttpPost]
        public async Task<IActionResult> CustomerUpdate(CustomerUpdateDto customerUpdateDto)
        {
            IResponseResult result = (IResponseResult)await authService.CustomerUpdateAsync(customerUpdateDto);
            if (result.IsSuccessed)
                return RedirectToAction("Detail", new { userName = customerUpdateDto.UserName });
            return View(customerUpdateDto);

        }

        [HttpGet]
        public async Task<IActionResult> SellerUpdate(int id)
        {
            List<AppUser> appUsers = new List<AppUser>();
            CustomerGetDto customer = await authService.CustomerGetDtoByIdAsync(id);
            if (customer != null)
            {
                AppUser userCustomer = mapper.Map<AppUser>(customer);
                appUsers.Add(userCustomer);
            }
            SellerGetDto seller = await authService.SellerGetDtoByIdAsync(id);
            if (seller != null)
            {
                AppUser userSeller = mapper.Map<AppUser>(seller);
                appUsers.Add(userSeller);
            }
            return View(appUsers);
        }
        [HttpPost]
        public async Task<IActionResult> SellerUpdate(SellerUpdateDto sellerUpdateDto)
        {
            IResponseResult result = (IResponseResult)await authService.SellerUpdateAsync(sellerUpdateDto);
            if (result.IsSuccessed)
                return RedirectToAction("Detail", new { companyName = sellerUpdateDto.CompanyName });
            return View(sellerUpdateDto);

        }

        [HttpGet]
        public async Task<IActionResult> Passivating()
        {
            List<AppUser> appUsers = await authService.SellerAndCustomerGetAll();
            return View(appUsers);
        }
        [HttpPost]
        public async Task<IActionResult> Passivating(AppUser appUser)
        {
            List<AppUser> appUsers = await authService.SellerAndCustomerGetAll();
            string allName = appUser.Customer.FirstName + appUser.Customer.LastName;
            CustomerGetDto customer = await authService.CustomerGetDtoByUsernameAsync(allName);
            if (allName != null)
            {
                AppUser userCustomer = mapper.Map<AppUser>(customer);
                customer.Status = Status.IsPassive;
                CustomerUpdateDto updateCustomer = mapper.Map<CustomerUpdateDto>(userCustomer);
                 await authService.CustomerUpdateAsync(updateCustomer);
            }
            string name = appUser.Seller.CompanyName;
            SellerGetDto seller = await authService.SellerGetDtoByUsernameAsync(name);
            if (name != null)
            {
                AppUser userSeller = mapper.Map<AppUser>(seller);
                seller.Status = Status.IsPassive;
                SellerUpdateDto updateSeller = mapper.Map<SellerUpdateDto>(userSeller);
                await authService.SellerUpdateAsync(updateSeller);
            }

            return View(appUsers);
        }
      
    }
}
