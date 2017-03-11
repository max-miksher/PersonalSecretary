using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSecretary
{
    class Transcript
    {
        private static int[] My_RSA_O = new int[2];
        private static int[] My_RSA_P = new int[2];

        private static int[] Ex_RSA_O = new int[2];
        private static int[] Ex_RSA_P = new int[2];

        private static byte[] AES_key;
        private static byte[] AES_IV;
        /// <summary>
        /// создание RSA ключа программы
        /// </summary>
        public static string Keys()
        {
            try
            {
                // Создаем новый экземпляр класса Aes 
                // Создаем ключ и вектор инициализации (IV)
                using (var myAes = Aes.Create())
                {
                    AES_key = myAes.Key;
                    AES_IV = myAes.IV;
                }

                Random rnd = new Random();
                int[] Key = new int[2];
                int value;
                while (Key.Length < 2)
                {
                    value = rnd.Next(100, 30000);
                    for (int i = 2; i <= value; i++)
                    {
                        if (value % i > 0 && i < value) i = value + 1;
                        if (i == value) Key[Key.Length] = value;
                    }
                }
                int n = Key[0] * Key[1];
                int fi = (Key[0] - 1) * (Key[1] - 1);
                int e = 0;
                int d = 0;

                while (e == 0)
                {
                    value = rnd.Next(100, fi);
                    for (int i = 2; i <= value; i++)
                    {
                        if ((value % i > 0 && i < value) || fi % value > 0) i = value + 1;
                        if (i == value) e = value;
                    }
                }

                while ((d * e) % fi != 1)
                    d++;

                int[] OpenKey = new int[2];
                int[] CloseKey = new int[2];

                My_RSA_O[0] = e;
                My_RSA_O[1] = n;

                My_RSA_P[0] = d;
                My_RSA_P[1] = n;

                return "Успешное выполнение команд шифрования";
            }
            catch (Exception E)
            {
                // Если что-то не так выбрасываем исключение
                return E.Message;
            }
        }

        static byte[] EncryptStringToBytesAes(string plainText, byte[] AES_key, byte[] AES_IV)
        {
            // Проверка аргументов
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (AES_key == null || AES_key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (AES_IV == null || AES_IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Создаем объект класса AES
            // с определенным ключом and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = AES_key;
                aesAlg.IV = AES_IV;

                // Создаем объект, который определяет основные операции преобразований.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Создаем поток для шифрования.
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Записываем в поток все данные.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            //Возвращаем зашифрованные байты из потока памяти.
            return encrypted;
        }
        static string DecryptStringFromBytesAes(byte[] cipherText, byte[] AES_key, byte[] AES_IV)
        {
            // Проверяем аргументы
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (AES_key == null || AES_key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (AES_IV == null || AES_IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Строка, для хранения расшифрованного текста
            string plaintext;

            // Создаем объект класса AES,
            // Ключ и IV
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = AES_key;
                aesAlg.IV = AES_IV;

                // Создаем объект, который определяет основные операции преобразований.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Создаем поток для расшифрования.
                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Читаем расшифрованное сообщение и записываем в строку
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }
            return plaintext;
        }
        /*static byte[] EncryptStringToBytesRSA(string plainText)
        {
            // Проверка аргументов
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            byte[] encrypted;


        }
        static string DecryptStringFromBytesRSA(byte[] cipherText)
        {

        }*/
    }
}
