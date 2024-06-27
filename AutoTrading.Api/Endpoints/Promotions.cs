using AutoTrading.Application.Promotions.Commands.CreatePromotion;
using AutoTrading.Application.Promotions.Commands.DeletePromotion;
using AutoTrading.Application.Promotions.Commands.UpdatePromotion;
using AutoTrading.Application.Promotions.Queries.GetMainPromotion;

namespace AutoTrading.Api.Endpoints;

public class Promotions : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetPromotions)
            .MapPost(CreatePromotion)
            .MapPut(UpdatePromotion, "{id}")
            .MapDelete(DeletePromotion, "{id}");
    }

    private Task<List<PromotionBriefDto>> GetPromotions(ISender sender)
    {
        return sender.Send(new GetPromotionsQuery());
    }

    private Task<long> CreatePromotion(ISender sender, CreatePromotionCommand command)
    {
        return sender.Send(command);
    }

    private async Task<IResult> UpdatePromotion(ISender sender, long id, UpdatePromotionCommand command)
    {
        if (id != command.Id)
            return Results.BadRequest();

        await sender.Send(command);
        return Results.NoContent();
    }

    private async Task<IResult> DeletePromotion(ISender sender, int id)
    {
        await sender.Send(new DeletePromotionCommand(id));
        return Results.NoContent();
    }
}