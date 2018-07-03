using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {

    [System.Serializable]
    public class BlackboardCondition<T> : Decorator {

        private BlackboardKey<T> blackboardKey;
        private T keyValue;
        private Utils.KEY_QUERY keyQuery;

        public BlackboardCondition(ref BlackboardKey<T> blackboardKey, T keyValue, Utils.KEY_QUERY keyQuery) {
            this.blackboardKey = blackboardKey;
            this.keyValue = keyValue;
            this.keyQuery = keyQuery;
        }

        public override bool Verify() {
            switch (keyQuery) {
                case Utils.KEY_QUERY.IS_EQUAL_TO:
                    return EqualityComparer<T>.Default.Equals(keyValue, blackboardKey.GetValue());
                case Utils.KEY_QUERY.IS_NOT_EQUAL_TO:
                    return !EqualityComparer<T>.Default.Equals(keyValue, blackboardKey.GetValue());
                default: return false;
            }
        }
    }
}
