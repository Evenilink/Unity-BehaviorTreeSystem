using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BehaviorTree {

    [System.Serializable]
    public class Utils {

        private static double vectorCompareDiff = 0.1f;

        public enum NODE_STATES {
            SUCCESS,
            FAILURE,
            RUNNING,
            ERROR
        }

        public enum KEY_QUERY {
            IS_EQUAL_TO,
            IS_NOT_EQUAL_TO,
            IS_LESS_THAN,
            IS_LESS_THAN_OR_EQUAL_TO,
            IS_GREATER_THAN,
            IS_GREATER_THAN_OR_EQUAL_TO
        }

        public static bool CompareVectors(Vector3 vector, Vector3 otherVector) {
            return Math.Abs(vector.x - otherVector.x) + Math.Abs(vector.y - otherVector.y) + Math.Abs(vector.z - otherVector.z) <= vectorCompareDiff;
        }
    }
}
