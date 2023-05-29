using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для IndexWindow.xaml
    /// </summary>
    public partial class IndexWindow : Window
    {
        public IndexWindow()
        {
            InitializeComponent();
            CategoryComboBox.Items.Add("Сотрудники");
            CategoryComboBox.Items.Add("Кандидаты");
            CategoryComboBox.Items.Add("Вакансии");
        }
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedItem = CategoryComboBox.SelectedItem.ToString();

            if (selectedItem == "Сотрудники")
            {
                StuffForm form = new StuffForm();
                Hide();
                form.ShowDialog();
                Show();
            }
            else if (selectedItem == "Кандидаты")
            {
                CandidatesForm form = new CandidatesForm();
                Hide();
                form.ShowDialog();
                Show();
            }
            else if (selectedItem == "Вакансии")
            {
                JobListWindow form = new JobListWindow();
                Hide();
                form.ShowDialog();
                Show();
            }
        }
    }
}
