using AutoTrading.Application.Common.Models;
using AutoTrading.Application.Stocks.Queries.GetStocksWithPagination;
using AutoTrading.Client.Common;

namespace AutoTrading.Client.Services.Stock;

public interface IStockService
{
    Task<RestResult<PaginatedList<StockBriefDto>>> GetStocksWithPagination(GetStocksWithPaginationQuery query);
}