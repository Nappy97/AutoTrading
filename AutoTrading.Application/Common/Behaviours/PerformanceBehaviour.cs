using System.Diagnostics;
using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.Common.Behaviours;

public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly Stopwatch _timer;
    private readonly ILogger<TRequest> _logger;
    private readonly IUser _user;
    private readonly IIdentityService _identityService;

    public PerformanceBehaviour(ILogger<TRequest> logger, IUser user, IIdentityService identityService)
    {
        _timer = new Stopwatch();
        _logger = logger;
        _user = user;
        _identityService = identityService;
    }


    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds > 500 && _user.HasAuthenticated)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _user.Id;
            var userName = string.Empty;

            if (userId is not 0)
                userName = await _identityService.GetUserNameAsync(userId);

            _logger.LogWarning("AutoTrading Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}",
                requestName, elapsedMilliseconds, userId, userName, request);
        }

        return response;
    }
}