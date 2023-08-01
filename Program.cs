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

    }
}