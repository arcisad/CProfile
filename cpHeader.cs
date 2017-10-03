using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cProfile
{
   public struct cpHeader<T>
    {
        public T[] size;  
        public T[] type; 
        public T[] version; 
        public T[] clas; 
        public T[] c_space; 
        public T[] PCS; 
        public T[] DateTime; 
        public T[] Sign; 
        public T[] Field; 
        public T[] Flags; 
        public T[] d_Manu; 
        public T[] d_Model; 
        public T[] d_Atts; 
        public T[] Render;
        public T[] Illum; 
        public T[] Creator; 
        public T[] ID;
        public T[] Reserved; 
        public cpHeader(int size)
        {
            this.size = new T[size];
            this.type = new T[size];
            this.version = new T[size];
            this.clas = new T[size];
            this.c_space = new T[size];
            this.PCS = new T[size];
            this.DateTime = new T[3*size];
            this.Sign = new T[size];
            this.Field = new T[size];
            this.Flags = new T[size];
            this.d_Manu = new T[size];
            this.d_Model = new T[size];
            this.d_Atts = new T[2*size];
            this.Render = new T[size];
            this.Illum = new T[3*size];
            this.Creator = new T[size];
            this.ID = new T[4*size];
            this.Reserved = new T[7*size];

        }

    }
}
