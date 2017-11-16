using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperLogger.Targets
{
    public class DatabaseLogTarget : ILogTarget
    {
        private readonly string _connectionString;

        public DatabaseLogTarget(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void WriteLog(LogEntry info)
        {
            //creare connessione al db

            using (var conn = new SqlConnection(_connectionString))
            {

                //creare cmd
                var cmd = conn.CreateCommand();
                cmd.CommandText = "insert into Log (Source, Date, Level, Message, Exception) values(@Source,@Date,@Level,@Message,@Exception)";
                //riempire parametri 

                AddParameter(cmd, "Source", "Alexis");
                AddParameter(cmd, "Date", info.Date);
                AddParameter(cmd, "Level", info.Level.ToString());
                AddParameter(cmd, "Message", info.Message);
                AddParameter(cmd, "Exception", CreateMessageForException(info));

                //aprire connessione
                conn.Open();
                //eseguire comando
                cmd.ExecuteNonQuery();
                //chiudere connessione
                conn.Close();
            }

        }

        private static string CreateMessageForException(LogEntry info)
        {
            if (info.Exception != null)
                return info.Exception.Message + " - " + info.Exception.StackTrace;
            else
                return null;
        }

        private static void AddParameter(SqlCommand cmd, string parameterName, object parameterValue)
        {
            var param = cmd.CreateParameter();
            param.ParameterName = parameterName;
            if (parameterValue == null)
                parameterValue = DBNull.Value;

            param.Value = parameterValue;
            cmd.Parameters.Add(param);
        }
    }
}
