using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using library_architecture_mvvm_modify_c_sharp;

namespace template_for_lamm_c_sharp;

/// <summary>
/// Interaction logic for AppView.xaml
/// </summary>
public partial class AppView : Application
{
    /// RELEASE CODE
    // private readonly AppViewModel viewModel;
    /// TEST CODE
    private readonly TestAppViewModel viewModel;
    
    public AppView()
    {
        /// RELEASE CODE
        // viewModel = new AppViewModel();
        /// TEST CODE
        viewModel = new TestAppViewModel();
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
        Utility.DebugPrint($"AppView: {result}");
        viewModel.NotifyStreamDataForNamedParameterNamedStreamWState();
    }

    private void BuildParameterViewModel() 
    {
        var dataForNamedParameterNamedStreamWState = viewModel.GetDataForNamedParameterNamedStreamWState();
        switch(dataForNamedParameterNamedStreamWState.GetEnumDataForNamed()) 
        {
            case EnumDataForAppView.isLoading:
                Utility.DebugPrint("Build: IsLoading");
                break;
            case EnumDataForAppView.exception:
                Utility.DebugPrint($"Build: Exception({dataForNamedParameterNamedStreamWState.exceptionController.GetKeyParameterException()})");
                break;
            case EnumDataForAppView.success:
                Utility.DebugPrint($"Build: Success({dataForNamedParameterNamedStreamWState.isLoading})");
                break;
            default:
                break;            
        }
    }
}