using Microsoft.AspNetCore.Components;

namespace AutoTrading.Client.Layout;

public partial class NavMenu : IDisposable
{
    [Inject]
    private IEnumerable<string> CategoryService { get; set; } = default!;

    private bool _collapseNavMenu = true;

    private string? NavMenuCssClass => _collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        _collapseNavMenu = !_collapseNavMenu;
    }

    protected override async Task OnInitializedAsync()
    {
        //await
        CategoryService = new[]
        {
            "a", "b", "c"
        };
    }

    public void Dispose()
    {
    }
}