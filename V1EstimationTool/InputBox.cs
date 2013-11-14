using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace V1EstimationTool
{
    public class InputBoxDialog : Form
    {
        private readonly Container components = null;
        private Button btnCancel;
        private Button btnOK;
        private string defaultValue = string.Empty;

        private string formCaption = string.Empty;
        private string formPrompt = string.Empty;
        private string inputResponse = string.Empty;
        private Label lblPrompt;
        private TextBox txtInput;

        public InputBoxDialog()
        {
            InitializeComponent();
        }

        public string FormCaption
        {
            get { return formCaption; }
            set { formCaption = value; }
        }

        public string FormPrompt
        {
            get { return formPrompt; }
            set { formPrompt = value; }
        }

        public string InputResponse
        {
            get { return inputResponse; }
            set { inputResponse = value; }
        }

        public string DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblPrompt = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            txtInput = new TextBox();
            SuspendLayout();
            // 
            // lblPrompt
            // 
            lblPrompt.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;
            lblPrompt.BackColor = SystemColors.Control;
            lblPrompt.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrompt.Location = new Point(12, 9);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(302, 82);
            lblPrompt.TabIndex = 3;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.FlatStyle = FlatStyle.System;
            btnOK.Location = new Point(326, 24);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(64, 24);
            btnOK.TabIndex = 1;
            btnOK.Text = "&OK";
            btnOK.Click += btnOK_Click;
            btnOK.DialogResult = DialogResult.OK;
            // 
            // button1
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.System;
            btnCancel.Location = new Point(326, 56);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(64, 24);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "&Cancel";
            btnCancel.Click += button1_Click;
            btnCancel.DialogResult = DialogResult.Cancel;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(8, 100);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(379, 20);
            txtInput.TabIndex = 0;
            txtInput.Text = "";
            // 
            // InputBoxDialog
            // 
            AutoScaleBaseSize = new Size(5, 13);
            ClientSize = new Size(398, 128);
            Controls.Add(txtInput);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(lblPrompt);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InputBoxDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InputBox";
            Load += InputBox_Load;
            AcceptButton = btnOK;
            CancelButton = btnCancel;
            ResumeLayout(false);
        }

        private void InputBox_Load(object sender, EventArgs e)
        {
            txtInput.Text = defaultValue;
            lblPrompt.Text = formPrompt;
            Text = formCaption;
            txtInput.SelectionStart = 0;
            txtInput.SelectionLength = txtInput.Text.Length;
            txtInput.Focus();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            InputResponse = txtInput.Text;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static string InputBox(string prompt, string title, string defaultValue)
        {
            var ib = new InputBoxDialog {FormPrompt = prompt, FormCaption = title, DefaultValue = defaultValue};
            ib.ShowDialog();
            ib.Close();
            return ib.InputResponse;
        }
    }
}