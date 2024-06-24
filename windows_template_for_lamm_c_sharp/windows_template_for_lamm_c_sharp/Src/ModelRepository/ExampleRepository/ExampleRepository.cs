using library_architecture_mvvm_modify_c_sharp;

namespace windows_template_for_lamm_c_sharp;

public class ExampleRepository<T, Y> : BaseModelRepository<T, Y> where T : Example where Y : ListExample<T>
{
    private readonly Func<Task<Result<T>>> getExampleParameterQweServiceWReleaseCallback;
    private readonly Func<Task<Result<T>>> getExampleParameterQweServiceWTestCallback;

    public ExampleRepository(EnumRWTMode enumRWTMode) : base(enumRWTMode)
    {
        getExampleParameterQweServiceWReleaseCallback = () =>
        {
            throw new Exception();
        };
        getExampleParameterQweServiceWTestCallback = () =>
        {
            throw new Exception();
        };
    }

    protected override T GetBaseModelFromMapAndListKeys(Dictionary<string, dynamic> map, List<string> listKeys)
    {
        if(listKeys.Count < 1)
        {
            return (new Example("") as T)!;
        }
        return (new Example(map.TryGetValue(listKeys[0], out dynamic? value) ? value : "") as T)!;
    }

    protected override Y GetBaseListModelFromListModel(List<T> listModel)
    {
        return (new ListExample<T>(listModel) as Y)!;
    }

    public Task<Result<T>> GetExampleParameterQweService() 
    {
        return GetModeCallbackFromReleaseCallbackAndTestCallbackParameterEnumRWTMode(getExampleParameterQweServiceWReleaseCallback,getExampleParameterQweServiceWTestCallback)();
    }
}