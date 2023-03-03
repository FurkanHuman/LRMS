﻿using Core.Domain.Concrete.Security.Entities;
using Core.Domain.Concrete.Security.Enums;
using Core.Security.JWT;

namespace Application.Features.Auths.Dtos;

public class LoggedDto
{
    public AccessToken? AccessToken { get; set; }
    public RefreshToken? RefreshToken { get; set; }
    public AuthenticatorType? RequiredAuthenticatorType { get; set; }

}