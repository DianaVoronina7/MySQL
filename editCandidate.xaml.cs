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
    /// Логика взаимодействия для editCandidate.xaml
    /// </summary>
    public partial class editCandidate : Window
    {
        private readonly Candidate candidate;
        private bool isEditing;

        private readonly ObservableCollection<Vacancy> vacancies;

        public editCandidate(Candidate candidate)
        {
            InitializeComponent();

            this.candidate = candidate;
            isEditing = false;

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
            FillFields();
        }

        private void FillFields()
        {
            FirstNameTextBox.Text = candidate.FirstName;
            LastNameTextBox.Text = candidate.LastName;
            MiddleNameTextBox.Text = candidate.MiddleName;
            EmailTextBox.Text = candidate.Email;
            PhoneNumberTextBox.Text = candidate.PhoneNumber;
            ExperienceTextBox.Text = candidate.Experience;
            EducationTextBox.Text = candidate.Education;
            RecommendationsTextBox.Text = candidate.Recommendations;
            VacancyComboBox.SelectedItem = vacancies.FirstOrDefault(v => v.VacancyId == candidate.VacancyId);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            isEditing = true;
            EditButton.Visibility = Visibility.Collapsed;
            SaveButton.Visibility = Visibility.Visible;
            EnableControls();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (isEditing)
            {
                var newCandidate = new Candidate
                {
                    CandidateId = candidate.CandidateId,
                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    MiddleName = MiddleNameTextBox.Text,
                    Email = EmailTextBox.Text,
                    PhoneNumber = PhoneNumberTextBox.Text,
                    Experience = ExperienceTextBox.Text,
                    Education = EducationTextBox.Text,
                    Recommendations = RecommendationsTextBox.Text,
                    VacancyId = (VacancyComboBox.SelectedItem as Vacancy).VacancyId
                };

                using (var connection = new SqlConnection(Properties.Settings.Default.SqlString))
                {
                    connection.Open();
                    var command = new SqlCommand(@"UPDATE Кандидаты SET [Фамилия]=@lastName, [Имя]=@firstName, [Отчество]=@middleName, 
                                                  [Адрес электронной почты]=@email, [Номер телефона]=@phoneNumber, 
                                                  [Опыт работы]=@experience, [Образование]=@education, [Рекомендации]=@recommendations, [Код вакансии]=@vacancyId
                                                  WHERE [ID кандидата]=@candidateId", connection);
                    command.Parameters.AddWithValue("@lastName", newCandidate.LastName);
                    command.Parameters.AddWithValue("@firstName", newCandidate.FirstName);
                    command.Parameters.AddWithValue("@middleName", string.IsNullOrEmpty(newCandidate.MiddleName) ? DBNull.Value : (object)newCandidate.MiddleName);
                    command.Parameters.AddWithValue("@email", string.IsNullOrEmpty(newCandidate.Email) ? DBNull.Value : (object)newCandidate.Email);
                    command.Parameters.AddWithValue("@phoneNumber", string.IsNullOrEmpty(newCandidate.PhoneNumber) ? DBNull.Value : (object)newCandidate.PhoneNumber);
                    command.Parameters.AddWithValue("@experience", string.IsNullOrEmpty(newCandidate.Experience) ? DBNull.Value : (object)newCandidate.Experience);
                    command.Parameters.AddWithValue("@education", string.IsNullOrEmpty(newCandidate.Education) ? DBNull.Value : (object)newCandidate.Education);
                    command.Parameters.AddWithValue("@recommendations", string.IsNullOrEmpty(newCandidate.Recommendations) ? DBNull.Value : (object)newCandidate.Recommendations);
                    command.Parameters.AddWithValue("@vacancyId", newCandidate.VacancyId);
                    command.Parameters.AddWithValue("@candidateId", newCandidate.CandidateId);

                    command.ExecuteNonQuery();
                }

                candidate.FirstName = newCandidate.FirstName;
                candidate.LastName = newCandidate.LastName;
                candidate.MiddleName = newCandidate.MiddleName;
                candidate.Email = newCandidate.Email;
                candidate.PhoneNumber = newCandidate.PhoneNumber;
                candidate.Experience = newCandidate.Experience;
                candidate.Education = newCandidate.Education;
                candidate.Recommendations = newCandidate.Recommendations;
                candidate.VacancyId = newCandidate.VacancyId;

                DisableControls();
                isEditing = false;
                SaveButton.Visibility = Visibility.Collapsed;
                EditButton.Visibility = Visibility.Visible;

                MessageBox.Show("Кандидат успешно сохранен", "Сохранено", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void TextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (isEditing)
            {
                SaveButton.IsEnabled = !string.IsNullOrEmpty(LastNameTextBox.Text) && !string.IsNullOrEmpty(FirstNameTextBox.Text);
            }
        }

        private void EnableControls()
        {
            FirstNameTextBox.IsEnabled = true;
            LastNameTextBox.IsEnabled = true;
            MiddleNameTextBox.IsEnabled = true;
            EmailTextBox.IsEnabled = true;
            PhoneNumberTextBox.IsEnabled = true;
            ExperienceTextBox.IsEnabled = true;
            EducationTextBox.IsEnabled = true;
            RecommendationsTextBox.IsEnabled = true;
            VacancyComboBox.IsEnabled = true;
        }

        private void DisableControls()
        {
            FirstNameTextBox.IsEnabled = false;
            LastNameTextBox.IsEnabled = false;
            MiddleNameTextBox.IsEnabled = false;
            EmailTextBox.IsEnabled = false;
            PhoneNumberTextBox.IsEnabled = false;
            ExperienceTextBox.IsEnabled = false;
            EducationTextBox.IsEnabled = false;
            RecommendationsTextBox.IsEnabled = false;
            VacancyComboBox.IsEnabled = false;
        }
    }
}