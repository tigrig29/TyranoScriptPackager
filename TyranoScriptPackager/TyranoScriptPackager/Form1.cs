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
            // 前回値の復元
            textBox_project_path.Text = Properties.Settings.Default.project_path;
            textBox_export_path.Text = Properties.Settings.Default.export_path;
            textBox_id.Text = Properties.Settings.Default.id;
            textBox_title.Text = Properties.Settings.Default.title;
            numericUpDown_width.Value = (int)Properties.Settings.Default.width;
            numericUpDown_height.Value = (int)Properties.Settings.Default.height;
            numericUpDown_max_width.Value = (int)Properties.Settings.Default.max_width;
            numericUpDown_max_height.Value = (int)Properties.Settings.Default.max_height;
            numericUpDown_min_width.Value = (int)Properties.Settings.Default.min_width;
            numericUpDown_min_height.Value = (int)Properties.Settings.Default.min_height;
            comboBox_export_folder.SelectedIndex = (int)Properties.Settings.Default.export_folder_auto;
            comboBox_resize.SelectedIndex = (int)Properties.Settings.Default.resize;


            // 実行ファイルと同階層にexportフォルダがない場合は作成する
            string export_path = Application.ExecutablePath.Replace(@"\TyranoScriptPackager", @"\export\").Replace(".exe", "").Replace(".EXE", "");
            if (!Directory.Exists(export_path))
            {
                Directory.CreateDirectory(export_path);
            }

            // プロジェクトフォルダ参照：デフォルトではCドライブを参照する
            folderBrowserDialog1.SelectedPath = Path.GetFullPath(textBox_project_path.Text);
            // 出力フォルダを設定
            if (textBox_export_path.Text == "")
            {
                textBox_export_path.Text = Application.ExecutablePath.Replace(@"\TyranoScriptPackager.exe", @"\export");
            }
            // 出力フォルダ参照：実行ファイルの同階層のexportフォルダを参照する
            folderBrowserDialog2.SelectedPath = Path.GetFullPath(textBox_export_path.Text);
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
            if (dr == DialogResult.OK)
            {
                textBox_project_path.Text = folderBrowserDialog1.SelectedPath;
            }
        }


        // 出力先フォルダの参照ボタン
        private void button_reference_export_Click(object sender, EventArgs e)
        {
            // 参照ダイアログの説明
            folderBrowserDialog2.Description = "出力先のフォルダを選択";
            
            // 参照ダイアログ表示
            DialogResult dr = folderBrowserDialog2.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBox_export_path.Text = folderBrowserDialog2.SelectedPath;
            }
        }

        // 出力先フォルダ名横のコンボボックス内容変更イベント
        private void comboBox_export_folder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_export_folder.SelectedIndex == 0)
            {
                textBox_export_folder.Enabled = false;
                textBox_export_folder.Text = System.Text.RegularExpressions.Regex.Replace(DateTime.Now.ToString(), @"[\/\s\:]", "_");
            }
            else
            {
                textBox_export_folder.Enabled = true;
                textBox_export_folder.Text = "";
            }
        }



        // パッケージング実行ボタン
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
                DialogResult result;

                // 指定した出力フォルダがない場合は作成する
                if (!Directory.Exists(export_path))
                {
                    Directory.CreateDirectory(export_path);
                }

                // パッケージ出力先フォルダの作成
                string exportUrl = Path.Combine(export_path.Replace(@"\", @"\\"), textBox_export_folder.Text);
                // 既に指定名称のフォルダが存在する場合
                if (Directory.Exists(exportUrl))
                {
                    // 確認ダイアログ出して、NOならば処理を終了
                    result = MessageBox.Show("既に存在しているフォルダ名が指定されています。\nフォルダを上書きしてよろしいですか？", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }
               
                // 「処理中」を表示
                button_execute.Text = "処理中…";
                button_execute.Enabled = false;

                // パッケージング処理
                Util.TyranoPackage(project_path.Replace(@"\", @"\\"), exportUrl, textBox_id.Text, textBox_title.Text, System.Convert.ToBoolean(comboBox_resize.Text), (int)numericUpDown_width.Value, (int)numericUpDown_height.Value, (int)numericUpDown_max_width.Value, (int)numericUpDown_max_height.Value, (int)numericUpDown_min_width.Value, (int)numericUpDown_min_height.Value);

                // 「処理中」を解除
                button_execute.Text = "パッケージング実行";
                button_execute.Enabled = true;

                // 完了通知
                result = MessageBox.Show("パッケージ化が完了しました。\n出力先のフォルダを開きますか？", "フォルダの確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    // 出力フォルダを開く
                    System.Diagnostics.Process.Start(exportUrl);
                }

                // 出力先フォルダが自動生成ならば、名称を更新する
                if (comboBox_export_folder.SelectedIndex == 0)
                {
                    textBox_export_folder.Text = System.Text.RegularExpressions.Regex.Replace(DateTime.Now.ToString(), @"[\/\s\:]", "_");
                }
            }
        }

        // アプリケーション終了時に、前回値を保存する
        private void TyranoScriptPackager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.project_path = textBox_project_path.Text;
            Properties.Settings.Default.export_path = textBox_export_path.Text;
            Properties.Settings.Default.id = textBox_id.Text;
            Properties.Settings.Default.title = textBox_title.Text;
            Properties.Settings.Default.width = (int)numericUpDown_width.Value;
            Properties.Settings.Default.height = (int)numericUpDown_height.Value;
            Properties.Settings.Default.max_width = (int)numericUpDown_max_width.Value;
            Properties.Settings.Default.max_height = (int)numericUpDown_max_height.Value;
            Properties.Settings.Default.min_width = (int)numericUpDown_min_width.Value;
            Properties.Settings.Default.min_height = (int)numericUpDown_min_height.Value;
            Properties.Settings.Default.export_folder_auto = (int)comboBox_export_folder.SelectedIndex;
            Properties.Settings.Default.resize = (int)comboBox_resize.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        // タブキーで選択した際に全選択を行う
        private void textBox_Enter(object sender, EventArgs e)
        {
            if (sender.ToString().Contains("TextBox"))
            {
                ((TextBox)sender).SelectAll();
            }
            if (sender.ToString().Contains("NumericUpDown"))
            {
                NumericUpDown nud = (NumericUpDown)sender;
                (nud).Select(0, nud.Value.ToString().Length);
            }   
        }
    }

    // 処理関数群
    public class Util
    {
        public static void TyranoPackage(string projectUrl, string exportUrl, string id = "TyranoScriptGame", string title = "loading...", bool resizable = true, int width = 1280, int height = 720, int max_width = 1920, int max_height = 1080, int min_width = 640, int min_height = 480)
        {
            // ================================================================
            // エクスポート先フォルダ作成
            // ================================================================
            // 必要なデータを、出力先フォルダにコピーする
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
            zip.AddDirectory(Path.Combine(projectUrl, "node_modules"), "node_modules");
            zip.AddFile(Path.Combine(projectUrl, "index.html"), "");
            zip.AddFile(Path.Combine(exportUrl, "package.json"), "");

            // 保存
            zip.Save(Path.Combine(exportUrl, "app.nw"));

            // ================================================================
            // copyコマンド実行
            // ================================================================
            string arguments = @"/c copy /b " + exportUrl + @"\nw.exe" + "+" + exportUrl + @"\app.nw" + " " + exportUrl + @"\" + id + ".exe";
            ExecuteCommand(arguments, false);

            // ================================================================
            // 後処理
            // ================================================================
            // 削除が速いとエラー起きるので一旦止める
            //Task.Delay(300);
            System.Threading.Thread.Sleep(300);

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
        }
        // Package.jsonをファイルとして出力
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

    }
}
