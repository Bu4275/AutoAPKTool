using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
namespace apkdecompiler
{
    public partial class Form1 : Form
    {
        string SIGN_PEM = @".\tool\certificate.shared.x509.pem";
        string SIGN_KEY = @".\tool\key.pk8";
        string JAR_APKTOOL = @".\tool\apktool_2.0.1.jar";
        string JAR_SIGNAPK = @".\tool\signapk.jar";
        string D2J_DEX2JAR = @".\tool\dex2jar-2.0\d2j-dex2jar.bat";
        string JAR_JD_GUI = @".\tool\jd-gui-1.4.0.jar";

        public Form1()
        {
            InitializeComponent();
            new Thread(ExcuteCmd).Start("/c dir");
        }

        // GetArg
        private string GetDecompilerArg(string input_APK, string output_FolderName)
        {
            return string.Format("-jar \"{0}\" d \"{1}\" -o \"{2}\"", JAR_APKTOOL, input_APK, output_FolderName);
        }
        private string GetBuildArg(string input_FolderName, string output_APK)
        {
            return string.Format("-jar \"{0}\" b \"{1}\" -o \"{2}\"", JAR_APKTOOL, input_FolderName, output_APK);
        }
        private string GetSignArg(string apkName_old, string apkName_new)
        {
            return string.Format("-jar \"{0}\" \"{1}\" \"{2}\" \"{3}\" \"{4}\"",
                                JAR_SIGNAPK, SIGN_PEM, SIGN_KEY, apkName_old, apkName_new);
        }
        private string GetDex2JarArg(string input_Dex, string output_Jar)
        {
            return string.Format("/c \"\"{0}\" \"{1}\" -o \"{2}\"\"", D2J_DEX2JAR, input_Dex, output_Jar);
        }

        private void setTextBoxStr(TextBox tb, string info)
        {
            tb.Text = info + "\r\n";
            tb.SelectionStart = tb.Text.Length;
            tb.ScrollToCaret();
        }
        // ExcuteJar
        private void ExcuteJar(object args)
        {
            
            this.Invoke(new Action(() =>
            {
                setTextBoxStr(textBox1, "java.exe " + args.ToString() + "\r\n");
            }));

            ProcessStartInfo start_info =
                new ProcessStartInfo("java.exe", args.ToString());
            start_info.UseShellExecute = false;
            start_info.CreateNoWindow = true;
            start_info.RedirectStandardOutput = true;
            start_info.RedirectStandardError = true;

            // Make the process and set its start information.
            using (Process proc = new Process())
            {
                proc.StartInfo = start_info;
                proc.OutputDataReceived += (s, e) =>
                {
                    this.Invoke(new Action(() =>
                    {
                        setTextBoxStr(textBox1, textBox1.Text + e.Data);
                    }));
                };

                proc.ErrorDataReceived += (s, e) =>
                {
                    this.Invoke(new Action(() =>
                    {
                        setTextBoxStr(textBox1, textBox1.Text + e.Data);
                    }));
                };
                // Start the process.
                proc.Start();
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
                proc.WaitForExit();
                proc.Close();
            }

            this.Invoke(new Action(() =>
            {
                textBox1.Text += "Finish!\r\n";
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();
            }));
        }
        private void ExcuteCmd(object args)
        {
            this.Invoke(new Action(() =>
            {
                setTextBoxStr(textBox1, "cmd.exe " + args.ToString() + "\r\n");
            }));

            ProcessStartInfo start_info =
                            new ProcessStartInfo("cmd.exe", args.ToString());
            start_info.UseShellExecute = false;
            start_info.CreateNoWindow = true;
            start_info.RedirectStandardOutput = true;
            start_info.RedirectStandardError = true;

            // Make the process and set its start information.
            using (Process proc = new Process())
            {
                proc.StartInfo = start_info;
                proc.OutputDataReceived += (s, e) =>
                {
                    this.Invoke(new Action(() =>
                    {
                        setTextBoxStr(textBox1, textBox1.Text + e.Data);
                    }));
                };

                proc.ErrorDataReceived += (s, e) =>
                {
                    this.Invoke(new Action(() =>
                    {
                        setTextBoxStr(textBox1, textBox1.Text + e.Data);
                    }));
                };
                
                // Start the process.
                proc.Start();
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
                proc.WaitForExit();
                proc.Close();
            }

            this.Invoke(new Action(() =>
            {
                setTextBoxStr(textBox1, textBox1.Text + "Finish!");
            }));
        }

