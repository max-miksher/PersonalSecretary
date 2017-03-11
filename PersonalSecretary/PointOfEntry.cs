using Awesomium.Core;
using System;
using System.Windows.Forms;
using VarDumpDll;

namespace PersonalSecretary
{
    public partial class PointOfEntry : Form
    {
        private static int Stage = 4;//стадии проверки системы , начинаем с первой
        private static int MaxStage = 99;//максимальная стадия проверки системы
        private static string FileString = "";
        
        
        public PointOfEntry()
        {
            InitializeComponent();
            //WebView views = WebCore.CreateWebView(640, 480);
            //this.webControl1.Source = new Uri("https://vk.com");
            //.Source = new Uri("https://vk.com");

            //bool aa = this.webControl1.IsLoading;
            
        }
        ///<summary>
        ///Этот метод SetText передает текст состояния проверки системы при запуске программы
        ///</summary>
        private void SetText(string text)
        {

                this.StatusBar.Text = text;
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

        
        ///<summary>
        ///этот метод вызывается при завершении загрузки окна проверки
        ///</summary>
        private void PointOfEntry_Shown(object sender, EventArgs e)
        {
            TestingStages();
            this.CloseButton.Visible = true;
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

        private void Awesomium_Windows_Forms_WebControl_DocumentReady(object sender, DocumentReadyEventArgs e)
        {
            string a = this.webControl1.HTML;

            this.textBox1.Text = a;
        }
    }
}
