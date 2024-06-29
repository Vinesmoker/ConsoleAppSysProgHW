using System;
using System.Runtime.InteropServices;
using static System.Console;
class Program
{
    [DllImport("kernel32.dll")]
    private static extern bool Beep(uint dwFreq, uint dwDuration);
    [DllImport("user32.dll")]
    private static extern bool MessageBeep(uint uType);

    static void Main()
    {
        WriteLine("Нажмите '1', '2' или '3' для воспроизведения звука. Нажмите 'Esc' для выхода.");

        ConsoleKey key;
        do
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.D1:
                    Beep(1000, 300);
                    break;
                case ConsoleKey.D2:
                    Beep(1500, 300);
                    break;
                case ConsoleKey.D3:
                    MessageBeep(0xFFFFFFFF);
                    break;
                case ConsoleKey.Escape:
                    WriteLine("Программа завершена.");
                    break;
            }
        } while (key != ConsoleKey.Escape);
    }
}
   