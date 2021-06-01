using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.SqlConn;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace CsSQLServerTutorial
{
    class InsertDataExample
    {
        static void Main(string[] args)
        {

            SqlConnection connection = DBSQLServerUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Команда Insert.
                string sql = "Insert into Salary_Grade (Grade, High_Salary, Low_Salary) "
                                                 + " values (@grade, @highSalary, @lowSalary) ";

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                // Создать объект Parameter.
                SqlParameter gradeParam = new SqlParameter("@grade", SqlDbType.Int);
                gradeParam.Value = 3;
                cmd.Parameters.Add(gradeParam);

                // Добавить параметр @highSalary (Написать короче).
                SqlParameter highSalaryParam = cmd.Parameters.Add("@highSalary", SqlDbType.Float);
                highSalaryParam.Value = 20000;

                // Добавить параметр @lowSalary (Написать короче).
                cmd.Parameters.Add("@lowSalary", SqlDbType.Float).Value = 10000;

                // Выполнить Command (Используется для delete, insert, update).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }

            Console.Read();

        }
    }

}