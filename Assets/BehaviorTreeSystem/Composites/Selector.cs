using System.Collections.Generic;

namespace BehaviorTree {

    [System.Serializable]
    public class Selector : BaseNode {

        public Selector(List<BaseNode> children) : base(children) { }

        protected override NODE_STATE Execute(Tick tick) {
            for (int i = 0; i < children.Count; i++) {
                NODE_STATE status = children[i].Update(tick);
                if (status != NODE_STATE.FAILURE)
                    return status;
            }
            return NODE_STATE.FAILURE;
        }
    }
}
