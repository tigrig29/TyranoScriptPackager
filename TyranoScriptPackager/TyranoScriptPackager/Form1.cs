using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Compression;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;


namespace TyranoScriptPackager
{
    public partial class TyranoScriptPackager : Form
    {
        public TyranoScriptPackager()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 実行ファイルと同階層にexportフォルダがない場合は作成する
            string export_path = Application.ExecutablePath.Replace(@"\TyranoScriptPackager.exe", @"\export\");
            if (!Directory.Exists(export_path))
            {
                Directory.CreateDirectory(export_path);
            }

            // プロジェクトフォルダ参照：デフォルトではCドライブを参照する
            folderBrowserDialog1.SelectedPath = @"C:\";
            // 出力先フォルダ参照：実行ファイルの同階層のexportフォルダを参照する
            folderBrowserDialog2.SelectedPath = Application.ExecutablePath.Replace(@"\TyranoScriptPackager.exe", @"\export\");
        }

        public static void TyranoPackage(string projectUrl, string exportDirectory, string id = "TyranoScriptGame", string title = "loading...", bool resizable = true, int width = 1280, int height = 720, int max_width = 1920, int max_height = 1080, int min_width = 640, int min_height = 480)
        {
            // ================================================================
            // エクスポート先ディレクトリ作成
            // ================================================================
            string exportName = System.Text.RegularExpressions.Regex.Replace(DateTime.Now.ToString(), @"[\/\s\:]", "_");
            string exportUrl = Path.Combine(exportDirectory, exportName);
            CopyAndReplace(@".\binwin", exportUrl);

            // ================================================================
            // package.Json作成
            // ================================================================
            string json = CreatePackageJson(id, title, resizable, width, height, max_width, max_height, min_width, min_height);
            OutputPackageJson(exportUrl, json);

            // ================================================================
            // プロジェクトのZIPファイル作成
            // ================================================================
            Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile();
            // 圧縮レベル
            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;

            // ファイルやディレクトリをZIPアーカイブに追加
            zip.AddDirectory(Path.Combine(projectUrl, "data"), "data");
            zip.AddDirectory(Path.Combine(projectUrl, "tyrano"), "tyrano");
            zip.AddFile(Path.Combine(projectUrl, "index.html"), "");
            zip.AddFile(Path.Combine(exportUrl, "package.json"), "");

            // 保存
            zip.Save(Path.Combine(exportUrl, "app.nw"));

            // ================================================================
            // copyコマンド実行
            // ================================================================
            string arguments = @"/c copy /b " + exportUrl + @"\nw.exe" + "+" + exportUrl + @"\app.nw" + " " + exportUrl + @"\app.exe";
            ExecuteCommand(arguments, true);

            // ================================================================
            // 後処理
            // ================================================================

            // 不要ファイルの削除
            File.Delete(Path.Combine(exportUrl, "app.nw"));
            File.Delete(Path.Combine(exportUrl, "nw.exe"));
            File.Delete(Path.Combine(exportUrl, "package.json"));
        }
        // package.json用のJSONデータ出力
        public static string CreatePackageJson(string name = "TyranoScriptGame", string title = "loading...", bool resizable = true, int width = 1280, int height = 720, int max_width = 1920, int max_height = 1080, int min_width = 640, int min_height = 480)
        {
            var dic = new
            {
                name = name,
                main = "app://./index.html",
                window = new
                {
                        title = title,
                        icon = "link.png",
                        toolbar = false,
                        frame = true,
                        resizable = resizable,
                        width = width,
                        height = height,
                        max_width = max_width,
                        max_height = max_height,
                        min_width = min_width,
                        min_height = min_height,
                        position = "center",

                },
                webkit = new
                {
                    plugin = true,
                }
            };
            string json = JsonConvert.SerializeObject(dic);
            return json;


            //StreamWriter sw = new StreamWriter(Path.Combine(projectUrl, "package.json"), false, System.Text.Encoding.GetEncoding("utf-8"));
            
            //sw.Write(json);
            //sw.Close();

        }
        public static void OutputPackageJson(string projectUrl, string json)
        {
            StreamWriter sw = new StreamWriter(Path.Combine(projectUrl, "package.json"), false, System.Text.Encoding.GetEncoding("utf-8"));
            sw.Write(json);
            sw.Close();
        }
        // DOSコマンドの実行
        public static void ExecuteCommand(string arguments, bool output)
        {
            System.Diagnostics.Process pro = new System.Diagnostics.Process();

            // コマンド実行の設定
            pro.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
            pro.StartInfo.Arguments = arguments;
            pro.StartInfo.CreateNoWindow = true;                // DOSプロンプトの黒い画面を非表示
            pro.StartInfo.UseShellExecute = false;              // プロセスを新しいウィンドウで起動するか否か
            pro.StartInfo.RedirectStandardOutput = output;      // 標準出力をリダイレクトして取得したい

            // 実行
            pro.Start();

            // 出力の表示
            if (output)
            {
                string log = pro.StandardOutput.ReadToEnd();
                log.Replace("\r\r\n", "\n"); // 改行コード変換
                pro.WaitForExit();
                pro.Close();
                Console.WriteLine(log);
            }
        }
        // ディレクトリの削除
        public static void Delete(string targetDirectoryPath)
        {
            if (!Directory.Exists(targetDirectoryPath))
            {
                return;
            }

            //ディレクトリ以外の全ファイルを削除
            string[] filePaths = Directory.GetFiles(targetDirectoryPath);
            foreach (string filePath in filePaths)
            {
                File.SetAttributes(filePath, FileAttributes.Normal);
                File.Delete(filePath);
            }

            //ディレクトリの中のディレクトリも再帰的に削除
            string[] directoryPaths = Directory.GetDirectories(targetDirectoryPath);
            foreach (string directoryPath in directoryPaths)
            {
                Delete(directoryPath);
            }

            //中が空になったらディレクトリ自身も削除
            Directory.Delete(targetDirectoryPath, false);
        }
        // ディレクトリコピー
        public static void CopyAndReplace(string sourcePath, string copyPath)
        {
            //既にディレクトリがある場合は削除し、新たにディレクトリ作成
            Delete(copyPath);
            Directory.CreateDirectory(copyPath);

            //ファイルをコピー
            foreach (var file in Directory.GetFiles(sourcePath))
            {
                File.Copy(file, Path.Combine(copyPath, Path.GetFileName(file)));
            }

            //ディレクトリの中のディレクトリも再帰的にコピー
            foreach (var dir in Directory.GetDirectories(sourcePath))
            {
                CopyAndReplace(dir, Path.Combine(copyPath, Path.GetFileName(dir)));
            }
        }



        // プロジェクトフォルダのパス入力欄
        // 変更時のイベント
        private void textBox_project_path_TextChanged(object sender, EventArgs e)
        {
        }

        // プロジェクトフォルダの参照ボタン
        private void button_reference_project_Click(object sender, EventArgs e)
        {
            // 参照ダイアログの説明
            folderBrowserDialog1.Description = "パッケージ化するプロジェクトのフォルダを選択";
            // 参照のルートアドレスをマイコンピュータに設定
            folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;

            // 参照ダイアログ表示
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                textBox_project_path.Text = folderBrowserDialog1.SelectedPath;
            }
        }


