using UnityEngine;
using System.Collections;

public class InGamePosition : MonoBehaviour {

	public float ExactX, ExactY;
	public int LastFullX;
	public int LastFullY;
	public float Rotation;

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

	public Side Side {
		get {
			return (Side)((int)Rotation);
		}
	}

	void Start () {
		InitializeBasedOnStartingPosition();
	}

	private void InitializeBasedOnStartingPosition() {
		ExactX = transform.position.x;
		ExactY = transform.position.z;
		LastFullX = X;
		LastFullY = Y;
	}

	void Update () {
		transform.position = new Vector3(ExactX, transform.position.y, ExactY);

		if (Mathf.Abs(LastFullX - ExactX) > 0.98) {
			
			LastFullX = X;
		}
		if (Mathf.Abs(LastFullY - ExactY) > 0.98) {
			LastFullY = Y;
		}
		transform.localEulerAngles = new Vector3(transform.rotation.x, Rotation, transform.rotation.z);
	}

	internal bool IsNeighbour(InGamePosition other) {

		int hisX = other.X;
		int hisY = other.Y;

		return Mathf.Abs(X - hisX) <= 1 && Y == hisY || Mathf.Abs(Y - hisY) <= 1 && hisX == X;
	}

	internal global::Side GetDirection(InGamePosition pos) {
		if (!IsNeighbour(pos)) {
			throw new WrongTouchException("To get direction you have to get neightbour tile, but got  " + X + " to " + pos.X + " and " + Y + " to " + pos.Y);
		}

		if (pos.X > X) {
			return Side.Right;
		}
		if (pos.X < X) {
			return Side.Left;
		}

		if (pos.Y > Y) {
			return Side.Up;
		}

		if (pos.Y < Y){
			return Side.Down;
		}
		throw new System.Exception("How did I not found any direction?");

	}

	internal void MakeRotationExact() {
		Rotation = Mathf.Round(Rotation / 90) * 90;
	}

	internal bool IsTheSame(InGamePosition other) {
		return X == other.X && Y == other.Y;
	}
}
