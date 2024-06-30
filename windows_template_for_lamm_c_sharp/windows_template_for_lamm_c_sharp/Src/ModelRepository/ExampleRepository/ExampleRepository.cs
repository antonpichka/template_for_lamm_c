using library_architecture_mvvm_modify_c_sharp;

namespace windows_template_for_lamm_c_sharp;

public class ExampleRepository<T, Y> : BaseModelRepository<T, Y> where T : Example where Y : ListExample<T>
{
    protected Func<Task<Result<T>>> getExampleParameterOneWReleaseCallback;
    protected Func<Task<Result<T>>> getExampleParameterOneWTestCallback;

    public ExampleRepository(EnumRWTMode enumRWTModeFirst)
    {
        enumRWTMode = enumRWTModeFirst;
        getExampleParameterOneWReleaseCallback = () =>
        {
            throw new Exception();
        };
        getExampleParameterOneWTestCallback = () =>
        {
            throw new Exception();
        };
    }

    protected override T GetBaseModelFromMapAndListKeys(Dictionary<string, dynamic> map, List<string> listKeys)
    {
        return (new Example(
            GetSafeValueWhereUsedInMethodGetModelFromMapAndListKeysAndIndexAndDefaultValue(map,listKeys,0,"")) as T)!;
    }

    protected override Y GetBaseListModelFromListModel(List<T> listModel)
    {
        return (new ListExample<T>(listModel) as Y)!;
    }

    public Task<Result<T>> GetExampleParameterOne() 
    {
        return GetModeCallbackFromReleaseCallbackAndTestCallbackParameterEnumRWTMode(getExampleParameterOneWReleaseCallback,getExampleParameterOneWTestCallback)();
    }

    protected List<string> GetExampleParameterOneWListKeys() {
        throw new Exception();
    }
}