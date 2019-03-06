using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {

    public enum VALIDATION {
        EQUAL_TO,
        NOT_EQUAL_TO,
        LESS_THAN,
        LESS_THAN_OR_EQUAL_TO,
        GREATER_THAN,
        GREATER_THAN_OR_EQUAL_TO
    }

    [System.Serializable]
    public class Condition<T> : BaseNode {

        private BlackboardKey<T> blackboardKey;
        private T valueToCheck;
        private VALIDATION testToPerform;

        public Condition(BlackboardKey<T> blackboardKey, T valueToCheck, VALIDATION testToPerform) : base(null) {
            this.blackboardKey = blackboardKey;
            this.valueToCheck = valueToCheck;
            this.testToPerform = testToPerform;
        }

        protected override NODE_STATE Execute(Tick tick) {
            NODE_STATE result;
            switch (testToPerform) {
                case VALIDATION.EQUAL_TO:
                    if (EqualityComparer<T>.Default.Equals(blackboardKey.GetValue(), valueToCheck))
                        result = NODE_STATE.SUCCESS;
                    else result = NODE_STATE.FAILURE;
                    break;
                case VALIDATION.NOT_EQUAL_TO:
                    if (!EqualityComparer<T>.Default.Equals(blackboardKey.GetValue(), valueToCheck))
                        result = NODE_STATE.SUCCESS;
                    else result = NODE_STATE.FAILURE;
                    break;
                case VALIDATION.LESS_THAN:
                    if (Comparer<T>.Default.Compare(blackboardKey.GetValue(), valueToCheck) < 0)
                        result = NODE_STATE.SUCCESS;
                    else result = NODE_STATE.FAILURE;
                    break;
                case VALIDATION.LESS_THAN_OR_EQUAL_TO:
                    if (Comparer<T>.Default.Compare(blackboardKey.GetValue(), valueToCheck) <= 0)
                        result = NODE_STATE.SUCCESS;
                    else result = NODE_STATE.FAILURE;
                    break;
                case VALIDATION.GREATER_THAN:
                    if (Comparer<T>.Default.Compare(blackboardKey.GetValue(), valueToCheck) > 0)
                        result = NODE_STATE.SUCCESS;
                    else result = NODE_STATE.FAILURE;
                    break;
                case VALIDATION.GREATER_THAN_OR_EQUAL_TO:
                    if (Comparer<T>.Default.Compare(blackboardKey.GetValue(), valueToCheck) >= 0)
                        result = NODE_STATE.SUCCESS;
                    else result = NODE_STATE.FAILURE;
                    break;
                default:
                    Debug.LogError("<Behavior Tree - Condition>: Invalid VALIDATION signature.");
                    result = NODE_STATE.ERROR;
                    break;
            }
            return result;
        }
    }
}
