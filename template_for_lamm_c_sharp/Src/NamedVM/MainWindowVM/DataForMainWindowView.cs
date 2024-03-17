using library_architecture_mvvm_modify_c_sharp;

namespace template_for_lamm_c_sharp;

public sealed class DataForMainWindowView(bool isLoading) : BaseDataForNamed<EnumDataForMainWindowView>(isLoading)
{
    public override EnumDataForMainWindowView GetEnumDataForNamed()
    {
        if(isLoading) 
        {
            return EnumDataForMainWindowView.isLoading;
        }
        if(exceptionController.IsWhereNotEqualsNullParameterException()) 
        {
            return EnumDataForMainWindowView.exception;
        }
        return EnumDataForMainWindowView.success;
    }
}
