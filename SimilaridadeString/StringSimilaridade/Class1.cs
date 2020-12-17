using System;

namespace StringSimilaridade
{
     public class StringSimilaridade
        {
            public static double retornaPercentual_Palavra(string fonte, string alvo)
            {
                double percentualAcerto, aux, qntOK;
                int contadorFonte, contadorAlvo;
                percentualAcerto = 0;
                contadorFonte = fonte.Split().Length;
                contadorAlvo = alvo.Split().Length;
                if (contadorFonte == 0)
                    contadorFonte = 1;
                if (contadorAlvo == 0)
                    contadorAlvo = 1;
                foreach (string a in alvo.Split()) // String pesquisada
                {
                    aux = 0;
                    qntOK = 0;
                    foreach (string f in fonte.Split()) // String Fonte
                    {
                        aux = retornaPercentual(f, a);
                        if (aux >= 66)
                        {
                            qntOK += 1;
                            break;
                        }
                    }
                    percentualAcerto += (qntOK / contadorFonte) * 100;
                }
                percentualAcerto = percentualAcerto / contadorAlvo;
                return percentualAcerto;
            }

            public static double retornaPercentual(string fonte, string alvo)
            {
                fonte = fonte.ToLower();
                alvo = alvo.ToLower();
                int tm = Math.Max(fonte.Length, alvo.Length);
                int sb = DamerauLevenshteinDistance(fonte, alvo);
                double po = Math.Round((-(System.Convert.ToDouble(sb) / System.Convert.ToDouble(tm)) + 1) * 100, 2);
                return po;
            }

            private static int DamerauLevenshteinDistance(string fonte, string alvo)
            {
                if (string.IsNullOrEmpty(fonte) || fonte.Trim() == string.Empty)
                {
                    if (!string.IsNullOrEmpty(alvo))
                        return alvo.Length;
                    return 0;
                }

                if (string.IsNullOrEmpty(alvo) || alvo.Trim() == string.Empty)
                {
                    if (!string.IsNullOrEmpty(fonte))
                        return fonte.Length;
                    return 0;
                }

                int length1 = fonte.Length;
                int length2 = alvo.Length;
                int[,] d = new int[length1 + 1 - 1 + 1, length2 + 1 - 1 + 1];
                int cost, del, ins, sub;

                for (int i = 0; i <= d.GetUpperBound(0); i++)
                    d[i, 0] = i;

                for (int i = 0; i <= d.GetUpperBound(1); i++)
                    d[0, i] = i;

                for (int i = 1; i <= d.GetUpperBound(0); i++)
                {
                    for (int j = 1; j <= d.GetUpperBound(1); j++)
                    {
                        if (fonte[i - 1] == alvo[j - 1])
                            cost = 0;
                        else
                            cost = 1;

                        del = d[i - 1, j] + 1;
                        ins = d[i, j - 1] + 1;
                        sub = d[i - 1, j - 1] + cost;
                        d[i, j] = Math.Min(del, Math.Min(ins, sub));
                        if (i > 1 && j > 1 && fonte[i - 1] == alvo[j - 2] && fonte[i - 2] == alvo[j - 1])
                            d[i, j] = Math.Min(d[i, j], d[i - 2, j - 2] + cost);
                    }
                }

                return d[d.GetUpperBound(0), d.GetUpperBound(1)];
            }
        }

}
