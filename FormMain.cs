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
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;


namespace PDFArrange
{
	public partial class FormMain : Form
	{
		[System.Runtime.InteropServices.DllImport("ole32.dll")]
		private static extern void CoFreeUnusedLibraries();

		private string exeFolder = null;
		private string workingFolder = null;
		private string outputFolder = null;
		private List<PDFPageEntry> pdfPageEntryList = null;
		private PDFPageEntry currPage = null;
		private List<UCCategory> categoryList = null;
		private List<int> deletePageList = null;
		private List<int> undoList = null;
		private List<Image> allThumbNailImageList = null;
		private bool saveFlag = false;
		private bool inProcFlag = false;
		private bool pauseWebViewFlag = false;

		private const int SIZEX = 64;
		private const int SIZEY = 64;

		public FormMain()
		{
			InitializeComponent();
			Assembly asm = Assembly.GetEntryAssembly();
			string exePath = asm.Location;
			exeFolder = Path.GetDirectoryName(exePath);
			workingFolder = Path.Combine(exeFolder, "WorkingFolder");
			if (Directory.Exists(workingFolder))
			{
				DeleteAll(workingFolder, true);
			}
			else
			{
				Directory.CreateDirectory(workingFolder);
			}
			outputFolder = Path.Combine(exeFolder, "OutputFolder");
			if (Directory.Exists(outputFolder))
			{
			}
			else
			{
				Directory.CreateDirectory(outputFolder);
			}

			imageList_paPDFPageList.ImageSize = new Size(SIZEX, SIZEY);
			deletePageList = new List<int>();
			undoList = new List<int>();
			allThumbNailImageList = new List<Image>();
			InitWebView();
		}


		// WebView2初期化
		async private void InitWebView()
		{
			await webView2_paPDFView.EnsureCoreWebView2Async();
		}


		private void FormMain_Load(object sender, EventArgs e)
		{
			categoryList = new List<UCCategory>();
			UCCategory cat1 = new UCCategory();
			cat1.CategoryNo = categoryList.Count;
			cat1.AddEvent += CategoryAdd;
			cat1.EditEvent += CategoryEdit;
			categoryList.Add(cat1);
			flPanel_paDstPDF.Controls.Add(cat1);
			UCCategory cat2 = new UCCategory();
			cat2.CategoryNo = categoryList.Count;
			cat2.AddEvent += CategoryAdd;
			cat2.EditEvent += CategoryEdit;
			categoryList.Add(cat2);
			flPanel_paDstPDF.Controls.Add(cat2);
		}


