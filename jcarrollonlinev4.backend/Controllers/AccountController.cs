﻿using JCarrollOnlineV2.Controllers;
using jcarrollonlinev4.backend.Entities;
using jcarrollonlinev4.backend.Managers;
using jcarrollonlinev4.backend.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using System.Globalization;

namespace jcarrollonlinev4.backend.Controllers
{
    //[Authorize]
    //public class AccountController : Controller
    //{
    //    private readonly ApplicationSignInManager _signInManager;
    //    private readonly ApplicationUserManager _userManager;
    //    //private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    //    public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
    //    {
    //        _userManager = userManager;
    //        _signInManager = signInManager;
    //    }

    //    [Authorize(Roles = "Administrator")]
    //    [ValidateAntiForgeryToken]
    //    [HttpPost]
    //    public async Task<ActionResult> DeleteUser(string userId)
    //    {
    //        DeleteUserModel deleteUserViewModel = new DeleteUserModel();
    //        ApplicationUser user = await _userManager.FindByIdAsync(userId).ConfigureAwait(false);

    //        deleteUserViewModel.InjectFrom(user);

    //        return user == null ? View() : View(deleteUserViewModel);
    //    }

    //    [HttpPost, ActionName("DeleteUser")]
    //    [Authorize(Roles = "Administrator")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> DeleteUserConfirmed(string userId)
    //    {
    //        ApplicationUser user = await _userManager.FindByIdAsync(userId).ConfigureAwait(false);

    //        if (user == null)
    //        {
    //            return View();
    //        }
    //        _userManager.Delete(user);
    //        return RedirectToAction("Index", "Users");
    //    }

    //    //
    //    // GET: /Account/JCarrollOnlineV2Service
    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login")]
    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#")]
    //    [AllowAnonymous]
    //    [HttpGet]
    //    public ActionResult Login(string returnUrl)
    //    {
    //        LoginModel loginModel = new LoginModel
    //        {
    //            ReturnUrl = returnUrl
    //        };

    //        //_logger.Info("In Login(get)");

    //        return View(loginModel);
    //    }


    //    POST: /Account/JCarrollOnlineV2Service
    //   [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login")]
    //   [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#")]
    //   [HttpPost]
    //   [AllowAnonymous]
    //   [ValidateAntiForgeryToken]
    //    //[OutputCache(NoStore = true, Location = OutputCacheLocation.None)]
    //    public async Task<ActionResult> Login(LoginModel model, string returnUrl)
    //    {
    //        //_logger.Info("In Login(post)");

    //        if (!ModelState.IsValid)
    //        {
    //            return View(model);
    //        }

    //        // This doesn't count login failures towards account lockout
    //        // To enable password failures to trigger account lockout, change to shouldLockout: true
    //        SignInStatus result = await _signInManager.PasswordSignInAsync(model?.UserName, model?.Password, model?.RememberMe, /*shouldLockout: false*/).ConfigureAwait(false);

    //        _logger.Info(string.Format(CultureInfo.InvariantCulture, "PasswordSignInAsync with UserName {0}, Password {1}, returned {2}", model?.UserName, model?.Password, result));

    //        switch (result)
    //        {
    //            case SignInStatus.Success:
    //                if (!await UserManager.IsEmailConfirmedAsync((await UserManager.FindByNameAsync(model.UserName).ConfigureAwait(false)).Id).ConfigureAwait(false))
    //                {
    //                    AuthenticationManager.SignOut();
    //                    ModelState.AddModelError("", "You need to confirm your email");
    //                    return View(model);
    //                }

    //                _logger.Info(string.Format(CultureInfo.InvariantCulture, "Redirecting to local {0}", returnUrl));

    //                return RedirectToLocal(returnUrl);
    //            case SignInStatus.LockedOut:
    //                return View("Lockout");
    //            case SignInStatus.RequiresVerification:
    //                return RedirectToAction("SendCode", routeValues: new { ReturnUrl = returnUrl, model.RememberMe });
    //            case SignInStatus.Failure:
    //            default:
    //                ModelState.AddModelError("", "Invalid login attempt.");
    //                return View(model);
    //        }
    //    }


    //    GET: /Account/VerifyCode
    //   [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#")]
    //   [AllowAnonymous]
    //   [HttpGet]
    //    public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
    //    {
    //        // Require that the user has already logged in via username/password or external login
    //        return !await SignInManager.HasBeenVerifiedAsync().ConfigureAwait(false)
    //            ? View("Error")
    //            : View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
    //    }

    //    //
    //    // POST: /Account/VerifyCode
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View(model);
    //        }

