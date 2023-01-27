﻿using Core.Domain.Concrete.Security.Entities;
using Core.Security.JWT;

namespace Application.Features.Auths.Dtos;

public class RefreshedTokensDto
{
    public AccessToken AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
}