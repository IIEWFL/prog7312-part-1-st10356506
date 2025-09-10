using Municipality.Models;

namespace Municipality.DataStructures
{
    //this represents a single node in the doubly linked list 
    // - Kini, M. (2020). Doubly Linked List in C#. [online] C-sharpcorner.com. Available at: https://www.c-sharpcorner.com/article/doubly-linked-list-and-circular-linked-list-in-c-sharp/.
    public class IssueNode
    {
        public Issue Issue { get; set; }
        public IssueNode Next { get; set; }
        public IssueNode Previous { get; set; }

        //create a new node with only one issue
        public IssueNode(Issue issue)
        {
            Issue = issue;
            Next = null;
            Previous = null;
        }

        //create a new node with the issue and set the next and previous nodes
        public IssueNode(Issue issue, IssueNode next, IssueNode previous)
        {
            Issue = issue;
            Next = next;
            Previous = previous;
        }
    }
}
