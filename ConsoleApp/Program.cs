using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentNS;
using System.IO;
using Sorting;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            GenerateFileStudents gen = new GenerateFileStudents();
            Console.Write("размер файла (мб): ");
            long size = long.Parse(Console.ReadLine()) * 1048576;
            //long size = long.Parse(Console.ReadLine());
            Console.WriteLine("генерация...");
            gen.Generate(size);
            Console.WriteLine("ok");
            Console.Write("сколько записей вывести?");
            int count = int.Parse(Console.ReadLine());
            Student _stud = new Student();

            //выводим не отсортированный файл
            Console.WriteLine("ИСХОДНАЯ БАЗА");
            using (FileStream fs = new FileStream($"../../StudBase.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                BufferedStream bs = new BufferedStream(fs);
                TextReader tr = new StreamReader(bs);
                int _count = count;
                while (_count > 0)
                {
                    //_stud.Parse(tr.ReadLine());
                    Console.WriteLine(_stud.Parse(tr.ReadLine()));
                    _count--;
                }
                bs.Flush();
                fs.Flush();
            }

            int countStud = 0;
            Console.WriteLine("копирую базу...");
            //копируем базу для сохранения исходного файла
            using (FileStream fs = new FileStream($"../../StudBase.txt", FileMode.Open, FileAccess.Read),
                fs1 = new FileStream($"../../SortedStudBase.txt", FileMode.Create, FileAccess.Write)
                    )
            {
               
                BufferedStream bs = new BufferedStream(fs);
                BufferedStream bs1 = new BufferedStream(fs1);
                TextReader tr = new StreamReader(bs);
                TextWriter tw = new StreamWriter(bs1);
                Student student = new Student();
                while (true)
                {
                    string temp = tr.ReadLine();
                    if (temp == null) break;
                    student.Parse(temp);
                    tw.WriteLine(student.ToString());
                    countStud++;
                }
                bs.Flush();
                tw.Flush();
                fs.Flush();
                Console.WriteLine("количество студентов - " + countStud);
            }

            //сортируем
            Console.WriteLine("Сортирую...");
            SimpleMergeSort.Sort(countStud);
            Console.WriteLine("ok");

            //выводим данные из отсортированного файла
            Console.WriteLine("ОТСОРТИРОВАННАЯ БАЗА");
            using (FileStream fs = new FileStream($"../../SortedStudBase.txt", FileMode.Open, FileAccess.Read))
            {
                BufferedStream bs = new BufferedStream(fs);
                TextReader tr = new StreamReader(bs);
                int _count = count;
                while (_count > 0)
                {
                    Console.WriteLine(_stud.Parse(tr.ReadLine()));
                    _count--;
                }
                bs.Flush();
                fs.Flush();
            }
            Console.WriteLine("готово");
            Console.ReadKey();
        }
    }
}
