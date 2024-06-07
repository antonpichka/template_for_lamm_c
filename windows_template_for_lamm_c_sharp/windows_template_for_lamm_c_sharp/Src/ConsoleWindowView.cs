using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace windows_template_for_lamm_c_sharp;

public sealed class ConsoleWindowView : Window
{
    private Grid? grid;
    private ScrollViewer? scrollViewerWTextBlock;
    private TextBlock? textBlock;
    private Button? button;

    public ConsoleWindowView()
    {
        ExceptionHelperUtility.CallExceptionHelperFromThisClassAndCallback(this,()=> 
        {
            InitWindowParametersFour();
            AdditionalInitParameterTextBlock();
            BuildParametersFour();
        });
    }

    private void InitWindowParametersFour() 
    {
        Title = "Console";
        Height = 300;
        Width = 600;
        MinHeight = 300;
        MinWidth = 600;
        MaxHeight = 300;
        MaxWidth = 600;
        ResizeMode = ResizeMode.NoResize;
        /* YOU CAN CHANGE IT IF NECESSARY: WindowState.Maximized/WindowState.Normal */
        WindowState = WindowState.Maximized;
        /* YOU CAN CHANGE IT IF NECESSARY: WindowState.Maximized/WindowState.Normal */
        WindowStyle = WindowStyle.None;
        Icon = BitmapFrame.Create(new Uri(@"../build/Assets/Icon/CMD32.ico",UriKind.RelativeOrAbsolute));
        Closing += ClosingFromSenderAndE;
        grid = new();
        scrollViewerWTextBlock = new();
        textBlock = new()
        {
            Foreground = new SolidColorBrush(Color.FromRgb(192, 192, 192)),
            Background = new SolidColorBrush(Colors.Black),
            FontSize = 16.0,
        };
        button = new() 
        {
            Content = "Clear",
        };
        button.Click += ClickButtonFromSenderAndEParameterTextBlock;
    }

    private void AdditionalInitParameterTextBlock() 
    {
        Console.SetOut(new TextBlockWriterUtility(textBlock!));
    }

    private void BuildParametersFour() 
    {
        scrollViewerWTextBlock!.Content = textBlock;
        grid!.ColumnDefinitions.Add(new ColumnDefinition());
        grid.RowDefinitions.Add(new RowDefinition() {
            Height = new GridLength(10,GridUnitType.Star)
        });
        grid.RowDefinitions.Add(new RowDefinition());
        Grid.SetRow(scrollViewerWTextBlock, 0);
        grid.Children.Add(scrollViewerWTextBlock);
        Grid.SetRow(button, 1);
        grid.Children.Add(button);
        Content = grid;
    }

    private void ClickButtonFromSenderAndEParameterTextBlock(object sender, RoutedEventArgs e) 
    {
        if(textBlock?.Text == "") 
        {
            return;
        }
        textBlock!.Text = "";
    }

    private void ClosingFromSenderAndE(object? sender, CancelEventArgs e)
    {
        e.Cancel = true;
    }
}
