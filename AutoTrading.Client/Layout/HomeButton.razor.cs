using Microsoft.AspNetCore.Components;

namespace AutoTrading.Client.Layout;

public partial class HomeButton
{
    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    private void GoToHome()
    {
        NavigationManager.NavigateTo(string.Empty);
    }
}