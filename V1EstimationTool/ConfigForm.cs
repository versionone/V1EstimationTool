using System;
using System.Windows.Forms;

namespace V1EstimationTool
{
	public partial class ConfigForm : Form
	{
		public ConfigForm()
		{
			InitializeComponent();
		}

		private void ConfigForm_Load(object sender, EventArgs e)
		{
			txtAppPath.Text = Global.Config.ApplicationPath;
			txtUsername.Text = Global.Config.Username;
			txtPassword.Text = Global.Config.Password;
		    cbIntegratedSecurity.Checked = Global.Config.UseWindowsIntegrated;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Global.Config.ApplicationPath = txtAppPath.Text;
		    Global.Config.UseWindowsIntegrated = cbIntegratedSecurity.Checked;
			Global.Config.Username = txtUsername.Text;
			Global.Config.Password = txtPassword.Text;
			Close();
		}

        private void cbIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            lblIntegratedUsername.Visible = cbIntegratedSecurity.Checked;
        }
	}
}