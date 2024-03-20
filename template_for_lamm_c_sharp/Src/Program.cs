using System.IO;
using Serilog;

namespace template_for_lamm_c_sharp;

public class Program
{
    [STAThread]
    public static void Main()
    {
    //    ILoggerFactory loggerFactory = new LoggerFactory()
    //        .AddSerilog(new LoggerConfiguration()
    //            .WriteTo.File("log.txt")
    //            .CreateLogger());
    //    Microsoft.Extensions.Logging.ILogger logger = loggerFactory.CreateLogger<Program>();
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
           Exception e = (Exception)args.ExceptionObject;
           logger.LogError(e, $"Hello: {e.Message}");
          File.WriteAllText("log.txt", e.ToString()); // Запись ошибки в файл
        };

        try
        {
            AppView appView = new();
            appView.Run();
        } 
        catch(Exception ex) 
        {
            string logFilePath = "C:\\Users\\antonpichka\\Desktop\\log.txt";
            StreamWriter writer = new(logFilePath, true);
            writer.WriteLine("Время сбоя: " + DateTime.Now);
            writer.WriteLine("Сообщение об ошибке: " + ex.Message);
            writer.WriteLine("Стек вызовов: " + ex.StackTrace);
            writer.WriteLine("----------------------------------------");
        }
    //    Log.Logger = new LoggerConfiguration()
    //        .WriteTo.File("C:\\Users\\antonpichka\\Desktop\\log.txt")
    //        .CreateLogger();
    //    try
    //    {
    //        AppView appView = new();
    //        appView.Run();
    //    }
    //    catch (Exception ex)
    //    {
    //        Log.Error(ex, "Произошла ошибка");
    //    }
    //    finally
    //    {
    //        Log.CloseAndFlush();
    //    } 
    }
}
