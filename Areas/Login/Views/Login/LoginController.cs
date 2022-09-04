

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationMVC.Views.Login
{    
    [Icon("person")]
    [Label("Авторизация")]
    [Description("Процедура авторизации неообходима для определения функций необходимых пользователю.")]
    [Help("Если Вы не зарегистрированы на данном ресурсе, то Вам следует пройти в раздел регистрации предварительно")]
    [Area("Login")]
    [Route("/[controller]/[action]")]
    public class LoginController: FunctionController<LoginModel>
    {
        //private readonly APIAuthorization _authorization;
        private readonly TokenManagement _tokens;
        
        public LoginController(
                APIAuthorization authorization,
                 TokenManagement tokens, IServiceProvider  services,
                 IServiceProvider provider,
                  IUserNotificationsService notification) : base(provider,notification, services)
        {            
            _authorization = authorization;
            _tokens = tokens;
        }

        
        /// <summary>
        /// Выполнение операции "Авторизация"
        /// </summary>        
        protected override void Do(LoginModel model)
        {
            var user = _authorization.Signin(model.Email, model.Password);
            if(user != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name,model.Email)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokens.Secret));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var jwtToken = new JwtSecurityToken(
                    _tokens.Issuer,
                    _tokens.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: credentials);
                var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            }
        }


        /// <summary>
        /// URL следующей операции
        /// </summary>
        protected override string GetNext()
        {
            return "/Home/Index";
        }

        public override IActionResult Complete(LoginModel entity)
        {
            throw new NotImplementedException($"{GetType().GetTypeName()}");
        }
    }
}
