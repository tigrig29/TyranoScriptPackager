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

namespace TyranoScriptPackager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // プロジェクトのディレクトリパス入力
            Console.WriteLine("プロジェクトのディレクトリパスを入力して下さい");
            String projectUrl = Console.ReadLine();
            // \をエスケープ
            projectUrl.Replace(@"\", @"\\");

            // パッケージング処理
            TyranoPackage(projectUrl);


            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static void TyranoPackage(string projectUrl)
        {
            // ================================================================
            // 元プロジェクトコピー処理
            // ================================================================

            // dataディレクトリコピー
            CopyAndReplace(Path.Combine(projectUrl, "data"), @".\tmp\data");
            // tyranoディレクトリコピー
            CopyAndReplace(Path.Combine(projectUrl, "tyrano"), @".\tmp\tyrano");
            // index.htmlコピー
            string indexPath = @".\tmp\index.html";
            if (File.Exists(indexPath))
            {
                File.Delete(indexPath);
            }
            File.Copy(Path.Combine(projectUrl, "index.html"), indexPath);
            // package.jsonコピー
            string packagePath = @".\tmp\package.json";
            if (File.Exists(packagePath))
            {
                File.Delete(packagePath);
            }
            File.Copy(Path.Combine(projectUrl, "package.json"), packagePath);


            // ================================================================
            // エクスポート先ディレクトリ作成
            // ================================================================
            string exportName = System.Text.RegularExpressions.Regex.Replace(DateTime.Now.ToString(), @"[\/\s\:]", "_");
            string exportUrl = Path.Combine(@".\export", exportName);
            CopyAndReplace(@".\binwin", exportUrl);


            // ================================================================
            // プロジェクトのZIPファイル作成
            // ================================================================
            Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile();
            // 圧縮レベル
            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;

            // ファイルやディレクトリをZIPアーカイブに追加
            zip.AddDirectory(@".\tmp", "");

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

            // tmpディレクトリの削除
            Delete(@".\tmp");
            File.Delete(Path.Combine(exportUrl, "app.nw"));
            File.Delete(Path.Combine(exportUrl, "nw.exe"));
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
