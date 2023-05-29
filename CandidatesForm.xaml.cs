using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для CandidatesForm.xaml
    /// </summary>
    public partial class CandidatesForm : Window
    {
        private string ConnectionString;
        private SqlDataAdapter Adapter;
        private DataTable Table;

        private ObservableCollection<Candidate> candidates;
        public ObservableCollection<Candidate> Candidates
        {
            get => candidates;
            set
            {
                candidates = value;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public CandidatesForm()
        {
            InitializeComponent();

            ConnectionString = Properties.Settings.Default.SqlString;
            loadData();
        }
        public void loadData()
        {
            Adapter = new SqlDataAdapter("SELECT Кандидаты.*, Вакансии.[Название вакансии] AS Vacansy, Вакансии.[ID вакансии] AS VacancyId FROM Кандидаты, Вакансии WHERE Вакансии.[ID вакансии] = Кандидаты.[Код вакансии]", ConnectionString);
            Table = new DataTable();
            Adapter.Fill(Table);

            Candidates = new ObservableCollection<Candidate>(Table.AsEnumerable().Select(row => new Candidate(row)).ToList());
            CandidatesDataGrid.ItemsSource = Candidates;
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            Adapter.Fill(Table);
            Candidates = new ObservableCollection<Candidate>(Table.AsEnumerable().Select(row => new Candidate(row)).ToList());
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            addCandidate form = new addCandidate();
            form.ShowDialog();
            loadData();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Candidate SelectedCandidate = CandidatesDataGrid.SelectedItem as Candidate;
            var editCandidateWindow = new editCandidate(SelectedCandidate);
            editCandidateWindow.ShowDialog();
            loadData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Candidate SelectedCandidate = CandidatesDataGrid.SelectedItem as Candidate;
            if (MessageBox.Show("Вы действительно хотите удалить выбранного кандидата?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                SelectedCandidate.Delete();
                Candidates.Remove(SelectedCandidate);
                Adapter.Update(Table);
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = (sender as TextBox).Text;
            ICollectionView view = CollectionViewSource.GetDefaultView(Candidates);
            if (filter == "")
                view.Filter = null;
            else
                view.Filter = obj =>
                {
                    Candidate candidate = obj as Candidate;
                    return candidate.LastName.Contains(filter) || candidate.FirstName.Contains(filter) || candidate.MiddleName.Contains(filter) ||
                           candidate.Email.Contains(filter) || candidate.PhoneNumber.Contains(filter) || candidate.Experience.Contains(filter) ||
                           candidate.Education.Contains(filter) || candidate.Recommendations.Contains(filter);
                };
        }
    }
}