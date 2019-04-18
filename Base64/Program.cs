using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using lz68_base64;

namespace Base64
{
    class Program
    {
        static void Main(string[] args)
        {
            string test_string = "The Beatles";

            string res = lz68_base64.Encode(test_string);

            string decode_string = "sTERS6HxGG9t27cUDTCU";

            decode_string = lz68_base64.Decode("DU0hMw5BXNdPml8lbyjd");

            Console.Write(res);
        }
    }
}
