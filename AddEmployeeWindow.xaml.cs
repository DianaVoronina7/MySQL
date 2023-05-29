using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        private string connectionString =  Properties.Settings.Default.SqlString;

        public AddEmployeeWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Сотрудники (Фамилия, Имя, Отчество, [Дата рождения], [Номер телефона], " +
                                   "[Адрес электронной почты], [Адрес проживания], [Дата приема на работу]) " +
                                   "VALUES (@Фамилия, @Имя, @Отчество, @Дата_рождения, @Номер_телефона, @Адрес_почты, " +
                                   "@Адрес_проживания, @Дата_приема)";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Фамилия", LastNameTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@Имя", FirstNameTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@Отчество", MiddleNameTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@Дата_рождения", DateOfBirthPicker.SelectedDate);
                    command.Parameters.AddWithValue("@Номер_телефона", PhoneNumberTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@Адрес_почты", EmailTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@Адрес_проживания", AddressTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@Дата_приема", DateTime.Now);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    connection.Close();

                    if (result > 0)
                    {
                        MessageBox.Show("Сотрудник успешно добавлен!"); // вывод сообщения об успешном добавлении сотрудника
                        this.Close(); // закрытие формы
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавлении сотрудника!"); // вывод сообщения об ошибке
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении сотрудника: " + ex.Message); // вывод сообщения об ошибке
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // закрытие формы при нажатии кнопки "Отмена"
        }
    }
}