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
        InitParametersFour();
        AdditionalInitParameterTextBlockLog();
        BuildParametersFour();
    }

    private void InitParametersFour() 
    {
        Title = "LOG";
        Height = 450;
        Width = 600;
        grid = new();
        scrollViewerWTextBlockLog = new();
        textBlockLog = new()
        {
            Foreground = new SolidColorBrush(Color.FromRgb(192, 192, 192)),
            Background = new SolidColorBrush(Colors.Black),
            FontSize = 16.0,
        };
        buttonLog = new() 
        {
            Content = "Clear",
        };
        buttonLog.Click += ClickButtonLogParameterTextBlockLog;
    }

    private void AdditionalInitParameterTextBlockLog() 
    {
        Console.SetOut(new TextBlockWriterUtility(textBlockLog!));
    }

    private void BuildParametersFour() 
    {
        scrollViewerWTextBlockLog!.Content = textBlockLog;
        grid!.ColumnDefinitions.Add(new ColumnDefinition());
        grid.RowDefinitions.Add(new RowDefinition() {
            Height = new GridLength(10,GridUnitType.Star)
        });
        grid.RowDefinitions.Add(new RowDefinition());
        Grid.SetRow(scrollViewerWTextBlockLog, 0);
        grid.Children.Add(scrollViewerWTextBlockLog);
        Grid.SetRow(buttonLog, 1);
        grid.Children.Add(buttonLog);
        Content = grid;
    }

    private void ClickButtonLogParameterTextBlockLog(object sender, RoutedEventArgs e) 
    {
        if(textBlockLog?.Text == "") 
        {
            return;
        }
        textBlockLog!.Text = "";
    }
}
