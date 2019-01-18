using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using StudentNS;

namespace Sorting
{
    public class SimpleMergeSort
    {

        public static void Sort(int count)
        {
            for (int step = 1; step < count; step=step*2)
            {
                Split(step);
                Merge(step);
            }
        }

        //разбиение
        private static void Split(int step)
        {
            using (FileStream fs = new FileStream($"../../SortedStudBase.txt", FileMode.Open, FileAccess.Read),
                fs1 = new FileStream($"../../temp1.txt", FileMode.Create, FileAccess.Write),
                fs2 = new FileStream($"../../temp2.txt", FileMode.Create, FileAccess.Write)
                )
            {
                BufferedStream bs = new BufferedStream(fs);
                BufferedStream bs1 = new BufferedStream(fs1);
                BufferedStream bs2 = new BufferedStream(fs2);
                TextReader tr = new StreamReader(bs);
                TextWriter tw1 = new StreamWriter(bs1);
                TextWriter tw2 = new StreamWriter(bs2);
                string temp = string.Empty;
                Student student = new Student();
                bool flag = true;
                //int a = 0;
                //int b = 0;
                while (flag)
                {
                    for (int i = 0; i < step; i++)
                    {
                        temp = tr.ReadLine();
                        if (temp == null) { flag = false; break; }
                        student.Parse(temp);
                        tw1.WriteLine(student.ToString());
                        //a++;
                    }
                    for (int i = 0; i < step; i++)
                    {
                        temp = tr.ReadLine();
                        if (temp == null) { flag = false; break; }
                        student.Parse(temp);
                        tw2.WriteLine(student.ToString());
                        //b++;
                    }
                }
                //Console.WriteLine("разбиение " + a + "+" + b + "="+(a + b));
                bs.Flush();
                fs.Flush();
                bs1.Flush();
                fs1.Flush();
                tw1.Flush();
                bs2.Flush();
                fs2.Flush();
                tw2.Flush();
            }
        }

        private static void Merge(int step)
        {
            using (FileStream fs = new FileStream($"../../SortedStudBase.txt", FileMode.Create, FileAccess.Write),
                fs1 = new FileStream($"../../temp1.txt", FileMode.Open, FileAccess.Read),
                fs2 = new FileStream($"../../temp2.txt", FileMode.Open, FileAccess.Read)
                )
            {
                BufferedStream bs = new BufferedStream(fs);
                BufferedStream bs1 = new BufferedStream(fs1);
                BufferedStream bs2 = new BufferedStream(fs2);
                TextWriter tw = new StreamWriter(bs);
                TextReader tr1 = new StreamReader(bs1);
                TextReader tr2 = new StreamReader(bs2);

                string temp = string.Empty;
                bool flag1 = true;//флаг окончания первого файла
                bool flag2 = true;//флаг окончания второго файла

                Student student1 = new Student();
                temp = tr1.ReadLine();
                if (temp != null) { student1.Parse(temp); }
                else { flag1 = false; }
                Student student2 = new Student();
                temp = tr2.ReadLine();
                if (temp != null) { student2.Parse(temp); }
                else { flag2 = false; }

                while (flag1&&flag2)
                {
                    int i = 0;
                    int j = 0;
                    while(i<step && j<step && flag1 && flag2)
                    {
                        if(student1<student2)
                        {
                            tw.WriteLine(student1.ToString());
                            i++;
                            temp = tr1.ReadLine();
                            if (temp == null) { flag1 = false; break; }
                            student1.Parse(temp);
                            
                        }
                        else
                        {
                            tw.WriteLine(student2.ToString());
                            j++;
                            temp = tr2.ReadLine();
                            if (temp == null) { flag2 = false; break; }
                            student2.Parse(temp);
                            
                        }
                    }
                    while(i<step && flag1)
                    {
                        tw.WriteLine(student1.ToString());
                        i++;
                        temp = tr1.ReadLine();
                        if (temp == null) { flag1 = false; break; }
                        student1.Parse(temp);
                        
                    }
                    while(j<step && flag2)
                    {
                        tw.WriteLine(student2.ToString());
                        j++;
                        temp = tr2.ReadLine();
                        if (temp == null) { flag2 = false; break; }
                        student2.Parse(temp);
                        
                    }
                }
                while (flag1)
                {
                    tw.WriteLine(student1.ToString());
                    temp = tr1.ReadLine();
                    if (temp == null) { flag1 = false; break; }
                    student1.Parse(temp);
                }
                while (flag2)
                {
                    tw.WriteLine(student2.ToString());
                    temp = tr2.ReadLine();
                    if (temp == null) { flag2 = false; break; }
                    student2.Parse(temp);
                }
                bs.Flush();
                tw.Flush();
                fs.Flush();
            }
        }
    }
}
