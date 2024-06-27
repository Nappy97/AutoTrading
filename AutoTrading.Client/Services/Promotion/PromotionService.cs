using AutoTrading.Application.Promotions.Commands.CreatePromotion;
using AutoTrading.Application.Promotions.Commands.DeletePromotion;
using AutoTrading.Application.Promotions.Commands.UpdatePromotion;
using AutoTrading.Application.Promotions.Queries.GetMainPromotion;
using AutoTrading.Client.Common;
using AutoTrading.Shared.Extensions;

namespace AutoTrading.Client.Services.Promotion;

public class PromotionService : IPromotionService
{
    private readonly IRestClient _client;
    
    private const string BaseUri = "api/Promotions/";

    public PromotionService(IRestClient client)
    {
        _client = client;
    }
    
    public async Task<RestResult<List<PromotionBriefDto>>> GetPromotions()
    {
        return await _client.GetAsync<List<PromotionBriefDto>>($"{BaseUri}{nameof(GetPromotions)}");
    }

    public async Task<RestResult<long>> CreatePromotion(CreatePromotionCommand command)
    {
        return await _client.PostAsync<CreatePromotionCommand, long>($"{BaseUri}{nameof(CreatePromotion)}", command);
    }

    public async Task<RestResult<long>> UpdatePromotion(long id, UpdatePromotionCommand command)
    {
        return await _client.PutAsync<UpdatePromotionCommand, long>($"{BaseUri}{nameof(UpdatePromotion)}/{id}", command);
    }

    public async Task<RestResult<bool>> DeletePromotion(long id, DeletePromotionCommand command)
    {
        return await _client.DeleteAsync<bool>($"{BaseUri}{nameof(DeletePromotion)}/{id}");
    }
}