using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperLogger.LogEntry;

namespace SuperLogger.Targets
{
    public class DBLogTarget : ILogTarget
    {
       
        internal const string User = "AlexisT";
        internal static string exception;
        internal static string message;
        internal static LogLevel Level;
        internal static DateTime Date;



        public void WriteLog(LogEntry info)
        {
           //Debug.WriteLine($"{ info.Date } - { info.Level } - { info.Message }");
            if (info.Exception != null)
            {


                exception = ($"Exception: { info.Exception.GetType().ToString() }");
                message = ($"Exception: { info.Exception.GetType().ToString() }");
                Level = info.Level;
                Date = info.Date;

                using (IDbConnection conn = CreateConnection())
                {
                    conn.Open();

                    //ExecuteScalar(conn);
                    //ExecuteReader(conn);
                    ExecuteNonQuery(conn);
                }

                Console.ReadKey(true);
            }

            

        }


        private static IDbConnection CreateConnection()
        {
            return new SqlConnection("Server=192.168.9.219;Database=Logger;User Id=corso;Password=corso;");
        }

        private static void ExecuteNonQuery(IDbConnection conn)
        {
            //string idUser = "AlexisT";
            
            

            using (IDbTransaction tran = conn.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                //stesso per DELETE e per INSERT

                //string sql = $"update Corso set Id_aula={ idUser }, CF_Docente='{ exception }' where id={ idCorso }";
                string sql = "insert Corso set Source=@User, Date=@Date, Level=@Level, Message=@message, Exception=@exception where id=@idCorso";
                var cmd = conn.CreateCommand();
                cmd.Transaction = tran;
                cmd.CommandText = sql;

                

                var user = cmd.CreateParameter();
                //idAulaParam.DbType = DbType.Int32;
                //idAulaParam.Direction = ParameterDirection.Input;
                user.ParameterName = "User";
                user.Value = user;
                cmd.Parameters.Add(user);

                var exceptValue = cmd.CreateParameter();
                exceptValue.ParameterName = "exception";
                exceptValue.Value = exception;
                cmd.Parameters.Add(exceptValue);

                var LevelValue = cmd.CreateParameter();
                LevelValue.ParameterName = "Level";
                LevelValue.Value = Level;
                cmd.Parameters.Add(LevelValue);

                int rows = cmd.ExecuteNonQuery();

                tran.Commit();
            }
        }

        private static void ExecuteReader(IDbConnection conn)
        {
            string sql = "select * from CorsiPerStudente";
            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            StringBuilder sb = new StringBuilder();
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        sb.AppendFormat("col[{0}]={1} | ", i, reader.GetValue(i));
                    }

                    sb.AppendLine();
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}

