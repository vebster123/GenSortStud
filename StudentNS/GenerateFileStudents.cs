using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentNS
{
    public class GenerateFileStudents
    {
        List<string> names;
        List<string> surnames;
        List<string> patronymics;
        List<DateTime> birth = new List<DateTime>();
        List<int> studCard = new List<int>();
        List<int> idProf = new List<int>();
        List<string> departments;
        Random rand;
        Student student;

        public GenerateFileStudents()
        {
            this.names = File.ReadLines(@"../../name.txt").ToList();
            this.surnames = File.ReadLines(@"../../surname.txt").ToList();
            this.patronymics = File.ReadLines(@"../../patronymic.txt").ToList();
            this.departments = File.ReadLines(@"../../department.txt").ToList();
            DateTime date = new DateTime(1995,1,1);
            for(int i = 0;i<2000;i++)
            {
                date = date.AddDays(1);
                birth.Add(date);
            }
            for (int i = 10000000; i < 99999999; i++)
            {
                studCard.Add(i);
            }
            for (int i = 000000; i < 300908; i+=30)
            {
                idProf.Add(i);
            }
            rand = new Random();
            student = new Student();
        }

        public void Generate(long filesize)
        {
            using (FileStream fs = new FileStream($"../../StudBase.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                int countStud = 0;
                BufferedStream bs = new BufferedStream(fs);
                TextWriter tw = new StreamWriter(bs);
                while (bs.Length <= filesize)
                {
                    student = new Student(names[rand.Next(names.Count)], surnames[rand.Next(surnames.Count)],
                        patronymics[rand.Next(patronymics.Count)], birth[rand.Next(birth.Count)], studCard[rand.Next(studCard.Count)],
                        idProf[rand.Next(idProf.Count)], departments[rand.Next(departments.Count)]);
                    tw.WriteLine(student.ToString());
                    countStud++;
                }
                bs.Flush();
                tw.Flush();
                fs.Flush();
                Console.WriteLine("количество студентов - "+countStud);
            }
        }
    }
}
