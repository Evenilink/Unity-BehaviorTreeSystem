using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {

    [System.Serializable]
    public class Tick {

        private Blackboard blackboard;
        private Object target;

        public Tick(Blackboard blackboard, Object target) {
            this.blackboard = blackboard;
            this.target = target;
        }

        public Blackboard GetBlackboard() { return blackboard; }

        public Object GetTarget() { return target; }
    }
}
