using System.IO;
using System.Text;
using System.Windows.Controls;

namespace template_for_lamm_c_sharp;

public sealed class TextBlockWriterUtility(TextBlock textBlock) : TextWriter
{
    private readonly TextBlock textBlock = textBlock;

    public override Encoding Encoding => Encoding.UTF8;

#pragma warning disable CS8765
    public override void WriteLine(string value)
#pragma warning restore CS8765
    {
        if(AlgorithmsUtility.IsWhereEqualsStartExceptionFromStr(value))
        {
            textBlock.Text += value + Environment.NewLine;
            return;
        }
        textBlock.Text += value + Environment.NewLine;
    }
}
