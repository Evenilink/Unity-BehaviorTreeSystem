using System;
using UnityEngine;

namespace BehaviorTree {

    [Serializable]
    public class BTTask_MoveTo : BaseNode {

        private GameObject target;
        private BlackboardKey<Vector3> location;
        private float acceptableRadius;

        public BTTask_MoveTo(ref BlackboardKey<Vector3> location, float acceptableRadius) : base(null) {
            this.location = location;
            this.acceptableRadius = acceptableRadius;
        }

        protected override NODE_STATE Execute(Tick tick) {
            target = (GameObject)tick.GetTarget();
            if ((location.GetValue() - target.transform.position).magnitude <= acceptableRadius)
                return NODE_STATE.SUCCESS;
            else {
                Vector3 direction = location.GetValue() - target.transform.position;
                target.transform.position = new Vector3(target.transform.position.x + direction.x * Time.deltaTime, target.transform.position.y + direction.y * Time.deltaTime, target.transform.position.z);
                return NODE_STATE.RUNNING;
            }
        }
    }
}
