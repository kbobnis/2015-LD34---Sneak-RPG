using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	private float Speed;
	private InGamePosition TargetPos;

	// Update is called once per frame
	void Update () {

		InGamePosition myPos = GetComponent<InGamePosition>();

		if (TargetPos != null) {
			float deltaX = (TargetPos.GetComponent<InGamePosition>().X - myPos.LastFullX) * Speed * Time.deltaTime;
			float deltaY = (TargetPos.GetComponent<InGamePosition>().Y - myPos.LastFullY) * Speed * Time.deltaTime;

			Debug.Log("Moving by " + deltaX + " and " + deltaY);
			if (Mathf.Abs(deltaX) <= 0.001 && Mathf.Abs(deltaY) <= 0.001) {
				Destroy(TargetPos.gameObject.transform.GetChild(0).gameObject.GetComponent<Highlight>());
				Destroy(this);
			}

			myPos.ExactX += deltaX;
			myPos.ExactY += deltaY;
		}
	}

	internal void MoveTo(InGamePosition pos, float speed) {
		//only moving to direct neighbours
		if (gameObject.GetComponent<InGamePosition>().IsNeighbour(pos)) {
			Speed = speed;
			TargetPos = pos;
			pos.gameObject.transform.GetChild(0).gameObject.AddComponent<Highlight>();
		} else {
			InGamePosition pos2 = GetComponent<InGamePosition>();
			throw new System.Exception("Moving only to neighbour tiles. Trying to move from : " + pos2.X + ", " + pos2.Y + " to " + pos.X + ", " + pos.Y);
		}
	}
}
