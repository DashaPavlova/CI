using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задача_6_лр5
{
    class Program
    {
        static StackT<int> Input(int n)
        {
            StackT<int> tmp = new StackT<int>();
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                tmp.PushTail(rnd.Next(0, 10));
            return tmp;
        }
        static void Output(StackT<int> tmp)
        {
            StackT<int> a = new StackT<int>();
            while (tmp.Count > 0)
            {
                int n = (int)tmp.PopHead();
                Console.WriteLine(n);
                a.PushTail(n);
            }
            while (a.Count > 0)
            {
                tmp.PushTail((int)a.PopHead());
            }

        }
        /// <summary>
        /// Вставка в дек перед предыдущим элементом, равным введенному числу с клавиатуры, число равное произведению предыдущего и элемента
        /// </summary>
        /// <param name="tmp">Исходный дек</param>
        /// <param name="tmp3">Новый дек</param>
        /// <param name="K">Искомый элемент</param>
        /// <returns>Исходный дек</returns>
        static StackT<int> Vstavka(StackT<int> tmp, int K)
        {
            StackT<int> tmp3 = new StackT<int>();
            StackT<int> tmp1 = new StackT<int>();
            foreach(int y in tmp)
            {
                tmp1.PushTail(y);
            }
            while (tmp1.Count>1)
            {
                int x = (int)tmp1.PopHead();//Предыдущий элемент
                //Console.WriteLine("x={0}",x);
                int c = (int)tmp1.PopHead();// Элемент, который сравниваем
                //Console.WriteLine("c={0}",c);
                if (c==K)
                {
                    tmp3.PushTail(x*K);
                    tmp3.PushTail(x);
                }
                else
                {
                    tmp3.PushTail(x);
                }
                tmp1.PushHead(c);//Возвращаем элемент в дек
                //Console.WriteLine("--------------------------");
            }
            tmp3.PushTail(tmp1.PopHead());//Записываем самый последний элемент, перед которым уже пусто
            return tmp3;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите количество элементов дека");
                int C = int.Parse(Console.ReadLine());
                if (C > 0)
                {
                    StackT<int> st = new StackT<int>();
                    st = Input(C);
                    Console.WriteLine("Исходный дек:");
                    Output(st);
                    Console.WriteLine("Введите число для сравнения");
                    int K = int.Parse(Console.ReadLine());
                    StackT<int> tmp3 = new StackT<int>();
                    tmp3 = Vstavka(st, K);
                    Console.WriteLine("Новый дек:");
                    Output(tmp3);
                    //Console.WriteLine("------------");
                    //Output(st);
                }
                else
                {
                    Console.WriteLine("Размерность не может быть меньше или равна нуля");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

