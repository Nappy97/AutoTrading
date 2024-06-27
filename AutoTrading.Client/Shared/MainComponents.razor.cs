using AutoTrading.Application.Promotions.Queries.GetMainPromotion;
using AutoTrading.Client.Common;
using AutoTrading.Client.Services.Promotion;
using Microsoft.AspNetCore.Components;

namespace AutoTrading.Client.Shared;

public partial class MainComponents : IDisposable
{
    [Inject]
    private IPromotionService PromotionService { get; set; } = default!;

    private RestResult<List<PromotionBriefDto>> _restResult = default!;

    protected override async Task OnInitializedAsync()
    {
        _restResult = await PromotionService.GetPromotions();
    }

    public void Dispose()
    {
        // TODO release managed resources here
    }
}