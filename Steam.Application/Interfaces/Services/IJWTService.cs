using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Services;

public interface IJWTService
{
    string GenerateAccessToken(User user);
    RefreshToken CreateRefreshToken(Guid userId);
}