		// ファイル参照ボタン処理
		private void btn_paPDFFileRef_Click(object sender, EventArgs e)
		{
			lab_paMessage.Text = "";
			OpenFileDialog ofd = new OpenFileDialog();
			if (ofd.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			tBox_paPDFFile.Text = ofd.FileName;
		}


		// ファイル読み込み
		private void btn_psPDFRead_Click(object sender, EventArgs e)
		{
			lab_paMessage.Text = "";
			if (tBox_paPDFFile.Text.Trim() == "")
			{
				lab_paMessage.Text = "PDFファイルを指定してください。";
				return;
			}
			if (!File.Exists(tBox_paPDFFile.Text.Trim()))
			{
				lab_paMessage.Text = "ファイルが見つかりません。";
				return;
			}

			string filename = tBox_paPDFFile.Text.Trim();
			PdfDocument inputDocument;
			try
			{
				inputDocument = PdfReader.Open(filename, PdfDocumentOpenMode.Import);
			}
			catch (Exception ex)
			{
				lab_paMessage.Text = "PDFファイルの読み込みに失敗しました。";
				return;
			}

			pdfPageEntryList = new List<PDFPageEntry>();
			string name = Path.GetFileNameWithoutExtension(filename);
			for (int idx = 0; idx < inputDocument.PageCount; idx++)
			{ 
				PDFPageEntry entry = new PDFPageEntry(idx + 1, inputDocument.PageCount, name,
					String.Format("{0}_P{1}.pdf", name, idx + 1), Path.Combine(workingFolder, String.Format("{0}_P{1}.pdf", name, idx + 1)));
				PdfDocument outputDocument = new PdfDocument();
				outputDocument.Version = inputDocument.Version;
				outputDocument.Info.Title = String.Format("Page {0} of {1}", idx + 1, inputDocument.Info.Title);
				outputDocument.Info.Creator = inputDocument.Info.Creator;

				outputDocument.AddPage(inputDocument.Pages[idx]); 
				outputDocument.Save(entry.FilePath);
				pdfPageEntryList.Add(entry);
			}
			btn_psPDFRead.Enabled = false;
			btn_paPDFFileRef.Enabled = false;
			tBox_paPDFFile.Enabled = false;
			AllowDrop = false;

			MakeSrcPDFList();
			if (pdfPageEntryList.Count > 0)
			{
				lView_paPDFPageList.Items[0].Selected = true;
			}
			lView_paPDFPageList.Enabled = true;
		}


		// PDF一覧の元リスト作成
		private void MakeSrcPDFList()
		{
			for (int i1 = 0; i1 < pdfPageEntryList.Count; i1++)
			{
				PDFPageEntry entry = pdfPageEntryList[i1];
				if (entry.PageState != PDFPageEntry.PS_NONE)
				{
					continue;
				}
				string file = entry.FilePath;
				ThumbnailCreator thumbCreator = new ThumbnailCreator(SIZEX, SIZEY);
				Image thumbImage = thumbCreator.Thumbnail(null, file);
				allThumbNailImageList.Add(thumbImage);
				imageList_paPDFPageList.Images.Add(thumbImage);

				ListViewItem item = null;
				item = new ListViewItem();
				item.Text = entry.Page.ToString();
				item.ImageIndex = i1;
				item.Tag = i1;
				lView_paPDFPageList.Items.Add(item);
			}
		}


		// PDF一覧の元リスト更新
		private void RefreshSrcPDFList()
		{
			lView_paPDFPageList.Items.Clear();
			for (int i1 = 0; i1 < pdfPageEntryList.Count; i1++)
			{
				PDFPageEntry entry = pdfPageEntryList[i1];
				if (entry.PageState != PDFPageEntry.PS_NONE)
				{
					continue;
				}
				ListViewItem item = null;
				item = new ListViewItem();
				item.Text = entry.Page.ToString();
				item.ImageIndex = i1;
				item.Tag = i1;
				lView_paPDFPageList.Items.Add(item);
			}
		}


		// ファイル削除
		public static bool DeleteAll(string targetDirectoryPath, bool subFolderOnly)
		{
			if (!Directory.Exists (targetDirectoryPath))
			{
				return false;
			}

			try
			{
				string[] filePaths = Directory.GetFiles(targetDirectoryPath);
				foreach (string filePath in filePaths)
				{
					File.SetAttributes(filePath, FileAttributes.Normal);
					File.Delete(filePath);
				}

				string[] directoryPaths = Directory.GetDirectories(targetDirectoryPath);
				foreach (string directoryPath in directoryPaths)
				{
					if (DeleteAll(directoryPath, false) == false)
					{
						return false;
					}
				}

				if (subFolderOnly)
				{
					return true;
				}
				Directory.Delete(targetDirectoryPath, false);
			}
			catch
			{
				return false;
			}
			return true;
		}


		// ListView選択項目のTag取得
		private PDFPageEntry GetLViewTag()
		{
			if (lView_paPDFPageList.SelectedItems.Count != 1)
			{
				return null;
			}
			int tag = (int)lView_paPDFPageList.SelectedItems[0].Tag;
			if (tag < 0 || tag >= pdfPageEntryList.Count)
			{
				return null;
			}
			return pdfPageEntryList[tag];
		}


		// ListView選択変更イベントハンドラ
		private void lView_paPDFPageList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (pauseWebViewFlag)
			{
				return;
			}
			lab_paMessage.Text = "";
			splitContainer.Panel1.Enabled = false;
			currPage = null;
			PDFPageEntry entry = GetLViewTag();
			if (entry == null)
			{
				for (int i1 = 0; i1 < 10; i1++)
				{
					webView2_paPDFView.CoreWebView2.Navigate("about:blank");
					Application.DoEvents();
					CoFreeUnusedLibraries();
					Thread.Sleep(10);
				}
				splitContainer.Panel1.Enabled = true;
				return;
			}
			currPage = entry;
			webView2_paPDFView.CoreWebView2.Navigate(entry.FilePath);
			splitContainer.Panel1.Enabled = true;
		}


