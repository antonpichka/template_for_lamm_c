using library_architecture_mvvm_modify_c_sharp;

namespace template_for_lamm_c_sharp;

public sealed class MainWindowViewModel : BaseNamedViewModel<DataForMainWindowView, EnumDataForMainWindowView, DefaultStreamWState<DataForMainWindowView, EnumDataForMainWindowView>>, IMainWindowViewModel
{
    // OperationEEModel(EEWhereNamed)[EEFromNamed]EEParameterNamedService
    // NamedUtility

    public MainWindowViewModel() : base(new DefaultStreamWState<DataForMainWindowView,EnumDataForMainWindowView>(new DataForMainWindowView(true)))
    {
    }

    public override async Task<string> Init()
    {
        await Task.Delay(1);
        GetDataForNamedParameterNamedStreamWState().isLoading = false;
        return KeysSuccessUtility.sUCCESS;
    }
}
