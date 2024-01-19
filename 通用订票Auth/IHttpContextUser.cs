﻿using System.Security.Claims;

namespace Core.Auth
{
    public interface IHttpContextUser
    {
        string TenantId { get; }
        string Name { get; }
        string ID { get; }
        string RealTenantId { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
        List<string> GetClaimValueByType(string ClaimType);

        string GetToken();
        List<string> GetUserInfoFromToken(string ClaimType);
    }
}