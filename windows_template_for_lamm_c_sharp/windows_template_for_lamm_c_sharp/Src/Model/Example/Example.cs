using library_architecture_mvvm_modify_c_sharp;

namespace windows_template_for_lamm_c_sharp;

public class Example(string uniqueId) : BaseModel(uniqueId)
{
    public override Example GetClone()
    {
        return new Example(uniqueId);
    }

    public override string ToString()
    {
        return $"Example(uniqueId: {uniqueId})";
    }
}