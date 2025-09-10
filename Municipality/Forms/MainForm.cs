using Municipality.DataStructures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Municipality
{
    // Windows Forms UI: Microsoft. (2023). Windows Forms. [online] Available at: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/.
    // MVC Design Pattern: Microsoft. (2023). Model-View-Controller (MVC) Pattern. [online] Available at: https://learn.microsoft.com/en-us/dotnet/architecture/maui/mvvm.
    public partial class MainForm : Form
    {
        private IssueList issueList; //custom-built data structure

        //initialize the ui form and elements
        public MainForm()
        {
            InitializeComponent();
            issueList = new IssueList();
        }

        //handle the report issue click and redirect to the report form dialog
        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssueForm reportForm = new ReportIssueForm(issueList);
            reportForm.ShowDialog();
        }

        //handle event button
        private void btnEvents_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not available yet.");
        }

        //handle service button
        private void btnServiceStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not available yet.");
        }

        //handle the view reports button and shows the view reports form
        private void btnViewReports_Click(object sender, EventArgs e)
        {
            ViewReportsForm viewForm = new ViewReportsForm(issueList);
            viewForm.ShowDialog();
        }
    }
}