		// PDFページ削除処理
		private void btn_paPageDelete_Click(object sender, EventArgs e)
		{
			lab_paMessage.Text = "";
			if (currPage == null)
			{
				lab_paMessage.Text = "ページが指定されていません。";
				return;
			}
			if (inProcFlag)
			{
				return;
			}
			inProcFlag = true;
			currPage.PageState = PDFPageEntry.PS_DELETE;
			int page = currPage.Page;
			AddDeletePage(page);
			pauseWebViewFlag = true;
			lView_paPDFPageList.SelectedItems[0].Remove();
			pauseWebViewFlag = false;
			currPage = null;

			SetLViewPage(page + 2);		//page +1では、page + 1が削除されるのでpageになってしまう
			inProcFlag = false;
		}


		// ListViewで指定ページを選択
		private void SetLViewPage(int page)
		{
			if (lView_paPDFPageList.Items.Count == 0)
			{
				for (int i1 = 0; i1 < 10; i1++)
				{
					webView2_paPDFView.CoreWebView2.Navigate("about:blank");
					Application.DoEvents();
					CoFreeUnusedLibraries();
					Thread.Sleep(10);
				}
				return;
			}
			for (int i1 = lView_paPDFPageList.Items.Count - 1; i1 >= 0; i1--)
			{
				int tag = (int)lView_paPDFPageList.Items[i1].Tag;
				PDFPageEntry entry = pdfPageEntryList[tag];
				if (entry.Page < page)
				{
					lView_paPDFPageList.Items[i1].Selected = true;
					lView_paPDFPageList.EnsureVisible(i1);
					return;
				}
			}
			if (lView_paPDFPageList.Items.Count > 0)
			{
				int lastPage = lView_paPDFPageList.Items.Count - 1;
				lView_paPDFPageList.Items[lastPage].Selected = true;
				lView_paPDFPageList.EnsureVisible(lastPage);
			}
		}


		// 削除ページリストに新たなページを追加
		private void AddDeletePage(int page)
		{
			undoList.Add(page);
			deletePageList.Add(page);
			RefreshDeleteList();
			btn_paUndo.Enabled = true;
		}


		// 削除ページリストの更新
		private void RefreshDeleteList()
		{
			string str = "";
			for (int i1 = 0; i1 < deletePageList.Count; i1++)
			{
				if (str != "")
				{
					str += "、";
				}
				str += deletePageList[i1].ToString();
			}
			tBox_paDeletePages.Text = str;
		}


		// 分類追加ボタン処理
		private void btn_paCategoryAdd_Click(object sender, EventArgs e)
		{
			UCCategory cat = new UCCategory();
			cat.CategoryNo = categoryList.Count;
			cat.AddEvent += CategoryAdd;
			cat.EditEvent += CategoryEdit;
			categoryList.Add(cat);
			flPanel_paDstPDF.Controls.Add(cat);
		}


		// 分類にPDFページを追加する処理
		private void CategoryAdd(object sender, int catNo)
		{
			lab_paMessage.Text = "";
			if (currPage == null)
			{
				lab_paMessage.Text = "ページが指定されていません。";
				return;
			}

			if (inProcFlag)
			{
				return;
			}
			inProcFlag = true;
			pauseWebViewFlag = true;
			if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
			{
				int startTag = (int)lView_paPDFPageList.SelectedItems[0].Tag;
				for (int i1 = 0; i1 < lView_paPDFPageList.Items.Count; i1++)
				{
					int tag = (int)lView_paPDFPageList.Items[0].Tag;
					if (tag == startTag)
					{
						break;
					}

					PDFPageEntry entry = pdfPageEntryList[tag];
					entry.PageState = PDFPageEntry.PS_CATEGORIZED;
					entry.CategoryNo = catNo;
					categoryList[catNo].PageAdd(entry.Page);
					lView_paPDFPageList.Items[0].Remove();
					undoList.Add(entry.Page);
				}
			}

			currPage.PageState = PDFPageEntry.PS_CATEGORIZED;
			currPage.CategoryNo = catNo;
			int page = currPage.Page;
			categoryList[catNo].PageAdd(page);
			lView_paPDFPageList.SelectedItems[0].Remove();
			currPage = null;
			undoList.Add(page);
			btn_paUndo.Enabled = true;
			pauseWebViewFlag = false;

			for (int i1 = 0; i1 < lView_paPDFPageList.Items.Count; i1++)
			{
				int tag = (int)lView_paPDFPageList.Items[i1].Tag;
				PDFPageEntry entry = pdfPageEntryList[tag];
				if (entry.Page > page)
				{
					lView_paPDFPageList.Items[i1].Selected = true;
					lView_paPDFPageList.EnsureVisible(i1);
					inProcFlag = false;
					return;
				}
			}
			if (lView_paPDFPageList.Items.Count > 0)
			{
				int lastPage = lView_paPDFPageList.Items.Count - 1;
				lView_paPDFPageList.Items[lastPage].Selected = true;
				lView_paPDFPageList.EnsureVisible(lastPage);
			}
			inProcFlag = false;
		}


