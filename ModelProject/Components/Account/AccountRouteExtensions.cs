﻿using Microsoft.AspNetCore.Identity;
using ModelProject.Model;
using System.Security.Claims;

namespace ModelProject.Components.Account
{
    public static class AccountRouteExtensions
    {
        public static IEndpointConventionBuilder MapAdditionalAccountRoutes(this IEndpointRouteBuilder endpoints)
        {
            ArgumentNullException.ThrowIfNull(endpoints);

            var accountGroup = endpoints.MapGroup("/Account");

            accountGroup.MapGet("/Logout", async (
               ClaimsPrincipal user,
               SignInManager<Users> signInManager,
               string? returnUrl) =>
            {
                await signInManager.SignOutAsync();
                return TypedResults.LocalRedirect($"~/{returnUrl}");
            });


            return accountGroup;
        }
    }
}
