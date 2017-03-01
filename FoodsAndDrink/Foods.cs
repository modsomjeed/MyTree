using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace FoodsAndDrink
{
    public class Foods
    {
        public Node root;
        protected int SIZE;
        public class Node
        {
            public object Code;
            public string name;
            public int freq;
            public float price;
            public Node left, right;
            public Node(object Code, string name,float price,Node left, Node right, int freq)
            {
                this.Code = Code;
                this.name = name;
                this.left = left;
                this.right = right;
                this.price = price;
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
        private void splay(object Code)
        {
            Node header = new Node(null, null, 0, null, null, 0);
            Node l, r, t; l = r = header; t = root;
            for (; ; )
            {
                if (((IComparable)Code).CompareTo(t.Code) < 0)
                {
                    if (t.left == null) break;
                    if (((IComparable)Code).CompareTo(t.left.Code) < 0)
                    {
                        t = rotateLeftChild(t);
                        if (t.left == null) break;
                    }
                    r.left = t; r = t; t = t.left;
                }
                else if (((IComparable)Code).CompareTo(t.Code) > 0)
                {
                    if (t.right == null) break;
                    if (((IComparable)Code).CompareTo(t.right.Code) > 0)
                    {
                        t = rotateRightChild(t);
                        if (t.right == null) break;
                    }
                    l.right = t; l = t; t = t.right;
                }
                else break;
            }
            l.right = t.left; r.left = t.right;
            t.left = header.right; t.right = header.left;
            root = t;
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
        public bool contains(object Code)
        {
            Node x = root;
            if (root == null) return false;
            while (x.right != null) x = x.right;
            splay(Code);
            return x == null ? false : true;
        }

        public  object getMin()
        {
            Node x = root;
            if (root == null) return null;
            while (x.left != null)
                x = x.left;
            splay(x.Code);
            return x.Code;
        }

        public  object getMax()
        {
            Node x = root;
            if (root == null) return null;
            while (x.right != null)
                x = x.right;
            splay(x.Code);
            return x.Code;
        }

        public void add(string name,float price,int Code,int freq)
        {
            if (root == null)
            {
                root = new Node(Code, name, price, null, null, freq);
                SIZE++; return;
            }
            splay(Code);
            int cmp = compareTo(Code, root.Code);
            Node n = new Node(Code, name, price, null, null, freq);
            if (cmp < 0)
            {
                n.left = root.left;
                n.right = root;
                root.left = null;
            }
            else
            {
                n.right = root.right;
                n.left = root;
                root.right = null;
            }
            root = n; SIZE++;
       
        }
        public void remove(int Code)
        {
            splay(Code);
            if (compareTo(Code, root.Code) != 0)
                return;
            if (root.left == null)
                root = root.right;
            else
            {
                Node x = root.right;
                root = root.left;
                splay(Code);
                root.right = x;
            }
            SIZE--;
        }

        public Node getNode(int Code)
        {
            return getNode(root, Code);
        }
        private Node getNode(Node r, object Code)
        {
            if (r == null) return null;
            int cmp = compareTo(Code, r.Code);
            if (cmp == 0) return r;
            if (cmp < 0)
                return getNode(r.left, Code);
            else
                return getNode(r.right, Code);

        }
       
        protected int compareTo(object a, object b)
        {
            return ((IComparable)a).CompareTo(b);

        }
       

        public virtual object[] toArray(int i, int j)
        {
            int n = numNodes(root);
            object[] name = new object[n];
            object[] price = new object[n];
            object[] Code = new object[n];
            object[] freq = new object[n];
            switch (i)
            {
                case Traversal.Inorder: toArrayInorder(root, name, price, Code, 0,freq);
                    if (j == 1) return name;
                    else if (j == 2) return price;
                    else if (j == 3) return Code;
                    else return freq;
                 case Traversal.Preorder: toArrayPreorder(root, name, price, Code, 0,freq);
                    if (j == 1) return name;
                    else if (j == 2) return price;
                    else if (j == 3) return Code;
                    else return freq;

                 case Traversal.Postorder: toArrayPostorder(root, name, price, Code, 0,freq);
                    if (j == 1) return name;
                    else if (j == 2) return price;
                    else if (j == 3) return Code;
                    else return freq;
                 
                default: Console.WriteLine("Error");
                    return null;
            }

        }
        private int toArrayPreorder(Node x, object[] name, object[] price,object[] Code, int k,object [] freq)
        {
            if (x == null) return k;
            name[k] = x.name;
            Code[k] = x.Code;
            freq[k] = x.freq;
            price[k++] = x.price;
            k = toArrayPreorder(x.left, name,price, Code, k,freq);
            k = toArrayPreorder(x.right, name, price, Code, k,freq);
            return k;
        }
        private int toArrayInorder(Node x, object[] name, object[] price, object[] Code, int k,object [] freq)
        {
            if (x == null) return k;
            if (x.isLeaf())
            {
                name[k] = x.name;
                Code[k] = x.Code;
                freq[k] = x.freq;
                price[k++] = x.price;
            }
            k = toArrayInorder(x.left, name, price, Code, k,freq);
            if (!x.isLeaf())
            {
                name[k] = x.name;
                Code[k] = x.Code;
                freq[k] = x.freq;
                price[k++] = x.price;
            }
            k = toArrayInorder(x.right, name, price, Code, k,freq);
            return k;

        }
        private int toArrayPostorder(Node x, object[] name, object[] price, object[] Code, int k,object[] freq)
        {
            if (x == null) return k;
            if (x.isLeaf())
            {
                name[k] = x.name;
                Code[k] = x.Code;
                freq[k] = x.freq;
                price[k++] = x.price;
            }
            k = toArrayPostorder(x.left, name, price, Code,k, freq);
            k = toArrayPostorder(x.right, name, price, Code, k,freq);
            if (!x.isLeaf())
            {
                name[k] = x.name;
                Code[k] = x.Code;
                freq[k] = x.freq;
                price[k++] = x.price;
            }
            return k;
        }
    }
}
