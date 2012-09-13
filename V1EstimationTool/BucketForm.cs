using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace V1EstimationTool
{
	public partial class BucketForm : Form
	{
		public BucketForm()
		{
			InitializeComponent();

			LoadCheckList();
			UpdateButtonState();
		}

		private void UpdateButtonState()
		{
			btnRemove.Enabled = checkList.SelectedItem != null;
		}

		private void LoadCheckList()
		{
			checkList.Items.Clear();

			IList<double> all = Config.GetDoubleList(Global.Config.Buckets);
			IList<double> selected = Config.GetDoubleList(Global.Config.SelectedBuckets);

			foreach (double d in all)
				checkList.Items.Add(new ListItem(d), selected.Contains(d));
		}

		private void checkList_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateButtonState();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Global.Config.SelectedBuckets.Clear();
			Global.Config.Buckets.Clear();
			foreach (ListItem item in checkList.Items)
			{
				string value = item.Value.ToString(CultureInfo.InvariantCulture);
				Global.Config.Buckets.Add(value);
				if (checkList.CheckedItems.Contains(item))
					Global.Config.SelectedBuckets.Add(value);
			}
			Close();
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			checkList.Items.Remove(checkList.SelectedItem);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			string s = InputBoxDialog.InputBox("Enter the new value to add.", "New Bucket", "0.00");
			double res;
			if (double.TryParse(s, out res))
			{
				ListItem item = new ListItem(res);
				if (!checkList.Items.Contains(item))
				{
					checkList.Items.Add(item,true);
					checkList.Sorted = true;
				}
			}
		}

		private class ListItem
		{
			public readonly double Value;
			public ListItem(double value)
			{
				Value = value;
			}

			public override string ToString()
			{
				return Value.ToString("0.00");
			}

			public override bool Equals(object obj)
			{
				ListItem other = obj as ListItem;
				if (other == null) return false;
				if (object.ReferenceEquals(this, other)) return true;
				return Value == other.Value;
			}

			public override int GetHashCode()
			{
				return Value.GetHashCode();
			}

			public static bool operator ==(ListItem a, ListItem b)
			{
				if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
					return object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null);
				return a.Equals(b);
			}
			public static bool operator !=(ListItem a, ListItem b)
			{
				return !(a == b);
			}
		}

	}
}