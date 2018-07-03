using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {

    [System.Serializable]
    public class BTTask_Wait : BaseNode {

        private float timeToWait;
        private float currTime;

        public BTTask_Wait(float timeToWait, params Decorator[] decorators) : base(null, decorators) {
            this.timeToWait = timeToWait;
            currTime = timeToWait;
        }

        protected override void Open(Tick tick) {
            base.Open(tick);
            currTime = timeToWait;
        }

        protected override Utils.NODE_STATES Execute(Tick tick) {
            base.Execute(tick);
            if (currTime <= 0)
                return Utils.NODE_STATES.SUCCESS;
            else {
                currTime -= Time.deltaTime;
                return Utils.NODE_STATES.RUNNING;
            }
        }
    }
}
