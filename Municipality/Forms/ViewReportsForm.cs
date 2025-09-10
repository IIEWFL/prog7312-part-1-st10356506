using Municipality.DataStructures;
using Municipality.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Municipality
{
    //this whole form is part of my chosen user engagement strategy, Feedback and communication
    //this form allows users to view their submitted reports
    //users can filter the reports they see, search, and view a detailed report
    // Windows Forms UI: Microsoft. (2023). Windows Forms. [online] Available at: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/.
    public partial class ViewReportsForm : Form
    {
        //elements of the form
        private IssueList issueList;
        private ListBox lstReports;
        private TextBox txtReportDetails;
        private Label lblReports;
        private Label lblDetails;
        private Button btnRefresh;
        private Button btnClose;
        private ComboBox cmbFilterStatus;
        private Label lblFilter;
        private TextBox txtSearchEmail;
        private Label lblSearchEmail;
        private Label lblTitle;
        private Button btnSearch;

        //initialize the view reports form
        public ViewReportsForm(IssueList issueList)
        {
            this.issueList = issueList;
            InitializeComponent();
            LoadReports();
        }

        //initialize the form components 
        //Form Design and UI/UX: Microsoft. (2023). Windows Forms. [online] Available at: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/get-started/create-app-visual-studio.
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearchEmail = new System.Windows.Forms.Label();
            this.txtSearchEmail = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.lblReports = new System.Windows.Forms.Label();
            this.lstReports = new System.Windows.Forms.ListBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.txtReportDetails = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(310, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "My Submitted Reports";
            // 
            // lblSearchEmail
            // 
            this.lblSearchEmail.Location = new System.Drawing.Point(20, 60);
            this.lblSearchEmail.Name = "lblSearchEmail";
            this.lblSearchEmail.Size = new System.Drawing.Size(100, 20);
            this.lblSearchEmail.TabIndex = 1;
            this.lblSearchEmail.Text = "Search by Email:";
            // 
            // txtSearchEmail
            // 
            this.txtSearchEmail.Location = new System.Drawing.Point(130, 58);
            this.txtSearchEmail.Name = "txtSearchEmail";
            this.txtSearchEmail.Size = new System.Drawing.Size(200, 22);
            this.txtSearchEmail.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(340, 56);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 30);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "🔍 Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(450, 60);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(100, 20);
            this.lblFilter.TabIndex = 4;
            this.lblFilter.Text = "Filter by Status:";
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.Items.AddRange(new object[] {
            "All",
            "Open",
            "In Progress",
            "Responded",
            "Completed",
            "Closed"});
            this.cmbFilterStatus.Location = new System.Drawing.Point(560, 58);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(120, 24);
            this.cmbFilterStatus.TabIndex = 5;
            // 
            // lblReports
            // 
            this.lblReports.Location = new System.Drawing.Point(20, 100);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(60, 20);
            this.lblReports.TabIndex = 6;
            this.lblReports.Text = "Reports:";
            // 
            // lstReports
            // 
            this.lstReports.ItemHeight = 16;
            this.lstReports.Location = new System.Drawing.Point(20, 125);
            this.lstReports.Name = "lstReports";
            this.lstReports.Size = new System.Drawing.Size(400, 340);
            this.lstReports.TabIndex = 7;
            // 
            // lblDetails
            // 
            this.lblDetails.Location = new System.Drawing.Point(450, 100);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(100, 20);
            this.lblDetails.TabIndex = 8;
            this.lblDetails.Text = "Report Details:";
            // 
            // txtReportDetails
            // 
            this.txtReportDetails.Location = new System.Drawing.Point(450, 125);
            this.txtReportDetails.Multiline = true;
            this.txtReportDetails.Name = "txtReportDetails";
            this.txtReportDetails.ReadOnly = true;
            this.txtReportDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReportDetails.Size = new System.Drawing.Size(400, 350);
            this.txtReportDetails.TabIndex = 9;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(600, 500);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(720, 500);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            // 
            // ViewReportsForm
            // 
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSearchEmail);
            this.Controls.Add(this.txtSearchEmail);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cmbFilterStatus);
            this.Controls.Add(this.lblReports);
            this.Controls.Add(this.lstReports);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.txtReportDetails);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View My Reports";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //method to retrieve all the submitted reports
        //GeeksforGeeks (2025) Doubly linked list tutorial, GeeksforGeeks. Available at: https://www.geeksforgeeks.org/dsa/doubly-linked-list/ (Accessed: 10 September 2025). 
        private void LoadReports()
        {
            lstReports.Items.Clear();
            int totalIssues = issueList.GetAllIssuesCount();
            
            for (int i = 0; i < totalIssues; i++)
            {
                Issue issue = issueList.GetIssueByIndex(i);
                if (issue != null)
                {
                    string statusIcon = GetStatusIcon(issue.Status);
                    lstReports.Items.Add($"{statusIcon} [{issue.Id}] {issue.Title} - {issue.Status}");
                }
            }
        }

        //return an emoji based on the issues status
        private string GetStatusIcon(string status)
        {
            switch (status.ToLower())
            {
                case "open": return "📖";
                case "in progress": return "🕑";
                case "responded": return "✔️";
                case "completed": return "✔️✔️";
                case "closed": return "📕";
                default: return "⚪";
            }
        }
        //handles the event where the user selects a different item in the list box
        private void LstReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstReports.SelectedIndex >= 0)
            {
                string selectedItem = lstReports.SelectedItem.ToString();
                int startIndex = selectedItem.IndexOf('[') + 1;
                int endIndex = selectedItem.IndexOf(']');
                
                if (startIndex > 0 && endIndex > startIndex)
                {
                    string idString = selectedItem.Substring(startIndex, endIndex - startIndex);
                    if (int.TryParse(idString, out int issueId))
                    {
                        DisplayIssueDetails(issueId);
                    }
                }
            }
        }

        //displays detailed info about the issue
        private void DisplayIssueDetails(int issueId)
        {
            Issue issue = issueList.FindIssue(issueId);
            if (issue != null)
            {
                string details = $"ISSUE DETAILS\n";
                details += $"═══════════════════════════════════════\n\n";
                details += $"ID: {issue.Id}\n";
                details += $"Title: {issue.Title}\n";
                details += $"Description: {issue.Description}\n";
                details += $"Category: {issue.Category}\n";
                details += $"Priority: {issue.Priority}\n";
                details += $"Status: {issue.Status}\n\n";
                
                details += $"REPORTER INFORMATION\n";
                details += $"═══════════════════════════════════════\n\n";
                details += $"Name: {issue.ReporterName}\n";
                details += $"Email: {issue.ReporterEmail}\n";
                details += $"Phone: {issue.ReporterPhone}\n";
                details += $"Location: {issue.Location}\n\n";
                
                details += $"DATES\n";
                details += $"═══════════════════════════════════════\n\n";
                details += $"Reported: {issue.DateReported:yyyy-MM-dd HH:mm}\n";
                if (issue.DateViewed.HasValue)
                    details += $"Viewed: {issue.DateViewed:yyyy-MM-dd HH:mm}\n";
                if (issue.DateResponded.HasValue)
                    details += $"Responded: {issue.DateResponded:yyyy-MM-dd HH:mm}\n";
                if (issue.DateResolved.HasValue)
                    details += $"Resolved: {issue.DateResolved:yyyy-MM-dd HH:mm}\n";
                
                if (!string.IsNullOrEmpty(issue.StatusNotes))
                {
                    details += $"\nSTATUS NOTES\n";
                    details += $"═══════════════════════════════════════\n\n";
                    details += $"{issue.StatusNotes}\n";
                }
                
                if (!string.IsNullOrEmpty(issue.AttachedFiles))
                {
                    details += $"\nATTACHED FILES\n";
                    details += $"═══════════════════════════════════════\n\n";
                    string[] files = issue.AttachedFiles.Split('|');
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(files[i]))
                        {
                            details += $"• {System.IO.Path.GetFileName(files[i])}\n";
                        }
                    }
                }
                
                txtReportDetails.Text = details;
            }
        }
        //handles the search logic
        //GeeksforGeeks (2025b) Search an element in a doubly linked list, GeeksforGeeks. Available at: https://www.geeksforgeeks.org/dsa/search-an-element-in-a-doubly-linked-list/ (Accessed: 10 September 2025). 
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //if the search box is empty, load all reports
            if (string.IsNullOrWhiteSpace(txtSearchEmail.Text))
            {
                //load report
                LoadReports();
                return;
            }

            lstReports.Items.Clear();
            int emailIssuesCount = issueList.GetIssuesByEmailCount(txtSearchEmail.Text);
            
            for (int i = 0; i < emailIssuesCount; i++)
            {
                Issue issue = issueList.GetIssueByEmailAndIndex(txtSearchEmail.Text, i);
                if (issue != null)
                {
                    string statusIcon = GetStatusIcon(issue.Status);
                    lstReports.Items.Add($"{statusIcon} [{issue.Id}] {issue.Title} - {issue.Status}");
                }
            }
        }
        //filter reports based on status 
        //Angel ChanAngel ChanAngel Chan2533 bronze badges et al. (2020) How do I filter a doubly linked list?, Stack Overflow. Available at: https://stackoverflow.com/questions/60777473/how-do-i-filter-a-doubly-linked-list (Accessed: 10 September 2025). 
        private void CmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = cmbFilterStatus.SelectedItem.ToString();
            
            if (selectedStatus == "All")
            {
                LoadReports();
                return;
            }

            lstReports.Items.Clear();
            int statusIssuesCount = issueList.GetIssuesByStatusCount(selectedStatus);
            
            for (int i = 0; i < statusIssuesCount; i++)
            {
                Issue issue = issueList.GetIssueByStatusAndIndex(selectedStatus, i);
                if (issue != null)
                {
                    string statusIcon = GetStatusIcon(issue.Status);
                    lstReports.Items.Add($"{statusIcon} [{issue.Id}] {issue.Title} - {issue.Status}");
                }
            }
        }
        //refresh the reports 
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadReports();
            txtReportDetails.Clear();
        }
        //close the form
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
   
}
