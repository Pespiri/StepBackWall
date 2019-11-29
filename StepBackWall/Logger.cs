using StepBackWall.Settings;
using System;
using System.Diagnostics;
using System.Reflection;
using IPALogger = IPA.Logging.Logger;
using LogLevel = IPA.Logging.Logger.Level;

namespace StepBackWall
{
    public class Logger
    {
        internal static IPALogger log { private get; set; }

        public static void Log(string message, LogLevel severity = LogLevel.Info)
        {
            string caller = "";
            if (Configuration.ShowCallSource)
            {
                caller = $"{new StackTrace()?.GetFrame(1)?.GetMethod()?.DeclaringType?.FullName ?? Assembly.GetCallingAssembly().GetName().Name} - ";
            }

            if (log != null) log.Log(severity, $"{caller}{message}");
            else Console.WriteLine($"[{Plugin.PluginName}] {severity.ToString().ToUpper()} {caller}{message}");
        }

        public static void Log(Exception error, LogLevel severity = LogLevel.Error)
        {
            string caller = "";
            if (Configuration.ShowCallSource)
            {
                caller = $"{new StackTrace()?.GetFrame(1)?.GetMethod()?.DeclaringType?.FullName ?? Assembly.GetCallingAssembly().GetName().Name} - ";
            }

            if (log != null) log.Log(severity, error);
            else Console.WriteLine($"[{Plugin.PluginName}] {severity.ToString().ToUpper()} {caller}{error.Message}\n{error.StackTrace}");
        }
    }
}
