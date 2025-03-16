using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFArrange
{
	public partial class UCCategory : UserControl
	{
		private int categoryNo = -1;
		private List<int> pageList = null;

		public delegate void AddEventHandler(object sender, int catNo);
		public event AddEventHandler AddEvent = null;

		public delegate void EditEventHandler(object sender, int catNo);
		public event EditEventHandler EditEvent = null;


		public UCCategory()
		{
			InitializeComponent();
			pageList = new List<int>();
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


		private void btn_ctAdd_Click(object sender, EventArgs e)
		{
			if (AddEvent != null)
			{
				AddEvent(this, categoryNo);
			}
		}


		public void PageAdd(int pageNo)
		{
			pageList.Add(pageNo);
			tBox_ctPages.Text = PageListStr;
			UpdateEditButton();
		}


		public bool UndoPage(int page)
		{
			for (int i1 = 0; i1 < pageList.Count; i1++)
			{
				if (pageList[i1] == page)
				{
					pageList.RemoveAt(i1);
					tBox_ctPages.Text = PageListStr;
					UpdateEditButton();
					return true;
				}
			}
			UpdateEditButton();
			return false;
		}


		private void UpdateEditButton()
		{
			if (pageList.Count == 0)
			{
				btn_ctEdit.Enabled = false;
			}
			else
			{
				btn_ctEdit.Enabled = true;
			}
		}


		public void RefreshUC()
		{
			UpdateEditButton();
			tBox_ctPages.Text = PageListStr;
		}


		public string PageListStr
		{
			get
			{
				string str = "";
				for (int i1 = 0; i1 < pageList.Count; i1++)
				{
					if (str != "")
					{
						str += "、";
					}
					str += pageList[i1].ToString();
				}
				return str;
			}
		}


		public List<int> PageList
		{
			get
			{
				return pageList;
			}
		}


		public string FileName
		{
			get
			{
				return tBox_ctFileName.Text;
			}
		}


		public string Memo
		{
			get
			{
				return tBox_ctMemo.Text;
			}
		}


		public bool IsSave
		{
			get
			{
				if (cBox_ctSave.Checked)
				{
					if (pageList.Count == 0)
					{
						return false;
					}
				}
				return cBox_ctSave.Checked;
			}
		}

		private void btn_ctEdit_Click(object sender, EventArgs e)
		{
			if (EditEvent != null)
			{
				EditEvent(this, categoryNo);
			}
		}
	}
}
