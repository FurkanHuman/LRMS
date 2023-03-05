﻿using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.RefreshTokenService;
using Application.Services.UserService;
using Core.Domain.Concrete.Security.Entities;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.RefreshTokenCommand;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshedTokensDto>
{
    private readonly IAuthService _authService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IUserService _userService;
    private readonly AuthBusinessRules _authBusinessRules;

    public RefreshTokenCommandHandler(IAuthService authService, IRefreshTokenService refreshTokenService, IUserService userService, AuthBusinessRules authBusinessRules)
    {
        _authService = authService;
        _refreshTokenService = refreshTokenService;
        _userService = userService;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<RefreshedTokensDto> Handle(RefreshTokenCommand request,
                                                 CancellationToken cancellationToken)
    {
        RefreshToken? refreshToken = _refreshTokenService.GetRefreshTokenByToken(request.RefleshToken);
        await _authBusinessRules.RefreshTokenShouldBeExists(refreshToken);

        if (refreshToken.Revoked != null)
            _refreshTokenService.RevokeDescendantRefreshTokens(refreshToken, request.IPAddress,
                                                             $"Attempted reuse of revoked ancestor token: {refreshToken.Token}");
        await _authBusinessRules.RefreshTokenShouldBeActive(refreshToken);

        User user = _userService.GetById(refreshToken.UserId);

        RefreshToken newRefreshToken = await _refreshTokenService.RotateRefreshToken(user, refreshToken, request.IPAddress);
        RefreshToken addedRefreshToken = _refreshTokenService.AddRefreshToken(newRefreshToken);

        _refreshTokenService.DeleteOldRefreshTokens(refreshToken.UserId);

        AccessToken createdAccessToken = _authService.CreateAccessToken(user);

        RefreshedTokensDto refreshedTokensDto = new()
        { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
        return refreshedTokensDto;
    }
}