        // button Click
        private void btn_Decompiler_Click(object sender, EventArgs e)
        {
            string input_APK = textBox_path.Text;

            if (!File.Exists(input_APK))
            {
                MessageBox.Show("Error 404: Can't find the input apkfile!");
                return;
            }

            // save as folder
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Folder|*";
            // set default path
            sf.InitialDirectory = Path.GetDirectoryName(input_APK);
            sf.FileName = Path.GetFileNameWithoutExtension(input_APK);

            if (sf.ShowDialog() == DialogResult.OK)
            {
                string outputFolderName = sf.FileName.ToString();
                string args = GetDecompilerArg(input_APK, outputFolderName);
                new Thread(ExcuteJar).Start(args);
            }
        }
        private void btn_Build_Click(object sender, EventArgs e)
        {
            string jarName = JAR_APKTOOL;
            string inpputFloderName = textBox_path.Text;

            if (!Directory.Exists(inpputFloderName))
            {
                MessageBox.Show("Error 404: Can't find the input folder!");
                return;
            }

            // save as apk
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "APK|*.apk|All|*.*";
            sf.DefaultExt = "apk";
            // set default path
            sf.InitialDirectory = Path.GetDirectoryName(inpputFloderName);
            sf.FileName = Path.GetFileNameWithoutExtension(inpputFloderName) + "_Mod.apk";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                string outputAPK = sf.FileName.ToString();
                Console.WriteLine("path: {0}", outputAPK);
                string args = GetBuildArg(inpputFloderName, outputAPK);
                new Thread(ExcuteJar).Start(args);
            }


        }
        private void btn_SignAPK_Click(object sender, EventArgs e)
        {
            string apkName_old = textBox_path.Text;

            if (!File.Exists(apkName_old))
            {
                MessageBox.Show("Error 404: Can't find the input apkfile!");
                return;
            }

            // save as apk
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "APK|*.apk|All|*.*";
            sf.DefaultExt = "apk";
            // set default path 
            sf.InitialDirectory = Path.GetDirectoryName(apkName_old);
            sf.FileName = Path.GetFileNameWithoutExtension(apkName_old) + "_Signed.apk";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                string apkName_new = sf.FileName.ToString();
                string args = GetSignArg(apkName_old, apkName_new);
                new Thread(ExcuteJar).Start(args);
            }
        }
        private void btn_BuildAndSign_Click(object sender, EventArgs e)
        {
            string input_apkFolderName = textBox_path.Text;

            if (!Directory.Exists(input_apkFolderName))
            {
                MessageBox.Show("Error 404: Can't find the input folder!");
                return;
            }

            // save as apk
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "APK|*.apk|All|*.*";
            sf.DefaultExt = "apk";
            // set default path
            sf.InitialDirectory = Path.GetDirectoryName(input_apkFolderName);
            sf.FileName = Path.GetFileNameWithoutExtension(input_apkFolderName) + "_Mod.apk";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                var tasks = new Task[2];

                // Build arg
                string output_ApkFileName = sf.FileName.ToString();
                Console.WriteLine("path: {0}", output_ApkFileName);
                string args1 = GetBuildArg(input_apkFolderName, output_ApkFileName);
                
                // Sign arg
                string apkName_old = output_ApkFileName;
                // get Full ApkPath without ".apk", than append "_Signed.apk"
                string apkName_new = 
                    output_ApkFileName.Substring(0, output_ApkFileName.Length - 4) + "_Signed.apk"; 
                string args2 = GetSignArg(apkName_old, apkName_new);

                // Start
                new Thread(()=>
                {
                    ExcuteJar(args1); // Build
                    ExcuteJar(args2); // Sign
                }).Start();
            }
        }
        private void btn_dex2jar_Click(object sender, EventArgs e)
        {

            string input_Dex = textBox_path.Text;
            if (!File.Exists(input_Dex) || Path.GetExtension(input_Dex) != ".dex")
            {
                MessageBox.Show("Error 404: Can't find the input dexfile!");
                return;
            }

            // save as folder
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Jar|*.jar";
            // set default path
            sf.InitialDirectory = Path.GetDirectoryName(input_Dex);
            sf.FileName = Path.GetFileNameWithoutExtension(input_Dex);

            if (sf.ShowDialog() == DialogResult.OK)
            {
                string output_Jar = sf.FileName.ToString();

                string args = GetDex2JarArg(input_Dex, output_Jar);
                Console.WriteLine(args);
                new Thread(ExcuteCmd).Start(args);
            }
        }

        // Form Event
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileInfo = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string filePath = string.Join("", fileInfo, 0, fileInfo.Length);

            textBox_path.Text = filePath;
        }
        private void btn_JdGUI_Click(object sender, EventArgs e)
        {
            new Thread(ExcuteJar).Start("-jar " + JAR_JD_GUI);
        }
        private void chkBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBox_TopMost.Checked)
                this.TopMost = true;
            else
                this.TopMost = false;
        }
        private void btn_openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                textBox_path.Text = op.FileName;
            }

        }
    }
}
