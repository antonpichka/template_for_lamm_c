using library_architecture_mvvm_modify_c_sharp;

namespace template_for_lamm_c_sharp;

public sealed class TestAppViewModel : BaseNamedViewModel<DataForAppView, EnumDataForAppView, DefaultStreamWState<DataForAppView, EnumDataForAppView>>, IAppViewModel
{
    // OperationEEModel(EEWhereNamed)[EEFromNamed]EEParameterNamedService
    // NamedUtility
    
    public TestAppViewModel() : base(new DefaultStreamWState<DataForAppView,EnumDataForAppView>(new DataForAppView(true)))
    {
    }

    public override async Task<string> Init()
    {
        await Task.Delay(1);
        GetDataForNamedParameterNamedStreamWState().isLoading = false;
        return KeysSuccessUtility.sUCCESS;
    }
}
