using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Microsoft.Web.WebView2.Core;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;


namespace PDFArrange
{
	public partial class FormCategoryView : Form
	{
		[System.Runtime.InteropServices.DllImport("ole32.dll")]
		private static extern void CoFreeUnusedLibraries();

		private string workingFolder = null;
		private string outputFolder = null;
		private UCCategory category = null;
		private List<Image> allThumbNailImageList = null;
		private List<PDFPageEntry> pdfPageEntryList = null;
		private PDFPageEntry currPage = null;
		private List<int> undoPageList = null;
		private bool inProcFlag = false;
		private bool pauseWebViewFlag = false;

		private const int SIZEX = 128;
		private const int SIZEY = 128;


		public FormCategoryView()
		{
			InitializeComponent();
			imageList_cvPDFPageList.ImageSize = new Size(SIZEX, SIZEY);
			InitWebView();
		}


		// WebView2コントロール初期化
		async private void InitWebView()
		{
			await webView2_cvPDFView.EnsureCoreWebView2Async();
		}


		public void SetAppInfo(string wFolder, string oFolder, List<PDFPageEntry> entryList, List<Image> imageList, UCCategory cat)
		{
			workingFolder = wFolder;
			outputFolder = oFolder;
			pdfPageEntryList = entryList;
			allThumbNailImageList = imageList;
			category = cat;

			for (int i1 = 0; i1 < allThumbNailImageList.Count; i1++)
			{
				Image thumbImage = allThumbNailImageList[i1];
				imageList_cvPDFPageList.Images.Add(thumbImage);
			}
			undoPageList = new List<int>();
		}



		private void FormCatetoryView_Load(object sender, EventArgs e)
		{
			//ShownでないとWebView2でnull exception
		}


		private void FormCategoryView_Shown(object sender, EventArgs e)
		{
			tBox_cvFile.Text = category.FileName;
			tBox_cvMemo.Text = category.Memo;
			tBox_cvPages.Text = category.PageListStr;

			RefreshPDFList();
			if (category.PageList.Count > 0)
			{
				lView_cvPDFPageList.Items[0].Selected = true;
			}
		}


		// ListViewの再描画
		private void RefreshPDFList()
		{
			lView_cvPDFPageList.Items.Clear();
			for (int i1 = 0; i1 < category.PageList.Count; i1++)
			{
				int page = category.PageList[i1];
				ListViewItem item = null;
				item = new ListViewItem();
				item.Text = page.ToString();
				item.ImageIndex = page - 1;
				item.Tag = page;
				lView_cvPDFPageList.Items.Add(item);
			}
		}


		// PDF削除処理
		private void btn_cvDelete_Click(object sender, EventArgs e)
		{
			lab_cvMessage.Text = "";
			if (currPage == null)
			{
				lab_cvMessage.Text = "ページが指定されていません。";
				return;
			}

			if (inProcFlag)
			{
				return;
			}
			inProcFlag = true;
			currPage.PageState = PDFPageEntry.PS_NONE;
			int page = currPage.Page;

			pauseWebViewFlag = true;
			undoPageList.Add(page);
			for (int i1 = 0; i1 < category.PageList.Count; i1++)
			{
				if (category.PageList[i1] == page)
				{
					category.PageList.RemoveAt(i1);
					break;
				}
			}

			int sel = lView_cvPDFPageList.SelectedIndices[0];
			lView_cvPDFPageList.SelectedItems[0].Remove();
			currPage = null;
			pauseWebViewFlag = false;

			SetLViewSel(sel);
			tBox_cvPages.Text = category.PageListStr;
			inProcFlag = false;
		}


		// ListView選択時の処理
		private void SetLViewSel(int sel)
		{
			if (sel == -1)
			{
				return;
			}
			if (lView_cvPDFPageList.Items.Count == 0)
			{
				for (int i1 = 0; i1 < 10; i1++)
				{
					webView2_cvPDFView.CoreWebView2.Navigate("about:blank");
					Application.DoEvents();
					CoFreeUnusedLibraries();
					Thread.Sleep(10);
				}
				return;
			}
			if (sel >= lView_cvPDFPageList.Items.Count)
			{
				sel = lView_cvPDFPageList.Items.Count - 1;
			}
			lView_cvPDFPageList.Items[sel].Selected = true;
			lView_cvPDFPageList.EnsureVisible(sel);
		}


		// PDFページ左回転の処理(PDFRorateメソッド呼び出し)
		private void btn_cvRotateLeft_Click(object sender, EventArgs e)
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
			PDFRorate(page, lView_cvPDFPageList.SelectedIndices[0], false);
			inProcFlag = false;
		}


