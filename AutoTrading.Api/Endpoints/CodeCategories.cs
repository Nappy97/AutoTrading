using AutoTrading.Application.CodeCategories.Commands.CreateCodeCategory;
using AutoTrading.Application.CodeCategories.Commands.DeleteCodeCategory;
using AutoTrading.Application.CodeCategories.Commands.UpdateCodeCategory;
using AutoTrading.Application.CodeCategories.Queries.GetCodes;

namespace AutoTrading.Api.Endpoints;

public class CodeCategories : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetCodeLists)
            .MapPost(CreateCodeCategory)
            .MapPut(UpdateCodeCategory, "{id}")
            .MapDelete(DeleteCodeCategory, "{id}");
    }

    private Task<CodesVm> GetCodeLists(ISender sender)
    {
        return sender.Send(new GetCodesQuery());
    }

    private Task<long> CreateCodeCategory(ISender sender, CreateCodeCategoryCommand command)
    {
        return sender.Send(command);
    }

    private async Task<IResult> UpdateCodeCategory(ISender sender, UpdateCodeCategoryCommand command, long id)
    {
        if (id != command.Id)
            return Results.BadRequest();

        await sender.Send(command);
        return Results.NoContent();
    }

    private async Task<IResult> DeleteCodeCategory(ISender sender, long id)
    {
        await sender.Send(new DeleteCodeCategoryCommand(id));
        return Results.NoContent();
    }
}