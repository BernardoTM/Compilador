using System.Text.RegularExpressions;

namespace Compilador
{
    public class Lexico
    {
        public static void Run()
        {


            var erros = new List<Erro>();

            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] Linhas = System.IO.File.ReadAllLines(@"../Codigos/Codigo_fonte.txt");

            char[] umaLinha;
            for (int linha = 0; linha < Linhas.Length; linha++)
            {
                int coluna = 0;
                string auxiliar = "";
                umaLinha = Linhas[linha].ToCharArray();
                for (int i = 0; i < umaLinha.Length; i++)
                {

                    //pega os operadores expeciais
                    if (umaLinha[i] == '/')
                    {
                        if (i < umaLinha.Length - 1 && umaLinha[i + 1] == '/')
                        {
                            auxiliar = "";
                            coluna = i;
                            for (; i < umaLinha.Length; i++)
                            {
                                if (Regex.Match(umaLinha[i].ToString(), @"[\n]").Success)
                                {
                                    break;

                                }
                                auxiliar += umaLinha[i];
                            }
                            break;
                        }
                    }

                    else if (umaLinha[i] == '+')
                    {
                        if (i < umaLinha.Length - 1 && umaLinha[i + 1] == '+')
                        {
                            auxiliar = "";
                            coluna = i;
                            for (; i < umaLinha.Length; i++)
                            {
                                if (Regex.Match(umaLinha[i].ToString(), Regexs.operador_duplo_sep).Success)
                                {
                                    break;

                                }
                                auxiliar += umaLinha[i];
                            }
                            i--;
                            Token.tokens.Add(new Token(linha, coluna, "Operador ++ ", auxiliar));
                        }
                    }
                    else if (umaLinha[i] == '-')
                    {
                        if (i < umaLinha.Length - 1 && umaLinha[i + 1] == '-')
                        {
                            auxiliar = "";
                            coluna = i;
                            for (; i < umaLinha.Length; i++)
                            {
                                if (Regex.Match(umaLinha[i].ToString(), Regexs.operador_duplo_sep).Success)
                                {
                                    break;

                                }
                                auxiliar += umaLinha[i];
                            }
                            i--;
                            Token.tokens.Add(new Token(linha, coluna, "Operador -- ", auxiliar));
                        }
                    }
                    else if (umaLinha[i] == '=')
                    {
                        if (i < umaLinha.Length - 1 && umaLinha[i + 1] == '=')
                        {
                            auxiliar = "";
                            coluna = i;
                            for (; i < umaLinha.Length; i++)
                            {
                                if (Regex.Match(umaLinha[i].ToString(), Regexs.operador_duplo_sep).Success)
                                {
                                    break;

                                }
                                auxiliar += umaLinha[i];
                            }
                            i--;
                            Token.tokens.Add(new Token(linha, coluna, "Operador == ", auxiliar));
                        }
                    }
                    else if (umaLinha[i] == '>')
                    {
                        if (i < umaLinha.Length - 1 && umaLinha[i + 1] == '=')
                        {
                            auxiliar = "";
                            coluna = i;
                            for (; i < umaLinha.Length; i++)
                            {
                                if (Regex.Match(umaLinha[i].ToString(), Regexs.operador_duplo_sep).Success)
                                {
                                    break;

                                }
                                auxiliar += umaLinha[i];
                            }
                            i--;
                            Token.tokens.Add(new Token(linha, coluna, "Operador >= ", auxiliar));
                        }
                    }
                    else if (umaLinha[i] == '<')
                    {
                        if (i < umaLinha.Length - 1 && umaLinha[i + 1] == '=')
                        {
                            auxiliar = "";
                            coluna = i;
                            for (; i < umaLinha.Length; i++)
                            {
                                if (Regex.Match(umaLinha[i].ToString(), Regexs.operador_duplo_sep).Success)
                                {
                                    break;

                                }
                                auxiliar += umaLinha[i];
                            }
                            i--;
                            Token.tokens.Add(new Token(linha, coluna, "Operador <= ", auxiliar));
                        }
                    }
                    else if (umaLinha[i] == '&')
                    {
                        if (i < umaLinha.Length - 1 && umaLinha[i + 1] == '&')
                        {
                            auxiliar = "";
                            coluna = i;
                            for (; i < umaLinha.Length; i++)
                            {
                                if (Regex.Match(umaLinha[i].ToString(), Regexs.operador_duplo_sep).Success)
                                {
                                    break;

                                }
                                auxiliar += umaLinha[i];
                            }
                            i--;
                            Token.tokens.Add(new Token(linha, coluna, "Operador logico && ", auxiliar));
                        }
                    }
                    else if (umaLinha[i] == '!')
                    {
                        if (i < umaLinha.Length - 1 && umaLinha[i + 1] == '!')
                        {
                            auxiliar = "";
                            coluna = i;
                            for (; i < umaLinha.Length; i++)
                            {
                                if (Regex.Match(umaLinha[i].ToString(), Regexs.operador_duplo_sep).Success)
                                {
                                    break;

                                }
                                auxiliar += umaLinha[i];
                            }
                            i--;
                            Token.tokens.Add(new Token(linha, coluna, "Operador logico || ", auxiliar));
                        }
                    }
                    //pega os identificadores e palavas reservadas
                    if (Regex.Match(umaLinha[i].ToString(), Regexs.letras).Success)
                    {
                        auxiliar = "";
                        coluna = i;
                        for (; i < umaLinha.Length; i++)
                        {
                            if (Regex.Match(umaLinha[i].ToString(), Regexs.stringSep).Success)
                            {
                                break;

                            }
                            auxiliar += umaLinha[i];
                        }
                        i--;
                        if (Regex.Match(auxiliar, Regexs.stringVali).Success)
                        {
                            var tipo = Reservadas.palavras.GetValueOrDefault(auxiliar, "Variavel ");
                            Token.tokens.Add(new Token(linha, coluna, tipo, auxiliar));
                        }
                        else
                        {
                            erros.Add(new Erro(linha, coluna, "Erro na declaração ", auxiliar));
                        }
                    }

                    //pega literais
                    else if (Regex.Match(umaLinha[i].ToString(), Regexs.numeros).Success)
                    {
                        auxiliar = "";
                        coluna = i;
                        for (; i < umaLinha.Length; i++)
                        {
                            if (Regex.Match(umaLinha[i].ToString(), Regexs.numeroSep).Success)
                            {
                                break;

                            }
                            auxiliar += umaLinha[i];
                        }
                        i--;

                        if (Regex.Match(auxiliar, Regexs.floatVali).Success)
                        {

                            Token.tokens.Add(new Token(linha, coluna, "Numeral float ", auxiliar));
                        }
                        else if (Regex.Match(auxiliar, Regexs.intVali).Success)
                        {
                            Token.tokens.Add(new Token(linha, coluna, "Numeral int ", auxiliar));
                        }
                        else
                        {
                            erros.Add(new Erro(linha, coluna, "Numero invalido ", auxiliar));
                        }
                    }

                    //pega operador aritimedico
                    else if (Regex.Match(umaLinha[i].ToString(), Regexs.aritimetico).Success)
                    {
                        coluna = i;
                        var tipo = Reservadas.operadores.GetValueOrDefault(umaLinha[i].ToString(), "");
                        Token.tokens.Add(new Token(linha, coluna, tipo, umaLinha[i].ToString()));
                    }
                }
            }
            foreach (var token in Token.tokens)
            {
                token.ImprimeToken();
            }
            System.Console.WriteLine();
            foreach (var erro in erros)
            {
                erro.ImprimeToken();
            }
        }

    }
}