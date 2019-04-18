using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64
{
    class lz68_base64
    {
        static string base64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

        internal static string Encode(string in_string)
        {
            List<byte> in_string_array = new List<byte>(Encoding.ASCII.GetBytes(in_string));

            while (in_string_array.Count % 3 != 0)
            {
                in_string_array.Add(0);
            }

            string out_string = string.Empty;

            for (int i = 0; i < in_string_array.Count; i += 3)
            {
                int sample = 0;

                int c = i;

                for (int j = 2; j >= 0; j--)
                {
                    sample += in_string_array[c++] << j * 8;
                }

                for (int j = 3; j >= 0; j--)
                {
                    int b = (sample >> j * 6) & 0x3f;
                    out_string += (b == 0) ? '=' : base64[b];
                }
            }

            return out_string;
        }

        internal static string Decode(string in_string)
        {
            string out_string = string.Empty;

            for (int i = 0; i < in_string.Length; i += 4)
            {
                int sample = 0;

                int c = i;

                for (int j = 3; j >=0; j--)
                {
                    char b = in_string[c];
                    sample += (b == '=') ? 0 : base64.IndexOf(in_string[c++]) << j * 6;
                }

                for (int j = 2; j >= 0; j--)
                {
                    if ((sample >> j * 8 & 0xff) != 0) out_string += (char)(sample >> j * 8 & 0xff);
                }
            }

            return out_string;
        }
    }
}
