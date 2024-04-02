using ClassLibrary10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _11_лабораторная_работа
{
    public class TestCollection
    {
        LinkedList<DebitCard> collection1 = new LinkedList<DebitCard>();
        LinkedList<string> collection2 = new LinkedList<string>();  
        SortedDictionary<BankCard, DebitCard> collection3 = new SortedDictionary<BankCard, DebitCard>();
        SortedDictionary<string, DebitCard> collection4 = new SortedDictionary<string, DebitCard>();
        
        DebitCard first, middle, last;
        DebitCard noexist = new DebitCard();
        Stopwatch sw = new Stopwatch();

        public TestCollection(int length) 
        {
            for (int i = 0; i < length; i++)
            {
                try
                {
                    DebitCard debit = new DebitCard();
                    debit.RandomInit();
                    debit.Name += i.ToString();
                    collection1.AddLast(debit);
                    collection2.AddLast(debit.ToString());

                    collection3.Add(debit.GetBase, debit);//хз вторая штука я хз чем должна быть
                    collection4.Add(debit.GetBase.ToString(), debit);
                    if (i == 0)
                        first = (DebitCard)debit.Clone();
                    if (i == length / 2)
                        middle = (DebitCard)debit.Clone();
                    if (i == length - 1)
                        last = (DebitCard)debit.Clone();
                    
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex); ;
                }



            }
        }
       
        public void MeasureTime()
        {
            //foreach (var item in collection1)
            //{
            //    Console.WriteLine(item);
            //}
            
            Console.WriteLine("Поиск первого элемента");
            sw.Restart();
            bool isFindCol1 = collection1.Contains(first);
            sw.Stop();
            if(isFindCol1)
                Console.WriteLine($"элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindCol2 = collection2.Contains(first.ToString());
            sw.Stop();
            if (isFindCol2)
                Console.WriteLine($"элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindCol3 = collection3.ContainsKey(first.GetBase); //key
            sw.Stop();
            if (isFindCol3)
                Console.WriteLine($"элемент по ключу найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"элемент по ключу не найден за {sw.ElapsedTicks}");

           

            sw.Restart();
            bool isFindCol4 = collection4.ContainsKey(first.GetBase.ToString()); //добавить с containsvalue
            sw.Stop();
            if (isFindCol4)
                Console.WriteLine($"элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"элемент не найден за {sw.ElapsedTicks}");



            Console.WriteLine("Поиск последнего элемента");
            sw.Restart();
            bool isFindLastCol1 = collection1.Contains(last);
            sw.Stop();
            if (isFindLastCol1)
                Console.WriteLine($"элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindLastCol2 = collection2.Contains(last.ToString());
            sw.Stop();
            if (isFindLastCol2)
                Console.WriteLine($"элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindLastCol3 = collection3.ContainsKey(last.GetBase); 
            sw.Stop();
            if (isFindLastCol3)
                Console.WriteLine($"элемент по ключу найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"элемент по ключу не найден за {sw.ElapsedTicks}");

           

            sw.Restart();
            bool isFindLastCol4 = collection4.ContainsKey(last.GetBase.ToString()); //добавить с containsvalue
            sw.Stop();
            if (isFindLastCol4)
                Console.WriteLine($"элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"элемент не найден за {sw.ElapsedTicks}");




            Console.WriteLine("Поиск среднего элемента");
            sw.Restart();
            bool isFindLMiddleCol1 = collection1.Contains(middle);
            sw.Stop();
            if (isFindLMiddleCol1)
                Console.WriteLine($"элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindLMiddleCol2 = collection2.Contains(middle.ToString());
            sw.Stop();
            if (isFindLMiddleCol2)
                Console.WriteLine($"элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindLMiddleCol3 = collection3.ContainsKey(middle.GetBase); //key
            sw.Stop();
            if (isFindLMiddleCol3)
                Console.WriteLine($"элемент по ключу найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"элемент по ключу не найден за {sw.ElapsedTicks}");

            

            sw.Restart();
            bool isFindLMiddleCol4 = collection4.ContainsKey(middle.GetBase.ToString()); //добавить с containsvalue
            sw.Stop();
            if (isFindLMiddleCol4)
                Console.WriteLine($"элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"элемент не найден за {sw.ElapsedTicks}");



            Console.WriteLine("Поиск несуществующего элемента");
            sw.Restart();
            bool isFindLNoExistCol1 = collection1.Contains(noexist);
            sw.Stop();
            if (isFindLNoExistCol1)
                Console.WriteLine($"элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindLNoExistCol2 = collection2.Contains(noexist.ToString());
            sw.Stop();
            if (isFindLNoExistCol2)
                Console.WriteLine($"элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"элемент не найден за {sw.ElapsedTicks}");

            sw.Restart();
            bool isFindLNoExistCol3 = collection3.ContainsKey(noexist.GetBase); //key
            sw.Stop();
            if (isFindLNoExistCol3)
                Console.WriteLine($"элемент по ключу найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"элемент по ключу не найден за {sw.ElapsedTicks}");

           

            sw.Restart();
            bool isFindLNoExistCol4 = collection4.ContainsKey(noexist.GetBase.ToString()); //добавить с containsvalue
            sw.Stop();
            if (isFindLNoExistCol4)
                Console.WriteLine($"элемент найден за {sw.ElapsedTicks}");
            else
                Console.WriteLine($"элемент не найден за {sw.ElapsedTicks}");

           
        }
    }
}
