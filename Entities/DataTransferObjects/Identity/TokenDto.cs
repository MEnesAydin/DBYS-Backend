﻿namespace Entities.DataTransferObjects.Identity;

public record TokenDto
{
    public String AccessToken { get; init; }
    public String RefreshToken { get; init; }
}