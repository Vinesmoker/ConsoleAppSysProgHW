using System;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text;
using System.Threading;

class Program
{
    /*
    private static readonly char[] punctuation = { ' ', '\r', '\n', '\t', '.', ',', ';', ':', '-', '_', '/' };
    public static void Main(string[] args)
    {
        string filePath = "C:\\Users\\User\\Desktop\\1.txt";
        FileStream sream = new(filePath, FileMode.Open, FileAccess.Read);
        byte[] buff = new byte[sream.Length];
        IAsyncResult res = sream.BeginRead(buff, 0, buff.Length, null, null);
        sream.EndRead(res);
        string encod = Encoding.UTF8.GetString(buff);
        int wordsNum = CountWords(encod);
        Console.WriteLine($"Количество слов в файле: {wordsNum}");
        sream.Close();
    }
    private static int CountWords(string stringSepar)
    {
        string[] words = stringSepar.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }
    */

    /*
    private static FileStream? startStream;
    private static FileStream? endStream;
    private static byte[]? buff;

    public static void Main()
    {
        string? sourcePath = "C:\\Users\\User\\Desktop\\1.txt";
        string? destPath = "C:\\Users\\User\\Desktop\\2.txt";
        startStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
        endStream = new FileStream(destPath, FileMode.Create, FileAccess.Write);
        buff = new byte[4096];
        AsyncCallback? readCall = new(OnReadComplete);
        startStream.BeginRead(buff, 0, buff.Length, readCall, null);
    }
    private static void OnReadComplete(IAsyncResult res)
    {
        int read = startStream.EndRead(res);
        if (read > 0)
        {
            endStream.BeginWrite(buff, 0, read, new(OnWriteComplete), null);
        }
        else
        {
            startStream.Close();
            endStream.Close();
        }
    }
    private static void OnWriteComplete(IAsyncResult asyncResult)
    {
        endStream.EndWrite(asyncResult);
        AsyncCallback? readCallback = new(OnReadComplete);
        startStream.BeginRead(buff, 0, buff.Length, readCallback, null);
    }
    */

    /*
    private static FileStream? fStream;
    private static byte[]? buff;
    private static AsyncCallback? callbackRead;

    public static void Main()
    {
        string? filePath = "C:\\Users\\User\\Desktop\\1.txt";

        try
        {
            fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 1024, true);
            buff = new byte[fStream.Length];
            callbackRead = new AsyncCallback(ReadCompleted);
            fStream.BeginRead(buff, 0, buff.Length, callbackRead, null);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Ошибка: Файл не найден.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Ошибка: Нет доступа к файлу.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
    private static void ReadCompleted(IAsyncResult res)
    {
        int read = fStream.EndRead(res);

        if (read > 0)
        {
            string? content = Encoding.UTF8.GetString(buff, 0, read);
            Console.WriteLine(content);
        }

        fStream.Close();
    }
    */

    /*
    static FileStream fSream;
    static byte[] buff;
    static int sCount = 0;
    static AutoResetEvent resEv = new(false);
    static void Main(string[] args)
    {
        try
        {
            fSream = new FileStream("C:\\Users\\User\\Desktop\\1.txt", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, true);
            buff = new byte[fSream.Length];
            AsyncCallback callbackRead = new(ReadCompleted);
            fSream.BeginRead(buff, 0, buff.Length, callbackRead, null);
            resEv.WaitOne();
            Console.WriteLine($"Количество строк в файле: {sCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
        finally
        {
            fSream?.Close();
        }
    }
    static void ReadCompleted(IAsyncResult res)
    {
        int read = fSream.EndRead(res);
        if (read > 0)
        {
            string content = Encoding.UTF8.GetString(buff, 0, read);
            sCount = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Length;
            Console.WriteLine($"{content} \n\n");
        }
        resEv.Set();
    }
    */

    /*
    private static int count = 0;
    private readonly static object @object = new();
    static void Main()
    {
        Thread[] threads = new Thread[10];

        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(IncrementCounter);
            threads[i].Start(i + 1);
        }
        foreach (Thread t in threads)
        {
            t.Join();
        }
        Console.WriteLine($"Итоговое значение счетчика: {count}");
    }
    static void IncrementCounter(object? number)
    {
        Console.WriteLine($"Поток {number} подключился.");
        for (int i = 0; i < 1000; i++)
        {
            lock (@object)
            {
                count++;
            }
        }
        Console.WriteLine($"Поток {number} завершил работу.");
    }
    */

    static int Fibonacci(int n)
    {
        if (n <= 1)
            return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    static void Main()
    {
        int number = 100; // Вы можете изменить это число, чтобы вычислить другое число Фибоначчи
        Console.WriteLine($"Число Фибоначчи под номером {number} равно {Fibonacci(number)}");
    }
}
