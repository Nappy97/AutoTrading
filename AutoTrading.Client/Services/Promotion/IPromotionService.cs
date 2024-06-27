using AutoTrading.Application.Promotions.Commands.CreatePromotion;
using AutoTrading.Application.Promotions.Commands.DeletePromotion;
using AutoTrading.Application.Promotions.Commands.UpdatePromotion;
using AutoTrading.Application.Promotions.Queries.GetMainPromotion;
using AutoTrading.Client.Common;

namespace AutoTrading.Client.Services.Promotion;

public interface IPromotionService
{
    public Task<RestResult<List<PromotionBriefDto>>> GetPromotions();

    public Task<RestResult<long>> CreatePromotion(CreatePromotionCommand command);

    public Task<RestResult<long>> UpdatePromotion(long id, UpdatePromotionCommand command);

    public Task<RestResult<bool>> DeletePromotion(long id, DeletePromotionCommand command);
}