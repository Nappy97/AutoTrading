using AutoTrading.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly IUser _user;
    private readonly IIdentityService _identityService;

    public LoggingBehaviour(ILogger<TRequest> logger, IUser user, IIdentityService identityService)
    {
        _logger = logger;
        _user = user;
        _identityService = identityService;
    }
    
    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _user.Id;
        var userName = string.Empty;

        if (userId != 0)
            userName = await _identityService.GetUserNameAsync(userId);
        
        _logger.LogInformation("AutoTrading Request: {Name} {@UserId} {@UserName} {@Request}",
            requestName, userId, userName, request);
    }
}