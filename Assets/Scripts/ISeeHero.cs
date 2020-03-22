using UnityEngine;
using System.Collections;

public class ISeeHero : MonoBehaviour {

	private float SawHeroTime;
	private float RememberSeeingTime = 2f;

	void Start () {
	
	}
	
	void Update () {
		if (SawHeroTime + RememberSeeingTime < Time.time) {
			Destroy(this);
		}
	}

	internal void Prepare(InGamePosition inGamePosition) {
		if (GetComponents<ISeeHero>().Length > 1) {
			Destroy(this);
			return;
		}
		gameObject.GetComponent<Animator>().SetTrigger("roar");
		gameObject.GetComponent<AnimationSounds>().Play("roar");


		SawHeroTime = Time.time;
		Debug.Log("i see hero " + gameObject.name);
	}
}
