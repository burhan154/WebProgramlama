using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session,string key,object value)
        {
            //key cart olacak, gönderdiğim object kart nesnesi sınıfı ve bu sınıfı SerializeObject diyip Jsona çevirecek.Ve Json olarak bu session içerisinde saklanacak.
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this ISession session,string key) //session içerisinde sadece cart nesnesini değil generic olarak gelen tüm sınıfları saklayabilirim
        {
            var data = session.GetString(key); //Session da bu nesne var mı yok mu kontrol edicez. yoksa o nesneyi serialize edeceğiz.

            return data == null ? default(T) : JsonConvert.DeserializeObject<T>(data);
        }
    }
}
