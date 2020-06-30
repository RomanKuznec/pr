using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TPerson resp;
        class TPerson
        {
            public String fName;
            public String fSome;
            public int Salary;
            public TPerson(string fam, string name, int okl)
            {
                fSome = fam;
                fName = name;
                Salary = okl;
            }
            public virtual string info()
            {
                return fSome + ' ' + fName;
            }
            public virtual double GetSum()
            {
                return Salary;
            }
        }
        class Tstud : TPerson
        {
            public double fGr;
            public DateTime fGod;
            public string fGroup;
            public Tstud(string fam, string name, int okl, DateTime god, double gr, string group) : base(fam, name, okl)
            {
                fGr = gr;
                fGod = god;
                fGroup = group;

            }
            public override string info()
            {
                return (string.Format("студент{0}{1}{2}, Дата рождения {3}, средний балл{5}, стипендия{4}, группа{6}", fSome, ' ', fName, fGod.ToString("D"), Convert.ToDouble(GetSum()), Convert.ToDouble(fGr), fGroup));
            }
            public override double GetSum()
            {
                if (fGr >= 4.5) return Salary * 2;
                else if (fGr >= 3.5) return Salary * 1.5;
                else if (fGr < 3) return Salary * 0;
                else return Salary;

            }
        }
        class TProf : TPerson
        {
            public String fKat;
            public String fDep;
            public TProf(String fam, String name, int okl, String kat, String dep) :
                    base(fam, name, okl)
            {
                fKat = kat;
                fDep = dep;
            }
            public override String info()
            {
                return (string.Format("преподаватель {0}{1}{2} , категория {3}, кафедра {5}, зарплата {4}", fSome, ' ', fName, fKat, Convert.ToDouble(GetSum()), fDep));

            }
            public override double GetSum()
            {
                if (fKat == "высшая") return Salary * 1.7;
                else if (fKat == "первая") return Salary * 1.4;
                else return Salary;
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonGet_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGet.Checked)
            {
                labelDate.Text = "Дата рождения";
                labelNum.Text = "Номер группы";
                labelStip.Text = "Стипендия";
                textBoxP.Text = "";
                textBoxR.Text = "";
                textBoxS.Text = "";
                textBoxN.Text = "";
                textBoxG.Text = "";


            }

        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            if (radioButtonGet.Checked)
            {
                resp = new Tstud(textBoxP.Text, textBoxR.Text, Convert.ToInt32(textBoxG.Text), Convert.ToDateTime(textBoxS.Text), 3.6, textBoxN.Text);
            }
            if (radioButtonFam.Checked)

            {
                resp = new TProf(textBoxP.Text, textBoxR.Text, Convert.ToInt32(textBoxG.Text), textBoxS.Text, textBoxN.Text);
            }

            textBox1.AppendText(resp.info() + Environment.NewLine);
        }

        private void buttonFam_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButtonFam_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFam.Checked)

            {
                labelDate.Text = "Категория";
                labelNum.Text = "Название кафедры";
                labelStip.Text = "Оклад";
                textBoxP.Text = "";
                textBoxR.Text = "";
                textBoxS.Text = "";
                textBoxN.Text = "";
                textBoxG.Text = "";
            }
        }

        private void textBoxP_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxP_Click(object sender, EventArgs e)
        {
            if (radioButtonGet.Checked == false && radioButtonFam.Checked == false)
            {
                MessageBox.Show("Выберите кто вы, преподаватель или студент.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButtonGet.Checked)
            {
                resp = new Tstud(textBoxP.Text, textBoxR.Text, Convert.ToInt32(textBoxG.Text), Convert.ToDateTime(textBoxS.Text), 3.6, textBoxN.Text);
            }
            if (radioButtonFam.Checked)

            {
                resp = new TProf(textBoxP.Text, textBoxR.Text, Convert.ToInt32(textBoxG.Text), textBoxS.Text, textBoxN.Text);

            }

            textBox1.AppendText(resp.info() + Environment.NewLine);
        }
    }
}

