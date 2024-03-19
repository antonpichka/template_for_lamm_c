using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace template_for_lamm_c_sharp;

public sealed class ConsoleWindowView : Window
{
    private Grid? grid;
    private ScrollViewer? scrollViewerWTextBlockLog;
    private TextBlock? textBlockLog;
    private Button? buttonLog;

    public ConsoleWindowView()
    {
        Init();
        AdditionalInitialization();
        Build();
    }

    private void Init() 
    {
        Title = "LOG";
        Height = 450;
        Width = 800;
        grid = new();
        scrollViewerWTextBlockLog = new();
        textBlockLog = new()
        {
            Foreground = new SolidColorBrush(Color.FromRgb(192, 192, 192)),
            Background = new SolidColorBrush(Colors.Black),
            FontSize = 16.0,
        };
        buttonLog = new();
    }

    private void AdditionalInitialization() 
    {
        Console.SetOut(new TextBlockWriterUtility(textBlockLog!));
    }

    private void Build() 
    {
        scrollViewerWTextBlockLog!.Content = textBlockLog;
        grid!.ColumnDefinitions.Add(new ColumnDefinition());
        grid.RowDefinitions.Add(new RowDefinition() {
            Height = new GridLength(2,GridUnitType.Star)
        });
        grid.RowDefinitions.Add(new RowDefinition());
        Grid.SetRow(scrollViewerWTextBlockLog, 0);
        grid.Children.Add(scrollViewerWTextBlockLog);
        Grid.SetRow(buttonLog, 1);
        grid.Children.Add(buttonLog);
        Content = grid;
    }
}
