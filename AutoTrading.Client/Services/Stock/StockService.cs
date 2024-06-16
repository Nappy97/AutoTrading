using AutoTrading.Application.Common.Models;
using AutoTrading.Application.Stocks.Queries.GetStocksWithPagination;
using AutoTrading.Client.Common;
using AutoTrading.Shared.Constants;

namespace AutoTrading.Client.Services.Stock;

public class StockService : IStockService
{
    private readonly IRestClient _client;

    public StockService(IRestClient client)
    {
        _client = client;
    }

    public async Task<RestResult<PaginatedList<StockBriefDto>>> GetStocksWithPagination(
        GetStocksWithPaginationQuery query)
    {
        return await _client.GetAsync<GetStocksWithPaginationQuery, PaginatedList<StockBriefDto>>(
            $"{ApiOptions.Stocks}", query);
    }
}