# Unity Behavior Tree System

To read about Behavior Tree theory, check this amazing article → [Behavior trees for AI: How they work](https://www.gamasutra.com/blogs/ChrisSimpson/20140717/221339/Behavior_trees_for_AI_How_they_work.php)

## Blackboard

A **Blackboard** holds all the variables that a **Behavior Tree** needs to access in order to execute correctly. It defines the environment as seen from the **Behavior Tree's** perspective.

Each variable is a **Blackboard Key** of a desired type, and it needs to be initialized.

```C#
[Serializable]
public class BB_Player : Blackboard {

    public BlackboardKey<Vector3> nextPointVector;

    public BB_Player() : base() {
        nextPointVector = new BlackboardKey<Vector3>(new Vector3(0, 0, -1));
    }
}
```

## Composite Nodes

A Composite node is a node that can have one or more children. They will process one or more of these children in either a first to last sequence or random order depending if the composite is a **Sequence** or a **Selector**, and at some stage will consider their processing complete and pass either success or failure to their parent, often determined by the success or failure of the child nodes.

During the time they are processing children, they will continue to return Running to the parent.

**A Sequence runs its child nodes until one of them fails, and a Selector runs its child nodes until one of them succeeds.**

## Tasks

Tasks can’t have any child nodes, and it’s in these nodes that the actual actions are programmed.

## Decorators

As of right now, the only available decorator is the **Blackboard Condition**, that allows a condition to be checked before going to a specific branch of the tree.

## Behavior Tree

The **Behaviour Tree** class itself has a reference to the Blackboard that it uses, that is passed on to as the argument in the constructor.
Then, you can start to build the **Behavior Tree**, starting on the root node.

Below is a very simple **Behavior Tree**, using **Composite** and **Task** nodes, with a **Decorator**.

```C#
[Serializable]
public class BT_EscapePlayer : BehaviourTree {
    public BT_EscapePlayer(BB_EscapePlayer blackboard) : base(blackboard) {
        root =
            new MemSelector(new List<BaseNode> {
                new MemSequence(new List<BaseNode> {
                    new BTTask_MoveTo2D(ref blackboard.nextPointVector, 3.0f)
                }, new BlackboardCondition<Hero.State>(ref blackboard.heroState, Hero.State.Unprotected, Utils.KEY_QUERY.IS_EQUAL_TO))
            });
    }
}
```

## Full Example

For a complete example, check this [project](https://github.com/Evenilink/FEUP-ASSO).