    //        // The following code protects for brute force attacks against the two factor codes. 
    //        // If a user enters incorrect codes for a specified amount of time then the user account 
    //        // will be locked out for a specified amount of time. 
    //        // You can configure the account lockout settings in IdentityConfig
    //        SignInStatus result = await SignInManager.TwoFactorSignInAsync(model?.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser).ConfigureAwait(false);
    //        switch (result)
    //        {
    //            case SignInStatus.Success:
    //                return RedirectToLocal(model.ReturnUrl);
    //            case SignInStatus.LockedOut:
    //                return View("Lockout");
    //            case SignInStatus.Failure:
    //            default:
    //                ModelState.AddModelError("", "Invalid code.");
    //                return View(model);
    //        }
    //    }


    //    GET: /Account/Register
    //   [AllowAnonymous]
    //   [HttpGet]
    //    public ActionResult Register()
    //    {
    //        RegisterViewModel vm = new RegisterViewModel();

    //        return View(vm);
    //    }

    //    //
    //    // POST: /Account/Register
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> Register(RegisterViewModel model)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            ApplicationUser user = new ApplicationUser { UserName = model?.UserName, Email = model.Email };
    //            IdentityResult result = await UserManager.CreateAsync(user, model.Password).ConfigureAwait(false);

    //            if (result.Succeeded)
    //            {
    //                //await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

    //                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
    //                // Send an email with this link
    //                string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id).ConfigureAwait(false);
    //                Uri callbackUri = new Uri(Url.Action("ConfirmEmail", "Account", routeValues: new { userId = user.Id, code }, protocol: Request.Url.Scheme));

    //                //#if DEBUG
    //                //                    var cleanUrl = callbackUri;
    //                //#else
    //                //var cleanUrl = new Uri(callbackUri.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Port, UriFormat.UriEscaped));
    //                //#endif

    //                //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code });
    //                await SendWelcomeEmail(user, callbackUri).ConfigureAwait(false);
    //                ApplicationUserViewModel appplicationUserViewModel = new ApplicationUserViewModel();

    //                appplicationUserViewModel.InjectFrom(user);

    //                //await SendWelcomeEmail(auVM, cleanUrl);

    //                return RedirectToAction("RegistrationNotification", "Account");
    //            }

    //            AddErrors(result);
    //        }

    //        // If we got this far, something failed, redisplay form
    //        return View(model);
    //    }


    //    [AllowAnonymous]
    //    [HttpGet]
    //    public ActionResult RegistrationNotification()
    //    {
    //        RegistrationNotificationViewModel registrationNotificationViewModel = new RegistrationNotificationViewModel();

    //        return View(registrationNotificationViewModel);
    //    }

    //    private async Task SendWelcomeEmail(ApplicationUser user, Uri callbackUrl)
    //    {
    //        UserWelcomeViewModel userWelcomeViewModel = GenerateViewModel(user, callbackUrl);

    //        await SendEmail(userWelcomeViewModel).ConfigureAwait(false);
    //    }

    //    private static UserWelcomeViewModel GenerateViewModel(ApplicationUser user, Uri callbackUrl)
    //    {
    //        UserWelcomeViewModel userWelcomeViewModel = new UserWelcomeViewModel
    //        {
    //            TargetUser = user,
    //            CallbackUrl = callbackUrl
    //        };

    //        return userWelcomeViewModel;
    //    }

    //    private async Task SendEmail(UserWelcomeViewModel userWelcomeViewModel)
    //    {

    //        string templateFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmailTemplates");
    //        string templateFilePath = System.IO.Path.Combine(templateFolderPath, "UserWelcomePage.cshtml");

    //        // TODO: User RazorLight instead here, make the conversion
    //        //using (IRazorEngineService templateService = RazorEngineService.Create())
    //        //{

    //        //    userWelcomeViewModel.Content = templateService.RunCompile(System.IO.File.ReadAllText(templateFilePath), "userWelcomeTemplatekey", null, userWelcomeViewModel);

    //        //    await SendEmailAsync(userWelcomeViewModel).ConfigureAwait(false);
    //        //}
    //    }

    //    public async Task SendEmailAsync(UserWelcomeViewModel userWelcomeViewModel)
    //    {
    //        IdentityMessage email = new IdentityMessage()
    //        {
    //            Body = userWelcomeViewModel?.Content,
    //            Destination = userWelcomeViewModel.TargetUser.Email,
    //            Subject = "Welcome to JCarrollOnline"
    //        };

    //        await UserManager.EmailService.SendAsync(email).ConfigureAwait(false);
    //    }

    //    //
    //    // GET: /Account/ConfirmEmail
    //    [AllowAnonymous]
    //    [HttpGet]
    //    public async Task<ActionResult> ConfirmEmail(string userId, string code)
    //    {
    //        if (userId == null || code == null)
    //        {
    //            return View("Error");
    //        }

