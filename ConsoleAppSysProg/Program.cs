using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static System.Console;

namespace ConsoleAppSysProg
{
    partial class Program
    {
        [LibraryImport("user32.dll", EntryPoint = "MessageBoxW", StringMarshalling = StringMarshalling.Utf16)]
        public static partial int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        static void Main()
        {
            string? userName = GetInput("Введите ваше имя: ");
            while (!IsValidName(userName))
            {
                WriteLine("Ошибка! Имя не должно содержать цифр или быть пустым!");
                userName = GetInput("Введите ваше имя: ");
            }
            string? userAge = GetInput("Введите ваш возраст: ");
            int age;
            while (!int.TryParse(userAge, out age) || age <= 0)
            {
                WriteLine("Ошибка! Введите корректный возраст (целое число больше 0).");
                userAge = GetInput("Введите ваш возраст: ");
            }
            string? userOccupation = GetInput("Введите вашу профессию: ");
            while (!IsValidName(userOccupation))
            {
                WriteLine("Ошибка! Профессия не должна содержать цифр или быть пустой!");
                userOccupation = GetInput("Введите вашу профессию: ");
            }
            DisplayMessageBox(userName ?? "", "Имя");
            DisplayMessageBox(age.ToString(), "Возраст");
            DisplayMessageBox(userOccupation ?? "", "Профессия");
            DisplayMessageBox("Спасибо за использование!", "Вот и всё!");
        }
        static string? GetInput(string prompt)
        {
            Write(prompt);
            return ReadLine();
        }
        static int DisplayMessageBox(string? message, string caption)
        {
            return MessageBox(IntPtr.Zero, message ?? "", caption, 0);
        }
        static bool IsValidName(string? name)
        {
            return MyRegex().IsMatch(name ?? "");
        }

        [GeneratedRegex(@"^[a-zA-Zа-яА-ЯёЁ-]+$")]
        private static partial Regex MyRegex();
    }
}