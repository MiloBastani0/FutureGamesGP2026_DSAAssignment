
using System;
using System.Text.Json;
using UnityEngine;
namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "EmployeeDataParser", menuName = "EmployeeDataParser")]


    public class EmployeeDataParser : Task
    {
        [SerializeField] private TextAsset jsonFile;


        public override void Execute()
        {


            EmployeeData[] employee = JsonUtility.FromJson<EmployeeArray>(jsonFile.text).employees;
            Computer.Instance.employees = employee;

            Computer.Instance.employeeTree = new BinarySearchTree(employee);
        }
    }

    [Serializable]
    public class EmployeeData
    {
        public string name;
        public int employeeId;
        public bool hasEngineRoomClearance;
        public string lastEntranceInEngineRoom;
        public string lastExitFromEngineRoom; 

    }
    [Serializable]
    public class EmployeeArray
    {
        public EmployeeData[] employees;
    }
}

