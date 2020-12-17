using System;

namespace StringSimilaridadeCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StringSimilaridade.StringSimilaridade.retornaPercentual_Palavra("abacaxi com paçoca", "abacaxi banana"));


            Console.WriteLine(StringSimilaridade.StringSimilaridade.retornaPercentual_Palavra("abacaxi com paçoca", "banana banana"));

            Console.WriteLine(StringSimilaridade.StringSimilaridade.retornaPercentual_Palavra("abacaxi com paçoca", "abacaxi com hortela"));

            Console.ReadKey();
        }
    }
}
