using AutoTrading.Application.Common.Exceptions;
using AutoTrading.Application.Stocks.Commands.CreateStock;
using AutoTrading.Domain.Entities;
using AutoTrading.Shared.Generated;

namespace Application.FunctionalTests.Stocks.Commands;

using static Testing;

public class CreateStockTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateStockCommand();
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldRequireUniqueTitle()
    {
        await SendAsync(new CreateStockCommand
        {
            Name = "정의형주",
            StockCode = "0123",
            NationalityCode = C._11_국내,
            LocationCode = C._12_코스피
        });

        var command = new CreateStockCommand
        {
            Name = "정의형주",
            StockCode = "0123",
            NationalityCode = C._11_국내,
            LocationCode = C._12_코스피
        };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().NotThrowAsync();
    }

    [Test]
    public async Task ShouldCreateStock()
    {
        var userId = await RunAsDefaultUserAsync();
        
        var command = new CreateStockCommand
        {
            Name = "정의형주",
            StockCode = "0123",
            NationalityCode = C._11_국내,
            LocationCode = C._12_코스피
        };

        var id = await SendAsync(command);

        var stock = await FindAsync<Stock>(id);

        stock.Should().NotBeNull();
        stock!.Name.Should().Be(command.Name);
        stock!.StockCode.Should().Be(command.StockCode);
        stock!.NationalityCode.Should().Be(command.NationalityCode);
        stock!.LocationCode.Should().Be(command.LocationCode);
    }
}