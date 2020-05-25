using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace задача_6_лр5
{
    class StackT<T> : IEnumerable<T>
    {
        private class Element
        {

            public Element Next { get; set; }
            public T Val { get; set; }

            public Element() { }
            public Element(T a)
            {
                Val = a;
                Next = null;
            }

        }
        Element Head = null;
        public void PushHead(T a)
        {
            Element tmp = new Element(a);
            tmp.Next = Head;
            Head = tmp;
        }
        public void PushTail(T a)
        {
            Element tmp = new Element(a);
            if (Head != null)
            {
                Element t = Head;
                while (t.Next != null)
                {
                    t = t.Next;
                }
                t.Next = tmp;
            }
            else
            {
                Head = tmp;
            }
        }


        public int Count
        {
            get
            {
                int count = 0;
                if (Head != null)
                {
                    Element t = Head;
                    while (t != null)
                    {
                        count++;
                        t = t.Next;
                    }
                    return count;
                }
                else
                    return 0;
            }


        }
        public T PopHead()
        {

            if (Head != null)
            {
                T a = Head.Val;
                Head = Head.Next;
                return a;
            }
            else
                return default(T);

        }
        public T PopTail()
        {
            if (Head != null)
            {
                if (Head.Next != null)
                {
                    Element t = Head;
                    while (t.Next.Next != null)
                    {
                        t = t.Next;
                    }
                    T a = t.Next.Val;
                    t.Next = null;
                    return a;
                }
                else
                {
                    T a = Head.Val;
                    Head = null;
                    return a;
                }
            }
            else
                return default(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var tmp = Head;
            while (tmp != null)
            {
                yield return tmp.Val;
                tmp = tmp.Next;
            }
        }
        // Интерфейс IEnumerable<T> наследуется от интерфейса IEnumerable, который придется реализовать
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            string s = "";
            if (Head != null)
            {
                Element t = Head;
                while (t != null)
                {
                    s += t.Val + " ";
                    t = t.Next;
                }
                return s;
            }
            else
                return s;
        }
    }
}
