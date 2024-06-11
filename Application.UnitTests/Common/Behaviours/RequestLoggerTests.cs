using AutoTrading.Application.Accounts.Commands.CreateAccount;
using AutoTrading.Application.Common.Behaviours;
using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Shared.Generated;
using Microsoft.Extensions.Logging;
using Moq;

namespace Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    private Mock<ILogger<CreateAccountCommand>> _logger = null!;
    private Mock<IUser> _user = null!;
    private Mock<IIdentityService> _identityService = null!;

    [SetUp]
    public void Setup()
    {
        _logger = new Mock<ILogger<CreateAccountCommand>>();
        _user = new Mock<IUser>();
        _identityService = new Mock<IIdentityService>();
    }
    
    [Test]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _user.Setup(x => x.Id).Returns(1L);

        var requestLogger = new LoggingBehaviour<CreateAccountCommand>(_logger.Object, _user.Object, _identityService.Object);

        await requestLogger.Process(new CreateAccountCommand { AccountNumber = "test", UserId = 1L, AccountTypeCode = C._14_위탁계좌, StockFirmCode = C._13_한국투자증권}, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<long>()), Times.Once);
    }

    [Test]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        var requestLogger = new LoggingBehaviour<CreateAccountCommand>(_logger.Object, _user.Object, _identityService.Object);

        await requestLogger.Process(new CreateAccountCommand { AccountNumber = "test", UserId = 1L, AccountTypeCode = C._14_위탁계좌, StockFirmCode = C._13_한국투자증권 }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<long>()), Times.Never);
    }
}