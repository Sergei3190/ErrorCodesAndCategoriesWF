using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCodesAndCategoriesWF.Models
{
    public class MyHttpClient: HttpClient
    {
        private static readonly HttpClient httpClient;

        static MyHttpClient()
        {
            httpClient = new HttpClient();
        }
    }
}
