using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("✫ Blackboard")]
    public class MultiplyVector : ActionTask
    {

        public BBParameter<Vector2> targetVector;
        public BBParameter<float> multiply = -1;

        protected override void OnExecute() {
            targetVector.value = targetVector.value.normalized * multiply.value;
            EndAction(true);
        }
    }
}