using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsAndLog
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                OpenData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey(true);
        }

        static void OpenData()
        {
            //ReadLibrary();
            ReadBook();
        }

        static void ReadBook()
        {

            //try
            //{
            try
            {
                List<string> lista = ReadFromFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Eseguito Level3");
            //}
            //catch (MyException myEx)
            //{
            //    Console.WriteLine("Errore: " + myEx.Message);
            //    Console.WriteLine(myEx.Action);
            //}
            //catch (ArgumentException aEx)
            //{
            //    Console.WriteLine(aEx.Message);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Errore: " + ex.Message);

            //    if (ex is MyException)
            //    {
            //        var myEx = (MyException)ex;
            //        Console.WriteLine(myEx.Action);
            //    }
            //}
        }

        static List<string> ReadFromFile()
        {
            List<string> lista = new List<string>();
            FileStream fs = null;
            //foreach (var file in directory)
            //{
            try
            {
                fs = File.OpenRead("C:\\temp\\...");
                //fs.Read()

                ////leggo contenuto del file
                //throw new System.IO.FileNotFoundException("Errore in lettura del file");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Elementi della lista: " + lista.Count);//, ex);

                var myEx = new Exception("Errore in fase di lettura del file <NomeFile>", ex);

                throw myEx;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            //}

            return lista;

            //if (lista.Count > 0)
            //{
            //    var ex = new MyException("Errore più o meno dettagliato che consenta di capire cosa effettivamente non ha funzionato");
            //    ex.Action = "Ricerca con index";

            //    throw ex;
            //}
        }

        class MyException : Exception
        {
            public string Action { get; set; }

            public MyException(string message) : base(message)
            {
            }

            public MyException(string message, Exception innerException) : base(message, innerException)
            {
            }
        }
    }
}
