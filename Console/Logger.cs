using CubivoxCore.Mods;

namespace CubivoxCore.Console
{
    /// <summary>
    /// Log information into the console.
    /// 
    /// <para>Loggers are Mod specific and will prefix the log message with the mod name.</para>
    /// 
    /// <para>Mods should use thier specific logger from <see cref="Mod.GetLogger"/> when logging information.</para>
    /// </summary>
    public interface Logger
    {
        void Info(string message);
        void Debug(string message);
        void Warn(string message);
        void Error(string message);
    }
}
