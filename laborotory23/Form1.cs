using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laborotory23
{
    public partial class Form1 : Form
    { public void SAVE()
        {
            studdent.Clear();
            for (int i = 0; i < changestud.Count(); ++i)
            {
                studdent.Add(changestud[i]);
            }
            PRint();
        }
        public Form1()
        {
            InitializeComponent();
        }
        List<student> studdent = new List<student>();
        List<student> changestud = new List<student>();
       
        public  void Form1_Load(object sender, EventArgs e) //загрузка из файла
        {
            menu();
            if (File.Exists("Base.txt"))
            {
                string path = "base.txt";
                string[] array = File.ReadAllLines(path);
                for (int i = 0; i < array.Length; i++)
                {
                    student student = new student(array[i]);
                    studdent.Add(student);
                    changestud.Add(student);

                }
            }
            else
            {
                MessageBox.Show("Файл не обнаружен!");
            }
    }

        public void button1_Click(object sender, EventArgs e) //вывод
        {
            PRint();
        }

       async private void button2_Click(object sender, EventArgs e) //добавить элемент
        {
            try
            {
               
                    int number = studdent.Count + 1;
                    string stadent = number + " " + textBox1.Text;
                    student stude = new student(stadent);
                if (stude.ball >= 0 && stude.ball <= 100 && stude.course>0 && stude.course <=6)
                {
                    changestud.Add(stude);
                    SAVE();
                    richTextBox2.Text = "В БД добавлен студент";
                    await Task.Delay(2000);
                    richTextBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Значения ср.балла находятся в промежутке от 0 до 100 ,курс от 1 до 6", "DataBase");
                }
                
            }
            catch
            {
                MessageBox.Show("Формат ввода:Фам. Имя Отчество Дата рождения(дд.мм.гг)  Институт Группа Курс Ср.балл", "DataBase");
            }
           


        }

        private void button5_Click(object sender, EventArgs e) //кнопка меню
        {
            menu();


        }


        public void PRint() //вывод бд
        {
            string lav = "";
            for (int i = 0; i < studdent.Count(); i++)
            {
                
                lav += ((i + 1).ToString() +" "+ studdent[i].print());
            }
            richTextBox1.Text = lav;
        }
        public void menu() //меню
        {
            richTextBox1.Text = "";
            richTextBox1.Text = "Структура БД:\n-№(номер студента)\n-ФИО Студента\n-Дата рождения(день,месяц,год)\n-Институт\n-Группа\n-курс\n-Средний балл" +
                 "\n\nРабота БД:\n-Добавление,изменение,удаление записи\n-Прямая и обратная сортировка по полям:ФИО,Дата рождения\n-поиск элемента по полям:ФИО,Дата рождения\n-Нахождение Min,Max," +
                 "среднего значения и суммы по полю:Средний балл\n\nСтруктура элемента:\nИмя Фамилия Отчество дата рождения(день.месяц.год) институт группа курс(цифра) балл(цифра).";
        }

        private void textBox1_DoubleClick(object sender, EventArgs e) //очистка текстбокса
        {
            textBox1.Text = "";
        }

       async private void button3_Click(object sender, EventArgs e) //удаление

        {
            try
            {
                int id = int.Parse(textBox1.Text) - 1;

                changestud.RemoveAt(id);
                SAVE();
                richTextBox2.Text = $"Из БД был удален студент под номером {id+1}";
                await Task.Delay(2000);
                richTextBox2.Text = "";
            }
            catch
            {
                MessageBox.Show("Ошибка,чтобы удалить студента,введите его номер", "DataBase");
            }
        }

    async public void button4_Click(object sender, EventArgs e) //изменить весь элемент
        {
            try
            {
                int number = int.Parse(textBox1.Text.Remove(1))-1;
                string s = textBox1.Text;
                student stude = new student(s);
                if (stude.ball >= 0 && stude.ball <= 100 && stude.course > 0 && stude.course <= 6)
                {
                    changestud[number] = stude;
                    SAVE();
                    richTextBox2.Text = $"Был изменен студент под номером {number+1}";
                    await Task.Delay(2000);
                    richTextBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Значения ср.балла находятся в промежутке от 0 до 100,курс от 1 до 6", "DataBase");
                }
            }
            catch
            {
                MessageBox.Show("Формат ввода:номер Фам. Имя Отчество Дата рождения(дд.мм.гг)  Институт Группа Курс Ср.балл", "DataBase");
            }
        }

    async    public void button10_Click(object sender, EventArgs e) //измена фио
        {
            try
            {
                int number = int.Parse(textBox1.Text.Remove(1)) - 1;
             string oao= textBox1.Text.Remove(0, 2).Trim();
                string[] aoa = oao.Split(' ');
                if (aoa.Length == 3 || aoa.Length==2 || aoa.Length == 1 || aoa.Length == 4)
                {
                    changestud[number].fio = oao;
                    SAVE();
                    richTextBox2.Text = $"ФИО студента под номером {number+1} было изменено";
                    await Task.Delay(2000);
                    richTextBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Ошибка,введите имя в формате (№студента Фамилия Имя Отчество)", "DataBase");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка,введите имя в формате (№студента Фамилия Имя Отчество)", "DataBase");
            }
        }

     async  public void button7_Click(object sender, EventArgs e) //измена даты
        {
            DateTime DATE = new DateTime();
            try
            {
                int number = int.Parse(textBox1.Text.Remove(1)) - 1;
                string data = textBox1.Text.Remove(0, 2).Trim();
                string[] arr = data.Split('.');
                int[] count = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    count[i] = Convert.ToInt32(arr[i]);
                }
                DATE = new DateTime(count[2], count[1], count[0]);
                  changestud[number].date =  DATE;
                    SAVE();
                richTextBox2.Text = $"Дата рождения студента под номером {number + 1} было изменено";
                await Task.Delay(2000);
                richTextBox2.Text = "";


            }
            catch
            {
                MessageBox.Show("Ошибка,введите дату рождения в формате (№студента дд.мм.гг)", "DataBase");
            }

          /*  try
            {       
                int number = int.Parse(textBox1.Text.Remove(1)) - 1;
                string oao = textBox1.Text.Remove(0, 2).Trim();
                string[] aoa = oao.Split(' ');
               
                if (aoa.Length ==1)
                {
                 //   changestud[number].date =  oao;
                    SAVE();
                }
                else
                {
                    MessageBox.Show("Ошибка", "warning");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка", "warning");
            }  */
        }

     async   private void button9_Click(object sender, EventArgs e) //меняем группу
        {
            try
            {
                int number = int.Parse(textBox1.Text.Remove(1)) - 1;
                string oao = textBox1.Text.Remove(0, 2).Trim();
                string[] aoa = oao.Split(' ');

                if (aoa.Length == 1)
                {
                    changestud[number].group = oao;
                    SAVE();
                    richTextBox2.Text = $"Группа студента под номером {number + 1} было изменено";
                    await Task.Delay(2000);
                    richTextBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Ошибка,введите группу в формате (№студента №группы)", "DataBase");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка,введите группу в формате (№студента №группы)", "DataBase");
            }
        }

      async  private void button11_Click(object sender, EventArgs e) //вуз
        {
            try
            {
                int number = int.Parse(textBox1.Text.Remove(1)) - 1;
                string oao = textBox1.Text.Remove(0, 2).Trim();
                string[] aoa = oao.Split(' ');

                if (aoa.Length == 1)
                {
                    changestud[number].uni = oao;
                    SAVE();
                    richTextBox2.Text = $"Институт студента под номером {number + 1} было изменено";
                    await Task.Delay(2000);
                    richTextBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Ошибка,введите название ВУЗа в формате (№студента ВУЗ)", "DataBase");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка,введите название ВУЗа в формате (№студента ВУЗ)", "DataBase");
            }

        }

      async  private void button13_Click(object sender, EventArgs e) //курс
        {
            try
            {
                int number = int.Parse(textBox1.Text.Remove(1)) - 1;
                string oao = textBox1.Text.Remove(0, 2).Trim();
                string[] aoa = oao.Split(' ');

                if (aoa.Length == 1)
                {   if (int.Parse(oao) > 0 && int.Parse(oao) <= 6)
                    {
                        changestud[number].course = int.Parse(oao);
                        SAVE();
                        richTextBox2.Text = $"Курс студента под номером {number + 1} было изменено";
                        await Task.Delay(2000);
                        richTextBox2.Text = "";
                    }
                    else { MessageBox.Show("Ошибка,курс может быть в пределах от 1 до 6", "DataBase"); }
                }
                else
                {
                    MessageBox.Show("Ошибка,введите курс в формате (№студента курс)", "DataBase");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка,введите курс в формате (№студента курс)", "DataBase");
            }
        }

       async private void button12_Click(object sender, EventArgs e) //србал
        {
            try
            {   
                int number = int.Parse(textBox1.Text.Remove(1)) - 1;
                string oao = textBox1.Text.Remove(0, 2).Trim();

                string[] aoa = oao.Split(' ');
                double a = double.Parse(oao);
                if (a <= 100 && a >= 0)
                {
                    if (aoa.Length == 1)
                    {
                        changestud[number].ball = double.Parse(oao);
                        SAVE();
                        richTextBox2.Text = $"Средний балл студента под номером {number + 1} было изменено";
                        await Task.Delay(2000);
                        richTextBox2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Ошибка,введите кол-во баллов в формате (№студента баллы[0,100])", "DataBase");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка,введите кол-во баллов в формате (№студента баллы[0,100])", "DataBase");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка,введите кол-во баллов в формате (№студента баллы[0,100])", "DataBase");
            }

        }

        async public void button6_Click(object sender, EventArgs e) //поиск по ФИО
        {
            richTextBox2.Text = "";
            try
            {
                int k = 0;
                int i = 0;
                for (; i < changestud.Count; i++)
                {
                    if ((changestud[i].fio).ToString().Contains(textBox1.Text) && !(textBox1.Text.Length == 0))
                    {
                        richTextBox2.Text += $"Искомый студент:\n{i + 1} {changestud[i].print()}";
                        await Task.Delay(5000);
                        richTextBox2.Text = "";
                    }
                    else
                    {
                        k++;

                    }
                    

                }
                
                if (k == changestud.Count)
                {
                    richTextBox2.Text = $"Искомый студент не найден";
                    await Task.Delay(1000);
                    richTextBox2.Text = "";

                }
               
              
            }
            
            catch
            {
                MessageBox.Show("Ошибка", "DataBase");
            }
           
        }

        async public void button8_Click(object sender, EventArgs e) //Поиск По дате рождения    
        {
            richTextBox2.Text = "";
            try
            {
                int k = 0;
                int i = 0;
                for (; i < changestud.Count; i++)
                {
                    if ((changestud[i].date).ToString().Contains(textBox1.Text)&& !(textBox1.Text.Length == 0))
                    {
                        richTextBox2.Text += $"Искомый студент:\n{i + 1} {changestud[i].print()}";
                        await Task.Delay(5000);
                        

                    }
                    else
                    {
                        k++;
                    }

                }
                richTextBox2.Text = "";

                if (k == changestud.Count)
                {
                    richTextBox2.Text = $"Искомый студент не найден";
                    await Task.Delay(1000);
                    richTextBox2.Text = "";
                }
               

            }

            catch
            {
                MessageBox.Show("Ошибка", "DataBase");
            }
        }

      async  public void button14_Click(object sender, EventArgs e) //максы мины
        { double sum = 0;
            double[] sortball=new double [changestud.Count];
             for(int i = 0; i < changestud.Count; i++)
            {
                sortball[i] = changestud[i].ball;
                sum += sortball[i];
            }
            double average = sum / changestud.Count;
            double min = sortball.Min();
            double max = sortball.Max();
            richTextBox2.Text = $"Информация о средних баллах:\nMax={max} Min={min} Сумма={sum} Среднее значение={average}";
            await Task.Delay(5000);
            richTextBox2.Text = "";
        }

        private void richTextBox2_DoubleClick(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
        }

     async   private void button16_Click(object sender, EventArgs e) //сорт фио
        {
           
            studdent.Sort(new Fio_Compare());
            PRint();
            richTextBox2.Text = $"БД отсортирована по полю ФИО ";
            await Task.Delay(2000);
            richTextBox2.Text = "";

        }

      async  public void button17_Click(object sender, EventArgs e) //reverse sort fio
        { 
           
            studdent.Sort(new Fio_Compare());
            studdent.Reverse();
            PRint();
            richTextBox2.Text = $"БД отсортирована по полю ФИО в обратном порядке ";
            await Task.Delay(2000);
            richTextBox2.Text = "";

        }

     async   private void button18_Click(object sender, EventArgs e)
        {
            studdent.Sort(new Date_comparer());
            PRint(); richTextBox2.Text = $"БД отсортирована по полю Дата рождения  ";
            await Task.Delay(2000);
            richTextBox2.Text = "";
        }

      async  private void button19_Click(object sender, EventArgs e)
        {
            studdent.Sort(new Date_comparer());
            studdent.Reverse();
            PRint();
            richTextBox2.Text = $"БД отсортирована по полю ФИО в обратном порядке ";
            await Task.Delay(2000);
            richTextBox2.Text = "";
        }
        class Fio_Compare : IComparer<student>
        {
            public int Compare(student x, student y)
            {
                return (x.fio.CompareTo(y.fio));
            }
        }
       
        class Date_comparer : IComparer<student>
        {
            public int Compare(student x, student y)
            {
                return x.date.CompareTo(y.date); ;
            }
        }

     async   private void button15_Click(object sender, EventArgs e)//сохранить
        {
            DialogResult rez = MessageBox.Show("Вы хотите сохранить изменения?", "DataBase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rez == DialogResult.Yes)
                
            {
                string sas = "";
                using (StreamWriter Save = new StreamWriter("Base.txt",false, System.Text.Encoding.UTF8))
                {
                    for(int i = 0; i < studdent.Count; i++)
                    {
                        sas =(i+1).ToString()+" "+studdent[i].SaveToFile();
                        Save.WriteLine(sas);
                    }
                }
                    while (progressBar1.Value != 100)
                    {
                        progressBar1.Value++;

                        await Task.Delay(10);
                    }
                
                await Task.Delay(500);
                progressBar1.Value = 0;
                richTextBox2.Text = "Сохранение произведено";
                await Task.Delay(2000);
                richTextBox2.Text = "";
            }
            else
            {
                richTextBox2.Text = "Сохранение отменено";
                await Task.Delay(2000);
                richTextBox2.Text="";
            }
        }
    }
}
