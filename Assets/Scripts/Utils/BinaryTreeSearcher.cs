using Environment;
using Environment.Tasks;

using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BinaryTreeSearcher", menuName = "Scriptable Objects/BinaryTreeSearcher")]
public class BinaryTreeSearcher : Task
{
    
    public override void Execute()
    {
        DateTime lowestValueInRange = DateTime.Parse("2234-08-09 22:00");
        DateTime highestValueInRange = DateTime.Parse("2234-08-09 23:00");

        List<BSTNode> matchingNodes = SearchRange(lowestValueInRange, highestValueInRange);
        
        

        for(int i = 0; i < matchingNodes.Count; i++)
        {
           
            if(DateTime.Parse(matchingNodes[i].GetData().lastEntranceInEngineRoom) >= lowestValueInRange && DateTime.Parse(matchingNodes[i].GetData().lastEntranceInEngineRoom) <= highestValueInRange && DateTime.Parse(matchingNodes[i].GetData().lastExitFromEngineRoom) >= lowestValueInRange && DateTime.Parse(matchingNodes[i].GetData().lastExitFromEngineRoom) <= highestValueInRange)
            {
                EmployeeData employee = matchingNodes[i].GetData();
 
               
                Debug.Log("name" + employee.name);
                Debug.Log("Entrance " + employee.lastEntranceInEngineRoom);
                Debug.Log("exit " + employee.lastExitFromEngineRoom);
            }
   
        }
      
       
    }
    public List<BSTNode> SearchRange(DateTime lowestValueInRange, DateTime highestValueInRange)
    {
        List<BSTNode> matchingNodes = new List<BSTNode>();

        BSTNode root = Computer.Instance.employeeTree.GetRoot();

        LastEntranceSearcher(root, lowestValueInRange, highestValueInRange, matchingNodes);
        LastExitSearcher(root, lowestValueInRange, highestValueInRange, matchingNodes);

        return matchingNodes;

    }


    public void LastEntranceSearcher(BSTNode currentNode, DateTime lowestValueInRange, DateTime highestValueInRange, List<BSTNode> matchingNodes)
    {
        if (currentNode == null)
            return;

        DateTime nodeBeingChecked = DateTime.Parse(currentNode.GetData().lastEntranceInEngineRoom);


        if (nodeBeingChecked > lowestValueInRange)
        {
            LastEntranceSearcher(currentNode.leftChild, lowestValueInRange, highestValueInRange, matchingNodes);
        }

        if(nodeBeingChecked < highestValueInRange)
        {
            LastEntranceSearcher(currentNode.rightChild, lowestValueInRange, highestValueInRange, matchingNodes);
        }

        if (nodeBeingChecked >= lowestValueInRange && nodeBeingChecked <= highestValueInRange)
        {
            matchingNodes.Add(currentNode);
        }
    }

    public void LastExitSearcher(BSTNode currentNode, DateTime lowestValueInRange, DateTime highestValueInRange, List<BSTNode> matchingNodes)
    {
        if (currentNode == null)
            return;

        DateTime nodeBeingChecked = DateTime.Parse(currentNode.GetData().lastExitFromEngineRoom);


        if (nodeBeingChecked > lowestValueInRange)
        {
            LastExitSearcher(currentNode.leftChild, lowestValueInRange, highestValueInRange, matchingNodes);
        }

        if (nodeBeingChecked < highestValueInRange)
        {
            LastExitSearcher(currentNode.rightChild, lowestValueInRange, highestValueInRange, matchingNodes);
        }

        if (nodeBeingChecked >= lowestValueInRange && nodeBeingChecked <= highestValueInRange)
        {
            matchingNodes.Add(currentNode);
        }
    }

}
