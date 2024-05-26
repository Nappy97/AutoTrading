using AutoTrading.Application.Codes.Commands.CreateCode;
using AutoTrading.Application.Codes.Commands.DeleteCode;
using AutoTrading.Application.Codes.Commands.UpdateCode;
using AutoTrading.Application.Codes.Queries.GetCodesWithPagination;
using AutoTrading.Application.Common.Models;

namespace AutoTrading.Api.Endpoints;

public class Codes : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetCodesWithPagination)
            .MapPost(CreateCode)
            .MapPut(UpdateCode, "{id}")
            .MapDelete(DeleteCode, "{id}");
    }

    private Task<PaginatedList<CodeBriefDto>> GetCodesWithPagination(ISender sender,
        [AsParameters] GetCodesWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    private Task<int> CreateCode(ISender sender, CreateCodeCommand command)
    {
        return sender.Send(command);
    }

    private async Task<IResult> UpdateCode(ISender sender, long id, UpdateCodeCommand command)
    {
        if (id != command.CodeId)
            return Results.BadRequest();

        await sender.Send(command);
        return Results.NoContent();
    }

    private async Task<IResult> DeleteCode(ISender sender, int id)
    {
        await sender.Send(new DeleteCodeCommand(id));
        return Results.NoContent();
    }
}