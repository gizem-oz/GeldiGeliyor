using AutoMapper;
using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Business.Concrete.Dtos.UserDtos;
using GeldiGeliyor.DataAccess.Abstract;
using GeldiGeliyor.Entities.Concrete;
using GeldiGeliyor.Entities.Concrete.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GeldiGeliyor.Business.Concrete
{
    public class AuthManager(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, ICustomerDal customerDal, ISellerDal sellerDal, IMapper mapper) : IAuthService
    {


        public async Task<IdentityResult> CustomerAddAsync(CustomerAddDto customerAddDto)
        {
            AppUser user = new AppUser()
            {
                Email = customerAddDto.Email,
                PhoneNumber = customerAddDto.PhoneNumber,
                UserName = customerAddDto.UserName,


            };
            IdentityResult result = await userManager.CreateAsync(user, customerAddDto.Password);
            var rols = roleManager.Roles.ToList();

            var rol = new AppRole()
            {
                Name = "Customer",
                NormalizedName = "CUSTOMER"
            };
            if (rols.FirstOrDefault(x => x.Name == rol.Name) is null)
            {
                await roleManager.CreateAsync(rol);
            }

            await userManager.AddToRoleAsync(user, "Customer");


            Customer customer = mapper.Map<Customer>(customerAddDto);
            customer.Id = user.Id;
            bool response = await customerDal.AddAsync(customer);
            return result;
        }

        public async Task<CustomerGetDto> CustomerGetDtoByIdAsync(int id)
        {
            AppUser user = await GetUserByIdAsync(id);
            Customer customer = await customerDal.GetAsync(x => x.Id == user.Id);
            CustomerGetDto customerGetDto = mapper.Map<CustomerGetDto>(user);
            customerGetDto = mapper.Map<CustomerGetDto>(customer);
            return customerGetDto;
        }

        public async Task<CustomerGetDto> CustomerGetDtoByUsernameAsync(string username)
        {
            AppUser user = await GetUserByUserNameAsync(username);
            Customer customer = await customerDal.GetAsync(x => x.Id == user.Id);
            CustomerGetDto customerGetDto = mapper.Map<CustomerGetDto>(user);
            customerGetDto = mapper.Map<CustomerGetDto>(customer);
            return customerGetDto;
        }

        public async Task<List<CustomerGetDto>> CustomersGetDtoAsync()
        {
            List<CustomerGetDto> customerGetDtos = new List<CustomerGetDto>();
            List<AppUser> users = await userManager.Users.ToListAsync();

            foreach (AppUser user in users)
            {
                Customer customer = await customerDal.GetAsync(x => x.Id == user.Id);
                CustomerGetDto customerGetDto = mapper.Map<CustomerGetDto>(user);
                customerGetDto = mapper.Map<CustomerGetDto>(customer);
                customerGetDtos.Add(customerGetDto);
            }

            return customerGetDtos;
        }

        public async Task<IdentityResult> CustomerUpdateAsync(CustomerUpdateDto customerUpdateDto)
        {
            //AppUser user = await userManager.Users.FirstOrDefaultAsync(x=>x.Id == customerUpdateDto.Id);
            //Customer customer = await customerDal.GetAsync(x => x.Id == user.Id);
            AppUser user = mapper.Map<AppUser>(customerUpdateDto);
            Customer customer = mapper.Map<Customer>(customerUpdateDto);
            var result = await userManager.UpdateAsync(user);
            await customerDal.UpdateAsync(customer);
            return result;


        }

        public async Task<IdentityResult> SellerAddAsync(SellerAddDto sellerAddDto)
        {
            AppUser user = new AppUser()
            {
                Email = sellerAddDto.Email,
                PhoneNumber = sellerAddDto.PhoneNumber,
                UserName = sellerAddDto.UserName,

            };
            IdentityResult result = await userManager.CreateAsync(user, sellerAddDto.Password);
            var rols = roleManager.Roles.ToList();

            var rol = new AppRole()
            {
                Name = "Seller",
                NormalizedName = "SELLER"
            };
            if (rols.FirstOrDefault(x=>x.Name == rol.Name ) is null)
            {
                await roleManager.CreateAsync(rol);
            }

            await userManager.AddToRoleAsync(user, "Seller");


            Seller seller = mapper.Map<Seller>(sellerAddDto);
            seller.Id = user.Id;
            bool response = await sellerDal.AddAsync(seller);
            return result;
        }

        public async Task<SellerGetDto> SellerGetDtoByIdAsync(int id)
        {
            AppUser user = await GetUserByIdAsync(id);
            Seller seller = await sellerDal.GetAsync(x => x.Id == user.Id);

            SellerGetDto sellerGetDto = new SellerGetDto()
            {
                CompanyAddress = seller.CompanyAddress,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                CompanyName = seller.CompanyName,
                CreateDate = seller.CreateDate,
                DeleteDate = seller.DeleteDate,
                UpdateDate = seller.UpdateDate,
                Id = user.Id,
                Status = seller.Status,
            };
            sellerGetDto = mapper.Map<SellerGetDto>(seller);
            return sellerGetDto;
        }

        private async Task<AppUser> GetUserByIdAsync(int id)
            => await userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<SellerGetDto> SellerGetDtoByUsernameAsync(string username)
        {
            AppUser user = await GetUserByUserNameAsync(username);
            Seller seller = await sellerDal.GetAsync(x => x.Id == user.Id);
            SellerGetDto sellerGetDto = new SellerGetDto()
            {
                CompanyAddress = seller.CompanyAddress,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                CompanyName = seller.CompanyName,
                CreateDate = seller.CreateDate,
                DeleteDate = seller.DeleteDate,
                UpdateDate = seller.UpdateDate,
                Id = user.Id,
                Status = seller.Status,

            };

            return sellerGetDto;
        }

        private async Task<AppUser> GetUserByUserNameAsync(string username)
        => await userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);


        public async Task<List<SellerGetDto>> SellersGetDtoAsync()
        {
            List<SellerGetDto> sellerGetDtos = new List<SellerGetDto>();
            List<AppUser> users = await userManager.Users.ToListAsync();

            foreach (AppUser user in users)
            {
                Seller seller = await sellerDal.GetAsync(x => x.Id == user.Id);
                SellerGetDto sellerGetDto = new SellerGetDto()
                {
                    CompanyAddress = seller.CompanyAddress,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    UserName = user.UserName,
                    CompanyName = seller.CompanyName,
                    CreateDate = seller.CreateDate,
                    DeleteDate = seller.DeleteDate,
                    UpdateDate = seller.UpdateDate,
                    Id = user.Id,
                    Status = seller.Status,
                };
                //sellerGetDto = mapper.Map<SellerGetDto>(seller);
                sellerGetDtos.Add(sellerGetDto);
            }

            return sellerGetDtos;
        }

        public async Task<IdentityResult> SellerUpdateAsync(SellerUpdateDto sellerUpdateDto)
        {
            AppUser user = mapper.Map<AppUser>(sellerUpdateDto);
            Seller seller = mapper.Map<Seller>(sellerUpdateDto);
            var result = await userManager.UpdateAsync(user);
            await sellerDal.UpdateAsync(seller);
            return result;
        }

        public async Task<IdentityResult> CustomerRemoveAsync(int id)//yalnızca admine tanımlansın
        {
            AppUser user = await GetUserByIdAsync(id);
            user.LockoutEnabled = false;
            Customer customer = await customerDal.GetAsync(x => x.Id == id);
            customer.Status = Status.IsPassive;
            await customerDal.UpdateAsync(customer);
            var result = await userManager.UpdateAsync(user);
            return result;
        }
        public async Task<IdentityResult> SellerRemoveAsync(int id)//yalnızca admine tanımlansın
        {
            AppUser user = await GetUserByIdAsync(id);
            user.LockoutEnabled = false;
            Seller seller = await sellerDal.GetAsync(x => x.Id == id);
            seller.Status = Status.IsPassive;
            await sellerDal.UpdateAsync(seller);
            var result = await userManager.UpdateAsync(user);
            return result;
        }

        public async Task<SignInResult> SignInAsync(string username, string password)
        {
            var signInResult = await signInManager.PasswordSignInAsync(username, password, true, true);
            return signInResult;
        }

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<List<AppUser>> SellerAndCustomerGetAll()//düzenlendi - Meltem
        {
            List<AppUser> appUsers = new List<AppUser>();
            List<AppUser> users = await userManager.Users.ToListAsync();
            foreach (var user in users)
            {
                Customer customer = await customerDal.GetAsync(x => x.Id == user.Id);
                if (customer != null)
                {
                    CustomerGetDto customerGetDto = mapper.Map<CustomerGetDto>(customer);
                    
                }

                Seller seller = await sellerDal.GetAsync(x => x.Id == user.Id);
                if (seller != null)
                {
                    SellerGetDto sellerGetDto = mapper.Map<SellerGetDto>(seller);
                    
                }
                appUsers.Add(user);
            }

            return appUsers;
        }


        

        public async Task<string> CreateTokenAsync(LoginDto loginDto)
        {
            // Kullanıcıyı getir
            var user = await userManager.FindByNameAsync(loginDto.UserName);
            string token = "";
            if (user is not null)
            {
                var result = await signInManager.PasswordSignInAsync(user, loginDto.Password, true, false);

                // Şifresi doğru mu kontrol edelim
                if (result.Succeeded)
                {
                    // Kullanıcının özelliklerini ayırt etmek için claims'leri kullandık.
                    List<Claim> claims = new List<Claim>()
            {
                new Claim("UserName", user.UserName),
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

                    // Rolleri token içerisine dahil etmek için ekledik
                    IList<string> roles = await userManager.GetRolesAsync(user);
                    foreach (var role in roles)
                        claims.Add(new Claim(ClaimTypes.Role, role));

                    // Claims'leri token içerisine aktarmak için dahil ettik.
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);

                    // Token'i oluşturmak için gerekli anahtar
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("benimadimnameamasadecebukadarladakalmazabdurrahmandaolabilirdi"));

                    // Token oluşturma tanımı
                    var tokenDescription = new SecurityTokenDescriptor()
                    {
                        Subject = claimsIdentity, // Kimlik bilgileri
                        Audience = "localhost", // Sunucu kaynağı
                        Issuer = "localhost", // Kimlerin istek atabileceği adres kaynağı
                        Expires = DateTime.UtcNow.AddDays(1), // Token süresi
                        SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature) // 256 bit şifreleme
                    };

                    // Token oluşturucu
                    var tokenHandler = new JwtSecurityTokenHandler();
                    // Token'i oluştur
                    var securityToken = tokenHandler.CreateToken(tokenDescription);
                    // String olarak ilgili token'i dışarı alıyoruz
                    token = tokenHandler.WriteToken(securityToken);
                }
            }
            return token;
        }
    }
    }

