using ClassLibrary10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11_лабораторная_работа
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Dictionary
            //dictionary

            Dictionary<BankCard, DebitCard> dict = new Dictionary<BankCard, DebitCard>();
            Console.WriteLine($"в словаре {dict.Count} элементов");
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    DebitCard s = new DebitCard();
                    s.RandomInit();
                    var milliseconds = 300;
                    Thread.Sleep(milliseconds);
                    BankCard b = new BankCard(s.Number, s.Name, s.Term, s.id.number1);
                    dict.Add(b, s);
                }
                catch (Exception e)
                {
                    i--;
                }
            }
            Console.WriteLine("Dictionary:");
            foreach (var item in dict.Keys)
            {
                Console.WriteLine($"ключ: {item}, значение: {dict[item]}");
            }
            Console.WriteLine($"в словаре {dict.Count} элементов");
            //Console.WriteLine("vvedite element for search");



            Console.WriteLine("vvedite element for search");
            DebitCard find = new DebitCard();
            find.Init();

            BankCard b1 = new BankCard(find.Number, find.Name, find.Term, find.id.number1);
            dict.Add(b1, find);

            Console.WriteLine("Dictionary with new element:");
            foreach (var item in dict.Keys)
            {
                Console.WriteLine($"ключ: {item}, значение: {dict[item]}");
            }

            Console.WriteLine($" после добавления в словаре {dict.Count} элементов");



            Console.WriteLine("");
            if (dict.ContainsKey(b1))
                Console.WriteLine($"Найден по ключу"); //добавить ключ
            else
                Console.WriteLine("Не найден");


            Console.WriteLine("");
            if (dict.ContainsValue(find))
                Console.WriteLine($"Найден по значению"); //добавить значению
            else
                Console.WriteLine("Не найден");

            dict.Remove(b1);
            Console.WriteLine($" После удаления в словаре {dict.Count} элементов");
            Console.WriteLine($" Словарь после удаления:");
            foreach (var item in dict.Keys)
            {
                Console.WriteLine($"ключ: {item}, значение: {dict[item]}");
            }


            Dictionary<BankCard, DebitCard> dictclone = new Dictionary<BankCard, DebitCard>();
            foreach (var tt in dict)
            {
                DebitCard dictclonecard = tt.Value.Clone() as DebitCard;
                dictclone.Add(tt.Key, dictclonecard);
            }
            Console.WriteLine("КЛОН СЛОВАРЯ:");
            foreach (var item in dictclone.Keys)
            {
                Console.WriteLine($"ключ: {item}, значение: {dictclone[item]}");
            }





            #region ArrayList
            //ArrayList

            ArrayList list1 = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                BankCard c = new BankCard();
                list1.Add(c);
                c.RandomInit();
                var milliseconds = 300;
                Thread.Sleep(milliseconds);
            }
            for (int i = 0; i < 5; i++)
            {
                CreditCard r = new CreditCard();
                list1.Add(r);
                r.RandomInit();
                var milliseconds = 300;
                Thread.Sleep(milliseconds);
            }
            Console.WriteLine($" Лист для 1 задания:");
            list1.Sort();
            foreach (object c in list1)
            {
                Console.WriteLine(c.ToString());
            }



            Console.WriteLine($"Емкость = {list1.Capacity}");
            Console.WriteLine($"Количество элем = {list1.Count}");


            Console.WriteLine("Общий баланс дебетовых карт:"); //считаем вместе с молодежными
            double sum = 0;
            double count = 0;
            foreach (BankCard item in list1)
            {
                if (item is DebitCard t)
                {
                    sum += t.GetBalance();
                    count++;
                }
            }
            Console.WriteLine($"{sum} рублей");

            Console.WriteLine("");
            Console.WriteLine("Имена людей с истекшим сроком карты:");
            DateTime m = DateTime.UtcNow;
            foreach (BankCard item in list1)
            {
                if (item is BankCard s)
                    if (s.Term <= DateTime.Today)
                        Console.WriteLine(item.Name);
            }
            //search and remove
            Console.WriteLine("Введите элемент для поиска:");
            BankCard bankc = new BankCard();
            bankc.Init();
            list1[2] = bankc;
            list1.Sort();
            foreach (BankCard item in list1)
            { Console.WriteLine(item); }
            Console.WriteLine("");
            int pos = list1.IndexOf(bankc);
            if (pos >= 0)
            {
                Console.WriteLine($"Удалено: {list1[pos]}");
                list1.RemoveAt(pos);
            }
            if (list1.Contains(bankc))
            {
                Console.WriteLine("Найден");
            }
            else
                Console.WriteLine("Не найден");

            ArrayList sec_list = new ArrayList();
            sec_list = (ArrayList)list1.Clone();
            Console.WriteLine("\nElements of Cloned ArrayList: \n");
            foreach (object str1 in sec_list)
            {
                Console.WriteLine(str1);
            }
            BankCard card = new BankCard();
            card.RandomInit();
            BankCard card1 = new BankCard();
            card1.RandomInit();

            //YoungCard young = new YoungCard();
            //young.RandomInit();

            //DebitCard debit = new DebitCard();
            //debit.RandomInit();

            //CreditCard credit = new CreditCard();
            //credit.RandomInit();
            Console.WriteLine("");
            Console.WriteLine("Измерение времени коллекций:");
            TestCollection collection = new TestCollection(1000);
            collection.MeasureTime();


            #endregion
            #endregion

        }
    }
}
