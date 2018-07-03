using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {

    [System.Serializable]
    public class Tick {

        private BehaviourTree behaviourTree;
        private List<BaseNode> openNodes;
        private int nodeCount;  //Count the number of nodes ticked during the traversal.
        private Blackboard blackboard;
        private Object target;

        public Tick(BehaviourTree behaviourTree, Blackboard blackboard, Object target) {
            this.behaviourTree = behaviourTree;
            this.blackboard = blackboard;
            this.target = target;
            openNodes = new List<BaseNode>();
        }

        public void EnterNode(BaseNode node) {
            nodeCount++;
            openNodes.Add(node);
        }

        public void OpenNode(BaseNode node) { }

        public void TickNode(BaseNode node) { }

        public void CloseNode(BaseNode node) {
            openNodes.Remove(node);
        }

        public void ExitNode(BaseNode node) { }

        public List<BaseNode> GetOpenNodes() {
            return openNodes;
        }

        public Blackboard GetBlackboard() {
            return blackboard;
        }

        public Object GetTarget() {
            return target;
        }
    }
}
