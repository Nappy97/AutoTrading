using AutoTrading.Application.Accounts.Commands.CreateAccount;
using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework.Internal;

namespace Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    private Mock<ILogger<CreateAccountCommand>> _logger = null!;
    private Mock<User> _user = null!;
    private Mock<IIdentityService> _identityService = null!;
}