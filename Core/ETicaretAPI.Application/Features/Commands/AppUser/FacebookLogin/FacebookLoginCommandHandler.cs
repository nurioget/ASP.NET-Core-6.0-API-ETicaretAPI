using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.DTOs.Facebook;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.AppUser.FacebookLogin
{
    public class FacebookLoginCommandHandler : IRequestHandler<FacebookLoginCommandRequest, FacebookLoginCommandResponse>
    {
        readonly IAuthServices _authServices;

        public FacebookLoginCommandHandler(IAuthServices authService)
        {
            _authServices = authService;
        }

        public async Task<FacebookLoginCommandResponse> Handle(FacebookLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authServices.FacebookLoginAsync(request.AuthToken, 15);
            return new()
            {
                Token = token
            };
        }
    }
}