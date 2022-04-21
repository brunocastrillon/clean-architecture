using AutoMapper;
using Bookstore.Core.Application.DTO;
using Bookstore.Core.Domain.Contracts.Auth;
using Bookstore.Core.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Bookstore.Core.Application.Services.Auth.Account
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AccountService(SignInManager<User> signInManager, IMapper mapper, IUserRepository userRepository)
        {
            _signInManager = signInManager;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<bool> Login(LoginDTO dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async void Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserDTO> Register(UserDTO dto)
        {
            var entity = _mapper.Map<User>(dto);
            var entityResult = await _userRepository.CreateAsync(entity);
            var dtoResult = _mapper.Map<UserDTO>(entityResult);
            return dtoResult;
        }
    }
}