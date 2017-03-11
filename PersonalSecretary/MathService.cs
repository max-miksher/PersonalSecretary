using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSecretary
{
    /// <summary>
    ////класс, в котором будут храниться различные математические расчеты и маленькие методы
    /// </summary>
    static class MathService
    {
        /// <summary>
        /// парсит куки в массив
        /// </summary>
        /// <param name="Cookie">строка с куками</param>
        /// <returns>массив с куками</returns>
        public static Dictionary<string, string> ParseCookie(string Cookie)
        {
            var CookieArray = new Dictionary<string, string>();

            string[] tmpCookieArray = Cookie.Split('=', ';');

            for(int i=0;i<tmpCookieArray.Length;i+=2)
            {
                CookieArray[tmpCookieArray[i]] = tmpCookieArray[i + 1];
            }

            return CookieArray;
        }
        /// <summary>
        /// Выполняет проверку подключения к удаленным ресурсам
        /// </summary>
        /// <param name="strUrl">адрес удаленного ресурса</param>
        /// <returns>подключился или нет</returns>
        public static bool ConnectionAvailable(string strUrl)
        {
            int Point = 0;
            while (Point < 3)
            {
                try
                {
                    HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                    HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();
                    if (HttpStatusCode.OK == rspFP.StatusCode)
                    {
                        // HTTP = 200 - Интернет безусловно есть!
                        rspFP.Close();
                        //return true;
                        Point = 100;
                    }
                    else
                    {
                        // сервер вернул отрицательный ответ, возможно что инета нет
                        rspFP.Close();
                        //return false;
                        Point++;
                        System.Threading.Thread.Sleep(500);
                    }
                }
                catch (WebException)
                {
                    // Ошибка, значит интернета у нас нет. Плачем :'(
                    //return false;
                    Point++;
                    System.Threading.Thread.Sleep(500);
                }
            }
            if (Point == 3) return false;
            else if (Point == 100)
            {
                return true;
            }
            return false;
        }
    }
}
