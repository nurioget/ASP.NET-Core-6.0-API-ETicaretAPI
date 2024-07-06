using ETicaretAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserComandResponse 
    {

    }
    public class LoginUserSuccessCommandResponse : LoginUserComandResponse
    {
        public Token Token { get; set; }
    }
    public class LoginUserErrorCommandResponse: LoginUserComandResponse
    {
        public string Message { get; set; }
    }
}
