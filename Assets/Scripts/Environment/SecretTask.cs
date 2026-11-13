using Environment.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace Enviroment.Tasks
{
    [CreateAssetMenu(fileName = "SecretTask", menuName = "Scriptable Objects/SecretTask")]
    public class SecretTask : Task
    {
        bool changed;
        public override void Execute()
        {
            List<int> valueList = new() { 8, 2, 1, 3, 9, };
            CheckList(valueList);
        }

        private void CheckList(List<int> valueList)
        {
            changed = true;
            while (changed)
            {
                changed = false;
                for (int j = 0; j < valueList.Count - 1; j++)
                {
                    CompareNumbers(valueList, j);
                }
                PrintList(valueList);
            }
        }

        private void CompareNumbers(List<int> values, int index)
        {
            if (values[index] > values[index + 1])
            {
                (values[index + 1], values[index]) = (values[index], values[index + 1]);
                changed = true;
            }
        }
        private void PrintList(List<int> valueList)
        {
            Debug.Log("--------------------------------------");
            foreach (int j in valueList)
            {
                Debug.Log(j);

            }
        }

    }
}
