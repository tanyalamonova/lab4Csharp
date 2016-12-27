using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _4sharp
{
    class Program
    {
        class Token
        {
            public string data;
            public int recipient;

            public Token(string text, int number)
            {
                data = text;
                recipient = number;
            }
        }

        static void Opener(int index, Token token)
        {

            if (index < token.recipient)
            {
                Console.WriteLine("thread #" + index.ToString() + " got a token");
                Thread thread = new Thread(() => Opener(index + 1, token));
                thread.Start();
            }
            else
            {
                Console.WriteLine("thread #" + index.ToString() + " received a token: " + token.data);
            }
            //Console.WriteLine("thread #" + index.ToString() + " ended");
        }

        static void Main(string[] args)
        {

            Token token = new Token("ho ho ho!", 3000);
            Opener(1, token);
            
            Console.Read();

        }
     }
}
