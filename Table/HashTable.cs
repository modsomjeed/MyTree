using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyTree;
namespace Table
{
    public class HashTable
    {
        private BSTree[] table;
        private int SIZE;
        private int prime_number;
        public HashTable(int m)
        {
            this.prime_number = m;
            table = new BSTree[m];
            for (int i = 0; i < table.Length; i++)
                table[i] = new BSTree();
        }
        public int size() { return SIZE; }
        public bool isEmpty() { return SIZE == 0; }
        public bool contains(object x)
        {
            return table[f(x)].contains(x); 
        }
        public void add(object phoneId,string name,string Address,string Details)
        {
            int t = f(phoneId);
            table[f(phoneId)].add(phoneId,name,Address,Details); SIZE++;
        }
        public MyTree.BSTree.Node getDataNode(object PhoneId)
        {
            int i = f(PhoneId);
            if (table[i].contains(PhoneId)) 
               return table[i].getNode(PhoneId);
            return null;
        }
        public void remove(object x)
        {
            int i = f(x);
            int s = table[i].size();
            table[i].remove(x);
            if (s > table[i].size()) SIZE--;
        }
        private int f(object x)
        { 
            return ((int)x)% 13;
        }
        public object[] toArray(int i, int j,int k)
        {
            return table[k].toArray(i, j);
        }
        
    }
}
