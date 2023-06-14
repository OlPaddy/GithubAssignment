using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListWithErrors
{
    public class DLList
    {
        public DLLNode head; // pointer to the head of the list
        public DLLNode tail; // pointer to the tail of the list
        public DLList() { head = null; tail = null; } // constructor
        /*-------------------------------------------------------------------
        * The methods below includes several errors. Your  task is to write
        * unit test to discover these errors. During delivery the tutor may
        * add or remove errors to adjust the scale of the effort required by
        */
        public void addToTail(DLLNode p)
        {

            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                tail.next = p;
                p.previous = tail;
                tail = p;
            }
        } // end of addToTail

        public void addToHead(DLLNode p)
        {
            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                p.next = this.head;
                this.head.previous = p;
                head = p;
            }
        } // end of addToHead

        //--START OF OLD REMOVEHEAD METHOD WITH ERROR--
        //public void removHead()
        //{
        //    if (this.head == null) return;
        //    this.head = this.head.next;
        //    this.head.previous = null;
        //} // removeHead
        //--END OF OLD REMOVEHEAD METHOD WITH ERROR--

        //Changed removHead to removeHead for the sake of spelling

        //--START OF NEW REMOVEHEAD METHOD--
        public void removeHead()
        {
            if (this.head == null) return;

            if (this.head == this.tail)
            {
                this.head = null;
                // this.tail = null;
            }
            else
            {
                DLLNode next = this.head.next;
                this.head = next;
                next.previous = null;
            }
        }//end of remove head
        //--END OF NEW REMOVEHEAD METHOD--

        public void removeTail()
        {
            if (this.tail == null) return;
            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
                return;
            }
        } // remove tail

        /*-------------------------------------------------
         * Return null if the string does not exist.
         * ----------------------------------------------*/

        //--START OF OLD SEARCH METHOD WITH ERROR--
        //public DLLNode search(int num)
        //{
        //    DLLNode p = head;
        //    while (p != null)
        //    {
        //        p = p.next;
        //        if (p.num == num) break;
        //    }
        //    return p;
        //} // end of search (return pionter to the node);
        //--END OF OLD SEARCH METHOD WITH ERROR--

        //--START OF NEW SEARCH METHOD--
        public DLLNode search(int num)
        {
            DLLNode p = head;
            while (p != null)//this checks if the list is empty
            {
                if (p.num == num) return p;
                p = p.next;
            }
            return null;
        } // end of search (return pionter to the node);
        //--END OF NEW SEARCH METHOD--

        //--START OF OLD REMOVENODE METHOD WITH ERROR--
        //public void removeNode(DLLNode p)
        //{ // removing the node p.

        //    if (p.next == null)
        //    {
        //        this.tail = this.tail.previous;
        //        this.tail.next = null;
        //        p.previous = null;
        //        return;
        //    }
        //    if (p.previous == null)
        //    {
        //        this.head = this.head.next;
        //        p.next = null;
        //        this.head.previous = null;
        //        return;
        //    }
        //    p.next.previous = p.previous;
        //    p.previous.next = p.next;
        //    p.next = null;
        //    p.previous = null;
        //    return;
        //} // end of remove a node
        //--END OF OLD REMOVENODE METHOD WITH ERROR--

        //--START OF NEW REMOVENODE METHOD--
        public void removeNode(DLLNode p)
        {
            if (p == null) return;//if there are no nodes in the list
            if (p == head && p == tail)//if there is one node in the list
            {
                head = null;
                tail = null;
            }
            else if (p == head)//if there are 2 or more nodes in the list
            {
                head = p.next;
                if (head != null)
                {
                    head.previous = null;
                }
            }
            else if (p == tail)//if there are 2 or more nodes in the list
            {
                tail = p.previous;
                if (tail != null)
                {
                    tail.next = null;
                }
            }
            else//this connects the pointers of the nodes to the left and right of the removed node
            {
                p.previous.next = p.next;
                p.next.previous = p.previous;
            }
            p.previous = null;
            p.next = null;
        }//end of remove node
        //--END OF NEW REMOVENODE METHOD--

        //--START OF OLD TOTAL METHOD WITH ERROR--
        //public int total()//this is counting the total value of the nodes in the list
        //{
        //    DLLNode p = head;
        //    int tot = 0;
        //    while (p != null)
        //    {
        //        tot += p.num;
        //        p = p.next.next;
        //    }
        //    return (tot);
        //} // end of total
        //--END OF OLD TOTAL METHOD WITH ERROR--

        //--START OF NEW TOTAL METHOD--
        public int total()//this is counting the total value of the nodes in the list
        {
            DLLNode p = head;
            int tot = 0;
            while (p != null)
            {
                tot += p.num;
                p = p.next;
            }
            return (tot);
        } // end of total
        //--END OF NEW TOTAL METHOD--
    } // end of DLList class
}
