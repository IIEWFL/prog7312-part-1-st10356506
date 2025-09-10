using Municipality.DataStructures;
using Municipality.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Municipality
{
    //this form allows users to report an issue and capture information about the issue
    // Windows Forms UI: Microsoft. (2023). Windows Forms. [online] Available at: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/.
    public partial class ReportIssueForm : Form
    {
        private IssueList issueList;
        private TextBox txtTitle;
        private TextBox txtDescription;
        private ComboBox cmbCategory;
        private ComboBox cmbPriority;
        private TextBox txtReporterName;
        private TextBox txtReporterEmail;
        private TextBox txtReporterPhone;
        private TextBox txtLocation;
        private Button btnSubmit;
        private Button btnCancel;
        private Button btnAttachFiles;
        private ListBox lstAttachedFiles;
        private Label lblAttachedFiles;
        private OpenFileDialog openFileDialog;
        private ProgressBar progressBar;
        private Label lblProgress;

        public ReportIssueForm(IssueList issueList)
        {
            this.issueList = issueList;
            InitializeComponent();
        }

        //initialize the form components 
        //Form Design and UI/UX: Microsoft. (2023). Windows Forms. [online] Available at: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/get-started/create-app-visual-studio.
        private void InitializeComponent()
        {
            this.SuspendLayout();

            //form properties
            this.Text = "Report an Issue";
            this.Size = new Size(600, 750);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //progress bar section
            lblProgress = new Label();
            lblProgress.Text = "Form Completion: 0%";
            lblProgress.Location = new Point(20, 20);
            lblProgress.Size = new Size(150, 20);
            lblProgress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProgress.ForeColor = Color.FromArgb(41, 128, 185);
            this.Controls.Add(lblProgress);

            progressBar = new ProgressBar();
            progressBar.Location = new Point(20, 45);
            progressBar.Size = new Size(540, 25);
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            progressBar.Style = ProgressBarStyle.Continuous;
            this.Controls.Add(progressBar);

            //title
            Label lblTitle = new Label();
            lblTitle.Text = "Issue Title:";
            lblTitle.Location = new Point(20, 85);
            lblTitle.Size = new Size(100, 20);
            this.Controls.Add(lblTitle);

            txtTitle = new TextBox();
            txtTitle.Location = new Point(130, 83);
            txtTitle.Size = new Size(320, 25);
            txtTitle.TextChanged += TxtTitle_TextChanged;
            this.Controls.Add(txtTitle);

            //description
            Label lblDescription = new Label();
            lblDescription.Text = "Description:";
            lblDescription.Location = new Point(20, 120);
            lblDescription.Size = new Size(100, 20);
            this.Controls.Add(lblDescription);

            txtDescription = new TextBox();
            txtDescription.Location = new Point(130, 118);
            txtDescription.Size = new Size(320, 80);
            txtDescription.Multiline = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.TextChanged += TxtDescription_TextChanged;
            this.Controls.Add(txtDescription);

            //category
            Label lblCategory = new Label();
            lblCategory.Text = "Category:";
            lblCategory.Location = new Point(20, 220);
            lblCategory.Size = new Size(100, 20);
            this.Controls.Add(lblCategory);

            cmbCategory = new ComboBox();
            cmbCategory.Location = new Point(130, 218);
            cmbCategory.Size = new Size(150, 25);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Items.AddRange(new string[] { "Infrastructure", "Utilities", "Environment", "Safety", "Transportation", "Other" });
            cmbCategory.SelectedIndex = 0;
            cmbCategory.SelectedIndexChanged += CmbCategory_SelectedIndexChanged;
            this.Controls.Add(cmbCategory);

            //priority
            Label lblPriority = new Label();
            lblPriority.Text = "Priority:";
            lblPriority.Location = new Point(300, 220);
            lblPriority.Size = new Size(60, 20);
            this.Controls.Add(lblPriority);

            cmbPriority = new ComboBox();
            cmbPriority.Location = new Point(370, 218);
            cmbPriority.Size = new Size(80, 25);
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.Items.AddRange(new string[] { "Low", "Medium", "High", "Urgent" });
            cmbPriority.SelectedIndex = 1;
            cmbPriority.SelectedIndexChanged += CmbPriority_SelectedIndexChanged;
            this.Controls.Add(cmbPriority);

            //reporter name for reference
            Label lblReporterName = new Label();
            lblReporterName.Text = "Your Name:";
            lblReporterName.Location = new Point(20, 260);
            lblReporterName.Size = new Size(100, 20);
            this.Controls.Add(lblReporterName);

            txtReporterName = new TextBox();
            txtReporterName.Location = new Point(130, 258);
            txtReporterName.Size = new Size(320, 25);
            txtReporterName.TextChanged += TxtReporterName_TextChanged;
            this.Controls.Add(txtReporterName);

            //reporter email
            Label lblReporterEmail = new Label();
            lblReporterEmail.Text = "Email:";
            lblReporterEmail.Location = new Point(20, 300);
            lblReporterEmail.Size = new Size(100, 20);
            this.Controls.Add(lblReporterEmail);

            txtReporterEmail = new TextBox();
            txtReporterEmail.Location = new Point(130, 298);
            txtReporterEmail.Size = new Size(320, 25);
            txtReporterEmail.TextChanged += TxtReporterEmail_TextChanged;
            this.Controls.Add(txtReporterEmail);

            //reporter phone number
            Label lblReporterPhone = new Label();
            lblReporterPhone.Text = "Phone:";
            lblReporterPhone.Location = new Point(20, 340);
            lblReporterPhone.Size = new Size(100, 20);
            this.Controls.Add(lblReporterPhone);

            txtReporterPhone = new TextBox();
            txtReporterPhone.Location = new Point(130, 338);
            txtReporterPhone.Size = new Size(320, 25);
            txtReporterPhone.TextChanged += TxtReporterPhone_TextChanged;
            this.Controls.Add(txtReporterPhone);

            //location
            Label lblLocation = new Label();
            lblLocation.Text = "Location:";
            lblLocation.Location = new Point(20, 380);
            lblLocation.Size = new Size(100, 20);
            this.Controls.Add(lblLocation);

            txtLocation = new TextBox();
            txtLocation.Location = new Point(130, 378);
            txtLocation.Size = new Size(320, 25);
            txtLocation.TextChanged += TxtLocation_TextChanged;
            this.Controls.Add(txtLocation);

            //attached files section
            lblAttachedFiles = new Label();
            lblAttachedFiles.Text = "Attached Files:";
            lblAttachedFiles.Location = new Point(20, 420);
            lblAttachedFiles.Size = new Size(100, 20);
            this.Controls.Add(lblAttachedFiles);

            lstAttachedFiles = new ListBox();
            lstAttachedFiles.Location = new Point(130, 418);
            lstAttachedFiles.Size = new Size(320, 80);
            lstAttachedFiles.SelectionMode = SelectionMode.MultiExtended;
            this.Controls.Add(lstAttachedFiles);

            btnAttachFiles = new Button();
            btnAttachFiles.Text = "📎 Attach Files";
            btnAttachFiles.Location = new Point(460, 418);
            btnAttachFiles.Size = new Size(100, 30);
            btnAttachFiles.BackColor = Color.FromArgb(52, 152, 219);
            btnAttachFiles.FlatStyle = FlatStyle.Flat;
            btnAttachFiles.ForeColor = Color.White;
            btnAttachFiles.Click += BtnAttachFiles_Click;
            this.Controls.Add(btnAttachFiles);

            //open file dialog setup
            openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Document Files|*.pdf;*.doc;*.docx;*.txt|All Files|*.*";
            openFileDialog.Title = "Select files to attach";

            //submit button
            btnSubmit = new Button();
            btnSubmit.Text = "Submit Issue";
            btnSubmit.Location = new Point(200, 520);
            btnSubmit.Size = new Size(100, 30);
            btnSubmit.Click += BtnSubmit_Click;
            this.Controls.Add(btnSubmit);

            //cancel button
            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(320, 520);
            btnCancel.Size = new Size(80, 30);
            btnCancel.Click += BtnCancel_Click;
            this.Controls.Add(btnCancel);

            this.ResumeLayout(false);
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    Issue newIssue = new Issue(
                        txtTitle.Text.Trim(),
                        txtDescription.Text.Trim(),
                        cmbCategory.SelectedItem.ToString(),
                        txtReporterName.Text.Trim(),
                        txtReporterEmail.Text.Trim(),
                        txtLocation.Text.Trim()
                    )
                    {
                        Priority = cmbPriority.SelectedItem.ToString(),
                        ReporterPhone = txtReporterPhone.Text.Trim(),
                        AttachedFiles = GetAttachedFiles()
                    };

                    issueList.AddIssue(newIssue);

                    MessageBox.Show($"Issue submitted successfully!\nIssue ID: {newIssue.Id}", 
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error submitting issue: {ex.Message}", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a title for the issue.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter a description for the issue.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtReporterName.Text))
            {
                MessageBox.Show("Please enter your name.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReporterName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtReporterEmail.Text) || !IsValidEmail(txtReporterEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReporterEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter the location of the issue.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return false;
            }

            return true;
        }
        //validate email
        //karelz (2025). MailAddress Class (System.net.Mail). [online] Microsoft.com. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailaddress?view=net-9.0 [Accessed 10 Sep. 2025].
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void BtnAttachFiles_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    if (!lstAttachedFiles.Items.Contains(fileName))
                    {
                        lstAttachedFiles.Items.Add(fileName);
                    }
                }
                UpdateProgress(); //update progress when files are added
            }
        }

        private string GetAttachedFiles()
        {
            string files = "";
            for (int i = 0; i < lstAttachedFiles.Items.Count; i++)
            {
                if (i > 0)
                    files += "|"; //use pipe separator instead of comma
                files += lstAttachedFiles.Items[i].ToString();
            }
            return files;
        }

        //Programming Guru (2020). How to use ProgressBar in C# Visual Studio | using progress bar in c# windows form | c# progressbar. [online] YouTube. Available at: https://www.youtube.com/watch?v=pDkqCrf8Wz4.
        //Progress Bar: Microsoft. (2023). ProgressBar Control (Windows Forms). [online] Available at: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/progressbar-control-windows-forms.
        //progress tracking methods
        private void UpdateProgress()
        {
            int progress = 0;
            
            //title (10 points)
            if (!string.IsNullOrWhiteSpace(txtTitle.Text))
                progress += 10;
            
            //description (15 points)
            if (!string.IsNullOrWhiteSpace(txtDescription.Text))
                progress += 15;
            
            //category (10 points)
            if (cmbCategory.SelectedIndex >= 0)
                progress += 10;
            
            //priority (5 points)
            if (cmbPriority.SelectedIndex >= 0)
                progress += 5;
            
            //reporter Name (15 points)
            if (!string.IsNullOrWhiteSpace(txtReporterName.Text))
                progress += 15;
            
            //reporter Email (15 points)
            if (!string.IsNullOrWhiteSpace(txtReporterEmail.Text) && IsValidEmail(txtReporterEmail.Text))
                progress += 15;
            
            //reporter Phone (5 points)
            if (!string.IsNullOrWhiteSpace(txtReporterPhone.Text))
                progress += 5;
            
            //location (15 points)
            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
                progress += 15;
            
            //attached Files (10 points)
            if (lstAttachedFiles.Items.Count > 0)
                progress += 10;
            
            progressBar.Value = progress;
            lblProgress.Text = $"Form Completion: {progress}%";
            
            //change color based on progress
            if (progress < 30)
            {
                progressBar.ForeColor = Color.Red;
                lblProgress.ForeColor = Color.Red;
            }
            else if (progress < 70)
            {
                progressBar.ForeColor = Color.Orange;
                lblProgress.ForeColor = Color.Orange;
            }
            else
            {
                progressBar.ForeColor = Color.Green;
                lblProgress.ForeColor = Color.Green;
            }
        }

        //event handlers for progress tracking 
        //Programming Guru (2020). How to use ProgressBar in C# Visual Studio | using progress bar in c# windows form | c# progressbar. [online] YouTube. Available at: https://www.youtube.com/watch?v=pDkqCrf8Wz4.
        private void TxtTitle_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void TxtDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void CmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void TxtReporterName_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void TxtReporterEmail_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void TxtReporterPhone_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void TxtLocation_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }
    }
}
