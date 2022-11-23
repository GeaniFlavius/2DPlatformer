
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Category("Movement/Direct")]
    [Description("Casts A Ray from origin Point to in front of the Agent")]

    public class Vision : ConditionTask<Transform>
    {
        private Vector2 position;
        private BoxCollider2D boxCollider2D;
        private float boxWidth;
        private float boxHeight;
        private Vector2 boxColliderSize;
        private LayerMask layerMask;
        protected override string OnInit()
        {
            layerMask =LayerMask.GetMask("Platforms");
            boxCollider2D = agent.GetComponent<BoxCollider2D>();
            boxColliderSize = boxCollider2D.size;
            boxWidth = boxCollider2D.size.x;
            boxHeight = boxCollider2D.size.y;
            return null;
        }
        
        
        protected override bool OnCheck()
        {
            return Check45();
        }

        public bool Check45()
        {
            position.x = agent.position.x + boxWidth;
            position.y = agent.position.y - boxHeight;
            return Physics2D.BoxCast(position, boxColliderSize, 0, Vector2.down, 0.1f, layerMask);
        }
        
    }
}