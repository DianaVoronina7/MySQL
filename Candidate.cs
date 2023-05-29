using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Отдел_кадров
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public string Recommendations { get; set; }
        public int VacancyId { get; set; }
        public string Vacansy { get; set; }

        public Candidate() { }

        public Candidate(DataRow row)
        {
            CandidateId = (int)row["ID кандидата"];
            LastName = (string)row["Фамилия"];
            FirstName = (string)row["Имя"];
            MiddleName = (string)row["Отчество"];
            Email = (string)row["Адрес электронной почты"];
            PhoneNumber = (string)row["Номер телефона"];
            Experience = (string)row["Опыт работы"];
            Education = (string)row["Образование"];
            Recommendations = (string)row["Рекомендации"];
            Vacansy = (string)row["Vacansy"];
            VacancyId = (int)row["VacancyId"];
        }

        public void PopulateRow(DataRow row)
        {
            row["Фамилия"] = LastName ?? "";
            row["Имя"] = FirstName ?? "";
            row["Отчество"] = MiddleName ?? "";
            row["Адрес электронной почты"] = Email ?? "";
            row["Номер телефона"] = PhoneNumber ?? "";
            row["Опыт работы"] = Experience ?? "";
            row["Образование"] = Education ?? "";
            row["Рекомендации"] = Recommendations ?? "";
            row["Vacansy"] = Vacansy ?? "";
            row["VacancyId"] = VacancyId;
        }

        public void Delete()
        {
            using (var connection = new SqlConnection(Properties.Settings.Default.SqlString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Кандидаты WHERE [ID кандидата] = @candidateId", connection);
                command.Parameters.AddWithValue("@candidateId", CandidateId);

                command.ExecuteNonQuery();
            }
        }
    }
}