		// カテゴリ編集機能処理
		private void CategoryEdit(object sender, int catNo)
		{
			lab_paMessage.Text = "";
			FormCategoryView view = new FormCategoryView();
			view.SetAppInfo(workingFolder, outputFolder, pdfPageEntryList, allThumbNailImageList, categoryList[catNo]);
			view.ShowDialog(this);
			List<int> ucUndoPageList = view.UndoPageList;
			view.Dispose();
			view = null;

			int sel = -1;
			if (lView_paPDFPageList.SelectedIndices.Count > 0)
			{
				sel = lView_paPDFPageList.SelectedIndices[0];
			}
			categoryList[catNo].RefreshUC();
			for (int i1 = 0; i1 < ucUndoPageList.Count; i1++)
			{
				for (int i2 = 0; i2 < undoList.Count; i2++)
				{
					if (undoList[i2] == ucUndoPageList[i1])
					{
						undoList.RemoveAt(i2);
						break;
					}
				}
			}
			if (ucUndoPageList.Count > 0)
			{
				imageList_paPDFPageList.Images.Clear();
				for (int i1 = 0; i1 < allThumbNailImageList.Count; i1++)
				{
					Image thumbImage = allThumbNailImageList[i1];
					imageList_paPDFPageList.Images.Add(thumbImage);
				}
				RefreshSrcPDFList();
				SetLViewSel(sel);
			}
			if (undoList.Count <= 0)
			{
				btn_paUndo.Enabled = false;
			}
		}


		// ListView選択時の処理
		private void SetLViewSel(int sel)
		{
			if (sel == -1)
			{
				return;
			}
			if (lView_paPDFPageList.Items.Count == 0)
			{
				for (int i1 = 0; i1 < 10; i1++)
				{
					webView2_paPDFView.CoreWebView2.Navigate("about:blank");
					Application.DoEvents();
					CoFreeUnusedLibraries();
					Thread.Sleep(10);
				}
				return;
			}
			if (sel >= lView_paPDFPageList.Items.Count)
			{
				sel = lView_paPDFPageList.Items.Count - 1;
			}
			lView_paPDFPageList.Items[sel].Selected = true;
			lView_paPDFPageList.EnsureVisible(sel);
		}


		// Undoボタン処理
		private void btn_paUndo_Click(object sender, EventArgs e)
		{
			if (undoList.Count == 0)
			{
				return;
			}

			if (inProcFlag)
			{
				return;
			}
			inProcFlag = true;
			int idx = undoList.Count - 1;
			int page = undoList[idx];
			PDFPageEntry entry = pdfPageEntryList[page - 1];
			if (entry.PageState == PDFPageEntry.PS_DELETE)
			{
				RemoveFromDeleteList(page);
				RefreshDeleteList();
			}
			else if (entry.PageState == PDFPageEntry.PS_CATEGORIZED)
			{
				for (int i1 = 0; i1 < categoryList.Count; i1++)
				{
					if(categoryList[i1].UndoPage(page))
					{
						break;
					}
				}
			}
			entry.PageState = PDFPageEntry.PS_NONE;
			imageList_paPDFPageList.Images.Clear();
			for (int i1 = 0; i1 < allThumbNailImageList.Count; i1++)
			{
				Image thumbImage = allThumbNailImageList[i1];
				imageList_paPDFPageList.Images.Add(thumbImage);
			}
			RefreshSrcPDFList();
			SetLViewPage(page + 1);
			undoList.RemoveAt(idx);
			if (undoList.Count <= 0)
			{
				btn_paUndo.Enabled = false;
			}
			inProcFlag = false;
		}


