using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для JobListWindow.xaml
    /// </summary>
    public partial class JobListWindow : Window
    {
        private List<Job> jobs = new List<Job>();

        public JobListWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            SqlConnection connection = null;
            jobs.Clear();
            try
            {
                connection = new SqlConnection(Properties.Settings.Default.SqlString);
                connection.Open();

                string query = "SELECT * FROM Вакансии";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Job job = new Job()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("ID вакансии")),
                        Title = reader.GetString(reader.GetOrdinal("Название вакансии")),
                        Description = reader.IsDBNull(reader.GetOrdinal("Описание вакансии")) ? null : reader.GetString(reader.GetOrdinal("Описание вакансии")),
                        Requirements = reader.IsDBNull(reader.GetOrdinal("Требования к кандидату")) ? null : reader.GetString(reader.GetOrdinal("Требования к кандидату"))
                    };
                    jobs.Add(job);
                }
                JobDataGrid.ItemsSource = jobs;
                JobDataGrid.Items.Refresh();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            jobs.Clear();
            LoadData();
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            JobWindow window = new JobWindow(null);
            window.ShowDialog();
            LoadData();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (JobDataGrid.SelectedItem != null)
            {
                Job selectedJob = ((Job)JobDataGrid.SelectedItem);

                JobWindow window = new JobWindow(selectedJob);
                window.ShowDialog();
                LoadData();
            }
        }
    }
}
