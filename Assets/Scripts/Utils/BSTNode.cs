using System;
using UnityEngine;

namespace Environment.Tasks
{
    public class BSTNode
    {
        private EmployeeData data;
        public BSTNode? leftChild = null;
        public BSTNode? rightChild = null;

        public EmployeeData GetData()
        {
            return data;
        }

        public BSTNode(EmployeeData inData)
        {
            data = inData;
        }
    }

    
    public class BinarySearchTree
    {
        private BSTNode root;

        public BinarySearchTree(EmployeeData[] employees)
        {
            if (employees == null || employees.Length == 0)
                return;

            root = new BSTNode(employees[0]);

            for (int i = 1; i < employees.Length; i++)
            {
                Insert(employees[i]);
                
            }
        }
        public BSTNode? GetRoot()
        {
            return root;
        }
        public void PrintTree()
        {
            PrintInOrder(root);
        }

        private void PrintInOrder(BSTNode? node)
        {
            if (node == null)
                return;

            PrintInOrder(node.leftChild);

            Debug.Log(
                node.GetData().name + " - " +
                node.GetData().lastEntranceInEngineRoom
            );

            PrintInOrder(node.rightChild);
        }


        public void Insert(EmployeeData inData)
        {
            //assuming that values are unique
            BSTNode? newNode = new BSTNode(inData);
            BSTNode? currentNode = root;
            BSTNode? lastParent = root;
            while (currentNode != null)
            { // Keep searching until we find an empty child slot
                if (DateTime.Parse(inData.lastEntranceInEngineRoom) < DateTime.Parse(currentNode.GetData().lastEntranceInEngineRoom) /*node we are examining*/)
                {
                    lastParent = currentNode;
                    currentNode = currentNode.leftChild;
                }
                else
                {
                    lastParent = currentNode;
                    currentNode = currentNode.rightChild;
                }
            }

            //we reached a point where lastParent has an empty child slot fitting newNode
            if (DateTime.Parse(inData.lastEntranceInEngineRoom) < DateTime.Parse(lastParent.GetData().lastEntranceInEngineRoom))
            {
                lastParent.leftChild = newNode;
            }
            else
            {
                lastParent.rightChild = newNode;
            }
        }
    }
}


