using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {

    [System.Serializable]
    public class MemSequence : BaseNode {

        public MemSequence(List<BaseNode> children, params Decorator[] decorators) : base(children, decorators) { }

        protected override void Open(Tick tick) {
            base.Open(tick);
            tick.GetBlackboard().RemoveRunningChildIndex(this);
        }

        protected override Utils.NODE_STATES Execute(Tick tick) {
            base.Execute(tick);
            int childIndex = tick.GetBlackboard().GetRunningChildIndex(this);
            for (int i = childIndex; i < children.Count; i++) {
                Utils.NODE_STATES status = children[i].Update(tick);
                if (status != Utils.NODE_STATES.SUCCESS) {
                    if (status == Utils.NODE_STATES.RUNNING)
                        tick.GetBlackboard().AddRunningChildIndex(this, i);
                    return status;
                }
            }
            return Utils.NODE_STATES.SUCCESS;
        }
    }
}
