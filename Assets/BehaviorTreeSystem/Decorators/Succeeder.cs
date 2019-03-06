using System.Collections.Generic;

namespace BehaviorTree {

    [System.Serializable]
    public class Succeeder : BaseNode {

        public Succeeder(BaseNode child) : base(new List<BaseNode> { child }) { }

        protected override NODE_STATE Execute(Tick tick) {
            if (children != null && children.Count == 1) {
                children[0].Update(tick);
                return NODE_STATE.SUCCESS;
            } else return NODE_STATE.ERROR;
        }
    }
}