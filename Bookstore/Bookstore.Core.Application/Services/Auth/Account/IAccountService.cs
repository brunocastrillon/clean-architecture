using Bookstore.Core.Application.DTO;
using System.Threading.Tasks;

namespace Bookstore.Core.Application.Services.Auth.Account
{
    public interface IAccountService
    {
        /// <summary>
        /// executa o método 'PasswordSignInAsync' do AspNetCore.Identity.SignInManager
        /// </summary>
        /// <param name="dto">Application.DTO.LoginDTO</param>
        /// <returns>True/False</returns>
        Task<bool> Login(LoginDTO dto);

        /// <summary>
        /// executa o método 'SignOutAsync' do AspNetCore.Identity.SignInManager
        /// </summary>
        void Logout();

        /// <summary>
        /// efetua o registro na tabela 'USer' utilizando o repositório
        /// </summary>
        /// <param name="dto">Application.DTO.UserDTO</param>
        /// <returns>Application.DTO.UserDTO</returns>
        Task<UserDTO> Register(UserDTO dto);
    }
}