		// 削除一覧からページ除去
		private void RemoveFromDeleteList(int page)
		{
			for (int i1 = 0; i1 < deletePageList.Count; i1++)
			{
				if (deletePageList[i1] == page)
				{
					deletePageList.RemoveAt(i1);
				}
			}
		}


		// PDF上書き保存処理
		private void btn_paSave_Click(object sender, EventArgs e)
		{
			lab_paMessage.Text = "";
			for (int i1 = 0; i1 < categoryList.Count; i1++)
			{
				UCCategory cat = categoryList[i1];
				if (cat.IsSave == false)
				{
					continue;
				}
				if (cat.FileName.Trim() == "")
				{
					lab_paMessage.Text = "ファイル名が設定されいません。";
					return;
				}
			}
			for (int i1 = 0; i1 < categoryList.Count; i1++)
			{
				for (int i2 = i1 + 1; i2 < categoryList.Count; i2++)
				{
					if (String.Compare(categoryList[i1].FileName.Trim(), categoryList[i2].FileName.Trim(), true) == 0)
					{
						lab_paMessage.Text = "同一のファイル名が設定されています(" + (i1 + 1).ToString() + "番目と" + (i2 + 1).ToString() + "番目)。";
						return;
					}
				}
			}
			if (DoSave() == false)
			{
				lab_paMessage.Text = "保存に失敗しました。";
				return;
			}
			Process.Start("EXPLORER.EXE", outputFolder);
			saveFlag = true;
			Close();
		}


		// 保存処理本体
		public bool DoSave()
		{
			for (int i1 = 0; i1 < categoryList.Count; i1++)
			{
				UCCategory cat = categoryList[i1];
				if (cat.IsSave == false)
				{
					continue;
				}

				string outFile = cat.FileName.Trim();
				if (!outFile.ToUpper().StartsWith(".PDF"))
				{
					if (outFile.EndsWith("."))
					{
						outFile += "PDF";
					}
					else
					{
						outFile += ".PDF";
					}
				}
				string file = Path.Combine(outputFolder, outFile);

				PdfDocument outputDocument = new PdfDocument();
				List<int> pageList = cat.PageList;
				for (int i2 = 0; i2 < pageList.Count; i2++)
				{ 
					PDFPageEntry entry = pdfPageEntryList[pageList[i2] - 1];
					PdfDocument inputDocument = PdfReader.Open(entry.FilePath, PdfDocumentOpenMode.Import);
					PdfPage page = inputDocument.Pages[0];
					outputDocument.AddPage(page);
				}
				outputDocument.Save(file); 
			}
			return true;
		}


		private void btn_paClose_Click(object sender, EventArgs e)
		{
			Close();
		}


		private bool IsEdit
		{
			get
			{
				if (pdfPageEntryList == null)
				{
					return false;
				}
				for (int i1 = 0; i1 < pdfPageEntryList.Count; i1++)
				{
					PDFPageEntry entry = pdfPageEntryList[i1];
					if (entry.PageState != PDFPageEntry.PS_NONE)
					{
						return true;
					}
				}
				return false;
			}
		}


		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (saveFlag)
			{
				return;
			}
			if (IsEdit)
			{
				if (DialogResult.Cancel == MessageBox.Show("分類指定を破棄して終了します。終了してよろしいですか?", "PDF整理",
					MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2))
				{
					e.Cancel = true;
				}
			}
		}


		// PDFページ左回転の処理(PDFRorateメソッド呼び出し)
		private void btn_paRotateLeft_Click(object sender, EventArgs e)
		{
			if (currPage == null)
			{
				return;
			}
			if (inProcFlag)
			{
				return;
			}
			inProcFlag = true;
			int page = currPage.Page;
			PDFRorate(page, lView_paPDFPageList.SelectedIndices[0], false);
			inProcFlag = false;
		}


