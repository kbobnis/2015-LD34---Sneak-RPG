using UnityEngine;
using System.Collections;

public class InGamePosition : MonoBehaviour {

	public float ExactX, ExactY;
	public int LastFullX;
	public int LastFullY;

	public int X {
		get {
			int x = (int)(ExactX);
			return x;
		}
	}

	public int Y {
		get {
			int y = (int)(ExactY);
			return y;
		}
	}

	// Use this for initialization
	void Start () {
		InitializeBasedOnStartingPosition();
	}

	private void InitializeBasedOnStartingPosition() {
		ExactX = transform.position.x;
		ExactY = transform.position.z;
		LastFullX = X;
		LastFullY = Y;
	}

	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(ExactX, transform.position.y, ExactY);

		if (Mathf.Abs(LastFullX - ExactX) > 0.98) {
			
			LastFullX = X;
		}
		if (Mathf.Abs(LastFullY - ExactY) > 0.98) {
			Debug.Log("LastFullY changed from : " + LastFullY + " to " + Y + ", exactY is: " + ExactY);
			LastFullY = Y;
		}
	}

	internal bool IsNeighbour(InGamePosition other) {

		int hisX = other.X;
		int hisY = other.Y;
		Debug.Log("comparing " + X + ", " + Y + " and " + hisX + ", " + hisY);

		return Mathf.Abs(X - hisX) <= 1 && Y == hisY ||
			Mathf.Abs(Y - hisY) <= 1 && hisX == X;
	}

}
