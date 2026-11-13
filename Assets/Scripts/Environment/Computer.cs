
using Enviroment;
using Enviroment.Tasks;
using Environment.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        private Task testTask = null; // Put your stack/queue here :)
        private GenericQueue<Task> tasks = new();
        [SerializeField] private List<Task> starUpTask = new List<Task>();
        [SerializeField] private Task sorter;
        [SerializeField] private Task EmployeeDataParser;
        [SerializeField] private Task SecretTask;
        [SerializeField] private Task Searcher;
        [SerializeField] private Task BinaryTreeSearcher;
        public static Computer Instance;
        public EmployeeData[] employees;
        [System.NonSerialized]
        public BinarySearchTree employeeTree;

        private void Awake()
        {
            Instance = this;
            foreach (var task in starUpTask)
            {
                tasks.Push(task);
            }
                
        
        }
        public void OnInteract() 
        {
            EmployeeDataParser.Execute();
            sorter.Execute();

            double start = Time.realtimeSinceStartupAsDouble;

            Searcher.Execute();


            double duration = (Time.realtimeSinceStartupAsDouble - start) * 1000000;

            duration = Math.Round(duration);

            Debug.Log($"Search took {duration} micro sec time");

            //BinaryTreeSearcher.Execute();
        }
    }
}
