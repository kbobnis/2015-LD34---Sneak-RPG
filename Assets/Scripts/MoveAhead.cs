using UnityEngine;
using System.Collections;

public class MoveAhead : MonoBehaviour {

	private float DistanceLeft;
	private float Speed;

	// Update is called once per frame
	void Update () {

		InGamePosition myPos = GetComponent<InGamePosition>();

		Vector3 delta = gameObject.transform.forward * Speed * Time.deltaTime;
		DistanceLeft -= Mathf.Abs( delta.x + delta.z );
		myPos.ExactX += delta.x;
		myPos.ExactY += delta.z;

		if (DistanceLeft <= 0) {
			myPos.MakePosExact();
			GetComponent<Animator>().SetFloat("speed", 0.0f);
			Destroy(this);
		}
		
	}

	internal void Move(float speed) {

		InGamePosition myPos = GetComponent<InGamePosition>();
		DistanceLeft = 1;

		Speed = speed;
		GetComponent<Animator>().SetFloat("speed", 1.0f);
			
	}
}

