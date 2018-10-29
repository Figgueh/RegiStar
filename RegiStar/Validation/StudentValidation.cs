using RegiStar.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RegiStar.Validation
{
    public class StudentValidation : ValidationRule
    {

        public List<int> getUsers()
        {
            List<int> userID = new List<int>();

            //Setup connection to database.
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7C48ELV;Initial Catalog=wpfRegistar;Integrated Security=True"))
            {
                //Open the connection.
                conn.Open();

                //Create query.
                using (SqlCommand cmd = new SqlCommand("SELECT userID FROM dbo.tblUsers", conn))
                {

                    //Setup reader to interpret the data.
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        //While reading the data:
                        while (reader.Read())
                        {
                            userID.Add(Convert.ToInt32(reader["userID"]));
                        }
                    }
                    return userID;
                }
            }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int studentNumber = Convert.ToInt32(value);

            foreach(int user in getUsers())
            {
                if(user == studentNumber)
                {
                    return new ValidationResult(false, "This student ID is already being used!");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
