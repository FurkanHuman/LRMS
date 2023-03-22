using Application.Features.Auths.Commands.EnableEmailAuthenticator;
using Application.Features.Auths.Commands.EnableOtpAuthenticator;
using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.RefleshToken;
using Application.Features.Auths.Commands.Register;
using Application.Features.Auths.Commands.RevokeToken;
using Application.Features.Auths.Commands.VerifyEmailAuthenticator;
using Application.Features.Auths.Commands.VerifyOtpAuthenticator;
using Core.Application.Dtos;
using Core.Domain.Concrete.Security.Entities;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly WebAPIConfiguration _configuration;
        
        public AuthsController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration.GetSection("WebAPIConfiguration").Get<WebAPIConfiguration>();
       }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new() { UserForLoginDto = userForLoginDto, IPAddress = GetIpAddress() };
            LoggedResponse result = await _mediator.Send(loginCommand);

            if (result.RefreshToken is not null) SetRefresTokenToCookie(result.RefreshToken);

            return Ok(result.CreateResponseDto());
        }

        [HttpPut("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto register)
        {
            RegisterCommand registerCommand = new() { UserForRegisterDto = register, IPAddress = GetIpAddress() };

            RegisteredResponse result = await _mediator.Send(registerCommand);

            SetRefresTokenToCookie(result.RefreshToken);

            return Created("", result.AccessToken);
        }

        [HttpGet("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            RefreshTokenCommand refreshTokenCommand = new()
            { RefleshToken = GetRefreshTokenFromCookies(), IPAddress = GetIpAddress() };
            RefreshedTokensResponse result = await _mediator.Send(refreshTokenCommand);
            SetRefresTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        [HttpPut("RevokeToken")]
        public async Task<IActionResult> RevokeToken([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] string? refreshToken)
        {
            RevokeTokenCommand revokeTokenCommand = new()
            {
                Token = refreshToken ?? GetRefreshTokenFromCookies(),
                IPAddress = GetIpAddress()
            };
            RevokedTokenResponse result = await _mediator.Send(revokeTokenCommand);
            return Ok(result);
        }

        [HttpGet("EnableEmailAuthenticator")]
        public async Task<IActionResult> EnableEmailAuthenticator()
        {
            EnableEmailAuthenticatorCommand enableEmailAuthenticatorCommand = new()
            {
                UserId = GetUserIdFromRequest(),
                VerifyEmailUrlPrefix = $"{_configuration.APIDomain}/Auth/VerifyEmailAuthenticator"
            };
            await _mediator.Send(enableEmailAuthenticatorCommand);

            return Ok();
        }

        [HttpGet("EnableOtpAuthenticator")]
        public async Task<IActionResult> EnableOtpAuthenticator()
        {
            EnableOtpAuthenticatorCommand enableOtpAuthenticatorCommand = new()
            {
                UserId = GetUserIdFromRequest()
            };
            EnabledOtpAuthenticatorResponse result = await _mediator.Send(enableOtpAuthenticatorCommand);

            return Ok(result);
        }

        [HttpGet("VerifyEmailAuthenticator")]
        public async Task<IActionResult> VerifyEmailAuthenticator(
            [FromQuery] VerifyEmailAuthenticatorCommand verifyEmailAuthenticatorCommand)
        {
            await _mediator.Send(verifyEmailAuthenticatorCommand);
            return Ok();
        }

        [HttpPost("VerifyOtpAuthenticator")]
        public async Task<IActionResult> VerifyOtpAuthenticator(
            [FromBody] string authenticatorCode)
        {
            VerifyOtpAuthenticatorCommand verifyEmailAuthenticatorCommand =
                new() { UserId = GetUserIdFromRequest(), ActivationCode = authenticatorCode };

            await _mediator.Send(verifyEmailAuthenticatorCommand);
            return Ok();
        }

        private string? GetRefreshTokenFromCookies()
        {
            return Request.Cookies["refreshToken"];
        }

        protected string? GetIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For")) return Request.Headers["X-Forwarded-For"];
            return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }

        protected Guid GetUserIdFromRequest() //todo authentication behavior?
        {
            Guid userId = HttpContext.User.GetUserId();
            return userId;
        }

        private void SetRefresTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
