using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using VersionOne.SDK.ObjectModel;
using VersionOne.SDK.ObjectModel.Filters;

namespace V1EstimationTool
{
    public partial class MainForm : Form
    {
        private readonly IList<ListView> _buckets = new List<ListView>();
        private readonly IList<Label> _labels = new List<Label>();

        public MainForm()
        {
            InitializeComponent();

            EnsureBucketLists();
            LoadBucketMenu();
            CreateBuckets();

            storyList.ColumnClick += storyList_ColumnClick;
            storyList.ItemDrag += storyList_ItemDrag;
            storyList.DragDrop += storyList_DragDrop;
            storyList.DragOver += storyList_DragOver;
        }

        private Project SelectedProject
        {
            get
            {
                if (treeProjects.SelectedNode != null)
                    return Global.Instance.Get.ProjectByID((AssetID) treeProjects.SelectedNode.Tag);
                return null;
            }
        }

        private static void EnsureBucketLists()
        {
            if (Global.Config.Buckets.Count == 0)
            {
                Global.Config.Buckets.Add(1.ToString(CultureInfo.InvariantCulture));
                Global.Config.Buckets.Add(2.ToString(CultureInfo.InvariantCulture));
                Global.Config.Buckets.Add(4.ToString(CultureInfo.InvariantCulture));
            }

            if (Global.Config.SelectedBuckets.Count == 0)
            {
                Global.Config.SelectedBuckets.Add(1.ToString(CultureInfo.InvariantCulture));
                Global.Config.SelectedBuckets.Add(2.ToString(CultureInfo.InvariantCulture));
                Global.Config.SelectedBuckets.Add(4.ToString(CultureInfo.InvariantCulture));
            }
        }

        private void LoadBucketMenu()
        {
            IList<double> selected = Config.GetDoubleList(Global.Config.SelectedBuckets);
            IList<double> all = Config.GetDoubleList(Global.Config.Buckets);

            while (menuBuckets.DropDownItems.Count > 2)
                menuBuckets.DropDownItems.RemoveAt(menuBuckets.DropDownItems.Count - 1);

            foreach (double d in all)
            {
                var item = new ToolStripMenuItem(d.ToString("0.00"))
                    {CheckOnClick = true, Checked = selected.Contains(d)};
                item.CheckedChanged += BucketCheck_Changed;
                item.Tag = d;
                menuBuckets.DropDownItems.Add(item);
            }
        }

        private void BucketCheck_Changed(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem) sender;

            string value = ((double) item.Tag).ToString(CultureInfo.InvariantCulture);
            if (item.Checked)
                Global.Config.SelectedBuckets.Add(value);
            else
                Global.Config.SelectedBuckets.Remove(value);
            ClearBuckets();
            CreateBuckets();
        }

        private void ClearBuckets()
        {
            for (int i = 0; i < _buckets.Count; i++)
            {
                Label lbl = _labels[i];
                ListView list = _buckets[i];

                list.Items.Clear();

                lbl.Parent.Controls.Remove(lbl);
                list.Parent.Controls.Remove(list);
            }

            _labels.Clear();
            _buckets.Clear();
            RefreshStoryList();
        }

        private void CreateBuckets()
        {
            foreach (double d in Config.GetDoubleList(Global.Config.SelectedBuckets))
                CreateBucket(d);
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ConfigForm().ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            chkSingleLevel.Checked = Global.Config.SingleLevelProjectView;
            if (Global.IsValid)
                RefreshProjectTree();
        }

        private void RefreshProjectTree()
        {
            if (Global.IsValid)
            {
                treeProjects.Nodes.Clear();
                RecurseProjects(treeProjects.Nodes, Global.Instance.Projects);
            }
        }

        private static void RecurseProjects(TreeNodeCollection nodes, IEnumerable<Project> projects)
        {
            foreach (Project project in projects)
            {
                TreeNode node = nodes.Add(project.Name);
                node.Tag = project.ID;
                var filter = new ProjectFilter();
                filter.State.Add(State.Active);
                RecurseProjects(node.Nodes, project.GetChildProjects(filter));
            }
        }

        private static void RecurseProjects(PrimaryWorkitemFilter filter, IEnumerable<Project> projects)
        {
            foreach (Project project in projects)
            {
                filter.Project.Add(project);
                var pfilter = new ProjectFilter();
                pfilter.State.Add(State.Active);
                RecurseProjects(filter, project.GetChildProjects(pfilter));
            }
        }

        private void btnRefreshProjects_Click(object sender, EventArgs e)
        {
            RefreshProjectTree();
            RefreshStoryList();
        }

        private void chkSingleLevel_CheckedChanged(object sender, EventArgs e)
        {
            Global.Config.SingleLevelProjectView = chkSingleLevel.Checked;
            RefreshStoryList();
        }

