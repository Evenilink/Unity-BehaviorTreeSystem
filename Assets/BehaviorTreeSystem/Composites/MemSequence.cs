using System.Collections.Generic;

namespace BehaviorTree {

    [System.Serializable]
    public class MemSequence : BaseNode {

        public MemSequence(List<BaseNode> children) : base(children) { }

        protected override NODE_STATE Execute(Tick tick) {
            int childIndex = tick.GetBlackboard().GetRunningChildIndex(this);
            for (int i = childIndex; i < children.Count; i++) {
                NODE_STATE status = children[i].Update(tick);
                if (status != NODE_STATE.SUCCESS) {
                    if (status == NODE_STATE.RUNNING)
                        tick.GetBlackboard().AddRunningChild(this, i);
                    return status;
                }
            }
            return NODE_STATE.SUCCESS;
        }
    }
}
