using library_architecture_mvvm_modify_c_sharp;

namespace template_for_lamm_c_sharp;

public sealed class DataForAppView(bool isLoading) : BaseDataForNamed<EnumDataForAppView>(isLoading)
{
    public override EnumDataForAppView GetEnumDataForNamed()
    {
        if(isLoading) 
        {
            return EnumDataForAppView.isLoading;
        }
        if(exceptionController.IsWhereNotEqualsNullParameterException()) 
        {
            return EnumDataForAppView.exception;
        }
        return EnumDataForAppView.success;
    }
}
