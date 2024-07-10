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

        var attributes = authorizeAttributes as AuthorizeAttribute[] ?? authorizeAttributes.ToArray();
        if (attributes.Any())
        {
            // Must be authenticated user
            if (_user.Id is not 0)
                throw new UnauthorizedAccessException();

            // Role-based authorization
            var authorizeAttributesWithRoles = attributes.Where(a => a.Roles is not []);

            if (authorizeAttributesWithRoles.Any())
            {
                var authorized = false;

                foreach (var roles in authorizeAttributesWithRoles.Select(a => a.Roles))
                {
                    foreach (var role in roles)
                    {
                        var isInRole = _user.Roles.Any(x => x.Equals(role));
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

            // Action(policies)-based authorization
            var authorizeAttributesWithPolicies = attributes.Where(a => a.Actions is not []);
            var attributesWithPolicies = authorizeAttributesWithPolicies as AuthorizeAttribute[] ?? authorizeAttributesWithPolicies.ToArray();
            if (attributesWithPolicies.Any())
            {
                if (attributesWithPolicies.Select(a => a.Actions).Any(actions => actions.Select(action => _user.Actions.Any(x => x.Equals(action))).Any(isInActionRole => !isInActionRole)))
                {
                    throw new ForbiddenAccessException();
                }
            }
        }

        // User is authorized / authorization not required
        return await next();
    }
}