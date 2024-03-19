using System.Windows;
using library_architecture_mvvm_modify_c_sharp;

namespace template_for_lamm_c_sharp;

public sealed class MainWindowView : Window
{
    /// RELEASE CODE
    // private readonly MainWindowViewModel viewModel;
    /// TEST CODE
    private readonly TestMainWindowViewModel viewModel;

    public MainWindowView()
    {
        /// RELEASE CODE
        // viewModel = new MainWindowViewModel();
        /// TEST CODE
        viewModel = new TestMainWindowViewModel();
        InitParameterViewModel();
    }
    
    public void DisposeParameterViewModel() 
    {
        viewModel.Dispose();
    }

    private async void InitParameterViewModel() 
    {
        viewModel.ListenStreamDataForNamedFromCallbackParameterNamedStreamWState((data) =>
        {
            BuildParameterViewModel();
        });
        var result = await viewModel.Init();
        Utility.DebugPrint($"MainWindowView: {result}");
        viewModel.NotifyStreamDataForNamedParameterNamedStreamWState();
    }
    
    private void BuildParameterViewModel() 
    {
        new LocalException(this,EnumGuilty.developer,"qww");
        new LocalException(this,EnumGuilty.developer,"qww");
        new LocalException(this,EnumGuilty.developer,"qww");
        new LocalException(this,EnumGuilty.developer,"qww");
        new LocalException(this,EnumGuilty.developer,"qww");
        new LocalException(this,EnumGuilty.developer,"qww");
        new LocalException(this,EnumGuilty.developer,"qww");
        new LocalException(this,EnumGuilty.developer,"qww");
        new LocalException(this,EnumGuilty.developer,"qww");
        new LocalException(this,EnumGuilty.developer,"qww");
        new LocalException(this,EnumGuilty.developer,"qww");
        var dataForNamedParameterNamedStreamWState = viewModel.GetDataForNamedParameterNamedStreamWState();
        switch(dataForNamedParameterNamedStreamWState.GetEnumDataForNamed()) 
        {
            case EnumDataForMainWindowView.isLoading:
                Utility.DebugPrint("Build: IsLoading");
                break;
            case EnumDataForMainWindowView.exception:
                Utility.DebugPrint($"Build: Exception({dataForNamedParameterNamedStreamWState.exceptionController.GetKeyParameterException()})");
                break;
            case EnumDataForMainWindowView.success:
                Utility.DebugPrint($"Build: Success({dataForNamedParameterNamedStreamWState.isLoading})");
                break;
            default:
                break;            
        }
    }
}