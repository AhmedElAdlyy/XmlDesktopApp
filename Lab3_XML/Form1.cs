using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lab3_XML
{
    public partial class Form1 : Form
    {
        xmlOperations xmlOp = new xmlOperations();
        int empID = 0;
        int lastIndex;
        XmlNode currentNode;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayEmp();
            lastIndex = xmlOp.LastIndex;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (empID < lastIndex)
            {
                ++empID;
            }

            DisplayEmp();
        }



        private void DisplayEmp()
        {
            XmlNode emp = xmlOp.GetEmployee(empID);

            currentNode = emp;

            textBox1.Text = emp.ChildNodes[0].InnerText;
            textBox2.Text = emp.ChildNodes[1].InnerText;
            textBox3.Text = emp.ChildNodes[2].InnerText;
            textBox4.Text = emp.ChildNodes[3].InnerText;
        }

        private void DisplayEmp(XmlNode emp)
        {

            currentNode = emp;

            textBox1.Text = emp.ChildNodes[0].InnerText;
            textBox2.Text = emp.ChildNodes[1].InnerText;
            textBox3.Text = emp.ChildNodes[2].InnerText;
            textBox4.Text = emp.ChildNodes[3].InnerText;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (empID > 0)
            {
                --empID;
            }
            DisplayEmp();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XmlNode emp = xmlOp.SearchByName(textBox1.Text.ToLower());

            if (emp != null)
            {
                currentNode = emp;
                textBox2.Text = emp.ChildNodes[1].InnerText;
                textBox3.Text = emp.ChildNodes[2].InnerText;
                textBox4.Text = emp.ChildNodes[3].InnerText;
            }
            else
            {
                MessageBox.Show("Not Found");
                ClearBox();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = xmlOp.UpdateEmployee(currentNode, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

            if (result)
            {
                MessageBox.Show("Employee update successfully");
            }
            else
            {
                MessageBox.Show("something went wrong");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClearBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlNode newEmp = xmlOp.CreateEmployee(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            MessageBox.Show("Employee add successfully");
            DisplayEmp(newEmp);
            this.Invalidate();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            var result = xmlOp.RemoveEmployee(currentNode);
            if (result)
            {
                MessageBox.Show("Employee Deleted succesfully");
                ClearBox();
            }
            else
            {
                MessageBox.Show("something went wrong");
            }
        }

        private void ClearBox()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
            empID = 0;
        }
    }
}
