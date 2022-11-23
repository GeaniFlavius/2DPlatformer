using System;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Movement/Direct")]
    [Description("Moves the agent")]

    public class Move : ActionTask<Transform>

    {
        private Rigidbody2D rigidBody;
        private Vector3 velocity = Vector3.zero;
        [SerializeField] [Range(0, 1)] float startingSmooth= 0.3f;
        [SerializeField] [Range(0, 1)] float stoppingSmooth = 0.1f;
        [SerializeField] [Range(0, 20)] float moveSpeed = 10;
        private Vector2 targetVelocity;
        public bool dir;
        private BoxCollider2D boxCollider2D;
        private float boxWidth;
        private float boxHeight;
        private Vector2 boxColliderSize;
        private LayerMask layerMask;
        private Transform position;

        private bool facingRight = true;
        protected override string OnInit()
        {
            GameObject go = GameObject.Find ("MoveTowards");
            position = go.transform;
            rigidBody = agent.GetComponent<Rigidbody2D>();
            return null;
        }
        protected override void OnUpdate()
        {
            agent.position= Vector3.MoveTowards(agent.position, position.position, moveSpeed*Time.deltaTime);
            Debug.Log(agent.position);
            Debug.Log(position.position);
        }
        
        public void HorizontalMove(Vector2 input)
        {
            
            targetVelocity = new Vector2(input.x * moveSpeed, rigidBody.velocity.y);

            if (input.x == 0)
            {
                //Debug.Log("stoppping");
                rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, stoppingSmooth);
            }
            else if (input.x > 0 || input.x < 0)
            {
                //Debug.Log("Left/Right");
                rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, startingSmooth);
            }
        }


    }
}
