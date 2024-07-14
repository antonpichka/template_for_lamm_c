using library_architecture_mvvm_modify_c_sharp;

namespace windows_template_for_lamm_c_sharp;

public static class FactoryObjectUtility
{
    /* ModelRepository */
    public static ExampleRepository<Example,ListExample<Example>> GetExampleRepositoryFromEnumRWTMode(EnumRWTMode enumRWTMode) {
        return new ExampleRepository<Example,ListExample<Example>>(enumRWTMode);
    }

    /* NamedStreamWState */
    public static BaseNamedStreamWState<DataForExampleWindowVM, EnumDataForExampleWindowVM> GetNamedStreamWStateWhereDataWExampleWindowVM() {
        return new DefaultStreamWState<DataForExampleWindowVM,EnumDataForExampleWindowVM>(new DataForExampleWindowVM(true));
    }

    public static BaseNamedStreamWState<DataForMainWindowVM, EnumDataForMainWindowVM> GetNamedStreamWStateWhereDataWMainWindowVM() {
        return new DefaultStreamWState<DataForMainWindowVM,EnumDataForMainWindowVM>(new DataForMainWindowVM(true));
    }
}