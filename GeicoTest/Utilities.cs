using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GeicoTest
{
    public static class Utilities
    {

        public static string rest(string url)
        {

            string r = "";
            bool ok = false;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(resStream);

                r = reader.ReadToEnd();
                ok = true;
        
            }
            catch (Exception)
            {
        
                ok = false;
            }

            return r;
        }

    }
}
