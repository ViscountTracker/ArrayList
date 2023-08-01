using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Windows.Markup;

namespace ArrayList
{
    public class EntryPoint
    {
        static void Main()
        {
            ArrayList<String> arList = new ArrayList<String>(2);
            arList.Add("1");
            arList.Add("2");
            arList.Add("3");
            arList.Clear();
        }
    }
    public class ArrayList<T>
    {
        private T[] Values;
        private int Count;
        private int Capacity;
        private float MultiPlaer;
        private float PercentToDecrease;

        public ArrayList() : this(8) { }

        public ArrayList(int inputCapacity)
        {
            Count = 0;
            Capacity = inputCapacity;
            Values = new T[Capacity];
            MultiPlaer = 1.5f;
            PercentToDecrease = 0.25f;
        }

        public void Add(T Value)
        {
            if (Count == Capacity)
            {
                Capacity = (int)(Capacity * MultiPlaer);
                T[] TempArray = new T[Capacity];
                for (int i = 0; i < Count; i++)
                {
                    TempArray[i] = Values[i];
                }
                Values = TempArray;
                Console.WriteLine(Capacity);
                Console.WriteLine(Count);
                Console.WriteLine(Values.Length);
            }
            Values[Count] = Value;

            Count++;
        }

        public T Get(int index)
        {
            if (index > Capacity)
            {
                throw new Exception("Not in range");
            }
            return Values[index];
        }

        public void Remove(T elementToRemove)
        {
            #region Step by step for create methods Remove()
            // [1,2,3,4,5] -  inputArray,
            // ElementToRemove = 3; - Index to remove + 1 = 2;
            //tempArray - values copy in this array
            //IndexToRemove= index with new values
            //  inputArray.length - IndexToRemove -1;     
            #endregion

            int indexToRemove = Array.IndexOf(Values, elementToRemove);

            if (indexToRemove >= 0)
            {
                var tempArray = new T[Capacity];
                Array.Copy(Values, 0, tempArray, 0, indexToRemove);
                Array.Copy(Values, indexToRemove + 1, tempArray, indexToRemove, Values.Length - indexToRemove - 1);
                Count--;
                Values = tempArray;
            }
            if (Count < PercentToDecrease * Capacity)
            {
                Capacity /= 2;
                var tempArray = new T[Capacity];
                Array.Copy(Values, 0, tempArray, 0, Count);
                Values = tempArray;
            }
        }
        public void Clear()
        {
            Count = 0;
            Values = new T[Capacity];
        }
    }
}