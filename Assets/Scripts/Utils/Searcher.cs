using Environment;
using Environment.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Searcher", menuName = "Scriptable Objects/Searcher")]
public class Search : Task
{

    public override void Execute()
    {
       

        DateTime numberLookingForLowestRange = DateTime.Parse("2234-08-09T22:00:00");
        DateTime numberLookingForHighestRange = DateTime.Parse("2234-08-09T23:00:00");
        

        int foundLowestRange = FindLowestRange(Computer.Instance.employees, numberLookingForLowestRange);
        int foundHighestRange = FindHighestRange(Computer.Instance.employees, numberLookingForHighestRange);

        for (int i = foundLowestRange; i <= foundHighestRange; i++)
        {
            Debug.Log(Computer.Instance.employees[i].lastEntranceInEngineRoom);
            Debug.Log(Computer.Instance.employees[i].name);
        }
    }

    private int FindLowestRange(EmployeeData[] sortingList, DateTime lowestDate)
    {
        int left = 0;
        int right = sortingList.Length - 1;
        int result = -1;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;

            if (DateTime.Parse(sortingList[middle].lastEntranceInEngineRoom) >= lowestDate)
            {
                result = middle;
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }

        return result;
    }

    private int FindHighestRange(EmployeeData[] sortingList, DateTime highestDate)
    {
        int left = 0;
        int right = sortingList.Length - 1;
        int result = -1;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;

            if (DateTime.Parse(sortingList[middle].lastEntranceInEngineRoom) <= highestDate)
            {
                result = middle;
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return result;
    }
}
