using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserComandResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private readonly SignInManager<Domain.Entities.Identity.AppUser> _signManager;

        public LoginUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, SignInManager<Domain.Entities.Identity.AppUser> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }

        public async Task<LoginUserComandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user is null)
                user = await _userManager.FindByNameAsync(request.UsernameOrEmail);

            if (user is null)
                throw new NotFoundUserException("Kullanıcı adı veya Şifre hatalı");

            SignInResult result = await _signManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)//Authentication Succeeded
            {
                //yetki belirlenmeli
            }
                return new();

        }
    }
}