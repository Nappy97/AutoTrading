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

    public AuthorizationBehaviour(IUser user)
    {
        _user = user;
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
                    if (roles.Select(role => _user.Roles.Any(x => x.Equals(role))).Any(isInRole => isInRole))
                        authorized = true;
                }

                // Must be a member of at least one role in roles
                if (!authorized)
                    throw new ForbiddenAccessException();
            }

            // Action(policies)-based authorization
            var authorizeAttributesWithPolicies = authorizeAttributes.Where(a => a.Actions is not []);
            if (authorizeAttributesWithPolicies.Any())
            {
                if (authorizeAttributesWithPolicies.Select(a => a.Actions).Any(actions =>
                        actions.Select(action => _user.Actions.Any(x => x.Equals(action)))
                            .Any(isInActionRole => !isInActionRole)))
                    throw new ForbiddenAccessException();
            }
        }

        // User is authorized / authorization not required
        return await next();
    }
}