using Environment;
using Environment.Tasks;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Sorter", menuName = "Scriptable Objects/Sorter")]
public class Sorter : Task
{
    private static void QuickSort(EmployeeData[] employees, int left, int right)
    {
        int pivotIndex;
        if (left < right)
        {
            pivotIndex = Partition(employees, left, right);
            QuickSort(employees, pivotIndex + 1, right);
            QuickSort(employees, left, pivotIndex - 1);
        }
    }

    private static int Partition(EmployeeData[] employees, int left, int right)
    {
        int pivotIndex = UnityEngine.Random.Range(left, right + 1);

        (employees[pivotIndex], employees[right]) = (employees[right], employees[pivotIndex]);

        DateTime pivot = DateTime.Parse(employees[right].lastEntranceInEngineRoom);
        int j = left;

        for (int i = left; i < right; i++)
        {
            if (DateTime.Parse(employees[i].lastEntranceInEngineRoom) < pivot)
            {
                (employees[j], employees[i]) = (employees[i], employees[j]);
                j++;


            }
        }

        (employees[j], employees[right]) = (employees[right], employees[j]);


        return (j);
    }
 
    public override void Execute()
    {
        QuickSort(Computer.Instance.employees, 0, Computer.Instance.employees.Length - 1);
    }
}
