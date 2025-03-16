
namespace PDFArrange
{
    partial class UCCategory
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.cBox_ctSave = new System.Windows.Forms.CheckBox();
            this.tBox_ctFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBox_ctMemo = new System.Windows.Forms.TextBox();
            this.btn_ctAdd = new System.Windows.Forms.Button();
            this.tBox_ctPages = new System.Windows.Forms.TextBox();
            this.btn_ctEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cBox_ctSave
            // 
            this.cBox_ctSave.AutoSize = true;
            this.cBox_ctSave.Checked = true;
            this.cBox_ctSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBox_ctSave.Location = new System.Drawing.Point(3, 3);
            this.cBox_ctSave.Name = "cBox_ctSave";
            this.cBox_ctSave.Size = new System.Drawing.Size(48, 16);
            this.cBox_ctSave.TabIndex = 0;
            this.cBox_ctSave.Text = "保存";
            this.cBox_ctSave.UseVisualStyleBackColor = true;
            // 
            // tBox_ctFileName
            // 
            this.tBox_ctFileName.Location = new System.Drawing.Point(114, 1);
            this.tBox_ctFileName.Name = "tBox_ctFileName";
            this.tBox_ctFileName.Size = new System.Drawing.Size(207, 19);
            this.tBox_ctFileName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "ファイル名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "メモ";
            // 
            // tBox_ctMemo
            // 
            this.tBox_ctMemo.Location = new System.Drawing.Point(31, 26);
            this.tBox_ctMemo.Multiline = true;
            this.tBox_ctMemo.Name = "tBox_ctMemo";
            this.tBox_ctMemo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBox_ctMemo.Size = new System.Drawing.Size(290, 30);
            this.tBox_ctMemo.TabIndex = 3;
            // 
            // btn_ctAdd
            // 
            this.btn_ctAdd.Location = new System.Drawing.Point(326, 1);
            this.btn_ctAdd.Name = "btn_ctAdd";
            this.btn_ctAdd.Size = new System.Drawing.Size(75, 48);
            this.btn_ctAdd.TabIndex = 5;
            this.btn_ctAdd.Text = "この分類に\r\n追加";
            this.btn_ctAdd.UseVisualStyleBackColor = false;
            this.btn_ctAdd.Click += new System.EventHandler(this.btn_ctAdd_Click);
            // 
            // tBox_ctPages
            // 
            this.tBox_ctPages.BackColor = System.Drawing.Color.Ivory;
            this.tBox_ctPages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBox_ctPages.Location = new System.Drawing.Point(5, 60);
            this.tBox_ctPages.Name = "tBox_ctPages";
            this.tBox_ctPages.ReadOnly = true;
            this.tBox_ctPages.Size = new System.Drawing.Size(316, 19);
            this.tBox_ctPages.TabIndex = 6;
            // 
            // btn_ctEdit
            // 
            this.btn_ctEdit.Enabled = false;
            this.btn_ctEdit.Location = new System.Drawing.Point(326, 55);
            this.btn_ctEdit.Name = "btn_ctEdit";
            this.btn_ctEdit.Size = new System.Drawing.Size(75, 24);
            this.btn_ctEdit.TabIndex = 7;
            this.btn_ctEdit.Text = "編集";
            this.btn_ctEdit.UseVisualStyleBackColor = false;
            this.btn_ctEdit.Click += new System.EventHandler(this.btn_ctEdit_Click);
            // 
            // UCCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btn_ctEdit);
            this.Controls.Add(this.tBox_ctPages);
            this.Controls.Add(this.btn_ctAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBox_ctMemo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBox_ctFileName);
            this.Controls.Add(this.cBox_ctSave);
            this.Name = "UCCategory";
            this.Size = new System.Drawing.Size(402, 82);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cBox_ctSave;
        private System.Windows.Forms.TextBox tBox_ctFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBox_ctMemo;
        private System.Windows.Forms.Button btn_ctAdd;
        private System.Windows.Forms.TextBox tBox_ctPages;
        private System.Windows.Forms.Button btn_ctEdit;
    }
}
