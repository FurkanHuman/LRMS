using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.RefreshTokenService;
using AutoMapper;
using Core.Domain.Concrete.Security.Entities;
using MediatR;

namespace Application.Features.Auths.Commands.RevokeToken;

public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand, RevokedTokenResponse>
{
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IMapper _mapper;

    public RevokeTokenCommandHandler(IRefreshTokenService refreshTokenService, AuthBusinessRules authBusinessRules, IMapper mapper)
    {
        _refreshTokenService = refreshTokenService;
        _authBusinessRules = authBusinessRules;
        _mapper = mapper;
    }

    public async Task<RevokedTokenResponse> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
    {
        RefreshToken? refreshToken = _refreshTokenService.GetRefreshTokenByToken(request.Token);
        await _authBusinessRules.RefreshTokenShouldBeExists(refreshToken);
        await _authBusinessRules.RefreshTokenShouldBeActive(refreshToken);

        _refreshTokenService.RevokeRefreshToken(refreshToken, request.IPAddress, "Revoked without replacement");

        RevokedTokenResponse revokedTokenDto = _mapper.Map<RevokedTokenResponse>(refreshToken);
        return revokedTokenDto;
    }
}
