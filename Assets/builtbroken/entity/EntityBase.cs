using UnityEngine;
using System.Collections;
using BuiltBroken;
namespace BuiltBroken.TurnBased.Entity
{
	public class EntityBase : BoardPeace
	{
		private static int next_id = 0;

		protected int id = 0;

		public EntityBase(GameBoard board) : base(board)
		{
			id = next_id++;
		}

		public EntityBase setPosition(Vector3 pos)
		{
			gameObject.transform.position = pos;
			return this;
		}

		public EntityBase setYaw(float r)
		{
			gameObject.transform.rotation.SetLookRotation(new Vector3(0, r, 0));
			return this;
		}

		// Use this for initialization
		void Start () {
		
		}

		
		// Update is called once per frame
		void Update () {
		
		}
	}
}
