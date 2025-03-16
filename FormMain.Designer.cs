
namespace PDFArrange
{
    partial class FormMain
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.panel_paSrcPDF = new System.Windows.Forms.Panel();
			this.webView2_paPDFView = new Microsoft.Web.WebView2.WinForms.WebView2();
			this.lab_paMessage = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btn_psPDFRead = new System.Windows.Forms.Button();
			this.btn_paPDFFileRef = new System.Windows.Forms.Button();
			this.tBox_paPDFFile = new System.Windows.Forms.TextBox();
			this.lView_paPDFPageList = new System.Windows.Forms.ListView();
			this.imageList_paPDFPageList = new System.Windows.Forms.ImageList(this.components);
			this.flPanel_paDstPDF = new System.Windows.Forms.FlowLayoutPanel();
			this.btn_paPageDelete = new System.Windows.Forms.Button();
			this.btn_paCategoryAdd = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tBox_paDeletePages = new System.Windows.Forms.TextBox();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.btn_paRotateLeft = new System.Windows.Forms.Button();
			this.btn_paRotateRight = new System.Windows.Forms.Button();
			this.btn_paUndo = new System.Windows.Forms.Button();
			this.btn_paSave = new System.Windows.Forms.Button();
			this.btn_paClose = new System.Windows.Forms.Button();
			this.panel_paSrcPDF.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.webView2_paPDFView)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel_paSrcPDF
			// 
			this.panel_paSrcPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel_paSrcPDF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_paSrcPDF.Controls.Add(this.webView2_paPDFView);
			this.panel_paSrcPDF.Location = new System.Drawing.Point(6, 36);
			this.panel_paSrcPDF.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.panel_paSrcPDF.Name = "panel_paSrcPDF";
			this.panel_paSrcPDF.Size = new System.Drawing.Size(703, 547);
			this.panel_paSrcPDF.TabIndex = 137;
			// 
			// webView2_paPDFView
			// 
			this.webView2_paPDFView.AllowExternalDrop = true;
			this.webView2_paPDFView.CreationProperties = null;
			this.webView2_paPDFView.DefaultBackgroundColor = System.Drawing.Color.White;
			this.webView2_paPDFView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webView2_paPDFView.Location = new System.Drawing.Point(0, 0);
			this.webView2_paPDFView.Name = "webView2_paPDFView";
			this.webView2_paPDFView.Size = new System.Drawing.Size(701, 545);
			this.webView2_paPDFView.TabIndex = 3;
			this.webView2_paPDFView.ZoomFactor = 1D;
			// 
			// lab_paMessage
			// 
			this.lab_paMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lab_paMessage.BackColor = System.Drawing.Color.White;
			this.lab_paMessage.ForeColor = System.Drawing.Color.Red;
			this.lab_paMessage.Location = new System.Drawing.Point(14, 607);
			this.lab_paMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lab_paMessage.Name = "lab_paMessage";
			this.lab_paMessage.Size = new System.Drawing.Size(1028, 16);
			this.lab_paMessage.TabIndex = 138;
			this.lab_paMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(4, 11);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(67, 13);
			this.label6.TabIndex = 139;
			this.label6.Text = "PDFファイル";
			// 
			// btn_psPDFRead
			// 
			this.btn_psPDFRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_psPDFRead.Location = new System.Drawing.Point(514, 5);
			this.btn_psPDFRead.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btn_psPDFRead.Name = "btn_psPDFRead";
			this.btn_psPDFRead.Size = new System.Drawing.Size(103, 25);
			this.btn_psPDFRead.TabIndex = 142;
			this.btn_psPDFRead.Text = "PDF読み込み";
			this.btn_psPDFRead.UseVisualStyleBackColor = false;
			this.btn_psPDFRead.Click += new System.EventHandler(this.btn_psPDFRead_Click);
			// 
			// btn_paPDFFileRef
			// 
			this.btn_paPDFFileRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_paPDFFileRef.Location = new System.Drawing.Point(431, 6);
			this.btn_paPDFFileRef.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btn_paPDFFileRef.Name = "btn_paPDFFileRef";
			this.btn_paPDFFileRef.Size = new System.Drawing.Size(76, 25);
			this.btn_paPDFFileRef.TabIndex = 141;
			this.btn_paPDFFileRef.Text = "参照";
			this.btn_paPDFFileRef.UseVisualStyleBackColor = false;
			this.btn_paPDFFileRef.Click += new System.EventHandler(this.btn_paPDFFileRef_Click);
			// 
			// tBox_paPDFFile
			// 
			this.tBox_paPDFFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tBox_paPDFFile.Location = new System.Drawing.Point(77, 8);
			this.tBox_paPDFFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tBox_paPDFFile.Name = "tBox_paPDFFile";
			this.tBox_paPDFFile.Size = new System.Drawing.Size(346, 20);
			this.tBox_paPDFFile.TabIndex = 140;
			// 
			// lView_paPDFPageList
			// 
			this.lView_paPDFPageList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
			this.lView_paPDFPageList.AllowDrop = true;
			this.lView_paPDFPageList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lView_paPDFPageList.Enabled = false;
			this.lView_paPDFPageList.FullRowSelect = true;
			this.lView_paPDFPageList.HideSelection = false;
			this.lView_paPDFPageList.LargeImageList = this.imageList_paPDFPageList;
			this.lView_paPDFPageList.Location = new System.Drawing.Point(4, 475);
			this.lView_paPDFPageList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.lView_paPDFPageList.MultiSelect = false;
			this.lView_paPDFPageList.Name = "lView_paPDFPageList";
			this.lView_paPDFPageList.Size = new System.Drawing.Size(502, 111);
			this.lView_paPDFPageList.TabIndex = 143;
			this.lView_paPDFPageList.UseCompatibleStateImageBehavior = false;
			this.lView_paPDFPageList.SelectedIndexChanged += new System.EventHandler(this.lView_paPDFPageList_SelectedIndexChanged);
			// 
			// imageList_paPDFPageList
			// 
			this.imageList_paPDFPageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList_paPDFPageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList_paPDFPageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// flPanel_paDstPDF
			// 
			this.flPanel_paDstPDF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.flPanel_paDstPDF.AutoScroll = true;
			this.flPanel_paDstPDF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flPanel_paDstPDF.Location = new System.Drawing.Point(7, 79);
			this.flPanel_paDstPDF.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.flPanel_paDstPDF.Name = "flPanel_paDstPDF";
			this.flPanel_paDstPDF.Size = new System.Drawing.Size(498, 390);
			this.flPanel_paDstPDF.TabIndex = 144;
			// 
			// btn_paPageDelete
			// 
			this.btn_paPageDelete.Location = new System.Drawing.Point(379, 5);
			this.btn_paPageDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btn_paPageDelete.Name = "btn_paPageDelete";
			this.btn_paPageDelete.Size = new System.Drawing.Size(113, 20);
			this.btn_paPageDelete.TabIndex = 145;
			this.btn_paPageDelete.Text = "ページ削除";
			this.btn_paPageDelete.UseVisualStyleBackColor = false;
			this.btn_paPageDelete.Click += new System.EventHandler(this.btn_paPageDelete_Click);
			// 
			// btn_paCategoryAdd
			// 
			this.btn_paCategoryAdd.Location = new System.Drawing.Point(416, 47);
			this.btn_paCategoryAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btn_paCategoryAdd.Name = "btn_paCategoryAdd";
			this.btn_paCategoryAdd.Size = new System.Drawing.Size(90, 25);
			this.btn_paCategoryAdd.TabIndex = 146;
			this.btn_paCategoryAdd.Text = "分類追加";
			this.btn_paCategoryAdd.UseVisualStyleBackColor = false;
			this.btn_paCategoryAdd.Click += new System.EventHandler(this.btn_paCategoryAdd_Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.tBox_paDeletePages);
			this.panel1.Controls.Add(this.btn_paPageDelete);
			this.panel1.Location = new System.Drawing.Point(4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(498, 37);
			this.panel1.TabIndex = 147;
			// 
			// tBox_paDeletePages
			// 
			this.tBox_paDeletePages.BackColor = System.Drawing.Color.Ivory;
			this.tBox_paDeletePages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tBox_paDeletePages.Location = new System.Drawing.Point(4, 5);
			this.tBox_paDeletePages.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tBox_paDeletePages.Name = "tBox_paDeletePages";
			this.tBox_paDeletePages.ReadOnly = true;
			this.tBox_paDeletePages.Size = new System.Drawing.Size(369, 20);
			this.tBox_paDeletePages.TabIndex = 146;
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.Location = new System.Drawing.Point(10, 10);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.btn_paRotateLeft);
			this.splitContainer.Panel1.Controls.Add(this.btn_paRotateRight);
			this.splitContainer.Panel1.Controls.Add(this.panel_paSrcPDF);
			this.splitContainer.Panel1.Controls.Add(this.btn_psPDFRead);
			this.splitContainer.Panel1.Controls.Add(this.tBox_paPDFFile);
			this.splitContainer.Panel1.Controls.Add(this.btn_paPDFFileRef);
			this.splitContainer.Panel1.Controls.Add(this.label6);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.btn_paUndo);
			this.splitContainer.Panel2.Controls.Add(this.lView_paPDFPageList);
			this.splitContainer.Panel2.Controls.Add(this.btn_paCategoryAdd);
			this.splitContainer.Panel2.Controls.Add(this.panel1);
			this.splitContainer.Panel2.Controls.Add(this.flPanel_paDstPDF);
			this.splitContainer.Size = new System.Drawing.Size(1228, 586);
			this.splitContainer.SplitterDistance = 713;
			this.splitContainer.TabIndex = 148;
			// 
			// btn_paRotateLeft
			// 
			this.btn_paRotateLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_paRotateLeft.Location = new System.Drawing.Point(631, 6);
			this.btn_paRotateLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btn_paRotateLeft.Name = "btn_paRotateLeft";
			this.btn_paRotateLeft.Size = new System.Drawing.Size(37, 25);
			this.btn_paRotateLeft.TabIndex = 144;
			this.btn_paRotateLeft.Text = "左";
			this.btn_paRotateLeft.UseVisualStyleBackColor = false;
			this.btn_paRotateLeft.Click += new System.EventHandler(this.btn_paRotateLeft_Click);
			// 
			// btn_paRotateRight
			// 
			this.btn_paRotateRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_paRotateRight.Location = new System.Drawing.Point(671, 6);
			this.btn_paRotateRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btn_paRotateRight.Name = "btn_paRotateRight";
			this.btn_paRotateRight.Size = new System.Drawing.Size(37, 25);
			this.btn_paRotateRight.TabIndex = 143;
			this.btn_paRotateRight.Text = "右";
			this.btn_paRotateRight.UseVisualStyleBackColor = false;
			this.btn_paRotateRight.Click += new System.EventHandler(this.btn_paRotateRight_Click);
			// 
			// btn_paUndo
			// 
			this.btn_paUndo.Enabled = false;
			this.btn_paUndo.Location = new System.Drawing.Point(7, 48);
			this.btn_paUndo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btn_paUndo.Name = "btn_paUndo";
			this.btn_paUndo.Size = new System.Drawing.Size(122, 25);
			this.btn_paUndo.TabIndex = 148;
			this.btn_paUndo.Text = "削除/追加取り消し";
			this.btn_paUndo.UseVisualStyleBackColor = false;
			this.btn_paUndo.Click += new System.EventHandler(this.btn_paUndo_Click);
			// 
			// btn_paSave
			// 
			this.btn_paSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_paSave.Location = new System.Drawing.Point(1050, 602);
			this.btn_paSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btn_paSave.Name = "btn_paSave";
			this.btn_paSave.Size = new System.Drawing.Size(90, 25);
			this.btn_paSave.TabIndex = 149;
			this.btn_paSave.Text = "保存して終了";
			this.btn_paSave.UseVisualStyleBackColor = false;
			this.btn_paSave.Click += new System.EventHandler(this.btn_paSave_Click);
			// 
			// btn_paClose
			// 
			this.btn_paClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_paClose.Location = new System.Drawing.Point(1148, 602);
			this.btn_paClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btn_paClose.Name = "btn_paClose";
			this.btn_paClose.Size = new System.Drawing.Size(90, 25);
			this.btn_paClose.TabIndex = 150;
			this.btn_paClose.Text = "破棄して終了";
			this.btn_paClose.UseVisualStyleBackColor = false;
			this.btn_paClose.Click += new System.EventHandler(this.btn_paClose_Click);
			// 
			// FormMain
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1250, 633);
			this.Controls.Add(this.btn_paClose);
			this.Controls.Add(this.btn_paSave);
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.lab_paMessage);
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "FormMain";
			this.Text = "PDF整理 V2.2";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
			this.panel_paSrcPDF.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.webView2_paPDFView)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_paSrcPDF;
        private System.Windows.Forms.Label lab_paMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_psPDFRead;
        private System.Windows.Forms.Button btn_paPDFFileRef;
        private System.Windows.Forms.TextBox tBox_paPDFFile;
        private System.Windows.Forms.ListView lView_paPDFPageList;
        private System.Windows.Forms.FlowLayoutPanel flPanel_paDstPDF;
        private System.Windows.Forms.ImageList imageList_paPDFPageList;
        private System.Windows.Forms.Button btn_paPageDelete;
        private System.Windows.Forms.Button btn_paCategoryAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox tBox_paDeletePages;
        private System.Windows.Forms.Button btn_paSave;
        private System.Windows.Forms.Button btn_paUndo;
        private System.Windows.Forms.Button btn_paClose;
        private System.Windows.Forms.Button btn_paRotateLeft;
        private System.Windows.Forms.Button btn_paRotateRight;
		private Microsoft.Web.WebView2.WinForms.WebView2 webView2_paPDFView;
	}
}

