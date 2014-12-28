using UnityEngine;
using System.Collections;
namespace BuiltBroken.TurnBased
{
	/** Board that the player places, controls, and experiences the game on */
	public class GameBoard : MonoBehaviour 
	{
		public Vector3 tileSize = new Vector3(5, 5, 5);
		public Vector2 boardSize = new Vector2(10, 10);
		public float yOffset = 2;

		public Material materialA;
		public Material materialB;

		public GameObject tile;
		public GameObject primaryPeace;

		protected GameObject[,] tiles;
		protected Team[] teams = new Team[2];
		protected Vector3 tileCenter;



		// Use this for initialization
		void Start () 
		{
			tileCenter = new Vector3 (tileSize.x / 2, tileSize.y / 2, tileSize.z / 2);
			teams [0] = new Team (this);
			teams [1] = new Team (this);
			tiles = createFloor (boardSize, yOffset);
		}

		
		protected GameObject[,] createFloor(Vector2 size, float y)
		{
			GameObject[,] tiles = new GameObject[(int)size.x, (int)size.y];
			bool flag = true;

			//Sets the floor center to gameobject center, TODO add var to change
			Vector3 center = gameObject.transform.position;
			//Moves the floor to center around the origin
			center -= new Vector3 ((size.x / 2) * tileSize.x, 0, tileSize.z * (size.y / 2));
			//Moves the floor up
			center += new Vector3 (0, y + tileCenter.y, 0);

			//Loop threw and create cubes
			for (int x = 0; x < size.x; x++) 
			{
				flag = x % 2 == 0 ? false : true;

				for (int z = 0; z < size.y; z++) 
				{
					Vector3 pos = new Vector3(x * tileSize.x, 0, tileSize.z * z);
					pos += center;

					tiles[x, z] = (GameObject)Instantiate(tile, new Vector3(), Quaternion.identity);
					tiles[x, z].transform.localScale = tileSize;
					tiles[x, z].transform.position = pos;
					if(flag)
					{
						tiles[x, z].renderer.material = materialA;
						tiles[x, z].renderer.material.color = Color.black;
					}
					else
					{
						tiles[x, z].renderer.material = materialB;
						tiles[x, z].renderer.material.color = Color.white;
					}
					flag = !flag;
				}
			}
			return tiles;
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}

	/** Any object that will be placed into the game board */
	public class BoardPeace : MonoBehaviour 
	{
		/** Current Game Board the object is placed on */
		protected GameBoard board;
		
		public BoardPeace (GameBoard board)
		{
			this.board = board;
		}
	}
}
