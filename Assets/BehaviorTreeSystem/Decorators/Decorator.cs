using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {

    [System.Serializable]
    public abstract class Decorator {

        public Decorator() { }

        public abstract bool Verify();
    }
}
