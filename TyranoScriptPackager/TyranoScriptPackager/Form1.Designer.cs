namespace TyranoScriptPackager
{
    partial class TyranoScriptPackager
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_project_path = new System.Windows.Forms.TextBox();
            this.button_reference_project = new System.Windows.Forms.Button();
            this.button_execute = new System.Windows.Forms.Button();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.textBox_title = new System.Windows.Forms.TextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.label_risizable = new System.Windows.Forms.Label();
            this.comboBox_resize = new System.Windows.Forms.ComboBox();
            this.numericUpDown_width = new System.Windows.Forms.NumericUpDown();
            this.label_width = new System.Windows.Forms.Label();
            this.label_height = new System.Windows.Forms.Label();
            this.numericUpDown_height = new System.Windows.Forms.NumericUpDown();
            this.label_max_width = new System.Windows.Forms.Label();
            this.label_max_height = new System.Windows.Forms.Label();
            this.numericUpDown_max_width = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_max_height = new System.Windows.Forms.NumericUpDown();
            this.label_min_width = new System.Windows.Forms.Label();
            this.label_min_height = new System.Windows.Forms.Label();
            this.numericUpDown_min_width = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_min_height = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_export_path = new System.Windows.Forms.TextBox();
            this.button_reference_export = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox_export_folder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_export_folder = new System.Windows.Forms.ComboBox();
            this.checkBox_reflectIdToGameTitle = new System.Windows.Forms.CheckBox();
            this.label_projectId = new System.Windows.Forms.Label();
            this.textBox_projectId = new System.Windows.Forms.TextBox();
            this.comboBox_projectId = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_max_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_max_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_min_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_min_height)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_project_path
            // 
            this.textBox_project_path.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox_project_path.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.textBox_project_path.Location = new System.Drawing.Point(31, 39);
            this.textBox_project_path.Name = "textBox_project_path";
            this.textBox_project_path.Size = new System.Drawing.Size(291, 19);
            this.textBox_project_path.TabIndex = 0;
            this.textBox_project_path.Text = "C:";
            this.textBox_project_path.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // button_reference_project
            // 
            this.button_reference_project.Location = new System.Drawing.Point(328, 37);
            this.button_reference_project.Name = "button_reference_project";
            this.button_reference_project.Size = new System.Drawing.Size(75, 23);
            this.button_reference_project.TabIndex = 1;
            this.button_reference_project.Text = "参照...";
            this.button_reference_project.UseVisualStyleBackColor = true;
            this.button_reference_project.Click += new System.EventHandler(this.button_reference_project_Click);
            // 
            // button_execute
            // 
            this.button_execute.Location = new System.Drawing.Point(300, 594);
            this.button_execute.Name = "button_execute";
            this.button_execute.Size = new System.Drawing.Size(101, 23);
            this.button_execute.TabIndex = 15;
            this.button_execute.Text = "パッケージング実行";
            this.button_execute.UseVisualStyleBackColor = true;
            this.button_execute.Click += new System.EventHandler(this.button_execute_Click);
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(29, 223);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(137, 19);
            this.textBox_id.TabIndex = 6;
            this.textBox_id.Text = "tyranoscript";
            this.textBox_id.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // textBox_title
            // 
            this.textBox_title.Location = new System.Drawing.Point(29, 273);
            this.textBox_title.Name = "textBox_title";
            this.textBox_title.Size = new System.Drawing.Size(137, 19);
            this.textBox_title.TabIndex = 8;
            this.textBox_title.Text = "loading...";
            this.textBox_title.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(27, 208);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(47, 12);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "ゲーム名";
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Location = new System.Drawing.Point(27, 258);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(98, 12);
            this.label_title.TabIndex = 1;
            this.label_title.Text = "読み込み時タイトル";
            // 
            // label_risizable
            // 
            this.label_risizable.AutoSize = true;
            this.label_risizable.Location = new System.Drawing.Point(27, 310);
            this.label_risizable.Name = "label_risizable";
            this.label_risizable.Size = new System.Drawing.Size(108, 12);
            this.label_risizable.TabIndex = 0;
            this.label_risizable.Text = "ドラッグリサイズの許可";
            // 
            // comboBox_resize
            // 
            this.comboBox_resize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_resize.FormattingEnabled = true;
            this.comboBox_resize.Items.AddRange(new object[] {
            "False",
            "True"});
            this.comboBox_resize.Location = new System.Drawing.Point(29, 325);
            this.comboBox_resize.Name = "comboBox_resize";
            this.comboBox_resize.Size = new System.Drawing.Size(67, 20);
            this.comboBox_resize.TabIndex = 9;
            // 
            // numericUpDown_width
            // 
            this.numericUpDown_width.Location = new System.Drawing.Point(72, 388);
            this.numericUpDown_width.Maximum = new decimal(new int[] {
            3840,
            0,
            0,
            0});
            this.numericUpDown_width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_width.Name = "numericUpDown_width";
            this.numericUpDown_width.Size = new System.Drawing.Size(67, 19);
            this.numericUpDown_width.TabIndex = 10;
            this.numericUpDown_width.Value = new decimal(new int[] {
            1280,
            0,
            0,
            0});
            this.numericUpDown_width.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // label_width
            // 
            this.label_width.AutoSize = true;
            this.label_width.Location = new System.Drawing.Point(38, 390);
            this.label_width.Name = "label_width";
            this.label_width.Size = new System.Drawing.Size(29, 12);
            this.label_width.TabIndex = 3;
            this.label_width.Text = "横幅";
            // 
            // label_height
            // 
            this.label_height.AutoSize = true;
            this.label_height.Location = new System.Drawing.Point(156, 390);
            this.label_height.Name = "label_height";
            this.label_height.Size = new System.Drawing.Size(25, 12);
            this.label_height.TabIndex = 3;
            this.label_height.Text = "高さ";
            // 
            // numericUpDown_height
            // 
            this.numericUpDown_height.Location = new System.Drawing.Point(187, 388);
            this.numericUpDown_height.Maximum = new decimal(new int[] {
            2160,
            0,
            0,
            0});
            this.numericUpDown_height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_height.Name = "numericUpDown_height";
            this.numericUpDown_height.Size = new System.Drawing.Size(67, 19);
            this.numericUpDown_height.TabIndex = 11;
            this.numericUpDown_height.Value = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.numericUpDown_height.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // label_max_width
            // 
            this.label_max_width.AutoSize = true;
            this.label_max_width.Location = new System.Drawing.Point(38, 454);
            this.label_max_width.Name = "label_max_width";
            this.label_max_width.Size = new System.Drawing.Size(29, 12);
            this.label_max_width.TabIndex = 3;
            this.label_max_width.Text = "横幅";
            // 
            // label_max_height
            // 
            this.label_max_height.AutoSize = true;
            this.label_max_height.Location = new System.Drawing.Point(156, 454);
            this.label_max_height.Name = "label_max_height";
            this.label_max_height.Size = new System.Drawing.Size(25, 12);
            this.label_max_height.TabIndex = 3;
            this.label_max_height.Text = "高さ";
            // 
            // numericUpDown_max_width
            // 
            this.numericUpDown_max_width.Location = new System.Drawing.Point(72, 452);
            this.numericUpDown_max_width.Maximum = new decimal(new int[] {
            3840,
            0,
            0,
            0});
            this.numericUpDown_max_width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_max_width.Name = "numericUpDown_max_width";
            this.numericUpDown_max_width.Size = new System.Drawing.Size(67, 19);
            this.numericUpDown_max_width.TabIndex = 12;
            this.numericUpDown_max_width.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.numericUpDown_max_width.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // numericUpDown_max_height
            // 
            this.numericUpDown_max_height.Location = new System.Drawing.Point(187, 452);
            this.numericUpDown_max_height.Maximum = new decimal(new int[] {
            2160,
            0,
            0,
            0});
            this.numericUpDown_max_height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_max_height.Name = "numericUpDown_max_height";
            this.numericUpDown_max_height.Size = new System.Drawing.Size(67, 19);
            this.numericUpDown_max_height.TabIndex = 13;
            this.numericUpDown_max_height.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.numericUpDown_max_height.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // label_min_width
            // 
            this.label_min_width.AutoSize = true;
            this.label_min_width.Location = new System.Drawing.Point(38, 511);
            this.label_min_width.Name = "label_min_width";
            this.label_min_width.Size = new System.Drawing.Size(29, 12);
            this.label_min_width.TabIndex = 3;
            this.label_min_width.Text = "横幅";
            // 
            // label_min_height
            // 
            this.label_min_height.AutoSize = true;
            this.label_min_height.Location = new System.Drawing.Point(156, 511);
            this.label_min_height.Name = "label_min_height";
            this.label_min_height.Size = new System.Drawing.Size(25, 12);
            this.label_min_height.TabIndex = 3;
            this.label_min_height.Text = "高さ";
            // 
            // numericUpDown_min_width
            // 
            this.numericUpDown_min_width.Location = new System.Drawing.Point(72, 509);
            this.numericUpDown_min_width.Maximum = new decimal(new int[] {
            3840,
            0,
            0,
            0});
            this.numericUpDown_min_width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_min_width.Name = "numericUpDown_min_width";
            this.numericUpDown_min_width.Size = new System.Drawing.Size(67, 19);
            this.numericUpDown_min_width.TabIndex = 14;
            this.numericUpDown_min_width.Value = new decimal(new int[] {
            960,
            0,
            0,
            0});
            this.numericUpDown_min_width.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // numericUpDown_min_height
            // 
            this.numericUpDown_min_height.Location = new System.Drawing.Point(187, 509);
            this.numericUpDown_min_height.Maximum = new decimal(new int[] {
            2160,
            0,
            0,
            0});
            this.numericUpDown_min_height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_min_height.Name = "numericUpDown_min_height";
            this.numericUpDown_min_height.Size = new System.Drawing.Size(67, 19);
            this.numericUpDown_min_height.TabIndex = 15;
            this.numericUpDown_min_height.Value = new decimal(new int[] {
            540,
            0,
            0,
            0});
            this.numericUpDown_min_height.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(-2, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(420, 1);
            this.label10.TabIndex = 0;
            this.label10.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ウィンドウサイズ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 430);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "最大ウィンドウサイズ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 489);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "最小ウィンドウサイズ";
            // 
            // textBox_export_path
            // 
            this.textBox_export_path.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox_export_path.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.textBox_export_path.Location = new System.Drawing.Point(31, 94);
            this.textBox_export_path.Name = "textBox_export_path";
            this.textBox_export_path.Size = new System.Drawing.Size(291, 19);
            this.textBox_export_path.TabIndex = 2;
            this.textBox_export_path.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // button_reference_export
            // 
            this.button_reference_export.Location = new System.Drawing.Point(328, 92);
            this.button_reference_export.Name = "button_reference_export";
            this.button_reference_export.Size = new System.Drawing.Size(75, 23);
            this.button_reference_export.TabIndex = 3;
            this.button_reference_export.Text = "参照...";
            this.button_reference_export.UseVisualStyleBackColor = true;
            this.button_reference_export.Click += new System.EventHandler(this.button_reference_export_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "プロジェクトフォルダのパス";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "出力先";
            // 
            // textBox_export_folder
            // 
            this.textBox_export_folder.Enabled = false;
            this.textBox_export_folder.Location = new System.Drawing.Point(111, 137);
            this.textBox_export_folder.Name = "textBox_export_folder";
            this.textBox_export_folder.Size = new System.Drawing.Size(211, 19);
            this.textBox_export_folder.TabIndex = 5;
            this.textBox_export_folder.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "出力フォルダ名";
            // 
            // comboBox_export_folder
            // 
            this.comboBox_export_folder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_export_folder.FormattingEnabled = true;
            this.comboBox_export_folder.Items.AddRange(new object[] {
            "自動生成",
            "入力する"});
            this.comboBox_export_folder.Location = new System.Drawing.Point(31, 137);
            this.comboBox_export_folder.Name = "comboBox_export_folder";
            this.comboBox_export_folder.Size = new System.Drawing.Size(74, 20);
            this.comboBox_export_folder.TabIndex = 4;
            this.comboBox_export_folder.SelectedIndexChanged += new System.EventHandler(this.comboBox_export_folder_SelectedIndexChanged);
            // 
            // checkBox_reflectIdToGameTitle
            // 
            this.checkBox_reflectIdToGameTitle.AutoSize = true;
            this.checkBox_reflectIdToGameTitle.Checked = true;
            this.checkBox_reflectIdToGameTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_reflectIdToGameTitle.Location = new System.Drawing.Point(174, 226);
            this.checkBox_reflectIdToGameTitle.Name = "checkBox_reflectIdToGameTitle";
            this.checkBox_reflectIdToGameTitle.Size = new System.Drawing.Size(206, 16);
            this.checkBox_reflectIdToGameTitle.TabIndex = 7;
            this.checkBox_reflectIdToGameTitle.Text = "Config.tjs の System.title に反映する";
            this.checkBox_reflectIdToGameTitle.UseVisualStyleBackColor = true;
            // 
            // label_projectId
            // 
            this.label_projectId.AutoSize = true;
            this.label_projectId.Location = new System.Drawing.Point(27, 546);
            this.label_projectId.Name = "label_projectId";
            this.label_projectId.Size = new System.Drawing.Size(67, 12);
            this.label_projectId.TabIndex = 16;
            this.label_projectId.Text = "プロジェクトID";
            // 
            // textBox_projectId
            // 
            this.textBox_projectId.AcceptsReturn = true;
            this.textBox_projectId.Location = new System.Drawing.Point(111, 561);
            this.textBox_projectId.Name = "textBox_projectId";
            this.textBox_projectId.Size = new System.Drawing.Size(290, 19);
            this.textBox_projectId.TabIndex = 17;
            // 
            // comboBox_projectId
            // 
            this.comboBox_projectId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_projectId.FormattingEnabled = true;
            this.comboBox_projectId.Items.AddRange(new object[] {
            "指定する",
            "指定しない"});
            this.comboBox_projectId.Location = new System.Drawing.Point(29, 561);
            this.comboBox_projectId.Name = "comboBox_projectId";
            this.comboBox_projectId.Size = new System.Drawing.Size(76, 20);
            this.comboBox_projectId.TabIndex = 18;
            this.comboBox_projectId.SelectedIndexChanged += new System.EventHandler(this.comboBox_projectId_SelectedIndexChanged);
            // 
            // TyranoScriptPackager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 629);
            this.Controls.Add(this.comboBox_projectId);
            this.Controls.Add(this.label_projectId);
            this.Controls.Add(this.textBox_projectId);
            this.Controls.Add(this.checkBox_reflectIdToGameTitle);
            this.Controls.Add(this.comboBox_export_folder);
            this.Controls.Add(this.numericUpDown_min_height);
            this.Controls.Add(this.numericUpDown_min_width);
            this.Controls.Add(this.numericUpDown_max_height);
            this.Controls.Add(this.numericUpDown_max_width);
            this.Controls.Add(this.numericUpDown_height);
            this.Controls.Add(this.label_min_height);
            this.Controls.Add(this.numericUpDown_width);
            this.Controls.Add(this.label_max_height);
            this.Controls.Add(this.label_min_width);
            this.Controls.Add(this.comboBox_resize);
            this.Controls.Add(this.label_max_width);
            this.Controls.Add(this.label_height);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_width);
            this.Controls.Add(this.label_risizable);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.button_execute);
            this.Controls.Add(this.button_reference_export);
            this.Controls.Add(this.button_reference_project);
            this.Controls.Add(this.textBox_title);
            this.Controls.Add(this.textBox_export_folder);
            this.Controls.Add(this.textBox_export_path);
            this.Controls.Add(this.textBox_id);
            this.Controls.Add(this.textBox_project_path);
            this.Name = "TyranoScriptPackager";
            this.Text = "TyranoScriptPackager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TyranoScriptPackager_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_max_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_max_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_min_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_min_height)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_project_path;
        private System.Windows.Forms.Button button_reference_project;
        private System.Windows.Forms.Button button_execute;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.TextBox textBox_title;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_risizable;
        private System.Windows.Forms.ComboBox comboBox_resize;
        private System.Windows.Forms.NumericUpDown numericUpDown_width;
        private System.Windows.Forms.Label label_width;
        private System.Windows.Forms.Label label_height;
        private System.Windows.Forms.NumericUpDown numericUpDown_height;
        private System.Windows.Forms.Label label_max_width;
        private System.Windows.Forms.Label label_max_height;
        private System.Windows.Forms.NumericUpDown numericUpDown_max_width;
        private System.Windows.Forms.NumericUpDown numericUpDown_max_height;
        private System.Windows.Forms.Label label_min_width;
        private System.Windows.Forms.Label label_min_height;
        private System.Windows.Forms.NumericUpDown numericUpDown_min_width;
        private System.Windows.Forms.NumericUpDown numericUpDown_min_height;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_export_path;
        private System.Windows.Forms.Button button_reference_export;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.TextBox textBox_export_folder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_export_folder;
        private System.Windows.Forms.CheckBox checkBox_reflectIdToGameTitle;
        private System.Windows.Forms.Label label_projectId;
        private System.Windows.Forms.TextBox textBox_projectId;
        private System.Windows.Forms.ComboBox comboBox_projectId;
    }
}

