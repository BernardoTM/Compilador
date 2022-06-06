namespace Compilador
{
    public class Sintatico
    {
        public static void Run()
        {
            Queue<Token> filaToken = new Queue<Token>(Token.tokens);

            Token token;

            Token dequeue()
            {
                try
                {
                    return filaToken.Dequeue();
                }
                catch (Exception)
                {
                    return new Token(0, 0, "", "");
                }
            }

            token = dequeue();
            // while (token.Tipo != "")
            // {
            codigo();
            //  }

            void codigo()
            {
                if (token.Tipo == "Variavel ")
                {
                    //System.Console.WriteLine("atribuicao");
                    atribuicao();
                    if (token.Nome == ";")
                    {
                        token = dequeue();
                        codigo();
                    }
                    else
                    {
                        //  throw new Exception("Era esperado ; no final da linha " + (token.Linha - 1));
                        System.Console.WriteLine("Era esperado ; no final da linha " + (token.Linha - 1));
                    }
                }
                else if (token.Tipo == "Tipo")
                {
                    //System.Console.WriteLine("declaracao");
                    declaracao();
                    if (token.Nome == ";")
                    {
                        token = dequeue();
                        codigo();
                    }
                    else
                    {
                        System.Console.WriteLine("Era esperado ; no final da linha " + (token.Linha - 1));
                    }

                }
                else if (token.Tipo == "Palavra reservada for")
                {
                    //System.Console.WriteLine("repeticao");
                    repeticao();
                    codigo();
                }
                else if (token.Tipo == "Palavra reservada if")
                {
                    //System.Console.WriteLine("decisao");
                    decisao();
                    codigo();
                }
                else if (token.Nome == "{")
                {
                    //System.Console.WriteLine("bloco");
                    bloco();
                    codigo();

                }

            }


            void atribuicao()
            {
                token = dequeue();
                if (token.Nome == "=")
                {
                    //System.Console.WriteLine("espracao");
                    token = dequeue();
                    esprecao();
                }
                else
                {
                    // //System.Console.WriteLine("erro");
                    //erro
                }
                //   token = dequeue();
                if (token.Nome != ";")
                {
                    //erro
                }
            }
            void declaracao()
            {
                token = dequeue();
                if (token.Tipo == "Variavel ")
                {
                    //System.Console.WriteLine("atribuicao");
                    atribuicao();
                }
                else
                {
                    System.Console.WriteLine("Era esperado Variavel na " + token.Linha + " e coluna " + token.Coluna);

                }
                if (token.Nome == ",")
                {
                    //System.Console.WriteLine("declaracao");
                    declaracao();
                }
                else if (token.Tipo == "Variavel ")
                {
                    throw new Exception("Era esperado , na " + token.Linha + " e coluna " + token.Coluna);
                }



            }
            void decisao()
            {
                token = dequeue();
                if (token.Nome == "(")
                {
                    token = dequeue();
                    esprecaologica();
                }
                else
                {
                    System.Console.WriteLine("Era esperado ( na " + token.Linha + " e coluna " + token.Coluna);
                }
                if (token.Nome == ")")
                {
                    token = dequeue();
                    if (token.Nome == "{")
                    {

                        //System.Console.WriteLine("bloco");
                        bloco();
                    }
                    else
                    {
                        throw new Exception("Esprecao invalida na linha " + token.Linha);
                    }

                }
                else
                {
                    System.Console.WriteLine("Era esperado ) na " + token.Linha + " e coluna " + token.Coluna);
                }
                if (token.Tipo == "Palavra reservada else")
                {
                    token = dequeue();
                    if (token.Nome == "{")
                    {

                        //System.Console.WriteLine("bloco");
                        bloco();
                    }
                    else
                    {
                        System.Console.WriteLine("Era esperado { na " + token.Linha + " e coluna " + token.Coluna);
                    }
                }

            }

            void repeticao()
            {
                token = dequeue();
                if (token.Nome == "(")
                {
                    token = dequeue();
                    if (token.Tipo == "Tipo")
                    {
                        //System.Console.WriteLine("declaracao");
                        declaracao();
                    }
                    else if (token.Tipo == "Variavel ")
                    {
                        //System.Console.WriteLine("atribuicao");
                        atribuicao();
                    }
                    else if (token.Tipo == "")
                    {
                        ////ok
                    }
                    else
                    {
                        System.Console.WriteLine("Esprecao invalida na linha " + token.Linha + " e coluna " + token.Coluna);
                    }

                    if (token.Nome == ";")
                    {
                        //System.Console.WriteLine("esprecaologica");
                        token = dequeue();
                        esprecaologica();
                    }
                    else
                    {
                        throw new Exception("Era esperado ; na " + token.Linha + " e coluna " + token.Coluna);
                        //System.Console.WriteLine("Era esperado ; na " + token.Linha + " e coluna " + token.Coluna);
                    }

                    if (token.Nome == ";")
                    {
                        //System.Console.WriteLine("incremento");
                        token = dequeue();
                        atribuicao();
                    }
                    else
                    {
                        System.Console.WriteLine("Era esperado ; na " + token.Linha + " e coluna " + token.Coluna);
                    }

                    if (token.Nome == ")")
                    {
                        token = dequeue();
                        if (token.Nome == "{")
                        {

                            //System.Console.WriteLine("bloco");
                            bloco();
                        }
                        else
                        {
                            System.Console.WriteLine("Era esperado { na " + token.Linha + " e coluna " + token.Coluna);
                        }

                    }
                    else
                    {
                        throw new Exception("Esprecao invalida na linha " + token.Linha);
                    }


                }
                else
                {
                    System.Console.WriteLine("Era esperado ( na " + token.Linha + " e coluna " + token.Coluna);
                }

            }

            void bloco()
            {
                token = dequeue();
                codigo();
                if (token.Nome == "}")
                {
                    ////ok 
                    token = dequeue();
                }
                else
                {
                    System.Console.WriteLine("Era esperado } na " + token.Linha + " e coluna " + token.Coluna);

                }
            }
            void esprecaologica()
            {
                //System.Console.WriteLine("esprecao");
                esprecao();
                if (token.Nome == ">" || token.Nome == "<" || token.Nome == "==" || token.Nome == ">=" || token.Nome == "<=")
                {
                    //System.Console.WriteLine("esprecao");
                    token = dequeue();
                    esprecao();
                }
                if (token.Nome == "&&" || token.Nome == "!!")
                {
                    //System.Console.WriteLine("esprecaologica");
                    token = dequeue();
                    esprecaologica();
                }

            }
            void esprecao()
            {
                //System.Console.WriteLine("T");
                T();
                //System.Console.WriteLine("Elinha");
                Elinha();

            }

            void T()
            {
                if (token.Nome == "(" || token.Tipo == "Variavel " || token.Tipo == "Numeral int " || token.Tipo == "Numeral float ")
                {
                    //System.Console.WriteLine("F");
                    F();
                    //System.Console.WriteLine("Tlinha");
                    Tlinha();
                }
                else
                {
                    throw new Exception("Esprecao invalida na linha " + token.Linha + " e coluna " + token.Coluna);

                }
            }
            void F()
            {
                if (token.Nome == "(")
                {
                    token = dequeue();
                    esprecao();
                    if (token.Nome == ")")
                    {
                        ////ok
                        token = dequeue();
                    }
                    else
                        throw new Exception("Esprecao invalida na linha " + token.Linha);

                }
                else if (token.Tipo == "Variavel " || token.Tipo == "Numeral int " || token.Tipo == "Numeral float ")
                {
                    token = dequeue();
                    ////ok
                }

            }

            void Elinha()
            {
                if (token.Nome == "+" || token.Nome == "-")
                {
                    token = dequeue();
                    //System.Console.WriteLine("Tlinha");
                    T();
                    //System.Console.WriteLine("Elinha");
                    Elinha();
                }
            }

            void Tlinha()
            {
                if (token.Nome == "*" || token.Nome == "/")
                {
                    token = dequeue();
                    //System.Console.WriteLine("F");
                    F();
                    //System.Console.WriteLine("Tlinha");
                    Tlinha();
                }
            }
        }
    }
}