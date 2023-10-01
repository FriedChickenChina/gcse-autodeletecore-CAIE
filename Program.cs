using System;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;

class Program
{
    static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }

    static void Main()
    {


        // 指定大文件夹路径
        Console.WriteLine("Welcome to use exam board past paper 'core' subject paper deleting system.");
        Console.WriteLine("Please input the directory of the insert folder:");
        Console.WriteLine("As an example:");
        Console.WriteLine(@"D:\downloads\biogcse\wp-content\uploads\simple-file-list\CIE\IGCSE\Biology-0610");
        Console.OutputEncoding = Encoding.UTF8;

        // 输出分隔行
        int 分隔行长度 = 30; // 指定分隔行的长度
        char 分隔符字符 = '-'; // 指定分隔符字符

        for (int i = 0; i < 分隔行长度; i++)
        {
            Console.Write(分隔符字符);
        }

        Console.WriteLine("");
        Console.WriteLine("欢迎使用针对国外的往年试卷的核心试卷删减器");
        Console.WriteLine("请输入目标根目录地址");
        Console.WriteLine("例如");
        Console.WriteLine(@"D:\downloads\biogcse\wp-content\uploads\simple-file-list\CIE\IGCSE\Biology-0610");
        Console.WriteLine("将会自动为您删除1,3,5类试卷");

        var 大文件夹路径 = "";

        do
        {
            Console.WriteLine("请输入大文件夹路径：");
            大文件夹路径 = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(大文件夹路径))
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);  // 将光标移动到上一行
                Program.ClearCurrentConsoleLine();  // 清除当前行的内容
                Console.WriteLine("Please input something, this system isn't stupid");
            }
            if (大文件夹路径 == ".")
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);  // 将光标移动到上一行
                Program.ClearCurrentConsoleLine();  // 清除当前行的内容
                Console.WriteLine("你输入点有用的");
            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);  // 将光标移动到上一行
                Program.ClearCurrentConsoleLine();  // 清除当前行的内容
                Console.WriteLine("你输入了一些信息");

            }

        } while (string.IsNullOrWhiteSpace(大文件夹路径) || 大文件夹路径 == "." || !Directory.Exists(大文件夹路径));


        Console.WriteLine("你输入了正确的路径 正在执行");
        Thread.Sleep(3000); // 休眠 3000 毫秒（3 秒）


        // 遍历大文件夹及其子文件夹
        foreach (string 文件路径 in Directory.GetFiles(大文件夹路径, "*.pdf", SearchOption.AllDirectories))
        {
            // 获取文件名
            string 文件名 = Path.GetFileNameWithoutExtension(文件路径);

            // 获取文件名的倒数第二个字符
            char 倒数第二个字符 = 文件名[文件名.Length - 2];

            // 判断倒数第二个字符是否为1或3
            if (倒数第二个字符 == '1' || 倒数第二个字符 == '3' || 倒数第二个字符 == '5')
            {
                // 如果是1x或3x结尾的文件，删除它
                File.Delete(文件路径);
                Console.WriteLine($"deleted：{文件路径}");
            }

            else
            {
                // 如果是2x结尾的文件，保留它
                Console.WriteLine($"kept：{文件路径}");
            }
        }

        Console.WriteLine("finished。");
    }
}
