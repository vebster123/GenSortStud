using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentNS
{
    public class Student
    {
        string name;
        string surname;
        string patronymic;
        DateTime birth;
        int studCard;
        int idProfession;
        string department;

        public Student()
        {

        }

        public Student(string name, string surname, string patronymic, DateTime birth, int studCard, int idProfession, string department)
        {
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.birth = birth;
            this.studCard = studCard;
            this.idProfession = idProfession;
            this.department = department;
        }

        public override string ToString()
        {
            string date = birth.Day + "." + birth.Month + "." + birth.Year;
            return (name + " " + surname + " " + patronymic + " " + date + " " + studCard + " " + idProfession +" "+department);
        }

        public Student Parse(string _stud)
        {
            List<string> fields = _stud.Split(null as string[], StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            this.name = fields[0];
            this.surname = fields[1];
            this.patronymic = fields[2];
            this.birth = DateTime.Parse(fields[3]).Date;
            this.studCard = int.Parse(fields[4]);
            this.idProfession = int.Parse(fields[5]);
            this.department = fields[6];
            return new Student(name, surname, patronymic, birth, studCard, idProfession, department);
        }


        //операторы сравнения для объекта СТУДЕНТ, при сравнении учитываюся три атрибута ИМЯ(высокий приоритет), ФАМИЛИЯ(средний приоритет), НОМЕР СТУДИКА(низкий приоритет)
        public static bool operator <(Student f1, Student f2)
        {
            if(String.Compare(f1.name, f2.name) == 0 && String.Compare(f1.surname, f2.surname) == 0)
            {
                if (f1.studCard < f2.studCard) return true;
                else return false;
            }
            if (String.Compare(f1.name, f2.name) == 0)
            {
                if (String.Compare(f1.surname, f2.surname) < 0) return true;
                else return false;
            }
            if (String.Compare(f1.name, f2.name) < 0)
            {
                return true;
            }
            return false;
        }
        public static bool operator <=(Student f1, Student f2)
        {
            if (String.Compare(f1.name, f2.name) == 0 && String.Compare(f1.surname, f2.surname) == 0)
            {
                if (f1.studCard <= f2.studCard) return true;
                else return false;
            }
            if (String.Compare(f1.name, f2.name) == 0)
            {
                if (String.Compare(f1.surname, f2.surname) < 0 || String.Compare(f1.surname, f2.surname) == 0) return true;
                else return false;
            }
            if (String.Compare(f1.name, f2.name) < 0 || String.Compare(f1.name, f2.name) == 0)
            {
                return true;
            }
            return false;
        }
        public static bool operator >(Student f1, Student f2)
        {
            if (String.Compare(f1.name, f2.name) == 0 && String.Compare(f1.surname, f2.surname) == 0)
            {
                if (f1.studCard > f2.studCard) return true;
                else return false;
            }
            if (String.Compare(f1.name, f2.name) == 0)
            {
                if (String.Compare(f1.surname, f2.surname) > 0) return true;
                else return false;
            }
            if (String.Compare(f1.name, f2.name) > 0)
            {
                return true;
            }
            return false;
        }
        public static bool operator >=(Student f1, Student f2)
        {
            if (String.Compare(f1.name, f2.name) == 0 && String.Compare(f1.surname, f2.surname) == 0)
            {
                if (f1.studCard >= f2.studCard) return true;
                else return false;
            }
            if (String.Compare(f1.name, f2.name) == 0)
            {
                if (String.Compare(f1.surname, f2.surname) > 0 || String.Compare(f1.surname, f2.surname) == 0) return true;
                else return false;
            }
            if (String.Compare(f1.name, f2.name) > 0 || String.Compare(f1.name, f2.name) == 0)
            {
                return true;
            }
            return false;
        }
    }
}
