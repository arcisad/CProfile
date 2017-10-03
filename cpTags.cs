using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct cpTagCount<T>
{
    public T[] Count;
    public cpTagCount(int size)
    {
        this.Count = new T[size];
    }
}
public struct cpTagTable<T>
{
    public T[] Sign;
    public T[] Offset;
    public T[] Size;
    public cpTagTable(int size)
    {
        this.Sign = new T[size];
        this.Offset = new T[size];
        this.Size = new T[size];
    }
}
public struct cpTagData<T>
{
    public T[] Data;
    public cpTagData(int size)
    {
        this.Data = new T[size];
    }
}
public struct PAD<T>
{
    public T[] Padding;
    public PAD(int size)
    {
        this.Padding = new T[size];
    }
}
public struct LUT8<T>
{
    public T[] Sign;
    public T[] Reserved;
    public int[] IChan;
    public int[] OChan;
    public int[] gPoints;
    public T[] PadReserved;
    public T[] e1, e2, e3, e4, e5, e6, e7, e8, e9;
    public T[,] ITable;
    public T[,] OTable;
    public int[,] CLUT;
    public LUT8(int size)
    {
        this.Sign = new T[size];
        this.Reserved = new T[size];
        this.IChan = new int[size / 4];
        this.OChan = new int[size / 4];
        this.gPoints = new int[size / 4];
        this.PadReserved = new T[size / 4];
        this.e1 = this.e2 = this.e3 = this.e4 = this.e5 = this.e6 = this.e7 = this.e8 = this.e9 = new T[size];
        this.ITable = new T[256 , this.IChan[0]];
        this.OTable = new T[256 , this.OChan[0]];
        this.CLUT = new int[(int)(Math.Pow((double)this.gPoints[0], (double)this.IChan[0])) , this.OChan[0]];
    }
}

