using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для StuffForm.xaml
    /// </summary>
    public partial class StuffForm : Window
    {
        private List<Employee> _employees;
        public event PropertyChangedEventHandler PropertyChanged;


        public List<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Employees)));
            }
        }

        public StuffForm()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Сотрудники", connection);
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    Employees = dataTable.AsEnumerable().Select(row =>
                        new Employee
                        {
                            EmployeeId = row.Field<int>("ID сотрудника"),
                            LastName = row.Field<string>("Фамилия"),
                            FirstName = row.Field<string>("Имя"),
                            MiddleName = row.Field<string>("Отчество"),
                            DateOfBirth = row.Field<DateTime?>("Дата рождения"),
                            PhoneNumber = row.Field<string>("Номер телефона"),
                            Email = row.Field<string>("Адрес электронной почты"),
                            Address = row.Field<string>("Адрес проживания"),
                            HireDate = row.Field<DateTime>("Дата приема на работу"),
                            FireDate = row.Field<DateTime?>("Дата увольнения")
                        }).ToList();

                    EmployeeDataGrid.ItemsSource = Employees;
                }
            }
            catch (Exception ex)
            {
                ErrorTextBlock.Text = ex.Message;
                ErrorTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.Owner = this;
            addEmployeeWindow.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = EmployeeDataGrid.SelectedItem as Employee;
            if (selectedEmployee != null)
            {
                EditEmployeeWindow editEmployeeWindow = new EditEmployeeWindow(selectedEmployee);
                editEmployeeWindow.Owner = this;
                editEmployeeWindow.ShowDialog();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = EmployeeDataGrid.SelectedItem as Employee;
            if (selectedEmployee != null)
            {
                if (MessageBox.Show("Вы действительно хотите уволить выбранного сотрудника?", "Удаление сотрудника", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlString))
                        {
                            string query = "UPDATE Сотрудники SET [Дата увольнения]=@Дата_увольнения WHERE [ID сотрудника]=@id";

                            SqlCommand command = new SqlCommand(query, connection);

                            command.Parameters.AddWithValue("@id", selectedEmployee.EmployeeId);
                            command.Parameters.AddWithValue("@Дата_увольнения", DateTime.Now);

                            connection.Open();
                            int result = command.ExecuteNonQuery();
                            connection.Close();

                            if (result > 0)
                            {
                                selectedEmployee.FireDate = DateTime.Now;
                                MessageBox.Show("Сотрудник успешно уволен!"); // вывод сообщения об успешном увольнении сотрудника
                            }
                            else
                            {
                                MessageBox.Show("Ошибка при увольнении сотрудника!"); // вывод сообщения об ошибке
                            }

                            Employees.Remove(selectedEmployee);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorTextBlock.Text = ex.Message;
                        ErrorTextBlock.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLowerInvariant();

            ICollectionView view = CollectionViewSource.GetDefaultView(Employees);
            view.Filter = o =>
            {
                Employee employee = o as Employee;
                if (employee == null)
                    return false;

                string fullName = $"{employee.LastName} {employee.FirstName} {employee.MiddleName}".ToLowerInvariant();
                return fullName.Contains(searchText);
            };
        }

    }
}
