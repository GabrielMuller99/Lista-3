using System;
using System.Collections.Generic;

namespace Lista03_ED
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "...Uma atividade livre, conscientemente tomada como 'não-séria' e exterior à vida habitual, mas ao mesmo tempo capaz de" +
                " absorver o jogador de maneira intensa e total. É uma atividade desligada de todo e qualquer interesse material, com a qual não se " +
                "pode obter qualquer lucro, praticada dentro de limites espaciais e temporais próprios, segundo uma certa ordem e certas regras. " +
                "Promove a formação de grupos sociais com tendência a rodearem-se de segredo e a sublinharem sua diferença em relação ao resto do mundo " +
                "por meio de disfarces ou outros meios semelhantes.";

            string textTwo = "1+ (5 +3 - (8-5)*4 - ((3+7)*(3-1)))";

            string[] sentence = text.ToLower().Split(new string[] { ",", ".", "'", " "}, StringSplitOptions.RemoveEmptyEntries);
            char[] expression = textTwo.ToCharArray();

            Console.WriteLine("-----QUESTÃO 1-----");
            List<string> differentList = QuestaoUm(sentence);
            Console.WriteLine(differentList.Count);

            Console.WriteLine();
            Console.WriteLine("-----QUESTÃO 2-----");
            QuestaoDois(sentence, differentList);

            Console.WriteLine();
            Console.WriteLine("-----QUESTÃO 3-----");
            Console.WriteLine("Foi utilizado a estrutura Pilha");
            QuestaoTres(expression);
            Console.ReadKey();
        }

        public static List<string> QuestaoUm(string[] sentence)
        {
            bool isDifferent = true; //saber se a palavra é diferente ou não para adicionar na lista de palavras diferentes
            string auxWord; //auxiliar para guardar a string atual do texto
            int count = 1; //auxiliar para saber o quanto o segundo FOR vai percorrer o array de string do texto 
            List<string> words = new List<string>();

            for (int i = 0; i < sentence.Length; i++)
            {
                if (count == 1)                 //primeiro caso
                {
                    words.Add(sentence[i]);
                }
                else {                          //proximos casos
                    auxWord = sentence[i];

                    for (int j = 0; j < count - 1; j++) //compara a palavra atual i com as anteriores para ver se tem repetição
                    {
                        if (auxWord == sentence[j])
                        {
                            isDifferent = false;
                        }
                    }

                    if (isDifferent) //se for diferente coloca na lista de diferentes
                    {
                        words.Add(auxWord);
                    }

                    isDifferent = true; 
                }

                count++;
            }

            return words;
        }

        public static void QuestaoDois(string[] sentence, List<string> words)
        {
            int equals = 0; //variavel que conta quantos numeros iguais tem

            for (int i = 0; i < words.Count; i++)       //percorre a lista feita na questao um e as compara com as palavras do texto para saber quantas existem
            {                
                for (int j = 0; j < sentence.Length; j++) 
                {
                    if (words[i] == sentence[j])
                    {
                        equals++;
                    }
                }

                Console.WriteLine(words[i] + " " + equals);
                equals = 0;
            }
        }

        public static void QuestaoTres(char[] expression)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)         //percorre a expressão para achar os parenteses
            {
                if (stack.Count == 0 && expression[i] == '(')   //se a pilha está vazia e for parenteses aberto, sera empilhado
                {
                    stack.Push(expression[i]);
                    Console.Write(expression[i]);
                }
                else if (stack.Count == 0 && expression[i] == ')')  //se a pilha está vazia e for parenteses fechado, da erro
                {
                    Console.WriteLine("Os parênteses estão dispostos da forma errada!");
                }
                else if (expression[i] == '(' || expression[i] == ')')  
                {
                    if (stack.Peek() == '(' && expression[i] == ')')
                    {
                        stack.Pop();
                        Console.Write(expression[i]);
                    }
                    else if (stack.Peek() == '(' && expression[i] == '(')
                    {
                        stack.Push(expression[i]);
                        Console.Write(expression[i]);
                    }
                }
            }

            if(stack.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Os parênteses estão dispostos da forma correta!");
            }
        }
    }
}
