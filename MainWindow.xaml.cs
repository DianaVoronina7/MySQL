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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Отдел_кадров
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection connection;
        private string connectionString = Properties.Settings.Default.SqlString;

        public MainWindow()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);

        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();

                string login = LoginTextBox.Text;
                string password = PasswordPasswordBox.Password;

                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Пользователи WHERE Login=@Login AND Password=@Password", connection);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    IndexWindow mainWindow = new IndexWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
            catch (Exception ex)
            {
                string message = $"Ошибка при выполнении запроса: {ex.Message}";
                MessageBox.Show(message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
