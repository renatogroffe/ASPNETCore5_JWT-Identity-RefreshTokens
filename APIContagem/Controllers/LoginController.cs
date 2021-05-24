using Microsoft.AspNetCore.Mvc;
using APIContagem.Security;

namespace APIContagem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public Token Post(AccessCredentials credenciais,
            [FromServices]AccessManager accessManager)
        {
            if (accessManager.ValidateCredentials(credenciais))
                return accessManager.GenerateToken(credenciais);
            else
                return new ()
                {
                    Authenticated = false,
                    Message = "Falha ao autenticar"
                };
        }
    }
}