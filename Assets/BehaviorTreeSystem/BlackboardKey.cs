using System;

namespace BehaviorTree {

    [Serializable]
    public class BlackboardKey<T> {

        private T param;

        public BlackboardKey(T value) { param = value; }

        public void SetValue(T value) { param = value; }

        public T GetValue() { return param; }

        public void Nullify() { param = default(T); }

        public bool IsSet() { return !param.Equals(default(T)); }
    }
}
