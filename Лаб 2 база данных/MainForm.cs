using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Windows.Forms;

namespace Лаб_2_База_данных
{
    public partial class MainForm : Form
    {
        private List<Student> _list;
        private List<Teacher> _list_1;

        public MainForm()
        {
            InitializeComponent();
            _list = new List<Student>();
            _list_1 = new List<Teacher>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string[] linesStudents = File.ReadAllLines(@"list.txt");
                string[] linesTeachers = File.ReadAllLines(@"teachers.txt");
                foreach (string line in linesStudents)
                {
                    string[] data = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);//массив разделяет на ,
                    //richTextBox1.Text += line + Environment.NewLine;
                    Student student = new Student()
                    {
                        StLastName = data[0],
                        StFirstName = data[1],
                        Grade = int.Parse(data[2]),
                        Classroom = int.Parse(data[3]),
                        Bus = int.Parse(data[4])
                    };
                    _list.Add(student);//добовляем в список нового студента 
                }
                
                foreach (string line in linesTeachers)
                {
                    string[] data = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);//массив разделяет на ,
                    Teacher teacher = new Teacher()
                    {
                        TLastName = data[0],
                        TFirstName = data[1],
                        Classroom = int.Parse(data[2]),
                    };
                    _list_1.Add(teacher);//добовляем в список нового учителя
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            statusStrip2.Items[1].Text = _list.Count.ToString();
        }

        private void task1ToolStripMenuItem_Click(object sender, EventArgs e)//task1
        {
            tbResult.Text = "";
            Stopwatch clockt = new Stopwatch(); 
            clockt.Start();
            foreach (var item in _list)
            {
                var StudentSurname = tbSurname.Text.Trim();
                if (item.StLastName == StudentSurname)
                {
                    tbResult.Text += item.ToStringStudentClassTeacher();
                    foreach (var item_1 in _list_1)
                    {
                        if (item_1.Classroom == item.Classroom)
                        {
                            tbResult.Text += "  " + item_1.ToStringTeacher();
                            break;
                        }
                    }
                    tbResult.Text += "================================" + Environment.NewLine;
                }
            }
            clockt.Stop();
            statusStrip1.Items[1].Text = Convert.ToString(clockt.Elapsed);

        }

        private void task2ToolStripMenuItem_Click(object sender, EventArgs e)//task2
        {
            tbResult.Text = "";
            var StudentSurname = tbSurname_2.Text.Trim();
            Stopwatch clockt = new Stopwatch();
            clockt.Start();
            foreach (var item in _list)
            {
                if (item.StLastName == StudentSurname)
                {
                    tbResult.Text += item.ToStringStudentBus();
                }
            }
            clockt.Stop();
            statusStrip1.Items[1].Text = Convert.ToString(clockt.Elapsed);  /*_list.Count.ToString();*/
        }

        private void task3ToolStripMenuItem_Click(object sender, EventArgs e)//task3
        {
            tbResult.Text = "";
            var TeacherSurname = tbSurname_Professor.Text.Trim();
            Stopwatch clockt = new Stopwatch();
            clockt.Start();
            foreach (var item in _list_1)
            {
                if (item.TLastName == TeacherSurname)
                {
                    tbResult.Text += item.ToStringTeacher(); 

                    foreach (var item_1 in _list)
                    {
                        if (item.Classroom == item_1.Classroom) 
                        {
                            tbResult.Text += "  " + item_1.ToStringTeachersStudentsList();
                        }
                    }
                    tbResult.Text += "================================" + Environment.NewLine;
                }
                clockt.Stop();
                statusStrip1.Items[1].Text = Convert.ToString(clockt.Elapsed); 
            }
        }

        private void task4ToolStripMenuItem_Click(object sender, EventArgs e)//task4
        {
            tbResult.Text = "";
            int BusNum = Convert.ToInt32(Bus_Number.Text.Trim());
            Stopwatch clockt = new Stopwatch(); 
            clockt.Start(); 
            foreach (var item in _list)
            {
                if (item.Bus == BusNum)
                {
                    tbResult.Text += item.ToStringStudentsBus1();
                }
            }
            clockt.Stop();
            statusStrip1.Items[1].Text = Convert.ToString(clockt.Elapsed);
        }

        private void task5ToolStripMenuItem_Click(object sender, EventArgs e)//task5
        {
            tbResult.Text = "";
            int Grade = Convert.ToInt32(Grade_students.Text.Trim());
            Stopwatch clockt = new Stopwatch();
            clockt.Start();
            foreach (var item in _list)
            {
                if (item.Grade == Grade)
                {
                    tbResult.Text += item.ToStringStudentsGrade();
                }
            }
            clockt.Stop();
            statusStrip1.Items[1].Text = Convert.ToString(clockt.Elapsed);
        }

        private void task6ToolStripMenuItem_Click(object sender, EventArgs e)//task6
        {
            tbResult.Text = "";
            int Classroom = Convert.ToInt32(ClassroomTeacher.Text.Trim());
            Stopwatch clockt = new Stopwatch();
            clockt.Start();

            foreach (var item in _list_1)
            {
                if (item.Classroom == Classroom)
                {
                    tbResult.Text += item.ToStringTeacher();
                }
            }
            clockt.Stop();
            statusStrip1.Items[1].Text = Convert.ToString(clockt.Elapsed);
        }
        private void task7ToolStripMenuItem_Click(object sender, EventArgs e)//task7
        {
            tbResult.Text = "";
            int Grade = Convert.ToInt32(GradeTeacher.Text.Trim());
            Stopwatch clockt = new Stopwatch();
            clockt.Start();

            foreach (var item in _list)
            {
                if (item.Grade == Grade)
                {
                    foreach (var item_1 in _list_1)
                    {
                        if (item.Classroom == item_1.Classroom)
                        {
                            tbResult.Text += "  " + item_1.ToStringTeacher();
                        }
                    }
                    tbResult.Text += "================================" + Environment.NewLine;
                }
            }
            clockt.Stop();
            statusStrip1.Items[1].Text = Convert.ToString(clockt.Elapsed);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)//подсмотрел у чата джепети 
        {
            DialogResult resulted = MessageBox.Show("До побачення", "Сповіщення", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (resulted == DialogResult.Cancel)
            {
                e.Cancel = true; 
            }
        }
    }
}
