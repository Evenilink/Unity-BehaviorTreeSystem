using UnityEngine;

namespace BehaviorTree {

    [System.Serializable]
    public class BTTask_Wait : BaseNode {

        private float timeToWait;
        private float currTime;

        public BTTask_Wait(float timeToWait) : base(null) {
            this.timeToWait = timeToWait;
            currTime = timeToWait;
        }

        protected override void Open(Tick tick) {
            base.Open(tick);
            currTime = timeToWait;
        }

        protected override NODE_STATE Execute(Tick tick) {
            if (currTime <= 0)
                return NODE_STATE.SUCCESS;
            else {
                currTime -= Time.deltaTime;
                return NODE_STATE.RUNNING;
            }
        }
    }
}
