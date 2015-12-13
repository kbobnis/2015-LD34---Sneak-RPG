using UnityEngine;
using System.Collections;

public class TurnAround : MonoBehaviour {

	private float TargetRotation;
	private float Rotation;
	private int Speed;

	void Update () {
		if (TargetRotation != null) {

			float deltaRot = Speed * 2 * Time.deltaTime * Rotation;
			InGamePosition myPos = GetComponent<InGamePosition>();

			//Debug.Log("delta rotation: " + Mathf.Abs(TargetRotation - gameObject.GetComponent<InGamePosition>().Rotation ));
			if (Mathf.Abs( TargetRotation - gameObject.GetComponent<InGamePosition>().Rotation ) < 2.1f * Speed) {
				//correct the rotation to proper x * 90 value
				myPos.MakeRotationExact();
				GetComponent<Animator>().SetFloat("speed", 0.0f);
				Destroy(this);
			} else {
				myPos.Rotation += deltaRot;
			}

			
		}
	
	}

	internal void TurnBy(Side howTurn, int speed) {
		Rotation = (int)howTurn;
		TargetRotation = (int)howTurn + gameObject.GetComponent<InGamePosition>().Rotation;
		Speed = speed;
	}
}
