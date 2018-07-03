using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {

    [System.Serializable]
    public class Sequence : BaseNode {

        public Sequence(List<BaseNode> children) : base(children) { }

        protected override Utils.NODE_STATES Execute(Tick tick) {
            base.Execute(tick);
            for (int i = 0; i < children.Count; i++) {
                Utils.NODE_STATES status = children[i].Update(tick);
                if (status != Utils.NODE_STATES.SUCCESS)
                    return status;
            }
            return Utils.NODE_STATES.SUCCESS;
        }
    }
}
