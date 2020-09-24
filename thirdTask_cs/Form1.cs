using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thirdTask_cs
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        Int32[] usual_days = { 0, 1, 2, 4 };
        static DateTime beginning = new DateTime(2020, 2, 2, 8, 0, 0);
        static Boolean isLesson = true;
        private static DateTime add_lesson_time(DateTime time)
        {
            time = time.AddHours(1);
            time = time.AddMinutes(20);
            return time;
        }
        private static String Get_Current_Lesson(DateTime time, Int32 time_for_break = 15)
        {
            Int32 lesson = 0;
            String result = "";
            for (DateTime beginning = new DateTime(2020, 2, 2, 8, 0, 0); beginning < time; lesson++)
            {
                beginning = add_lesson_time(beginning);
                if (beginning < time)
                {
                    beginning = beginning.AddMinutes(time_for_break);
                    isLesson = beginning > time ? false : true;
                    lesson = beginning == time ? lesson + 1 : lesson;
                }
                if (lesson > 6)
                {
                    break;
                }
            }
            if (lesson > 6)
            {
                result = "Пары закончились";
            }
            else if (!isLesson)
            {
                result = "Сейчас идёт перемена.";
            }
            else if (beginning > time)
            {
                result = "Пары еще не начались";
            }
            else
            {
                result = String.Format("Сейчас идет {0} пара", lesson);
            }
            return result;
        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                int fl; fl = listBox2.SelectedIndex;
                DateTime time = dateTimePicker1.Value;

                fl = usual_days.Contains(fl) ? -2 : fl; // -2 для обычных дней
                switch (fl)
                {
                    case (-2):
                        {
                            MessageBox.Show(Get_Current_Lesson(time));
                            break;
                        }
                    case (-1):
                        {
                            MessageBox.Show("Вы не выбрали день");
                            break;
                        }
                    case (3):
                        {
                            MessageBox.Show("Сегодндя физ-ра");
                            break;
                        }
                    case (5):
                        {
                            MessageBox.Show(Get_Current_Lesson(time, time_for_break: 10));
                            break;
                        }
                    case (6):
                        {
                            MessageBox.Show("Сегодня выходной");
                            break;
                        }
                }
            }
        }
    }
}
