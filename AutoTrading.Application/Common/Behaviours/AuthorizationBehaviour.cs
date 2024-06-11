using System.Reflection;
using AutoTrading.Application.Common.Exceptions;
using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Common.Security;
using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Common.Behaviours;

public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IUser _user;
    private readonly IIdentityService _identityService;

    public AuthorizationBehaviour(IUser user, IIdentityService identityService)
    {
        _user = user;
        _identityService = identityService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

        if (authorizeAttributes.Any())
        {
            // Must be authenticated user
            if (_user.Id is not 0)
                throw new UnauthorizedAccessException();

            // Role-based authorization
            var authorizeAttributesWithRoles = authorizeAttributes.Where(a => a.Roles is not []);

            if (authorizeAttributesWithRoles.Any())
            {
                var authorized = false;

                foreach (var roles in authorizeAttributesWithRoles.Select(a => a.Roles))
                {
                    foreach (var role in roles)
                    {
                        var isInRole = await _identityService.IsInRoleAsync(_user.Id, role);
                        if (isInRole)
                        {
                            authorized = true;
                            break;
                        }
                    }
                }

                // Must be a member of at least one role in roles
                if (!authorized)
                {
                    throw new ForbiddenAccessException();
                }
            }

            // Policy-based authorization
            // TODO policy 는 추가예정
            // var authorizeAttributesWithPolicies = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Policy));
            // if (authorizeAttributesWithPolicies.Any())
            // {
            //     foreach (var policy in authorizeAttributesWithPolicies.Select(a => a.Policy))
            //     {
            //         var authorized = await _identityService.AuthorizeAsync(_user.Id, policy);
            //
            //         if (!authorized)
            //         {
            //             throw new ForbiddenAccessException();
            //         }
            //     }
            // }
        }

        // User is authorized / authorization not required
        return await next();
    }
}