		// PDFページ右回転の処理(PDFRorateメソッド呼び出し)
		private void btn_paRotateRight_Click(object sender, EventArgs e)
		{
			if (currPage == null)
			{
				return;
			}
			if (inProcFlag)
			{
				return;
			}
			inProcFlag = true;
			int page = currPage.Page;
			PDFRorate(page, lView_paPDFPageList.SelectedIndices[0], true);
			inProcFlag = false;
		}


		// PDFページ回転の処理
		private void PDFRorate(int page, int pos, bool rightFlag)
		{
			PDFPageEntry entry = pdfPageEntryList[page - 1];

			PdfDocument document = PdfReader.Open(entry.FilePath, PdfDocumentOpenMode.Import);
			var pdfPage = document.Pages[0];
			pdfPage.Rotate = (pdfPage.Rotate + (rightFlag?90:-90)) % 360;
			document.Close();

			for (int i1 = 0; i1 < 10; i1++)
			{
				webView2_paPDFView.CoreWebView2.Navigate("about:blank");
				Application.DoEvents();
				CoFreeUnusedLibraries();
				Thread.Sleep(10);
				try
				{
					document.Save(entry.FilePath);
					break;
				}
				catch
				{
				}
			}
			webView2_paPDFView.CoreWebView2.Navigate(entry.FilePath);

			string file = entry.FilePath;
			ThumbnailCreator thumbCreator = new ThumbnailCreator(SIZEX, SIZEY);
			Image thumbImage = thumbCreator.Thumbnail(null, file);

			allThumbNailImageList[page - 1].Dispose();
			allThumbNailImageList[page - 1] = thumbImage;
			imageList_paPDFPageList.Images[page - 1] = thumbImage;

			// ImageListを変更するだけでは、ListViewが更新されない
			int value = lView_paPDFPageList.Items[pos].ImageIndex;
			lView_paPDFPageList.Items[pos].ImageIndex = -1;
			lView_paPDFPageList.Items[pos].ImageIndex = value;

			// こうするとListViewをクリックすると更新される。クリックが必要な不具合を以下で回避
			string str = lView_paPDFPageList.Items[/*page - 1*/pos].SubItems[0].Text;
			lView_paPDFPageList.Items[pos].SubItems[0].Text = str + "R";
			lView_paPDFPageList.Items[pos].SubItems[0].Text = str;
		}

		private void FormMain_KeyDown(object sender, KeyEventArgs e)
		{
		}


		private void FormMain_KeyUp(object sender, KeyEventArgs e)
		{
		}


		private void FormMain_DragEnter(object sender, DragEventArgs e)
		{
			if (tBox_paPDFFile.Enabled == false)
			{
				return;
			}
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (drags.Length != 1)
				{
					return;
				}
				if (!File.Exists(drags[0]))
				{
					return;
				}
				e.Effect = DragDropEffects.Copy;
			}
		}


		private void FormMain_DragDrop(object sender, DragEventArgs e)
		{
			lab_paMessage.Text = "";
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length != 1)
			{
				lab_paMessage.Text = "複数のファイルが選択されています。";
				return;
			}
			tBox_paPDFFile.Text = files[0];
		}
	}


	public class PDFPageEntry
	{
		private int page = -1;
		private int totalPage = -1;
		private string parentFile = null;
		private string fileName = null;
		private string filePath = null;
		private int pageState = PS_NONE;
		private int categoryNo = -1;

		public const int PS_NONE = 0;
		public const int PS_DELETE = 10;
		public const int PS_CATEGORIZED = 20;


		public PDFPageEntry(int pg, int tpg, string pFile, string fName, string fPath)
		{
			page = pg;
			totalPage = tpg;
			parentFile = pFile;
			fileName = fName;
			filePath = fPath;
		}


		public int Page
		{
			get
			{
				return page;
			}
		}


		public int TotalPage
		{
			get
			{
				return totalPage;
			}
		}


		public string ParentFile
		{
			get
			{
				return parentFile;
			}
		}


		public string FileName
		{
			get
			{
				return fileName;
			}
		}


		public string FilePath
		{
			get
			{
				return filePath;
			}
		}


		public int PageState
		{
			get
			{
				return pageState;
			}

			set
			{
				pageState = value;
			}
		}


		public int CategoryNo
		{
			get
			{
				return categoryNo;
			}

			set
			{
				categoryNo = value;
			}
		}
	}
}
