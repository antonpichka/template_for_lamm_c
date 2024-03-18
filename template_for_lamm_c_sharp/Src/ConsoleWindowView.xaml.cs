using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace template_for_lamm_c_sharp;

public sealed partial class ConsoleWindowView : Window
{
    public ConsoleWindowView()
    {
        InitializeComponent();
        var textBlockLog = (TextBlock)FindName("textBlockLog");
        textBlockLog.Foreground = new SolidColorBrush(Color.FromRgb(192,192,192));
        var textBlockWriterUtility = new TextBlockWriterUtility(textBlockLog);
        Console.SetOut(textBlockWriterUtility);
    }   
}
