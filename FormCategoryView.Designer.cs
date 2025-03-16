
namespace PDFArrange
{
    partial class FormCategoryView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.tBox_cvMemo = new System.Windows.Forms.TextBox();
			this.tBox_cvFile = new System.Windows.Forms.TextBox();
			this.btn_cvDelete = new System.Windows.Forms.Button();
			this.btn_cvRotateLeft = new System.Windows.Forms.Button();
			this.btn_cvRotateRight = new System.Windows.Forms.Button();
			this.tBox_cvPages = new System.Windows.Forms.TextBox();
			this.panel = new System.Windows.Forms.Panel();
			this.webView2_cvPDFView = new Microsoft.Web.WebView2.WinForms.WebView2();
			this.btn_cvUp = new System.Windows.Forms.Button();
			this.btn_cvDown = new System.Windows.Forms.Button();
			this.lView_cvPDFPageList = new System.Windows.Forms.ListView();
			this.imageList_cvPDFPageList = new System.Windows.Forms.ImageList(this.components);
			this.btn_cvSave = new System.Windows.Forms.Button();
			this.lab_cvMessage = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.webView2_cvPDFView)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.Location = new System.Drawing.Point(12, 12);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.tBox_cvMemo);
			this.splitContainer.Panel1.Controls.Add(this.tBox_cvFile);
			this.splitContainer.Panel1.Controls.Add(this.btn_cvDelete);
			this.splitContainer.Panel1.Controls.Add(this.btn_cvRotateLeft);
			this.splitContainer.Panel1.Controls.Add(this.btn_cvRotateRight);
			this.splitContainer.Panel1.Controls.Add(this.tBox_cvPages);
			this.splitContainer.Panel1.Controls.Add(this.panel);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.btn_cvUp);
			this.splitContainer.Panel2.Controls.Add(this.btn_cvDown);
			this.splitContainer.Panel2.Controls.Add(this.lView_cvPDFPageList);
			this.splitContainer.Size = new System.Drawing.Size(715, 530);
			this.splitContainer.SplitterDistance = 546;
			this.splitContainer.TabIndex = 0;
			// 
			// tBox_cvMemo
			// 
			this.tBox_cvMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tBox_cvMemo.BackColor = System.Drawing.Color.Ivory;
			this.tBox_cvMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tBox_cvMemo.Location = new System.Drawing.Point(219, 3);
			this.tBox_cvMemo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tBox_cvMemo.Name = "tBox_cvMemo";
			this.tBox_cvMemo.ReadOnly = true;
			this.tBox_cvMemo.Size = new System.Drawing.Size(324, 19);
			this.tBox_cvMemo.TabIndex = 152;
			// 
			// tBox_cvFile
			// 
			this.tBox_cvFile.BackColor = System.Drawing.Color.Ivory;
			this.tBox_cvFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tBox_cvFile.Location = new System.Drawing.Point(4, 3);
			this.tBox_cvFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tBox_cvFile.Name = "tBox_cvFile";
			this.tBox_cvFile.ReadOnly = true;
			this.tBox_cvFile.Size = new System.Drawing.Size(207, 19);
			this.tBox_cvFile.TabIndex = 151;
			// 
			// btn_cvDelete
			// 
			this.btn_cvDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_cvDelete.Location = new System.Drawing.Point(338, 28);
			this.btn_cvDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btn_cvDelete.Name = "btn_cvDelete";
			this.btn_cvDelete.Size = new System.Drawing.Size(119, 25);
			this.btn_cvDelete.TabIndex = 150;
			this.btn_cvDelete.Text = "分類から削除(戻す)";
			this.btn_cvDelete.UseVisualStyleBackColor = false;
			this.btn_cvDelete.Click += new System.EventHandler(this.btn_cvDelete_Click);
			// 
			// btn_cvRotateLeft
			// 
			this.btn_cvRotateLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_cvRotateLeft.Location = new System.Drawing.Point(465, 28);
			this.btn_cvRotateLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btn_cvRotateLeft.Name = "btn_cvRotateLeft";
			this.btn_cvRotateLeft.Size = new System.Drawing.Size(37, 25);
			this.btn_cvRotateLeft.TabIndex = 149;
			this.btn_cvRotateLeft.Text = "左";
			this.btn_cvRotateLeft.UseVisualStyleBackColor = false;
			this.btn_cvRotateLeft.Click += new System.EventHandler(this.btn_cvRotateLeft_Click);
			// 
			// btn_cvRotateRight
			// 
			this.btn_cvRotateRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_cvRotateRight.Location = new System.Drawing.Point(505, 28);
			this.btn_cvRotateRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btn_cvRotateRight.Name = "btn_cvRotateRight";
			this.btn_cvRotateRight.Size = new System.Drawing.Size(37, 25);
			this.btn_cvRotateRight.TabIndex = 148;
			this.btn_cvRotateRight.Text = "右";
			this.btn_cvRotateRight.UseVisualStyleBackColor = false;
			this.btn_cvRotateRight.Click += new System.EventHandler(this.btn_cvRotateRight_Click);
			// 
			// tBox_cvPages
			// 
			this.tBox_cvPages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tBox_cvPages.BackColor = System.Drawing.Color.Ivory;
			this.tBox_cvPages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tBox_cvPages.Location = new System.Drawing.Point(4, 32);
			this.tBox_cvPages.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tBox_cvPages.Name = "tBox_cvPages";
			this.tBox_cvPages.ReadOnly = true;
			this.tBox_cvPages.Size = new System.Drawing.Size(326, 19);
			this.tBox_cvPages.TabIndex = 147;
			// 
			// panel
			// 
			this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel.Controls.Add(this.webView2_cvPDFView);
			this.panel.Location = new System.Drawing.Point(3, 59);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(540, 468);
			this.panel.TabIndex = 2;
			// 
			// webView2_cvPDFView
			// 
			this.webView2_cvPDFView.AllowExternalDrop = true;
			this.webView2_cvPDFView.CreationProperties = null;
			this.webView2_cvPDFView.DefaultBackgroundColor = System.Drawing.Color.White;
			this.webView2_cvPDFView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webView2_cvPDFView.Location = new System.Drawing.Point(0, 0);
			this.webView2_cvPDFView.Name = "webView2_cvPDFView";
			this.webView2_cvPDFView.Size = new System.Drawing.Size(538, 466);
			this.webView2_cvPDFView.TabIndex = 2;
			this.webView2_cvPDFView.ZoomFactor = 1D;
			// 
			// btn_cvUp
			// 
			this.btn_cvUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_cvUp.Location = new System.Drawing.Point(84, 8);
			this.btn_cvUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btn_cvUp.Name = "btn_cvUp";
			this.btn_cvUp.Size = new System.Drawing.Size(37, 25);
			this.btn_cvUp.TabIndex = 151;
			this.btn_cvUp.Text = "▲";
			this.btn_cvUp.UseVisualStyleBackColor = false;
			this.btn_cvUp.Click += new System.EventHandler(this.btn_cvUp_Click);
			// 
			// btn_cvDown
			// 
			this.btn_cvDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_cvDown.Location = new System.Drawing.Point(124, 8);
			this.btn_cvDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btn_cvDown.Name = "btn_cvDown";
			this.btn_cvDown.Size = new System.Drawing.Size(37, 25);
			this.btn_cvDown.TabIndex = 150;
			this.btn_cvDown.Text = "▼";
			this.btn_cvDown.UseVisualStyleBackColor = false;
			this.btn_cvDown.Click += new System.EventHandler(this.btn_cvDown_Click);
			// 
			// lView_cvPDFPageList
			// 
			this.lView_cvPDFPageList.AllowDrop = true;
			this.lView_cvPDFPageList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lView_cvPDFPageList.HideSelection = false;
			this.lView_cvPDFPageList.LargeImageList = this.imageList_cvPDFPageList;
			this.lView_cvPDFPageList.Location = new System.Drawing.Point(4, 39);
			this.lView_cvPDFPageList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.lView_cvPDFPageList.MultiSelect = false;
			this.lView_cvPDFPageList.Name = "lView_cvPDFPageList";
			this.lView_cvPDFPageList.Size = new System.Drawing.Size(157, 487);
			this.lView_cvPDFPageList.TabIndex = 144;
			this.lView_cvPDFPageList.UseCompatibleStateImageBehavior = false;
			this.lView_cvPDFPageList.SelectedIndexChanged += new System.EventHandler(this.lView_cvPDFPageList_SelectedIndexChanged);
			// 
			// imageList_cvPDFPageList
			// 
			this.imageList_cvPDFPageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList_cvPDFPageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList_cvPDFPageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// btn_cvSave
			// 
			this.btn_cvSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_cvSave.Location = new System.Drawing.Point(636, 548);
			this.btn_cvSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btn_cvSave.Name = "btn_cvSave";
			this.btn_cvSave.Size = new System.Drawing.Size(90, 25);
			this.btn_cvSave.TabIndex = 151;
			this.btn_cvSave.Text = "編集終了";
			this.btn_cvSave.UseVisualStyleBackColor = false;
			this.btn_cvSave.Click += new System.EventHandler(this.btn_cvSave_Click);
			// 
			// lab_cvMessage
			// 
			this.lab_cvMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lab_cvMessage.BackColor = System.Drawing.Color.White;
			this.lab_cvMessage.ForeColor = System.Drawing.Color.Red;
			this.lab_cvMessage.Location = new System.Drawing.Point(13, 553);
			this.lab_cvMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lab_cvMessage.Name = "lab_cvMessage";
			this.lab_cvMessage.Size = new System.Drawing.Size(615, 16);
			this.lab_cvMessage.TabIndex = 150;
			this.lab_cvMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormCategoryView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(739, 578);
			this.Controls.Add(this.btn_cvSave);
			this.Controls.Add(this.lab_cvMessage);
			this.Controls.Add(this.splitContainer);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormCategoryView";
			this.Text = "分類済みPDF編集";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCategoryView_FormClosing);
			this.Load += new System.EventHandler(this.FormCatetoryView_Load);
			this.Shown += new System.EventHandler(this.FormCategoryView_Shown);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.webView2_cvPDFView)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ListView lView_cvPDFPageList;
        private System.Windows.Forms.TextBox tBox_cvPages;
        private System.Windows.Forms.Button btn_cvDelete;
        private System.Windows.Forms.Button btn_cvRotateLeft;
        private System.Windows.Forms.Button btn_cvRotateRight;
        private System.Windows.Forms.Button btn_cvUp;
        private System.Windows.Forms.Button btn_cvDown;
        private System.Windows.Forms.ImageList imageList_cvPDFPageList;
        private System.Windows.Forms.TextBox tBox_cvFile;
        private System.Windows.Forms.TextBox tBox_cvMemo;
        private System.Windows.Forms.Button btn_cvSave;
        private System.Windows.Forms.Label lab_cvMessage;
		private Microsoft.Web.WebView2.WinForms.WebView2 webView2_cvPDFView;
	}
}