using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZTicaret.Application
{
    public class MyException : Exception                                                    
    {
        public MyException() : base("My error occured") { }
        public MyException(string message) : base(message) {}
        public MyException(Exception exception) : this(exception.Message) { }
    }

     public class BasketNotFoundException : Exception
      {
        public BasketNotFoundException() : base("Sepet Bulunamadı") {}
      }
    public class ProductNotFoundException : Exception
      {
        public ProductNotFoundException() : base("Ürün Bulunamadı") {}
      }
    

      

    
}
