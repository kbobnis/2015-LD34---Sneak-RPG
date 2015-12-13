using UnityEngine;
using System.Collections;

public class MoveAhead : MonoBehaviour {

	private float Speed;
	private InGamePosition TargetPos;

	// Update is called once per frame
	void Update () {

		InGamePosition myPos = GetComponent<InGamePosition>();

		if (TargetPos != null) {
			float deltaX = (TargetPos.GetComponent<InGamePosition>().X - myPos.LastFullX) * Speed * Time.deltaTime;
			float deltaY = (TargetPos.GetComponent<InGamePosition>().Y - myPos.LastFullY) * Speed * Time.deltaTime;

			if (Mathf.Abs(deltaX) <= 0.001 && Mathf.Abs(deltaY) <= 0.001) {
				GetComponent<Animator>().SetFloat("speed", 0.0f);
				Destroy(this);
			}

			myPos.ExactX += deltaX;
			myPos.ExactY += deltaY;
		}
	}

	internal void MoveTo(InGamePosition nextPos, float speed) {

		//only moving to direct neighbours
		if (!gameObject.GetComponent<InGamePosition>().IsNeighbour(nextPos)) {
			InGamePosition pos2 = GetComponent<InGamePosition>();
			throw new System.Exception("Moving only to neighbour tiles. Trying to move from : " + pos2.X + ", " + pos2.Y + " to " + nextPos.X + ", " + nextPos.Y);
		}

		//check if it doesn't need to turn first
		InGamePosition myPos = GetComponent<InGamePosition>();
		//Side turnHow = myPos.Side.GetDiff(myPos.GetDirection(nextPos));
		//if (turnHow != Side.Up) {
			//throw new System.Exception("You can only move forward. Please tell the programmer to turn around your hero first.");
		//}

		Speed = speed;
		TargetPos = nextPos;
		GetComponent<Animator>().SetFloat("speed", 1.0f);
			
	}
}

