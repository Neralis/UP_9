using System;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UP_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGenerateArrays_Click(object sender, EventArgs e)
        {
            // ������������� ���������� ��������� �����
            Random random = new Random();

            // �������� ���������� ������� L[8, 8]
            double[,] L = new double[8, 8];

            // ���������� ������� �� ������� L = 250 - r
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    double r = random.NextDouble();
                    L[i, j] = 250 - r;
                }
            }

            // ����� ����������� �������� � ��� ��������
            double maxElement = double.MinValue;
            int maxRowIndex = 0;
            int maxColIndex = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (L[i, j] > maxElement)
                    {
                        maxElement = L[i, j];
                        maxRowIndex = i;
                        maxColIndex = j;
                    }
                }
            }

            // ����� ������� ������� � TextBox1
            textBox1.Text = "������ ������ (L):\r\n";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    textBox1.AppendText($"{L[i, j]:F2}\t");
                }
                textBox1.AppendText("\r\n");
            }

            // ����� ����������� �������� � ��� ��������
            textBox1.AppendText($"\r\n���������� �������: {maxElement}\r\n");
            textBox1.AppendText($"�������: [{maxRowIndex}, {maxColIndex}]\r\n");

            // ������� ���� ��������� �� ��������� ���������� �������
            textBox2.Text = "������ ������ (����� ������� �� ���������� �������):\r\n";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    L[i, j] /= maxElement;
                    textBox2.AppendText($"{L[i, j]:F2}\t");
                }
                textBox2.AppendText("\r\n");
            }
        }


        // tab2-------------------------------------------------------------------------------------------


        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            double[,] X = new double[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    X[i, j] = i / (double)(i + j);
                }
            }

            textBox3.Text = "������ (X):\r\n";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    textBox3.AppendText($"{X[i, j]:F3}\t");
                }
                textBox3.AppendText("\r\n");
            }

            double sum = 0;
            int count = 0;

            for (int i = 1; i < 4; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    double currentElement = X[i, j];

                    if (currentElement > 0.2 && currentElement < 0.3)
                    {
                        sum += currentElement;
                        count++;
                    }
                }
            }

            // Assuming label1 and label2 are the names of your labels
            label1.Text = $"Sum: {sum:F3}";
            label2.Text = $"Count: {count}";
        }

    }
}
