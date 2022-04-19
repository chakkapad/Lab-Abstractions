using System.Text;

namespace Lab_Abstractions
{
    public partial class Form1 : Form
    {
        private double sum1 = 0;
        private double sum2 = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV (*.csv) | *.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] readAlline = File.ReadAllLines(ofd.FileName);

                string readAllText = File.ReadAllText(ofd.FileName);
                for (int i = 0; i < readAlline.Length; i++)
                {
                    string allDATARAW = readAlline[i];
                    string[] allDATASplited = allDATARAW.Split(',');
                    this.dataGridView2.Rows.Add(allDATASplited[0], allDATASplited[1], allDATASplited[3]);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.sum1 += sum2;

            string User_or_Id = textBox1.Text;
            string Password = textBox2.Text;

            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "staff";
            dataGridView1.Rows[n].Cells[1].Value = sum1;
            dataGridView1.Rows[n].Cells[2].Value = User_or_Id;
            dataGridView1.Rows[n].Cells[3].Value = Password;

            textBox1.Text = " ";
            textBox2.Text = " ";



        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Major = comboBox1.Text;
            string SSID = textBox3.Text;
            string Name = textBox4.Text;
            string Password = textBox5.Text;
            string data = " NO DATA ";

            int n = dataGridView2.Rows.Add();

            if (Major == "staff")
            {
                staff Staff = new staff();

                Staff.Name = Name;
                Staff.SSID = SSID;
                Staff.Password = Password;

                dataGridView2.Rows[n].Cells[2].Value = Staff.Name;
                dataGridView2.Rows[n].Cells[1].Value = Staff.SSID;
                dataGridView2.Rows[n].Cells[3].Value = Staff.Password;
                dataGridView2.Rows[n].Cells[0].Value = data;


            }
            if (Major == "teacher")
            {
                teacher th = new teacher();

                th.majo = Major;
                th.Name = Name;
                th.SSID = SSID;

                dataGridView2.Rows[n].Cells[0].Value = th.majo;
                dataGridView2.Rows[n].Cells[2].Value = th.Name;
                dataGridView2.Rows[n].Cells[1].Value = th.SSID;
                dataGridView2.Rows[n].Cells[3].Value = data;
            }
            if (Major == "student")
            {
                student student = new student();

                student.Major = Major;
                student.Name = Name;
                student.SSID = SSID;

                dataGridView2.Rows[n].Cells[0].Value = student.Major;
                dataGridView2.Rows[n].Cells[2].Value = student.Name;
                dataGridView2.Rows[n].Cells[1].Value = student.SSID;
                dataGridView2.Rows[n].Cells[3].Value = data;
            }
            comboBox1.Text = null;
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV(*.csv)|*.csv";
                bool fileError = false;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView2.Columns.Count;
                            string column = "";
                            string[] outputCSV = new string[dataGridView2.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                column += dataGridView2.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCSV[0] += column;
                            for (int i = 1; (i - 1) < dataGridView2.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCSV[i] += dataGridView2.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(saveFileDialog.FileName, outputCSV, Encoding.UTF8);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
        }
    }
}