    //        LoginConfirmationViewModel loginConfirmationViewModel = new LoginConfirmationViewModel();
    //        IdentityResult result = await UserManager.ConfirmEmailAsync(userId, code).ConfigureAwait(false);

    //        return View(result.Succeeded ? "ConfirmEmail" : "Error", loginConfirmationViewModel);
    //    }

    //    //
    //    // GET: /Account/ForgotPassword
    //    [AllowAnonymous]
    //    [HttpGet]
    //    public ActionResult ForgotPassword()
    //    {
    //        ForgotPasswordViewModel forgotPasswordViewModel = new ForgotPasswordViewModel();

    //        return View(forgotPasswordViewModel);
    //    }

    //    //
    //    // POST: /Account/ForgotPassword
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            //var user = await UserManager.FindByNameAsync(model.Email);
    //            ApplicationUser user = await UserManager.FindByEmailAsync(model?.Email).ConfigureAwait(false);

    //            if (user == null || !await UserManager.IsEmailConfirmedAsync(user.Id).ConfigureAwait(false))
    //            {
    //                ForgotPasswordConfirmationViewModel forgotPasswordConfirmationViewModel = new ForgotPasswordConfirmationViewModel();

    //                // Don't reveal that the user does not exist or is not confirmed
    //                return View("ForgotPasswordConfirmation", forgotPasswordConfirmationViewModel);
    //            }

    //            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
    //            // Send an email with this link
    //            string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id).ConfigureAwait(false);
    //            string callbackUrl = Url.Action("ResetPassword", "Account", routeValues: new { userId = user.Id, code }, protocol: Request.Url.Scheme);
    //            await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>").ConfigureAwait(false);
    //            return RedirectToAction("ForgotPasswordConfirmation", "Account");
    //        }

    //        // If we got this far, something failed, redisplay form
    //        return View(model);
    //    }

    //    //
    //    // GET: /Account/ForgotPasswordConfirmation
    //    [AllowAnonymous]
    //    [HttpGet]
    //    public ActionResult ForgotPasswordConfirmation()
    //    {
    //        ForgotPasswordConfirmationViewModel forgotPasswordConfirmationViewModel = new ForgotPasswordConfirmationViewModel();

    //        return View(forgotPasswordConfirmationViewModel);
    //    }

    //    //
    //    // GET: /Account/ResetPassword
    //    [AllowAnonymous]
    //    [HttpGet]
    //    public ActionResult ResetPassword(string code)
    //    {
    //        ResetPasswordViewModel resetPasswordViewModel = new ResetPasswordViewModel();

    //        return code == null ? View("Error") : View(resetPasswordViewModel);
    //    }

    //    //
    //    // POST: /Account/ResetPassword
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View(model);
    //        }
    //        ApplicationUser user = await UserManager.FindByEmailAsync(model?.Email).ConfigureAwait(false);
    //        if (user == null)
    //        {
    //            // Don't reveal that the user does not exist
    //            return RedirectToAction("ResetPasswordConfirmation", "Account");
    //        }
    //        IdentityResult result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password).ConfigureAwait(false);
    //        if (result.Succeeded)
    //        {
    //            return RedirectToAction("ResetPasswordConfirmation", "Account");
    //        }
    //        AddErrors(result);
    //        return View();
    //    }

    //    //
    //    // GET: /Account/ResetPasswordConfirmation
    //    [AllowAnonymous]
    //    [HttpGet]
    //    public ActionResult ResetPasswordConfirmation()
    //    {
    //        ResetPasswordConfirmationViewModel resetPasswordConfirmationViewModel = new ResetPasswordConfirmationViewModel();

    //        return View(resetPasswordConfirmationViewModel);
    //    }

    //    //
    //    // POST: /Account/ExternalLogin
    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login")]
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult ExternalLogin(string provider, string returnUrl)
    //    {
    //        // Request a redirect to the external login provider
    //        return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
    //    }

    //    //
    //    // GET: /Account/SendCode
    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#")]
    //    [AllowAnonymous]
    //    [HttpGet]
    //    public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
    //    {
    //        string userId = await SignInManager.GetVerifiedUserIdAsync().ConfigureAwait(false);
    //        if (userId == null)
    //        {
    //            return View("Error");
    //        }
    //        System.Collections.Generic.IList<string> userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId).ConfigureAwait(false);
    //        System.Collections.Generic.List<SelectListItem> factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
    //        return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
    //    }

    //    //
    //    // POST: /Account/SendCode
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> SendCode(SendCodeViewModel model)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View();
    //        }

