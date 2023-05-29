using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        private string connectionString = Properties.Settings.Default.SqlString;

        public Employee SelectedEmployee { get; set; }

        public EditEmployeeWindow(Employee employee)
        {
            InitializeComponent();
            SelectedEmployee = employee;
            LastNameTextBox.Text = employee.LastName;
            FirstNameTextBox.Text = employee.FirstName;
            MiddleNameTextBox.Text = employee.MiddleName;
            DateOfBirthPicker.SelectedDate = employee.DateOfBirth;
            PhoneNumberTextBox.Text = employee.PhoneNumber;
            EmailTextBox.Text = employee.Email;
            AddressTextBox.Text = employee.Address;
            HireDatePicker.SelectedDate = employee.HireDate;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Сотрудники SET Фамилия=@Фамилия, Имя=@Имя, Отчество=@Отчество, " +
                                   "[Дата рождения]=@Дата_рождения, [Номер телефона]=@Номер_телефона, " +
                                   "[Адрес электронной почты]=@Адрес_почты, [Адрес проживания]=@Адрес_проживания, " +
                                   "[Дата приема на работу]=@Дата_приема WHERE [ID сотрудника]=@Id";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Id", SelectedEmployee.EmployeeId);
                    command.Parameters.AddWithValue("@Фамилия", LastNameTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@Имя", FirstNameTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@Отчество", MiddleNameTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@Дата_рождения", DateOfBirthPicker.SelectedDate);
                    command.Parameters.AddWithValue("@Номер_телефона", PhoneNumberTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@Адрес_почты", EmailTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@Адрес_проживания", AddressTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@Дата_приема", HireDatePicker.SelectedDate);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    connection.Close();

                    if (result > 0)
                    {
                        MessageBox.Show("Данные сотрудника успешно обновлены!"); // вывод сообщения об успешном обновлении данных сотрудника
                        this.Close(); // закрытие формы
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при обновлении данных сотрудника!"); // вывод сообщения об ошибке
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении данных сотрудника: " + ex.Message); // вывод сообщения об ошибке
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // закрытие формы при нажатии кнопки "Отмена"
        }
    }
}
