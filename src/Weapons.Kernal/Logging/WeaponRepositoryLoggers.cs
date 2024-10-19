using Microsoft.Extensions.Logging;

namespace Weapons.Kernal.Logging;

public static partial class WeaponRepositoryLoggers
{
    [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = @"\x1B[33mSQL: \x1B[1m\x1B[37m{Query} - \x1B[1m\x1B[33m{ElapsedTime}ms")]
    public static partial void LogQuery(ILogger logger, string query, TimeSpan elapsedTime);
}

// static string GetForegroundColorEscapeCode(ConsoleColor color) =>
//     color switch
//     {
//         ConsoleColor.Black => "\x1B[30m",
//         ConsoleColor.DarkRed => "\x1B[31m",
//         ConsoleColor.DarkGreen => "\x1B[32m",
//         ConsoleColor.DarkYellow => "\x1B[33m",
//         ConsoleColor.DarkBlue => "\x1B[34m",
//         ConsoleColor.DarkMagenta => "\x1B[35m",
//         ConsoleColor.DarkCyan => "\x1B[36m",
//         ConsoleColor.Gray => "\x1B[37m",
//         ConsoleColor.Red => "\x1B[1m\x1B[31m",
//         ConsoleColor.Green => "\x1B[1m\x1B[32m",
//         ConsoleColor.Yellow => "\x1B[1m\x1B[33m",
//         ConsoleColor.Blue => "\x1B[1m\x1B[34m",
//         ConsoleColor.Magenta => "\x1B[1m\x1B[35m",
//         ConsoleColor.Cyan => "\x1B[1m\x1B[36m",
//         ConsoleColor.White => "\x1B[1m\x1B[37m",
//
//         _ => DefaultForegroundColor
//     };
//
// static string GetBackgroundColorEscapeCode(ConsoleColor color) =>
//     color switch
//     {
//         ConsoleColor.Black => "\x1B[40m",
//         ConsoleColor.DarkRed => "\x1B[41m",
//         ConsoleColor.DarkGreen => "\x1B[42m",
//         ConsoleColor.DarkYellow => "\x1B[43m",
//         ConsoleColor.DarkBlue => "\x1B[44m",
//         ConsoleColor.DarkMagenta => "\x1B[45m",
//         ConsoleColor.DarkCyan => "\x1B[46m",
//         ConsoleColor.Gray => "\x1B[47m",
//
//         _ => DefaultBackgroundColor
//     };