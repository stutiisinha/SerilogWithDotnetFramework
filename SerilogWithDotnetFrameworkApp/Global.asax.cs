using System.Web;
using System.Web.Http;
using Serilog;
using Serilog.Sinks.Console;


namespace SerilogWithDotnetFrameworkApp
{
    public class Global : HttpApplication
    {
        private static bool headerLogged = false;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(new Serilog.Sinks.Console.ConsoleSink.ConsoleSinkConfiguration
                {
                    OutputTemplate = !headerLogged ? GetHeaderTemplate() : "{Timestamp:yyyy-MM-dd HH:mm:ss.ffff} | {Level:u3} | {SourceContext} | {RequestId} | {Message}{NewLine}"
                })
                .CreateLogger();
        }

        private static string GetHeaderTemplate()
        {
            headerLogged = true;
            return "======================================================================================================================================================\n" +
                "Logging start    = {Timestamp:yyyy-MM-dd HH:mm:ss.ffff}\n" +
                "Machine name     = {MachineName}\n" +
                "Version          = 0.0.0.0\n" +
                "AssemblyVersion  = {AssemblyVersion}\n" +
                "Windows Version  = {WindowsVersion}\n" +
                "----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n" +
                "Date and Time            | Level | Product              | Module                                                     | Message\n" +
                "----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
        }
    }
}