        private void treeProjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Global.Config.SelectedProject = treeProjects.SelectedNode != null
                                                ? (AssetID) treeProjects.SelectedNode.Tag
                                                : null;
            RefreshStoryList();
        }

        private void RefreshStoryList()
        {
            storyList.Items.Clear();
            if (SelectedProject != null)
            {
                var filter = new PrimaryWorkitemFilter();
                filter.State.Add(State.Active);
                filter.Project.Add(SelectedProject);
                if (!Global.Config.SingleLevelProjectView)
                {
                    var pfilter = new ProjectFilter();
                    pfilter.State.Add(State.Active);
                    RecurseProjects(filter, SelectedProject.GetChildProjects(pfilter));
                }

                var sort = (List<string>) storyList.Tag;
                if (sort != null)
                    sort.ForEach(s => filter.OrderBy.Add(s));
                else
                    filter.OrderBy.Add(Global.Config.DefaultSort);

                ICollection<PrimaryWorkitem> items = Global.Instance.Get.PrimaryWorkitems(filter);
                foreach (PrimaryWorkitem item in items)
                {
                    bool bFound = _buckets.Any(bucket => bucket.Items.ContainsKey(item.ID));

                    if (!bFound)
                        AddBacklog(item, storyList);
                }

                storyList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private static void AddBacklog(PrimaryWorkitem item, ListView list)
        {
            var values = new List<string>
                {
                    item.Name,
                    item.DisplayID,
                    item.Project.Name,
                    item.Iteration == null ? string.Empty : item.Iteration.Name,
                    item.Team == null ? string.Empty : item.Team.Name,
                    item.Theme == null ? string.Empty : item.Theme.Name,
                    item.Estimate == null ? string.Empty : string.Format("{0:0.00}", item.Estimate.Value)
                };

            var value = new ListViewItem(values.ToArray(), item.GetType().Name) {Tag = item.ID, Name = item.ID};
            list.Items.Add(value);
        }

        private void CreateBucket(double value)
        {
            const int width = 175;
            const int height = 190;
            int buckets = _buckets.Count;

            var label = new Label();
            _labels.Add(label);
            label.Width = width - 32;
            label.Text = "Estimate: " + value.ToString("0.00");
            label.Left = buckets*(width + 4);
            label.Top = 0;
            label.Height = 16;
            bucketPanel.Controls.Add(label);

            var list = new ListView();
            _buckets.Add(list);
            list.Columns.Add("Name");
            list.Columns.Add("ID");
            list.View = View.Details;
            list.Width = width;
            list.Left = buckets*(width + 4);
            list.Height = height;
            list.Top = label.Top + label.Height;
            list.SmallImageList = iconList;
            list.AllowDrop = true;
            list.ItemDrag += Bucket_ItemDrag;
            list.DragDrop += Bucket_DragDrop;
            list.DragOver += Bucket_DragOver;
            list.DoubleClick += Bucket_DoubleClick;
            list.Tag = value;
            bucketPanel.Controls.Add(list);
        }

        private static void Bucket_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ((ListView) sender).DoDragDrop(((ListView) sender).SelectedItems, DragDropEffects.Move);
        }

        private static void Bucket_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private static void Bucket_DragDrop(object sender, DragEventArgs e)
        {
            DoListDragDrop(sender, e);
        }

        private static void Bucket_DoubleClick(object sender, EventArgs e)
        {
            OpenDetailPages((ListView) sender);
        }

        private static void storyList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ((ListView) sender).DoDragDrop(((ListView) sender).SelectedItems, DragDropEffects.Move);
        }

        private static void storyList_DragDrop(object sender, DragEventArgs e)
        {
            DoListDragDrop(sender, e);
        }

        private static void storyList_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private static void DoListDragDrop(object sender, DragEventArgs e)
        {
            var items =
                (ListView.SelectedListViewItemCollection)
                e.Data.GetData(typeof (ListView.SelectedListViewItemCollection));
            var target = (ListView) sender;

            foreach (ListViewItem item in items)
                MoveListItem(item, target);
        }

        private static void MoveListItem(ListViewItem item, ListView target)
        {
            PrimaryWorkitem pwi = Global.Instance.Get.PrimaryWorkitemByID((AssetID) item.Tag);
            item.ListView.Items.Remove(item);
            AddBacklog(pwi, target);
        }

        private void btnSaveStoryList_Click(object sender, EventArgs e)
        {
            foreach (ListView bucket in _buckets)
            {
                foreach (ListViewItem item in bucket.Items)
                {
                    PrimaryWorkitem entity = Global.Instance.Get.PrimaryWorkitemByID((AssetID) item.Tag);
                    entity.Estimate = (double) bucket.Tag;
                    entity.Save();

                    MoveListItem(item, storyList);
                }
            }

            RefreshStoryList();
        }

        private void storyList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            string columnTitle = storyList.Columns[e.Column].Text;
            var sort = (List<string>) storyList.Tag;
            if (sort == null)
                storyList.Tag = sort = new List<string>();
            sort.Remove(columnTitle);
            sort.Insert(0, columnTitle);
            RefreshStoryList();
        }

        private void btnRefreshStories_Click(object sender, EventArgs e)
        {
            RefreshStoryList();
        }

        private void menuBucketConfig_Click(object sender, EventArgs e)
        {
            if (new BucketForm().ShowDialog(this) == DialogResult.OK)
            {
                EnsureBucketLists();
                ClearBuckets();
                CreateBuckets();
                LoadBucketMenu();
            }
        }

        private void storyList_DoubleClick(object sender, EventArgs e)
        {
            OpenDetailPages((ListView) sender);
        }

        private static void OpenDetailPages(ListView sender)
        {
            foreach (ListViewItem item in sender.SelectedItems)
                Helper.OpenDetailPage((AssetID) item.Tag);
        }

        private void btnClearSort_Click(object sender, EventArgs e)
        {
            storyList.Tag = null;
            RefreshStoryList();
        }
    }
}