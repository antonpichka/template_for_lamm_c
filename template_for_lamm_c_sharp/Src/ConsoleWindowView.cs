using System.ComponentModel;
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
        Title = "Console";
        Height = 400;
        Width = 600;
        MinHeight = 400;
        MinWidth = 600;
        MaxHeight = 400;
        MaxWidth = 600;
        ResizeMode = ResizeMode.NoResize;
        /* You can change it if necessary: WindowState.Maximized/WindowState.Normal */
        WindowState = WindowState.Maximized;
        /* You can change it if necessary: WindowState.Maximized/WindowState.Normal */
        WindowStyle = WindowStyle.None;
        Closing += ClosingWindowFromSenderAndE;
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
        buttonLog.Click += ClickButtonLogFromSenderAndEParameterTextBlockLog;
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

    private void ClickButtonLogFromSenderAndEParameterTextBlockLog(object sender, RoutedEventArgs e) 
    {
        if(textBlockLog?.Text == "") 
        {
            return;
        }
        textBlockLog!.Text = "";
    }

    private void ClosingWindowFromSenderAndE(object? sender, CancelEventArgs e)
    {
        e.Cancel = true;
    }
}
