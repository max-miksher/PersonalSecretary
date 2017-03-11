using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalSecretary
{
    public partial class PointOfEntry : Form
    {
        private static int Stage = 5;//стадии проверки системы , начинаем с первой
        private static int MaxStage = 99;//максимальная стадия проверки системы
        private static string FileString = "";
        public PointOfEntry()
        {
            InitializeComponent();
        }
        ///<summary>
        ///Этот метод SetText передает текст состояния проверки системы при запуске программы
        ///</summary>
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if (this.StatusBar.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.StatusBar.Text = text;
            }
        }

        ///<summary>
        ///этот метод проверяет систему на наличие подключения и тд.
        ///</summary>
        public void TestingStages()
        {
            string msg = "";
            switch (Stage)
            {
                case 1:
                    SetText("Подключение к сети Интернет");
                    if (MathService.ConnectionAvailable("https://www.google.com"))
                    {
                        msg = "Успешное подключение к сети Интернет";
                    }
                    else
                    {
                        msg = "Отсутствует подключение к сети Интернет";
                        Stage = MaxStage;
                    }
                    SetText(msg);
                    Stage++;
                    TestingStages();
                    break;
                case 2:
                    SetText("Подключение к серверу ВКонтакте");
                    if (MathService.ConnectionAvailable("https://m.vk.com"))
                    {
                        msg = "Успешное подключение к ВКонтакте";
                    }
                    else
                    {
                        msg = "Отсутствует подключение к серверу ВКонтакте";
                        Stage = MaxStage;
                    }
                    SetText(msg);
                    Stage++;
                    TestingStages();
                    break;
                case 3:
                    SetText("Подключение к удаленному серверу");
                    if (MathService.ConnectionAvailable("http://localhost"))
                    {
                        msg = "Успешное подключение к удаленному серверу";
                    }
                    else
                    {
                        msg = "Отсутствует подключение к удаленному серверу";
                        Stage = MaxStage;
                    }
                    SetText(msg);
                    Stage++;
                    TestingStages();
                    break;
                case 4:
                    SetText("Чтение данных");
                    if (!WorkWithLocalFiles.CheckingFile())
                        switch (WorkWithLocalFiles.FileCreation())
                        {
                            case 0:
                                msg = "Файлы успешно созданы";
                                break;
                            case 1:
                                msg = "Не возможно создать файлы";
                                break;
                            case 2:
                                msg = "Не возможно создать каталоги";
                                break;
                        }
                    else
                    {
                        FileString = WorkWithLocalFiles.ReadFile();
                        Stage = MaxStage;
                        msg = "Чтение завершено";
                    }
                    SetText(msg);
                    Stage++;
                    break;
            }
        }

        /// <summary>
        /// следующий шаг, если все проверено и нормально. 
        /// закрываем это окно и открываем окно авторизации если не авторизовались, 
        /// окно работы если авторизовались ранее.
        /// </summary>
        /// <param name="result">ничего не передаем. без него не работает</param>
        public void DelegateMethod(IAsyncResult result)
        {
            //this.CloseButton.Visible = true;
            if(Stage<99)
            {
                Thread thread = new Thread(a);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();               
            }
            else
            {
                if (this.CloseButton.InvokeRequired)
                    this.CloseButton.Invoke(new Action(() => this.CloseButton.Visible = true));
                else this.CloseButton.Visible = true;
            }
        }
        private void a()
        {
            Auth auth = new Auth();
            auth.Show();
            //PointOfEntry.Close();
        }
        
        ///<summary>
        ///этот метод вызывается при завершении загрузки окна проверки
        ///</summary>
        private void PointOfEntry_Shown(object sender, EventArgs e)
        {
            //MethodInvoker simpleDelegate = new MethodInvoker(TestingStages);
            //simpleDelegate.BeginInvoke(new AsyncCallback(DelegateMethod), null);


            //Thread MyThread1 = new Thread(delegate () { TestingStages(); });

            //MyThread1.Start();
            //MyThread1.Join();

            /*Auth auth = new Auth();
            auth.Show();
            this.Close();*/
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
