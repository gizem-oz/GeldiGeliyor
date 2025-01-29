using GeldiGeliyor.Business.Concrete.Dtos.UserDtos;
using GeldiGeliyor.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace GeldiGeliyor.Business.Abstract
{
    public interface IAuthService
    {
        //Getirme
        Task<SellerGetDto> SellerGetDtoByIdAsync(int id);
        Task<CustomerGetDto> CustomerGetDtoByIdAsync(int id);
        Task<SellerGetDto> SellerGetDtoByUsernameAsync(string username);
        Task<CustomerGetDto> CustomerGetDtoByUsernameAsync(string username);
        //Listeleme
        Task<List<SellerGetDto>> SellersGetDtoAsync();
        Task<List<CustomerGetDto>> CustomersGetDtoAsync();

        Task<List<AppUser>> SellerAndCustomerGetAll();
        //Ekleme
        Task<IdentityResult> SellerAddAsync(SellerAddDto sellerAddDto);
        Task<IdentityResult> CustomerAddAsync(CustomerAddDto customerAddDto);
        //Güncelleme
        Task<IdentityResult> SellerUpdateAsync(SellerUpdateDto sellerUpdateDto);
        Task<IdentityResult> CustomerUpdateAsync(CustomerUpdateDto customerUpdateDto);
        //Silme(Pasife çekme)//sadece admine tanımlanabilir. 
        Task<IdentityResult> SellerRemoveAsync(int id);
        Task<IdentityResult> CustomerRemoveAsync(int id);
        // Login
        Task<SignInResult> SignInAsync(string username,string password);
        Task SignOutAsync();
        Task<string> CreateTokenAsync(LoginDto loginDto);


    }
}
