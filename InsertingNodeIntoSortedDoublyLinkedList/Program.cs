using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertingNodeIntoSortedDoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                DoublyLinkedList llist = new DoublyLinkedList();

                int llistCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llistCount; i++)
                {
                    int llistItem = Convert.ToInt32(Console.ReadLine());
                    llist.InsertNode(llistItem);
                }

                int data = Convert.ToInt32(Console.ReadLine());

                DoublyLinkedListNode llist1 = sortedInsert(llist.head, data);

                PrintDoublyLinkedList(llist1, " ");
                // textWriter.WriteLine();
            }

            //  textWriter.Flush();
            // textWriter.Close();
        }
        class DoublyLinkedListNode
        {
            public int data;
            public DoublyLinkedListNode next;
            public DoublyLinkedListNode prev;

            public DoublyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
                this.prev = null;
            }
        }

        class DoublyLinkedList
        {
            public DoublyLinkedListNode head;
            public DoublyLinkedListNode tail;

            public DoublyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                    node.prev = this.tail;
                }

                this.tail = node;
            }
        }

        static void PrintDoublyLinkedList(DoublyLinkedListNode node, string sep)
        {
            while (node != null)
            {
                Console.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    Console.Write(sep);
                }
            }
        }
        // Complete the sortedInsert function below.

        /*
         * For your reference:
         *
         * DoublyLinkedListNode {
         *     int data;
         *     DoublyLinkedListNode next;
         *     DoublyLinkedListNode prev;
         * }
         *
         */
        static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode head, int data)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(data);
            DoublyLinkedListNode temp = head;


            //handle case the list is empty  
            if(head == null)
            {
                head = newNode;
                return head;

            }

            //handle edge case element in the beginning
            if (temp.data > data)
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
                return head;

            }

            while (temp.next != null)
            {
                if (temp.data <= data && temp.next.data > data)
                {
                    newNode.next = temp.next;
                    temp.next = newNode;
                    newNode.prev = temp;
                    temp = temp.next.next;
                    temp.prev = newNode;
                }
                else
                {
                    temp = temp.next;
                }
            }

            //handle edge case the element inserted in the end
            if (temp.data <= data && temp != null)
            {
                temp.next = newNode;
                newNode.prev = temp;

                temp = null;
            }
            return head;
        }
    }
}




