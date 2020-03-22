using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject
{
    [TaskCategory("Unity/GameObject")]
    [TaskDescription("Sets the GameObject tag. Returns Success.")]
    public class SetTag : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [Tooltip("The GameObject tag")]
        public SharedString tag;
        public SharedGameObject GoA;
        public BehaviorTree bt;

        public override TaskStatus OnUpdate()
        {
            GetDefaultGameObject(targetGameObject.Value).tag = tag.Value;
            bt.SetVariable("temp", targetGameObject);
            GoA = (bt.GetVariable("temp") as SharedGameObject).Value;
            UnityEngine.Debug.LogError("Goa: " + GoA.Value.name);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetGameObject = null;
            tag = "";
        }
    }
}