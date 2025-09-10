# Municipality Management System

## Project Overview

The **Municipality Management System** is a comprehensive Windows Forms application designed to streamline municipal issue reporting and management. Built using C# and .NET Framework, this system allows citizens to report municipal issues, attach supporting files, and track the status of their reports through a user-friendly interface.

## Key Features

### Main Dashboard
- Clean, modern interface with professional design
- Quick access to all municipal services
- Real-time system status indicators
- Intuitive navigation with visual feedback

### Issue Reporting
- **Comprehensive Form**: Complete issue reporting with all necessary details
- **Dynamic Progress Bar**: Real-time progress tracking with color-coded feedback
- **File Attachments**: Support for images and documents (JPG, PNG, PDF, DOC, etc.)
- **Input Validation**: Real-time validation with helpful error messages
- **Smart Categories**: Predefined categories (Infrastructure, Utilities, Environment, Safety, Transportation)
- **Priority Levels**: Configurable priority settings (Low, Medium, High, Urgent)

### �� Report Management
- **View Reports**: Complete report viewing and management system
- **Search Functionality**: Search reports by email address
- **Status Filtering**: Filter reports by status (Open, In Progress, Responded, Completed)
- **Detailed Information**: Comprehensive report details with timeline tracking
- **File Management**: View and manage attached files

### Status Tracking
- **Real-time Updates**: Track issue status changes
- **Timeline View**: Complete history of issue processing
- **Administrative Notes**: Status notes and updates
- **Date Tracking**: View, respond, and resolve timestamps

### Technical Architecture

### Custom Data Structure
- **IssueList**: Custom-built doubly-linked list implementation
- **IssueNode**: Node class for list management
- **No Predefined Structures**: Uses only custom data structures (no List, Array, Dictionary)
- **Efficient Operations**: CRUD operations optimized for performance

### Data Model
- **Issue Class**: Comprehensive issue model with all necessary properties
- **File Management**: Pipe-separated string storage for file paths
- **Status Tracking**: Complete status and timeline management
- **Validation**: Built-in data validation and error handling

## Getting Started

### Prerequisites
- Windows 10/11
- .NET Framework 4.7.2 or later
- Visual Studio 2019 or later (for development)

### Installation
1. Clone or download the project repository
2. Open `Municipality.sln` in Visual Studio
3. Build the solution (Ctrl+Shift+B)
4. Run the application (F5)

### Running the Application
1. Launch the application
2. Use the main dashboard to navigate between features
3. Click "Report an Issue" to submit new reports
4. Click "View My Reports" to manage existing reports

## User Guide

### Reporting an Issue
1. Click "Report an Issue" on the main dashboard
2. Fill out the form fields (watch the progress bar!)
3. Select appropriate category and priority
4. Attach supporting files if needed
5. Submit the report

### Viewing Reports
1. Click "View My Reports" on the main dashboard
2. Use the search box to find reports by email
3. Use the status filter to view specific report types
4. Click on any report to see detailed information

### Progress Tracking
- The progress bar shows form completion percentage
- Color coding: Red (0-29%), Orange (30-69%), Green (70-100%)
- Real-time updates as you fill out the form

## Design Features

### User Interface
- **Modern Design**: Clean, professional appearance
- **Color Scheme**: Consistent blue and gray palette
- **Typography**: Segoe UI font throughout
- **Responsive**: Adapts to different screen sizes
- **Accessibility**: Clear labels and intuitive navigation

### User Experience
- **Visual Feedback**: Progress bars, color coding, and status indicators
- **Error Handling**: Clear error messages and validation
- **Intuitive Flow**: Logical navigation and form progression
- **Professional Polish**: Hover effects and smooth interactions

## Technical Details

### File Structure
Municipality/
├── Forms/
│   ├── MainForm.cs
│   ├── MainForm.Designer.cs
│   ├── ReportIssueForm.cs
│   └── ViewReportsForm.cs
├── Models/
│   └── Issue.cs
├── DataStructures/
│   ├── IssueList.cs
│   └── IssueNode.cs
├── Properties/
├── Program.cs
└── Municipality.csproj

### Key Components
- **MainForm**: Main dashboard and navigation
- **ReportIssueForm**: Issue reporting with progress tracking
- **ViewReportsForm**: Report management and viewing
- **IssueList**: Custom data structure for issue management
- **Issue**: Data model for issue information

## System Requirements

### Minimum Requirements
- **OS**: Windows 10 (64-bit)
- **RAM**: 4 GB
- **Storage**: 100 MB available space
- **Framework**: .NET Framework 4.7.2

### Recommended Requirements
- **OS**: Windows 11 (64-bit)
- **RAM**: 8 GB
- **Storage**: 500 MB available space
- **Framework**: .NET Framework 4.8

## Troubleshooting

### Common Issues
1. **Build Errors**: Ensure .NET Framework 4.7.2 is installed
2. **File Attachments**: Check file permissions and supported formats
3. **Form Validation**: Ensure all required fields are filled
4. **Progress Bar**: Progress updates automatically as you type

## Future Enhancements

### Planned Features
- Database integration for persistent storage
- Email notifications for status updates
- Mobile application version
- Administrative dashboard
- Report analytics and statistics
- Integration with municipal systems
