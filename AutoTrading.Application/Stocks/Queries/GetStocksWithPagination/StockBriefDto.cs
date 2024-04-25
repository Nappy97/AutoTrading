using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Stocks.Queries.GetStocksWithPagination;

public class StockBriefDto
{
    public long Id { get; init; }

    public int NationalityCode { get; init; }

    public int LocationCode { get; init; }

    public bool Enabled { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Stock, StockBriefDto>();
            /*CreateMap<Book, BookReadOnlyDto>()
                .ForMember(q => q.AuthorName, 
                    d => d.MapFrom(
                        map => $"{map.Author.FirstName} {map.Author.LastName}"))
                .ReverseMap();*/
        }
    }
}