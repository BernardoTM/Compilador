//using System;
namespace Compilador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lexico.Run();
            try
            {

                Sintatico.Run();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}


