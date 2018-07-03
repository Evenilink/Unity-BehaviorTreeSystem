using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {

    [Serializable]
    public class BTTask_MoveTo : BaseNode {

        private GameObject target;
        private BlackboardKey<Vector3> location;
        private Decorator[] decorator;

        public BTTask_MoveTo(ref BlackboardKey<Vector3> location, params Decorator[] decorators) : base(null, decorators) {
            this.location = location;
        }

        protected override void Open(Tick tick) {
            base.Open(tick);
        }

        protected override Utils.NODE_STATES Execute(Tick tick) {
            base.Execute(tick);
            target = (GameObject)tick.GetTarget();
            if (Utils.CompareVectors(target.transform.position, location.GetValue())) {
                return Utils.NODE_STATES.SUCCESS;
            }
            else {
                Vector3 direction = location.GetValue() - target.transform.position;
                target.transform.position = new Vector3(target.transform.position.x + direction.x * Time.deltaTime, target.transform.position.y + direction.y * Time.deltaTime, target.transform.position.z);
                return Utils.NODE_STATES.RUNNING;
            }
        }
    }
}
