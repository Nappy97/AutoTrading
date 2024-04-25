using AutoTrading.Application.Common.Models;
using AutoTrading.Application.Stocks.Commands.CreateStock;
using AutoTrading.Application.Stocks.Commands.DeleteStock;
using AutoTrading.Application.Stocks.Commands.UpdateStock;
using AutoTrading.Application.Stocks.Queries.GetStocksWithPagination;

namespace AutoTrading.Api.Endpoints;

public class Stocks : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetStocksWithPagination)
            .MapPost(CreateStock)
            .MapPut(UpdateStock, "{id}")
            .MapDelete(DeleteStock, "{id}");
    }

    private Task<PaginatedList<StockBriefDto>> GetStocksWithPagination(ISender sender,
        [AsParameters] GetStocksWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    private Task<long> CreateStock(ISender sender, CreateStockCommand command)
    {
        return sender.Send(command);
    }

    private async Task<IResult> UpdateStock(ISender sender, long id, UpdateStockCommand command)
    {
        if (id != command.Id)
            return Results.NotFound();

        await sender.Send(command);
        return Results.NoContent();
    }

    private async Task<IResult> DeleteStock(ISender sender, long id)
    {
        await sender.Send(new DeleteStockCommand(id));
        return Results.NoContent();
    }
}