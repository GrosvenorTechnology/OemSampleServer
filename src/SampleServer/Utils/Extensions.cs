using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SampleServer.Utils
{
    public static class Extensions
    {
        // ReSharper disable once InconsistentNaming
        public static string MD5Hash(this string data)
        {
            using (var md5 = MD5.Create())
            {
                md5.Initialize();
                md5.ComputeHash(Encoding.UTF8.GetBytes(data));
                return Convert.ToBase64String(md5.Hash);
            }
        }
    }
}