using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {

    [System.Serializable]
    public class BaseNode {

        protected List<BaseNode> children;
        private Decorator[] decorators;

        public BaseNode(List<BaseNode> children, params Decorator[] decorators) {
            this.children = children;
            this.decorators = decorators;
        }

        public virtual Utils.NODE_STATES Update(Tick tick) {
            bool canEnter = Enter(tick);
            if (!canEnter)
                return Utils.NODE_STATES.FAILURE;

            if (!tick.GetBlackboard().GetIsOpen(this))
                Open(tick);

            Utils.NODE_STATES status = Execute(tick);

            if (status != Utils.NODE_STATES.RUNNING)
                Close(tick);

            return status;
        }

        protected bool Enter(Tick tick) {
            // If there's any decorator that's not valid, the node can't be opened.
            for (int i = 0; i < decorators.Length; i++)
                if (!decorators[i].Verify())
                    return false;

            tick.EnterNode(this);
            return true;
        }

        protected virtual void Open(Tick tick) {
            tick.OpenNode(this);
            tick.GetBlackboard().SetOpen(this, true);
        }

        protected virtual Utils.NODE_STATES Execute(Tick tick) {
            tick.TickNode(this);
            return Utils.NODE_STATES.SUCCESS;   //This value doesn't matter, we just needed the parent function to return NODE_STATES, so that the overriden child function could also due it (and those matter).
        }

        public void Close(Tick tick) {
            tick.CloseNode(this);
            tick.GetBlackboard().SetOpen(this, false);
        }

        protected void Exit(Tick tick) {
            tick.ExitNode(this);
        }

        public List<BaseNode> GetChildren() {
            return this.children;
        }

        public Decorator[] GetDecorators() {
            return decorators;
        }
    }
}
