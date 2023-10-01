namespace Лаб_2_База_данных
{
    internal class Teacher
    {
        public string TLastName { get; set; }
        public string TFirstName { get; set; }
        public int Classroom { get; set; }

        public string ToStringTeacher()
        {
            string data = "Teacher: " + TLastName + "_" + TFirstName + Environment.NewLine;
            return data;
        }
    }
}