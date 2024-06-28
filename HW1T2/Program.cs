using System;
using System.Runtime.InteropServices;
using static System.Console;

partial class Program
{
    [LibraryImport("user32.dll", EntryPoint = "FindWindowW", StringMarshalling = StringMarshalling.Utf16)]
    internal static partial IntPtr FindWindow(string? lpClassName, string lpWindowName);

    [LibraryImport("user32.dll", EntryPoint = "SendMessageW", StringMarshalling = StringMarshalling.Utf16)]
    internal static partial IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, string lParam);
    const UInt32 WM_SETTEXT = 0x000C;
    const UInt32 WM_CLOSE = 0x0010;
    static void Main()
    {
        string? windowTitle = "C:\\";
        IntPtr hWnd = FindWindow(null, windowTitle);
        if (hWnd != IntPtr.Zero)
        {
            WriteLine("The window found, HWND: " + hWnd.ToString());
            WriteLine("Enter 'title' to change the title or 'close' to exit the programm:");
            string? action = ReadLine();

            switch (action?.ToLower())
            {
                case "title":
                    WriteLine("Enter a new title fo the window:");
                    string? newTitle = ReadLine();
                    if (newTitle != null)
                    {
                        SendMessage(hWnd, WM_SETTEXT, IntPtr.Zero, newTitle);
                    }
                    else
                    {
                        WriteLine("The title can not be empty!");
                    }
                    break;
                case "close":
                    SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, "");
                    break;
            }
        }
        else
        {
            WriteLine("The window not found!");
        }
    }
}
