using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace testeBuscaMarvel.Suporte
{
    public static class Busca
    {
        const string url = "https://gateway.marvel.com:443/v1/public/characters?name={0}&ts={1}&apikey={2}&hash={3}";
        const string chavePrivada = "8ae005a45d949c639a375d70731eaa26faaaf3f8";
        const string chavePublica = "0173a7f01e9f98a9d35b90d990ee96b1";

        public static string BuscaPersonagem(string nome)
        {
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string hashmd5 = CalculateMD5Hash(timeStamp + chavePrivada + chavePublica);
            string requisicao = String.Format(url, nome, timeStamp, chavePublica, hashmd5);
            return Get(requisicao);
        }

        public static string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "Get";
            request.ContentType = "application/json";
            request.ContentType = "application/json; charset=utf-8";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static string CalculateMD5Hash(string input)

        {

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("x2"));

            }

            return sb.ToString();

        }

    }
}