using System;
using System.Text;
class Box { public int Value; }
class Program {
 static void Main() {
  try { string s = Console.ReadLine(); int a = int.Parse(s); int b = Convert.ToInt32(s); Console.WriteLine(a); Console.WriteLine(b);} catch(Exception ex){ Console.WriteLine(ex.Message);} 
  string n = Console.ReadLine(); int x; Console.WriteLine(int.TryParse(n,out x)?x.ToString():"Invalid input");
  object o=5; Console.WriteLine(o.GetHashCode()); o="Hello"; Console.WriteLine(o.GetHashCode()); o=3.14; Console.WriteLine(o.GetHashCode());
  Box r1=new Box(); r1.Value=10; Box r2=r1; r1.Value=20; Console.WriteLine(r2.Value);
  string str="Hi"; Console.WriteLine(str.GetHashCode()); str+=" Willy"; Console.WriteLine(str.GetHashCode());
  StringBuilder sb=new StringBuilder("Hi"); Console.WriteLine(sb.GetHashCode()); sb.Append(" Willy"); Console.WriteLine(sb.GetHashCode());
  int i1=int.Parse(Console.ReadLine()); int i2=int.Parse(Console.ReadLine());
  Console.WriteLine("Sum is "+(i1+i2));
  Console.WriteLine(string.Format("Sum is {0}",i1+i2));
  Console.WriteLine($"Sum is {i1+i2}");
  StringBuilder sb2=new StringBuilder("Hello World"); sb2.Append(" !!!"); sb2.Replace("World","C#"); sb2.Insert(0,"Start "); sb2.Remove(0,6); Console.WriteLine(sb2.ToString());
 }
}