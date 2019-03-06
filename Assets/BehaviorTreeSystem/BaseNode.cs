using System.Collections.Generic;

namespace BehaviorTree {

    public enum NODE_STATE {
        SUCCESS,
        FAILURE,
        RUNNING,
        ERROR
    }

    [System.Serializable]
    public abstract class BaseNode {

        protected List<BaseNode> children;

        public BaseNode(List<BaseNode> children) { this.children = children; }

        public virtual NODE_STATE Update(Tick tick) {
            if (!tick.GetBlackboard().NodeOpened(this))
                Open(tick);
            NODE_STATE status = Execute(tick);
            if (status != NODE_STATE.RUNNING)
                Close(tick);
            return status;
        }

        protected virtual void Open(Tick tick) {
            tick.GetBlackboard().AddOpenNode(this);
            tick.GetBlackboard().RemoveRunningChild(this);
        }

        public void Close(Tick tick) { tick.GetBlackboard().RemoveOpenNode(this); }

        abstract protected NODE_STATE Execute(Tick tick);
    }
}
