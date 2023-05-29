using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для addCandidate.xaml
    /// </summary>
    public partial class addCandidate : Window
    {
        private readonly ObservableCollection<Vacancy> vacancies;

        public addCandidate()
        {
            InitializeComponent();

            vacancies = new ObservableCollection<Vacancy>();
            using (var connection = new SqlConnection(Properties.Settings.Default.SqlString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT [ID вакансии], [Название вакансии] FROM Вакансии", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var vacancy = new Vacancy
                    {
                        VacancyId = reader.GetInt32(0),
                        Title = reader.GetString(1)
                    };
                    vacancies.Add(vacancy);
                }
            }

            VacancyComboBox.ItemsSource = vacancies;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string lastName = LastNameTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string middleName = MiddleNameTextBox.Text;
            string email = EmailTextBox.Text;
            string phoneNumber = PhoneNumberTextBox.Text;
            string experience = ExperienceTextBox.Text;
            string education = EducationTextBox.Text;
            string recommendations = RecommendationsTextBox.Text;
            int vacancyId = (VacancyComboBox.SelectedItem as Vacancy).VacancyId;

            if (string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("Введите фамилию и имя кандидата", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var connection = new SqlConnection(Properties.Settings.Default.SqlString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Кандидаты ([Фамилия], [Имя], [Отчество], [Адрес электронной почты], [Номер телефона], [Опыт работы], [Образование], [Рекомендации], [Код вакансии]) VALUES (@lastName, @firstName, @middleName, @email, @phoneNumber, @experience, @education, @recommendations, @vacancyId)",
                                             connection);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@middleName", string.IsNullOrEmpty(middleName) ? DBNull.Value : (object)middleName);
                command.Parameters.AddWithValue("@email", string.IsNullOrEmpty(email) ? DBNull.Value : (object)email);
                command.Parameters.AddWithValue("@phoneNumber", string.IsNullOrEmpty(phoneNumber) ? DBNull.Value : (object)phoneNumber);
                command.Parameters.AddWithValue("@experience", string.IsNullOrEmpty(experience) ? DBNull.Value : (object)experience);
                command.Parameters.AddWithValue("@education", string.IsNullOrEmpty(education) ? DBNull.Value : (object)education);
                command.Parameters.AddWithValue("@recommendations", string.IsNullOrEmpty(recommendations) ? DBNull.Value : (object)recommendations);
                command.Parameters.AddWithValue("@vacancyId", vacancyId);

                command.ExecuteNonQuery();
            }

            DialogResult = true;
        }

        private void TextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            OkButton.IsEnabled = !string.IsNullOrEmpty(LastNameTextBox.Text) && !string.IsNullOrEmpty(FirstNameTextBox.Text);
        }
    }
}
