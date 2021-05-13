using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laborotory23
{
  public  class student
    {
        public string[] studint;
        public int number;
        public string fio;
        public DateTime date;
        public string uni;
        public string group;
        public int course;
        public double ball;
        public student(string stud)
        {
            studint = stud.Split(' ');
          number = int.Parse(studint[0]);
            fio = studint[1] + " " + studint[2] + " " + studint[3];
            date = DateTime.Parse(studint[4]);
            uni = studint[5];
            group = studint[6];
            course = int.Parse(studint[7]);
            ball = double.Parse(studint[8]);
        }

        public string SaveToFile()
        {
            return $"{fio} {date.ToString("dd.MM.yyyy")} {uni} {group} {course} {ball}";
        }
        public string print()
        {
            return $" {fio} {date.ToString("dd.MM.yyyy")} {uni} {group} {course} {ball} \n";
        }
    }
}
