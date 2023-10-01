
namespace Лаб_2_База_данных
{
    internal class Student
    {
        public string StLastName { get; set; }
        public string StFirstName { get; set; }
        public int Grade { get; set; }
        public int Classroom { get; set; }
        public int Bus { get; set; }

        public string ToStringStudentClassTeacher()//task1
        {
            string data = "Student LastName: " + StLastName + Environment.NewLine;
            data += "Student FirstName: " + StFirstName + Environment.NewLine;
            data += "Student Classroom: " + Classroom + Environment.NewLine;
            data += "================================" + Environment.NewLine;
            return data;
        }
        public string ToStringStudentBus()//task2
        {
            string data = "Student FirstName: " + StFirstName + Environment.NewLine;
            data += "Student Bus: " + Bus + Environment.NewLine;
            data += "================================" + Environment.NewLine;
            return data;
        }
        public string ToStringTeachersStudentsList()//task3
        {
            string data = "Student LastName: " + StLastName + Environment.NewLine;
            data += "Student FirstName: " + StFirstName + Environment.NewLine;
            data += "================================" + Environment.NewLine;
            return data;
        }
        public string ToStringStudentsBus1()//task4
        {
            string data = "Student LastName: " + StLastName + Environment.NewLine;
            data += "Student FirstName: " + StFirstName + Environment.NewLine;
            data += "================================" + Environment.NewLine;
            return data;
        }

        public string ToStringStudentsGrade()//task5
        {
            string data = "Student LastName: " + StLastName + Environment.NewLine;
            data += "Student FirstName: " + StFirstName + Environment.NewLine;
            data += "================================" + Environment.NewLine;
            return data;
        }
    }
}