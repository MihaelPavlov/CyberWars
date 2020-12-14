using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using CyberWars.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using CyberWars.Services.Data;
using CyberWars.Common;

namespace CyberWars.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IPlayerService playerService;
        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IPlayerService playerService,
            RoleManager<ApplicationRole> roleManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._logger = logger;
            this._emailSender = emailSender;
            this.playerService = playerService;
            this.roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string Type { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Avatar")]
            public string Avatar { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null, string type = null)
        {
            if (type == null)
            {
                return this.RedirectToPage("/Account/RegisterChoose");
            }

            this.Type = type;
            this.ReturnUrl = returnUrl;
            this.ExternalLogins = (await this._signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null, string type = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Username, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    // Create Player
                    var playerAvatar = this.Input.Avatar.Split(".");
                    await this.playerService.CreatePlayer(user.Id, playerAvatar[1], this.Input.Avatar);

                    // Create Player Skills
                    await this.playerService.CreateSkills(user.Id);

                    // Add Abilities
                    await this.playerService.CreatePlayerAbilities(user.Id);

                    //Create BattleRecord
                    await this.playerService.CreateBattleRecord(user.Id);

                    this._logger.LogInformation("User created a new account with password.");

                    var code = await this._userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: this.Request.Scheme);

                    await this._emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    // Roles Logic

                    if (!await this.roleManager.RoleExistsAsync(GlobalConstants.UserRoleName))
                    {
                        await this.roleManager.CreateAsync(new ApplicationRole
                        {
                            Name = GlobalConstants.UserRoleName,
                        });
                    }

                    await this._userManager.AddToRoleAsync(user, GlobalConstants.UserRoleName);

                    if (this._userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return this.RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await this._signInManager.SignInAsync(user, isPersistent: false);
                        return this.Redirect("/Home/Index");
                    }
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            this.Type = type;
            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
