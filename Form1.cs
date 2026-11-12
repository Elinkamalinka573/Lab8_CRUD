using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace Lab8_CRUD
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=PC238-11;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();

            buttonAdd.Click += buttonAdd_Click;
            buttonUpdate.Click += buttonUpdate_Click;
            buttonDelete.Click += buttonDelete_Click;
            buttonClear.Click += buttonClear_Click;
            buttonExport.Click += buttonExport_Click;
            buttonCancel.Click += buttonCancel_Click;

            dataGridViewStudents.SelectionChanged += dataGridViewStudents_SelectionChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DataTable dataTable = new DataTable();
                string query = "SELECT Id, FullName, Age, GroupName, AverageGrade FROM Students";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dataTable);
                }

                dataGridViewStudents.DataSource = dataTable;

                labelStatus.Text = $"Всего студентов: {dataTable.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
                labelStatus.Text = "Ошибка загрузки";
            }
        }

        private void dataGridViewStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewStudents.CurrentRow != null && dataGridViewStudents.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dataGridViewStudents.CurrentRow;
                textBoxName.Text = row.Cells["FullName"].Value?.ToString() ?? "";
                numericAge.Value = row.Cells["Age"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["Age"].Value) : 0;
                textBoxGroup.Text = row.Cells["GroupName"].Value?.ToString() ?? "";
                // Обратите внимание на имя ячейки AverageGrade
                numericGrade.Value = row.Cells["AverageGrade"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["AverageGrade"].Value) : 0;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Поле ФИО не может быть пустым!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsStudentExists(textBoxName.Text))
            {
                MessageBox.Show("Студент с таким ФИО уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Students (FullName, Age, GroupName, AverageGrade) VALUES (@name, @age, @group, @score)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@age", (int)numericAge.Value);
                    cmd.Parameters.AddWithValue("@group", textBoxGroup.Text);
                    cmd.Parameters.AddWithValue("@score", (double)numericGrade.Value);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.CurrentRow == null) return;
            if (string.IsNullOrWhiteSpace(textBoxName.Text)) return;

            int id = Convert.ToInt32(dataGridViewStudents.CurrentRow.Cells["Id"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Students SET FullName=@name, Age=@age, GroupName=@group, AverageGrade=@score WHERE Id=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@age", (int)numericAge.Value);
                    cmd.Parameters.AddWithValue("@group", textBoxGroup.Text);
                    cmd.Parameters.AddWithValue("@score", (double)numericGrade.Value);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
                labelStatus.Text = "Данные обновлены";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.CurrentRow == null) return;

            if (MessageBox.Show("Вы уверены, что хотите удалить студента?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridViewStudents.CurrentRow.Cells["Id"].Value);

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Students WHERE Id=@id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadData();
                    ClearFields();
                    labelStatus.Text = "Студент удален";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления: " + ex.Message);
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            labelStatus.Text = "Поля очищены";
        }

        private void ClearFields()
        {
            textBoxName.Clear();
            numericAge.Value = 0;
            textBoxGroup.Clear();
            numericGrade.Value = 0;
            dataGridViewStudents.ClearSelection();
        }

        private bool IsStudentExists(string fullName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Students WHERE FullName = @name", conn);
                cmd.Parameters.AddWithValue("@name", fullName);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV файл|*.csv", FileName = "students.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("ФИО;Возраст;Группа;Средний балл");

                    foreach (DataGridViewRow row in dataGridViewStudents.Rows)
                    {
                        if (row.IsNewRow) continue;
                        // Обратите внимание на имя ячейки AverageGrade
                        sb.AppendLine($"{row.Cells["FullName"].Value};{row.Cells["Age"].Value};{row.Cells["GroupName"].Value};{row.Cells["AverageGrade"].Value}");
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Экспорт завершен!");
                    labelStatus.Text = "Данные экспортированы";
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearFields();
            MessageBox.Show("Данные обновлены из базы.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            labelStatus.Text = "Изменения отменены";
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}