using UnityEngine;
using System.Collections;
using BuiltBroken.TurnBased.Entity;
using BuiltBroken.TurnBased;


namespace BuiltBroken
{
	public class Team {

		protected EntityBase[] peaces = new EntityBase[20];

		protected GameBoard board;

		public Team(GameBoard board)
		{
			this.board = board;
		}

		// Use this for initialization
		void Start () 
		{
			Debug.Log ("PrimaryPeace = " + board.primaryPeace);
			GameObject newPeace = (GameObject)UnityEngine.Object.Instantiate(board.primaryPeace, board.transform.position, board.transform.rotation);
		}

		// Update is called once per frame
		void Update () {
		
		}
	}
}