        // 出力先フォルダのパス入力欄
        // 変更時のイベント
        private void textBox_export_path_TextChanged(object sender, EventArgs e)
        {

        }
        // 出力先フォルダの参照ボタン
        private void button_reference_export_Click(object sender, EventArgs e)
        {
            // 参照ダイアログの説明
            folderBrowserDialog2.Description = "出力先のフォルダを選択";
            
            // 参照ダイアログ表示
            DialogResult dr = folderBrowserDialog2.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                textBox_export_path.Text = folderBrowserDialog2.SelectedPath;
            }
        }

        private void button_execute_Click(object sender, EventArgs e)
        {
            string export_path = textBox_export_path.Text;
            string project_path = textBox_project_path.Text;

            // 参照先にプロジェクトデータがあるかをチェックする
            bool flag = false;
            if (Directory.Exists(Path.Combine(project_path, "data")))
            {
                if (Directory.Exists(Path.Combine(project_path, "tyrano")))
                {
                    if (File.Exists(Path.Combine(project_path, "index.html")))
                    {
                        flag = true;
                    }
                }
            }

            // データチェック
            if (flag == false)
            {
                // エラーダイアログ
                MessageBox.Show("指定したパスにTyranoScriptデータが見つかりません。\nプロジェクトフォルダのパスを確認して下さい。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // 指定した出力フォルダがない場合は作成する
                if (!Directory.Exists(export_path))
                {
                    Directory.CreateDirectory(export_path);
                }

                // パッケージング処理
                TyranoPackage(project_path.Replace(@"\", @"\\"), export_path.Replace(@"\", @"\\"), textBox_id.Text, textBox_title.Text, System.Convert.ToBoolean(comboBox_resize.Text), (int)numericUpDown_width.Value, (int)numericUpDown_height.Value, (int)numericUpDown_max_width.Value, (int)numericUpDown_max_height.Value, (int)numericUpDown_min_width.Value, (int)numericUpDown_min_height.Value);
            }
        }
    }
}
