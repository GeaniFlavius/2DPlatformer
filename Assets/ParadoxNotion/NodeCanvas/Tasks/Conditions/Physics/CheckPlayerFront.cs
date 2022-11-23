using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.PlayerLoop;


namespace NodeCanvas.Tasks.Conditions
{
    [Category("GameObject")]
    [Description("A combination of line of sight and view angle check")]
    public class CheckPlayerFront : ConditionTask<Transform>
    {
        [RequiredField] public BBParameter<GameObject> target;
        public LayerMask mask = -1;
        [BlackboardOnly] public BBParameter<GameObject> saveHitGameObjectAs;
        [BlackboardOnly] public BBParameter<float> saveDistanceAs;
        public BBParameter<float> distance;
        [BlackboardOnly] public BBParameter<Vector3> savePointAs;
        [BlackboardOnly] public BBParameter<Vector3> saveNormalAs;



        private RaycastHit2D hit;

        protected override string OnInit()
        {
            return base.OnInit();
        }

        protected override bool OnCheck()
        {
            hit = Physics2D.Linecast(agent.position, agent.position  + ( agent.right * distance.value ), mask);

            if (hit.collider == target.value.GetComponent<Collider2D>())
            {
                saveHitGameObjectAs.value = hit.collider.gameObject;
                saveDistanceAs.value = hit.fraction;
                savePointAs.value = hit.point;
                saveNormalAs.value = hit.normal;
                return true;
            }

            return false;
        }

        public override void OnDrawGizmos()
        {
            if (agent && target.value)
                //Gizmos.DrawLine(agent.position, Vector2.right);
                //Gizmos.DrawLine(agent.position, agent.position );
                Gizmos.DrawLine(agent.position , agent.position  + ( agent.right * distance.value ));
        }
    }
}