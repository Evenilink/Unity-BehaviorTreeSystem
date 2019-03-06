using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {

    [System.Serializable]
    public class BehaviourTree {

        protected Blackboard blackboard;
        protected BaseNode root;
        protected Tick tick;

        public BehaviourTree(Blackboard blackboard) { this.blackboard = blackboard; }

        public void Execute(Object target) {
            if (root == null)
                return;
            tick = new Tick(blackboard, target);
            root.Update(tick);
        }

        // Debug only.
        protected void PrintOpenNodes(List<BaseNode> lastOpenNodes, List<BaseNode> currOpenNodes) {
            Debug.Log("BLACKBOARD OPEN NODES ====================");
            for (int i = 0; i < lastOpenNodes.Count; i++)
                Debug.Log("Open node [" + i + "]: " + lastOpenNodes[i]);

            Debug.Log("TICK OPEN NODES ====================");
            for (int i = 0; i < currOpenNodes.Count; i++)
                Debug.Log("Open node [" + i + "]: " + currOpenNodes[i]);
        }
    }
}
