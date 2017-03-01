using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Order;
namespace MyTree
{
    public class BSTree
    {
        public Node root;
        protected int SIZE;
        public class Node
        {
            public object PhoneID;
            public string name;
            public int freq;
            public string Address, Details;
            public Orders history;
            
            public Node left, right;
            public Node(object phone, string name, string Address, string Details, Node left, Node right, int freq)
            {
                this.PhoneID = phone;
                this.name = name;
                this.left = left;
                this.right = right;
                this.Address = Address;
                this.Details = Details;
                this.freq = freq;

            }
            public bool isLeaf()
            {
                return left == null && right == null;
            }
          
        }
        public static class Traversal
        {
            public const int Inorder = 1;
            public const int Preorder = 2;
            public const int Postorder = 3;
        }
        protected virtual Node rotateLeftChild(Node r)
        {
            Node newRoot = r.left;
            r.left = newRoot.right;
            return newRoot;
        }
        protected virtual Node rotateRightChild(Node r)
        {
            Node newRoot = r.right;
            r.right = newRoot.left;
            newRoot.left = r;
            return newRoot;
        }
        public int numNodes() { return numNodes(root); }
        public int depth() { return depth(root); }
        private int numNodes(Node node)
        {
            if (node == null) return 0;
            return 1 + numNodes(node.left) + numNodes(node.right);
        }
        private int depth(Node node)
        {
            if (root == null) return -1;
            return 1 + Math.Max(depth(node.left), depth(node.right));
        }
        public int size() { return SIZE; }
        public bool isEmpty() { return SIZE == 0; }
        public bool contains(object PhoneID)
        {
            Node node = getNode(root, PhoneID);
            return node == null ? false : true;
        }
        public object getMin()
        {
            Node l = root;
            if (l == null)
                return null;
            while (l.left != null)
                l = l.left;
            return l.PhoneID;
        }
        public object getMax()
        {
            Node r = root;
            if (r == null)
                return null;
            while (r.right != null)
                r = r.right;
            return r.PhoneID;
        }
        public virtual void add(object PhoneID, string name, string Address, string Details)
        {
            root = add(root, PhoneID, name, Address, Details);
           
            
        }
        public virtual void remove(object PhoneID)
        {
            root = remove(root, PhoneID);
        }
        public Node getNode(object PhoneID)
        {
            return getNode(root, PhoneID);
        }
        private Node getNode(Node r, object PhoneID)
        {
            if (r == null) return null;
            int cmp = compareTo(PhoneID, r.PhoneID);
            if (cmp == 0) return r;
            if (cmp < 0)
                return getNode(r.left, PhoneID);
            else
                return getNode(r.right, PhoneID);

        }
        protected virtual Node add(Node r, object PhoneID, string name, string Address, string Details)
        {
            if (r == null)
            {
                r = new Node(PhoneID, name, Address, Details, null, null, 1);
                SIZE++;
            }
            else
            {
                int cmp = compareTo(PhoneID, r.PhoneID);
                if (cmp < 0)
                    r.left = add(r.left, PhoneID, name, Address, Details);
                else
                    r.right = add(r.right, PhoneID, name, Address, Details);

            } return r;
        }
        protected int compareTo(object a, object b)
        {
            return ((IComparable)a).CompareTo(b);

        }
        protected virtual Node remove(Node r, object PhoneID)
        {
            if (r == null) return r;
            int cmp = compareTo(PhoneID, r.PhoneID);
            if (cmp < 0)
                r.left = remove(r.left, PhoneID);
            else if (cmp > 0)
                r.right = remove(r.right, PhoneID);
            else
            {
                if (r.right == null || r.left == null)
                {
                    r = r.left == null ? r.right : r.left;
                    SIZE--;
                }
                else
                {  // Take right
                    Node m = r.right;
                    while (m.left != null)
                        m = m.left;
                    r.PhoneID = m.PhoneID;
                    r.right = remove(r.right, m.PhoneID);
                }

            }
            return r;
        }

        public virtual object[] toArray(int i, int j)
        {
            int n = numNodes(root);
            object[] name = new object[n];
            object[] address = new object[n];
            object[] phone = new object[n];
            object[] detail = new object[n];
            object[] history = new object[n];
            switch (i)
            {
                case Traversal.Inorder: toArrayInorder(root, name, address, phone, detail, history, 0);
                    if (j == 1) return name;
                    else if (j == 2) return address;
                    else if (j == 3) return phone;
                    else if (j == 4) return detail;
                    else return history;
                case Traversal.Preorder: toArrayPreorder(root, name, address, phone, detail, history, 0);
                    if (j == 1) return name;
                    else if (j == 2) return address;
                    else if (j == 3) return phone;
                    else if (j == 4) return detail;
                    else return history;
                case Traversal.Postorder: toArrayPostorder(root, name, address, phone, detail, history, 0);
                    if (j == 1) return name;
                    else if (j == 2) return address;
                    else if (j == 3) return phone;
                    else if (j == 4) return detail;
                    else return history;
                default: Console.WriteLine("Error");
                    return null;
            }

        }
        private int toArrayPreorder(Node x, object[] name, object[] address, object[] phone, object[] detail, object[] history, int k)
        {
            if (x == null) return k;
            name[k] = x.PhoneID;
            address[k] = x.Address;
            phone[k] = x.PhoneID;
            detail[k] = x.Details;
            history[k++] = x.Details;
            k = toArrayPreorder(x.left, name, address, phone, detail, history, k);
            k = toArrayPreorder(x.right, name, address, phone, detail, history, k);
            return k;
        }
        private int toArrayInorder(Node x, object[] name, object[] address, object[] phone, object[] detail, object[] history, int k)
        {
            if (x == null) return k;
            if (x.isLeaf())
            {
                name[k] = x.PhoneID;
                address[k] = x.Address;
                phone[k] = x.PhoneID;
                detail[k] = x.Details;
                history[k++] = x.Details;
            }
            k = toArrayInorder(x.left, name, address, phone, detail, history, k);
            if (!x.isLeaf())
            {
                name[k] = x.PhoneID;
                address[k] = x.Address;
                phone[k] = x.PhoneID;
                detail[k] = x.Details;
                history[k++] = x.Details;
            }
            k = toArrayInorder(x.right, name, address, phone, detail, history, k);
            return k;

        }
        private int toArrayPostorder(Node x, object[] name, object[] address, object[] phone, object[] detail, object[] history, int k)
        {
            if (x == null) return k;
            if (x.isLeaf())
            {
                name[k] = x.PhoneID;
                address[k] = x.Address;
                phone[k] = x.PhoneID;
                detail[k] = x.Details;
                history[k++] = x.Details; ;
            }
            k = toArrayPostorder(x.left, name, address, phone, detail, history, k);
            k = toArrayPostorder(x.right, name, address, phone, detail, history, k);
            if (!x.isLeaf())
            {
                name[k] = x.PhoneID;
                address[k] = x.Address;
                phone[k] = x.PhoneID;
                detail[k] = x.Details;
                history[k++] = x.Details;
            }
            return k;
        }
    }

}

