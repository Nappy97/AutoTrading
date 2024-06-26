using AutoTrading.Client.Services.Stock;
using Microsoft.AspNetCore.Components;

namespace AutoTrading.Client.Layout;

public partial class AutoTradingNavMenu
{
    private bool _collapseNavMenu = true;

    private string? NavMenuCssClass => _collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        _collapseNavMenu = !_collapseNavMenu;
    }

    /*protected override async Task OnInitializedAsync()
    {
        await StockService.GetStocksWithPagination();
    }

    public void Dispose()
    {
    }*/
}