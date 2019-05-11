using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.Visa_Test
{
    public class Problem4Test
    {
       public static List<string> checkIPs(List<string> ip_array)
        {
            var result = new List<string>();

            foreach (var item in ip_array)
            {
                result.Add(ValidIPAddress(item));
            }

            return result;
        }

        private static string ValidIPAddress(string IP)
        {
            if (ValidateIPV4(IP)) return "IPv4";
            if (ValidateIPV6(IP)) return "IPv6";
            return "Neither";
        }

        private static bool ValidateIPV4(string s)
        {
            string[] parts = s.Split(new char[] { '.' });
            if (parts.Length != 4) return false;

            int x = 0;
            foreach (string p in parts)
            {
                if (!Int32.TryParse(p, out x)) return false;
                if (x < 0 || x > 255 || (x.ToString().Length != p.Length)) return false;
            }
            return true;
        }

        private static bool ValidateIPV6(string s)
        {
            string[] parts = s.Split(new char[] { ':' });
            if (parts.Length != 8) return false;

            int x = 0;
            foreach (string p in parts)
            {
                if (p.Length > 4) return false;

                if (!Int32.TryParse(
                    p,
                    System.Globalization.NumberStyles.HexNumber,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out x)) return false;

                if (x < 0) return false;
            }
            return true;
        }
    }
}
