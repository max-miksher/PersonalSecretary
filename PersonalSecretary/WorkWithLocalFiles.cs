using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSecretary
{
    /// <summary>
    ////класс провеки, создания и работы файлов с данными
    /// </summary>
    class WorkWithLocalFiles
    {
        /// <summary>
        /// проверяет наличие файла с данными
        /// </summary>
        /// <returns></returns>
        public static bool CheckingFile()
        {
            string dir = @"C:\Users\%UserName%\AppData\Roaming\PersonalSecretary";
            if (Directory.Exists(dir)) 
            {
                if (File.Exists(@"C:\Users\%UserName%\AppData\Roaming\PersonalSecretary\PeSeSet.dat"))
                    return true;
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// создает файл с данными
        /// </summary>
        /// <returns></returns>
        public static int FileCreation()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\%UserName%\AppData\Roaming");
            try
            {
                if (!Directory.Exists(@"C:\Users\%UserName%\AppData\Roaming\PersonalSecretary"))
                    dir.CreateSubdirectory("PersonalSecretary");
                try
                {
                    string path = @"C:\Users\%UserName%\AppData\Roaming\PersonalSecretary\PeSeSet.dat";
                    BinaryWriter writer = new BinaryWriter(File.Create(path));
                    writer.Close();
                    return 0;//файл успешно создан
                }
                catch (IOException e)
                {
                    return 1;//нельзя создать файл
                }
            }
            catch (IOException e)
            {
                return 2;//нельзя создать папку
            }
        }
        /// <summary>
        ////читает файл с данными
        /// </summary>
        public static string ReadFile()
        {
            string path = @"C:\Users\%UserName%\AppData\Roaming\PersonalSecretary\PeSeSet.dat";
            try
            {
                BinaryReader reader = new BinaryReader(File.OpenRead(path));
                string rr = reader.ReadString();
                reader.Close();
                return rr;
            }
            catch (IOException e)
            {
                return "";
            }
        }

        public static bool WriteFile(string str)
        {
            string path = @"C:\Users\%UserName%\AppData\Roaming\PersonalSecretary\PeSeSet.dat";
            try
            {
                BinaryWriter writer = new BinaryWriter(File.OpenWrite(path));
                writer.Write(str);
                writer.Close();
                return true;
            }
            catch (IOException e)
            {
                return false;
            }
        }
    }
}
