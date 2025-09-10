using Municipality.Models;
using System;

namespace Municipality.DataStructures
{
    //www.programiz.com. (n.d.). Doubly Linked List (With code). [online] Available at: https://www.programiz.com/dsa/doubly-linked-list.
    //i have created a custom built data structure, a doubly linked list to store and manage issue data
    public class IssueList
    {
        //Kini, M. (2020). Doubly Linked List in C#. [online] C-sharpcorner.com. Available at: https://www.c-sharpcorner.com/article/doubly-linked-list-and-circular-linked-list-in-c-sharp/.

        private IssueNode head; //points to the first node in the list
        private IssueNode tail; //points to the last node in the list 
        private int count; //keep track of the total number of issues
        private int nextId;//generate unique id's for each issue

        //public property to get the number of issues
        public int Count => count;

        //public property to check if the list is empty
        public bool IsEmpty => count == 0;

        //initialize the empty IssueList
        public IssueList()
        {
            head = null;
            tail = null;
            count = 0;
            nextId = 1; //start each id from 1
        }

        //add a new issue to the end of the list
        //GeeksforGeeks (2014). Insertion in a Doubly Linked List. [online] GeeksforGeeks. Available at: https://www.geeksforgeeks.org/dsa/introduction-and-insertion-in-a-doubly-linked-list/.
        public void AddIssue(Issue issue)
        {
            if (issue == null)
                //validate input
                throw new ArgumentNullException(nameof(issue));

            issue.Id = nextId++; //assign id to new issue
            IssueNode newNode = new IssueNode(issue);

            if (IsEmpty)
            {
                head = tail = newNode; //first element in the list
            }
            else
            {
                tail.Next = newNode; //link the previous tail to the new node
                newNode.Previous = tail;//link new node to previous tail
                tail = newNode;//update tail pointer
            }
            count++; //increment the count
        }

        //remove an issue by ID
        //GeeksforGeeks (2010). Deletion in a Doubly Linked List. [online] GeeksforGeeks. Available at: https://www.geeksforgeeks.org/dsa/delete-a-node-in-a-doubly-linked-list/ [Accessed 10 Sep. 2025].
        public bool RemoveIssue(int id)
        {
            IssueNode current = head; //start at the beginning
            while (current != null)
            {
                //find issue to delete by id
                if (current.Issue.Id == id)
                {
                    if (current == head && current == tail)
                    {
                        //remove only one node
                        head = tail = null;
                    }
                    else if (current == head)
                    {
                        //remove first node
                        head = current.Next;
                        head.Previous = null;
                    }
                    else if (current == tail)
                    {
                        // remove last node
                        tail = current.Previous;
                        tail.Next = null;
                    }
                    else
                    {
                        //middle node
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }
                    count--; //decrease the number of issues
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        //find an issue by ID
        public Issue FindIssue(int id)
        {
            IssueNode current = head;
            while (current != null)
            {
                if (current.Issue.Id == id)
                    return current.Issue; //return matching issue
                current = current.Next;
            }
            return null; //not found
        }

        //get all issues count

        public int GetAllIssuesCount()
        {
            return count;
        }

        //get issues by status count
        //www.programiz.com. (n.d.). Doubly Linked List (With code). [online] Available at: https://www.programiz.com/dsa/doubly-linked-list.
        public int GetIssuesByStatusCount(string status)
        {
            int statusCount = 0;
            IssueNode current = head;
            while (current != null)
            {
                if (current.Issue.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                    statusCount++;
                current = current.Next;
            }
            return statusCount;
        }

        //get issues by category count
        public int GetIssuesByCategoryCount(string category)
        {
            int categoryCount = 0;
            IssueNode current = head;
            while (current != null)
            {
                if (current.Issue.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                    categoryCount++;
                current = current.Next;
            }
            return categoryCount;
        }

        //find issue by index
        public Issue GetIssueByIndex(int index)
        {
            if (index < 0 || index >= count)
                return null;

            IssueNode current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Issue;
        }

        //find issue by email and index
        public Issue GetIssueByEmailAndIndex(string email, int index)
        {
            int currentIndex = 0;
            IssueNode current = head;
            while (current != null)
            {
                if (current.Issue.ReporterEmail.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    if (currentIndex == index)
                        return current.Issue;
                    currentIndex++;
                }
                current = current.Next;
            }
            return null;
        }

        //get issues by status and index
        public Issue GetIssueByStatusAndIndex(string status, int index)
        {
            int currentIndex = 0;
            IssueNode current = head;
            while (current != null)
            {
                if (current.Issue.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                {
                    if (currentIndex == index)
                        return current.Issue;
                    currentIndex++;
                }
                current = current.Next;
            }
            return null;
        }

        //get count of issues by email
        public int GetIssuesByEmailCount(string email)
        {
            int emailCount = 0;
            IssueNode current = head;
            while (current != null)
            {
                if (current.Issue.ReporterEmail.Equals(email, StringComparison.OrdinalIgnoreCase))
                    emailCount++;
                current = current.Next;
            }
            return emailCount;
        }

    }
}
