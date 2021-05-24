using System;
using Microsoft.AspNetCore.Identity;

namespace APIContagem.Security.Data
{
    public class IdentityInitializer
    {
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly APISecurityDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityInitializer(
            TokenConfigurations tokenConfigurations,
            APISecurityDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _tokenConfigurations = tokenConfigurations;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_context.Database.EnsureCreated())
            {
                if (!_roleManager.RoleExistsAsync(_tokenConfigurations.AccessRole).Result)
                {
                    var resultado = _roleManager.CreateAsync(
                        new IdentityRole(_tokenConfigurations.AccessRole)).Result;
                    if (!resultado.Succeeded)
                    {
                        throw new Exception(
                            $"Erro durante a criação da role {_tokenConfigurations.AccessRole}.");
                    }
                }

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "admin_apicontagem",
                        Email = "admin-apicontagem@teste.com.br",
                        EmailConfirmed = true
                    }, "AdminAPIContagem01!", _tokenConfigurations.AccessRole);

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "usrinvalido_apicontagem",
                        Email = "usrinvalido-apicontagem@teste.com.br",
                        EmailConfirmed = true
                    }, "UsrInvAPIContagem01!");
            }
        }

        private void CreateUser(
            ApplicationUser user,
            string password,
            string initialRole = null)
        {
            if (_userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var resultado = _userManager
                    .CreateAsync(user, password).Result;

                if (resultado.Succeeded &&
                    !String.IsNullOrWhiteSpace(initialRole))
                {
                    _userManager.AddToRoleAsync(user, initialRole).Wait();
                }
            }
        }
    }
}