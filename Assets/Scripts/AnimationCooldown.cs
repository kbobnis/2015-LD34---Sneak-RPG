using UnityEngine;
using System.Collections;

public class AnimationCooldown : MonoBehaviour {

	private string ParamName;
	private float Starting, Finishing;
	private float TimeToEnd = 0.2f;

	void Update() {
		
		float actualValue = GetComponent<Animator>().GetFloat(ParamName);

		float delta = Time.deltaTime * (Finishing - Starting) / TimeToEnd;

		GetComponent<Animator>().SetFloat(ParamName, actualValue + delta);

		if (Mathf.Abs(actualValue + delta - Finishing) < (Finishing-Starting)/TimeToEnd/50f) {
			Destroy(this);
		}
	}

	internal void Set(string name, float starting, float ending) {

		AnimationCooldown[] allC = gameObject.GetComponents<AnimationCooldown>();
		foreach (AnimationCooldown ac in allC) {
			if (ac != this) {
				Destroy(ac);
			}
		}

		ParamName = name;
		Starting = starting;
		Finishing = ending;

		
	}
}
