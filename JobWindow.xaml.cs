using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Отдел_кадров
{
    /// <summary>
    /// Логика взаимодействия для JobWindow.xaml
    /// </summary>

    public partial class JobWindow : Window
    {
        public Job Job { get; set; }
        bool addTrue = false;

        private readonly string ConnectionString;

        public event PropertyChangedEventHandler PropertyChanged;


        public JobWindow(Job job)
        {
            InitializeComponent();

            if (job == null)
            {
                addTrue = true;
                Job = new Job();
            }
            else
            {
                Job = job;
                MessageBox.Show(job.Title);
                Titler.Text = job.Title;
                Desc.Text = job.Description;
                Req.Text = job.Requirements;
            }

            ConnectionString = Properties.Settings.Default.SqlString;

            if (addTrue)
            {
                Title = "Новая вакансия";
            }
            else
            {
                Title = "Редактировать вакансию";
            }
        }


        private void byButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (!addTrue)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE Вакансии SET [Название вакансии] = @Title, [Описание вакансии] = @Description, [Требования к кандидату] = @Requirements WHERE [ID вакансии] = @ID", connection);
                    command.Parameters.AddWithValue("@ID", Job.Id);
                    command.Parameters.AddWithValue("@Title", Titler.Text);
                    command.Parameters.AddWithValue("@Description", Desc.Text);
                    command.Parameters.AddWithValue("@Requirements", Req.Text);

                    connection.Open();
                    command.ExecuteNonQuery();

                    DialogResult = true;
                    Close();
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Вакансии ([Название вакансии], [Описание вакансии], [Требования к кандидату]) VALUES (@Title, @Description, @Requirements)", connection);
                    command.Parameters.AddWithValue("@Title", Titler.Text);
                    command.Parameters.AddWithValue("@Description", Desc.Text);
                    command.Parameters.AddWithValue("@Requirements", Req.Text);

                    connection.Open();
                    command.ExecuteNonQuery();

                    DialogResult = true;
                    Close();
                }
            }
        }
    }
}