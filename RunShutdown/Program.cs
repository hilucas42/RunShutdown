using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace RunShutdown
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var proc1 = new ProcessStartInfo();
            int i;
            // Análise da linha de argumentos

            if (args.Length < 1)
            {
                MessageBox.Show("Argumento inválido!\nUse como argumento a hora que deseja desligar," +
                    "\nno formato: RunShutdown.exe hh:mm" +
                    "\nAgora é " + DateTime.Now.ToString(),
                    "RunShutdown - Powered by Luks");
                return;
            }

            //Localizãção da hora na data

            for (i = 6; ! DateTime.Now.ToString().ElementAt(i).Equals(' '); i++) ;

            // Loop de verificação do horário de desligamento

            do
            {
                if (DateTime.Now.ToString().ElementAt(i+1).Equals(args[0].ElementAt(0)))
                    if (DateTime.Now.ToString().ElementAt(i + 2).Equals(args[0].ElementAt(1)))
                        if (DateTime.Now.ToString().ElementAt(i + 4).Equals(args[0].ElementAt(3)))
                            if (DateTime.Now.ToString().ElementAt(i + 5).Equals(args[0].ElementAt(4)))
                                break;
                System.Threading.Thread.Sleep(10000);
            } while (true);

            // A execução do comando de desligamento

            proc1.UseShellExecute = true;
            proc1.WorkingDirectory = @"C:\Windows\System32";
            proc1.FileName = @"C:\Windows\System32\shutdown.exe";
            //proc1.Verb = "runas";
            proc1.Arguments = " -s -t 30";
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);

            System.Threading.Thread.Sleep(500);

            MessageBox.Show("Atenção!\n" +
                 "            (__) \n" +
                 "            (oo) \n" +
                 "   /------\\/ \n" +
                 " / |        || \n" +
                 "*  /\\---/\\ \n" +
                 "   ~~   ~~ \n" +
                "\nO sistema será desligado em 30 segundos!" +
                "\n\nClique em Ok para cancelar o desligamento", "RunShutdown - Powered by Luks");

            proc1.Arguments = " -a";
            Process.Start(proc1);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
