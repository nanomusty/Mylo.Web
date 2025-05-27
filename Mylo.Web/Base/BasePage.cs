using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace Mylo.Web.Base
{
    public class BasePage
    {
        [Inject] public IJSRuntime IJSRuntime { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public IDialogService DialogService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        public BasePage(NavigationManager navigationManager, IJSRuntime jSRuntime,
            ISnackbar snackbar, IDialogService iDialogService)
        {
            NavigationManager = navigationManager;
            IJSRuntime = jSRuntime;
            Snackbar = snackbar;
            DialogService = iDialogService;
        }
    }
}
