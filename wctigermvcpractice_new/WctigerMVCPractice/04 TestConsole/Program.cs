using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //ENTER TEST CODE BELOW..--------------------
            Guid guid = new Guid();
            string password = "123456";
            Console.WriteLine(SecurityUtility.EncryptPassword(password));
            Console.WriteLine();
            Console.WriteLine(SecurityUtility.EncryptPassword(password + guid.ToString()));


            //------------------------------------------
            Console.ReadLine();
        }
    }
}