		// PDFページ右回転の処理(PDFRorateメソッド呼び出し)
		private void btn_cvRotateRight_Click(object sender, EventArgs e)
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
			PDFRorate(page, lView_cvPDFPageList.SelectedIndices[0], true);
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
				webView2_cvPDFView.CoreWebView2.Navigate("about:blank");
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
			webView2_cvPDFView.CoreWebView2.Navigate(entry.FilePath);

			string file = entry.FilePath;
			ThumbnailCreator thumbCreator = new ThumbnailCreator(SIZEX, SIZEY);
			Image thumbImage = thumbCreator.Thumbnail(null, file);

			allThumbNailImageList[page - 1].Dispose();
			allThumbNailImageList[page - 1] = thumbImage;
			imageList_cvPDFPageList.Images[page - 1] = thumbImage;

			// ImageListを変更するだけでは、ListViewが更新されない
			int value = lView_cvPDFPageList.Items[pos].ImageIndex;
			lView_cvPDFPageList.Items[pos].ImageIndex = -1;
			lView_cvPDFPageList.Items[pos].ImageIndex = value;

			// こうするとListViewをクリックすると更新される。クリックが必要な不具合を以下で回避
			string str = lView_cvPDFPageList.Items[pos].SubItems[0].Text;
			lView_cvPDFPageList.Items[pos].SubItems[0].Text = str + "R";
			lView_cvPDFPageList.Items[pos].SubItems[0].Text = str;
		}


		// PDFページ上移動
		private void btn_cvUp_Click(object sender, EventArgs e)
		{
			if (currPage == null)
			{
				return;
			}
			if (lView_cvPDFPageList.SelectedItems.Count != 1)
			{
				return;
			}
			int sel = lView_cvPDFPageList.SelectedIndices[0];
			if (sel == -1)
			{
				return;
			}
			if (sel <= 0)
			{
				return;
			}
			if (inProcFlag)
			{
				return;
			}
			inProcFlag = true;
			pauseWebViewFlag = true;
			SwapOpeLViewItem(sel-1, sel);
			pauseWebViewFlag = false;
			lView_cvPDFPageList.Items[sel-1].Selected = true;
			lView_cvPDFPageList.EnsureVisible(sel-1);
			inProcFlag = false;
		}


		// PDFページ下移動
		private void btn_cvDown_Click(object sender, EventArgs e)
		{
			if (currPage == null)
			{
				return;
			}
			if (lView_cvPDFPageList.SelectedItems.Count != 1)
			{
				return;
			}
			int sel = lView_cvPDFPageList.SelectedIndices[0];
			if (sel == -1)
			{
				return;
			}
			if (sel >= lView_cvPDFPageList.Items.Count - 1)
			{
				return;
			}
			if (inProcFlag)
			{
				return;
			}
			inProcFlag = true;
			pauseWebViewFlag = true;
			SwapOpeLViewItem(sel, sel+1);
			pauseWebViewFlag = false;
			lView_cvPDFPageList.Items[sel+1].Selected = true;
			lView_cvPDFPageList.EnsureVisible(sel+1);
			inProcFlag = false;
		}


		// PDFページ位置移動に使用するListViewの項目swap
		private void SwapOpeLViewItem(int pos1, int pos2)
		{
			if (pos1 < 0 || pos1 >= lView_cvPDFPageList.Items.Count ||
				pos2 < 0 || pos2 >= lView_cvPDFPageList.Items.Count)
			{
				return;
			}

			int value = category.PageList[pos1];
			category.PageList[pos1] = category.PageList[pos2];
			category.PageList[pos2] = value;
			tBox_cvPages.Text = category.PageListStr;
			RefreshPDFList();
		}


		// ListView選択項目取得
		private int GetLViewTag()
		{
			if (lView_cvPDFPageList.SelectedItems.Count != 1)
			{
				return -1;
			}
			int tag = (int)lView_cvPDFPageList.SelectedItems[0].Tag;
			return tag;
		}


		// ListView選択処理
		private void lView_cvPDFPageList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (pauseWebViewFlag)
			{
				return;
			}
			lab_cvMessage.Text = "";
			currPage = null;
			int page = GetLViewTag();
			if (page == -1)
			{
				for (int i1 = 0; i1 < 10; i1++)
				{
					webView2_cvPDFView.CoreWebView2.Navigate("about:blank");
					Application.DoEvents();
					CoFreeUnusedLibraries();
					Thread.Sleep(10);
				}
				return;
			}
			PDFPageEntry entry = pdfPageEntryList[page - 1];
			currPage = entry;
			webView2_cvPDFView.CoreWebView2.Navigate(entry.FilePath);
			lView_cvPDFPageList.Enabled = true;
		}


		private void FormCategoryView_FormClosing(object sender, FormClosingEventArgs e)
		{
		}


		private void btn_cvSave_Click(object sender, EventArgs e)
		{
			Close();
		}


		public List<int> UndoPageList
		{
			get
			{
				return undoPageList;
			}
		}
	}
}