    //        // Generate the token and send it
    //        return !await SignInManager.SendTwoFactorCodeAsync(model?.SelectedProvider).ConfigureAwait(false)
    //            ? View("Error")
    //            : (ActionResult)RedirectToAction("VerifyCode", routeValues: new { Provider = model.SelectedProvider, model.ReturnUrl, model.RememberMe });
    //    }

    //    //
    //    // GET: /Account/ExternalLoginCallback
    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login")]
    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#")]
    //    [AllowAnonymous]
    //    [HttpGet]
    //    public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
    //    {
    //        ExternalLoginInfo loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync().ConfigureAwait(false);
    //        if (loginInfo == null)
    //        {
    //            return RedirectToAction("JCarrollOnlineV2Service");
    //        }

    //        // Sign in the user with this external login provider if the user already has a login
    //        SignInStatus result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false).ConfigureAwait(false);
    //        switch (result)
    //        {
    //            case SignInStatus.Success:
    //                return RedirectToLocal(returnUrl);
    //            case SignInStatus.LockedOut:
    //                return View("Lockout");
    //            case SignInStatus.RequiresVerification:
    //                return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
    //            case SignInStatus.Failure:
    //            default:
    //                // If the user does not have an account, then prompt the user to create an account
    //                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
    //        }
    //    }

    //    //
    //    // POST: /Account/ExternalLoginConfirmation
    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login")]
    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#")]
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
    //    {
    //        if (User.Identity.IsAuthenticated)
    //        {
    //            return RedirectToAction("Index", "Manage");
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            // Get the information about the user from the external login provider
    //            ExternalLoginInfo info = await AuthenticationManager.GetExternalLoginInfoAsync().ConfigureAwait(false);
    //            if (info == null)
    //            {
    //                return View("ExternalLoginFailure");
    //            }
    //            ApplicationUser user = new ApplicationUser { UserName = model?.SiteUserName, Email = model.Email };
    //            IdentityResult result = await UserManager.CreateAsync(user).ConfigureAwait(false);
    //            if (result.Succeeded)
    //            {
    //                result = await UserManager.AddLoginAsync(user.Id, info.Login).ConfigureAwait(false);
    //                if (result.Succeeded)
    //                {
    //                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false).ConfigureAwait(false);
    //                    return RedirectToLocal(returnUrl);
    //                }
    //            }
    //            AddErrors(result);
    //        }

    //        if (model != null)
    //        {
    //            model.ReturnUrl = returnUrl;
    //        }
    //        return View(model);
    //    }

    //    //
    //    // POST: /Account/LogOff
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult LogOff()
    //    {
    //        AuthenticationManager.SignOut();
    //        return RedirectToAction("Index", "Home");
    //    }

    //    //
    //    // GET: /Account/ExternalLoginFailure
    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login")]
    //    [AllowAnonymous]
    //    [HttpGet]
    //    public ActionResult ExternalLoginFailure()
    //    {
    //        return View();
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            if (_userManager != null)
    //            {
    //                _userManager.Dispose();
    //                _userManager = null;
    //            }

    //            if (_signInManager != null)
    //            {
    //                _signInManager.Dispose();
    //                _signInManager = null;
    //            }
    //        }

    //        base.Dispose(disposing);
    //    }

    //    #region Helpers
    //    Used for XSRF protection when adding external logins
    //    private const string _xsrfKey = "XsrfId";

    //    private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

    //    private void AddErrors(IdentityResult result)
    //    {
    //        foreach (string error in result.Errors)
    //        {
    //            ModelState.AddModelError("", error);
    //        }
    //    }

    //    private ActionResult RedirectToLocal(string returnUrl)
    //    {
    //        return Url.IsLocalUrl(returnUrl) ? Redirect(returnUrl) : (ActionResult)RedirectToAction("Index", "Home");
    //    }

    //    internal class ChallengeResult : HttpUnauthorizedResult
    //    {
    //        public ChallengeResult(string provider, string redirectUri)
    //            : this(provider, redirectUri, null)
    //        {
    //        }

    //        public ChallengeResult(string provider, string redirectUri, string userId)
    //        {
    //            LoginProvider = provider;
    //            RedirectUri = redirectUri;
    //            UserId = userId;
    //        }

    //        public string LoginProvider { get; set; }
    //        public string RedirectUri { get; set; }
    //        public string UserId { get; set; }

    //        public override void ExecuteResult(ControllerContext context)
    //        {
    //            if (context == null)
    //            {
    //                throw new ArgumentNullException(nameof(context));
    //            }

    //            AuthenticationProperties properties = new AuthenticationProperties { RedirectUri = RedirectUri };

    //            if (UserId != null)
    //            {
    //                properties.Dictionary[_xsrfKey] = UserId;
    //            }

    //            context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
    //        }
    //    }
    //    #endregion
    //}
}