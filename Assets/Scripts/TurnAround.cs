using UnityEngine;
using System.Collections;

public class TurnAround : MonoBehaviour {

	private float TargetRotation;
	private float RotationAngle;
	private float RotationLeft;
	private float Speed;

	void Update () {
		if (TargetRotation != null) {
			float deltaRot = Speed * Time.deltaTime * RotationAngle;
			RotationLeft -= Mathf.Abs( deltaRot );
			InGamePosition myPos = GetComponent<InGamePosition>();

			if (RotationLeft <= 0) {
				myPos.MakeRotationExact();
				Destroy(this);
			} else {
				myPos.Rotation += deltaRot;
			}
		}
	}

	internal void TurnBy(Side howTurn, float speed) {
		RotationAngle = (int)howTurn;
		RotationLeft = Mathf.Abs(RotationAngle);
		TargetRotation = (int)howTurn + gameObject.GetComponent<InGamePosition>().Rotation;
		Speed = speed * 2; //because turning around has to be faster than moving to look the same
	}
}
