using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static System.Console;

namespace ConsoleAppSysProg
{
    partial class Program
    {
        [LibraryImport("user32.dll", EntryPoint = "MessageBoxW", StringMarshalling = StringMarshalling.Utf16)]
        public static partial int MessageBox(IntPtr qwehWnd, string text, string caption, uint type);

        static void Main()
        {
            string? name = GetInput("Введите ваше имя: ");
            while (!WrongName(name))
            {
                WriteLine("Ошибка! Имя не должно содержать цифр или быть пустым!");
                name = GetInput("Введите ваше имя: ");
            }
            string? userAge = GetInput("Введите ваш возраст: ");
            int age;
            while (!int.TryParse(userAge, out age) || age <= 0 || age >= 150)
            {
                WriteLine("Ошибка! Введите корректный возраст (целое реальное число)!");
                userAge = GetInput("Введите ваш возраст: ");
            }
            string? profession = GetInput("Введите вашу профессию: ");
            while (!WrongName(profession))
            {
                WriteLine("Ошибка! Профессия не должна содержать цифр или быть пустой!");
                profession = GetInput("Введите вашу профессию: ");
            }
            DisplayMessageBox(name ?? "", "Имя");
            DisplayMessageBox(age.ToString(), "Возраст");
            DisplayMessageBox(profession ?? "", "Профессия");
            DisplayMessageBox("Спасибо за использование!", "Вот и всё!");
        }
        static string? GetInput(string temp)
        {
            Write(temp);
            return ReadLine();
        }
        static int DisplayMessageBox(string? message, string caption)
        {
            return MessageBox(IntPtr.Zero, message ?? "", caption, 0);
        }
        static bool WrongName(string? name)
        {
            return MyRegex().IsMatch(name ?? "");
        }
        [GeneratedRegex(@"^[a-zA-Zа-яА-ЯёЁ-]+$")]
        private static partial Regex MyRegex();
    }
}