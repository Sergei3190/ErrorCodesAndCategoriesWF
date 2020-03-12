using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCodesAndCategoriesWF.Models
{
    public class SqlCommands
    {
        NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public void AddErrorCodes(int code, string text)
        {
            using (var connect = new SqlConnection(ConnectDataBase.ConnectionString))
            {
                connect.Open();
                Logger.Debug("Добавление данных в таблицу БД [ErrorCodes]");
                SqlCommand addErrorCodes = new SqlCommand("EXEC AddErrorCodes @code, @text", connect);
                addErrorCodes.Parameters.AddWithValue("@code", code);
                addErrorCodes.Parameters.AddWithValue("@text", text);
                addErrorCodes.ExecuteScalar();
            }
        }

        public void AddCategories(int id, string name, int parent, string image)
        {
            using (var connect = new SqlConnection(ConnectDataBase.ConnectionString))
            {
                connect.Open();
                Logger.Debug("Добавление данных в таблицу БД [Categories]");
                SqlCommand addCategories = new SqlCommand("EXEC AddCategories @id, @name, @parent, @image", connect);
                addCategories.Parameters.AddWithValue("@id", id);
                addCategories.Parameters.AddWithValue("@name", name);
                addCategories.Parameters.AddWithValue("@parent", parent);
                addCategories.Parameters.AddWithValue("@image", image);
                addCategories.ExecuteScalar();
            }
        }
    }
}
