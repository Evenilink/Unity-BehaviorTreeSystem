using System.Collections.Generic;

namespace BehaviorTree {

    [System.Serializable]
    public class RepeatUntilFailure : BaseNode {

        public RepeatUntilFailure(BaseNode child) : base(new List<BaseNode> { child }) { }

        protected override NODE_STATE Execute(Tick tick) {
            if (children != null && children.Count == 1) {
                NODE_STATE childState = children[0].Update(tick);
                if (childState == NODE_STATE.FAILURE)
                    return NODE_STATE.SUCCESS;
                return NODE_STATE.RUNNING;
            } else return NODE_STATE.ERROR;
        }
    }
}
