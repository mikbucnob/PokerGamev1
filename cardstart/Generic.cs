using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class Generic<T>
        where T : IMyInterface
    {
        private T myvariable;

        public T Myvariable { get => myvariable; set => myvariable = value; }

        public T DoStuff(T i)
        {
            T t = default(T);
            t.AvailableMethod(); // <- guaranteed because T is where : IMyINterface.
                                 // If we didn't have the where : constraint, we don't know if t will have this
                                 // method or not.... OK?
                                 //cant do int types

            if (i > 5)
            {
                return myvariable;
            }
            else
            {
                
            }
        }
    }
}
