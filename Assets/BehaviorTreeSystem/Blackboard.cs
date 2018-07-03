using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {

    [System.Serializable]
    public class Blackboard {

        private List<BaseNode> openNodes;
        private Dictionary<BaseNode, int> runningChildIndex;

        public Blackboard() {
            openNodes = new List<BaseNode>();
            runningChildIndex = new Dictionary<BaseNode, int>();
        }

        public List<BaseNode> GetOpenNodes() {
            return openNodes;
        }

        public void SetOpen(BaseNode node, bool open) {
            if (open)
                openNodes.Add(node);
            else openNodes.Remove(node);
        }

        public bool GetIsOpen(BaseNode node) {
            return openNodes.Contains(node);
        }

        public void AddRunningChildIndex(BaseNode node, int index) {
            bool exists = runningChildIndex.ContainsKey(node);
            if (!exists)
                runningChildIndex.Add(node, index);
            else if (exists && runningChildIndex[node] != index)
                runningChildIndex[node] = index;
        }

        public int GetRunningChildIndex(BaseNode node) {
            foreach (BaseNode key in runningChildIndex.Keys) {
                if (key == node)
                    return runningChildIndex[key];
            }
            return 0;
        }

        public void RemoveRunningChildIndex(BaseNode node) {
            runningChildIndex.Remove(node);
        }

        public List<string> GetOpenNodesList() {
            List<string> openNodesNames = new List<string>();
            foreach (BaseNode node in openNodes)
                openNodesNames.Add(node.ToString());
            return openNodesNames;
        }
    }
}
