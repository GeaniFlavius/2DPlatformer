using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Category("Physics")]
	public class CheckGroundFront : ConditionTask<Transform>
	{

		private Vector2 size = new Vector2(1, 1);
		private LayerMask layerMask;
		private Transform position;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit()
		{
			GameObject go = GameObject.Find ("CheckGroundFront");
			position = go.transform;
			layerMask =LayerMask.GetMask("Main");
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable(){
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable(){
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck()
		{
			return Check45();
		}
		
		public bool Check45()
		{
			//Debug.Log(Physics2D.BoxCast(position.position, size, 0, Vector2.down, 0.1f, 6).collider.tag);
			//bool check = Physics2D.BoxCast(position.position, size, 0, Vector2.down, 0.1f, 6);
			//Debug.Log(check);
			return Physics2D.BoxCast(position.position, size, 0, Vector2.down, 0.1f, layerMask);
		}

		public override void OnDrawGizmosSelected()
		{
			//Gizmos.DrawCube(position.position,size);
		}
	}
}