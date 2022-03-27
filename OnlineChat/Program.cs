using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace OnlineChat
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin frmLogin = new frmLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                frmConnect frmConnect = new frmConnect();
                if(frmConnect.ShowDialog()==DialogResult.OK)
                {
                    frmChat frmChat = new frmChat();
                    frmChat.ShowDialog();
                }
            }
        }
    }
    static class Global
    {
        public static bool Remember = Config.Default.Remember;
        public static bool Automatic = Config.Default.Automatic;
        public static string Username = Config.Default.Username;
        public static string Password = Config.Default.Password;
        public static string Uppercases = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string Lowercases = "abcdefghijklmnopqrstuvwxyz";
        public static string Numbers = "0123456789";
        public static string Symbols = "!@#$%^&*-_=+";
        public static string ValidCharacters = Uppercases + Lowercases + Numbers + Symbols;
        public static string ServerIP = "127.0.0.1";
        public static int ServerPort = 25565;
        public static Socket socketClient;
        public static IPAddress socketIP;
        public static IPEndPoint socketPoint;
    }
}
