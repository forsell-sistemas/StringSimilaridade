
Module Module1

    Sub Main()
        Console.WriteLine(StringSimilaridade.StringSimilaridade.retornaPercentual_Palavra("abacaxi com paçoca", "abacaxi banana"))


        Console.WriteLine(StringSimilaridade.StringSimilaridade.retornaPercentual_Palavra("abacaxi com paçoca", "banana banana"))

        Console.WriteLine(StringSimilaridade.StringSimilaridade.retornaPercentual_Palavra("abacaxi com paçoca", "abacaxi com hortela"))

        Console.ReadKey()
    End Sub

End Module
