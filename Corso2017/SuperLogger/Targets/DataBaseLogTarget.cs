using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static SuperLogger.LogEntry;

namespace SuperLogger.Targets
{
    public class DataBaseLogTarget : ILogTarget

    {
        public void WriteLog(LogEntry info)
        {
            using (IDbConnection conn = CreateConnection())
            {

                string sql = "insert into Log (Source,Date,Message,Exception,Level) VALUES (@source, @date, @message, @exception, @level)";
                var cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                AddObject("Branz Adamo", cmd, "source");
                AddObject(info.Date, cmd, "date");
                AddObject(info.Message, cmd, "message");
                AddObject(info.Level.ToString(), cmd, "level");
                AddObject(CreateMexException(info), cmd, "exception");
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }

        }

        private static string CreateMexException(LogEntry info)
        {
            if(info.Exception != null)
            {
                return info.Exception.Message;
            }
            else
            {
                return null;
            }
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection("Server=192.168.9.219;Database=Logger;User Id=corso;Password=corso;");
        }

        

        private void AddObject(object inputParam, IDbCommand cmd, string paramName)
        {
            var param = cmd.CreateParameter();
            param.ParameterName = paramName;
            if (inputParam != null)
            {
                param.Value = inputParam;
            }
            else
            {
                param.Value = DBNull.Value;
            }
            cmd.Parameters.Add(param);

        }
    }
}



