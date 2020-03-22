using UnityEngine;
using System.Collections;

public class MonsterSeesIt : MonoBehaviour {

	private Material[] WhenHeSeesIt;
	private GameObject Monster;
	private float Distance;
	private float TimeActive;
	private float SawTime;

	void Update () {
		if (Time.time > SawTime + TimeActive) {
			Destroy(this);
		}
		//is hero here?
		GameObject hero = Game.Me.Hero;
		if (hero.GetComponent<InGamePosition>().IsTheSame(GetComponent<InGamePosition>())) {
			Monster.AddComponent<ISeeHero>().Prepare(GetComponent<InGamePosition>());
		}
	}

	void OnDestroy() {
		if (gameObject.GetComponents<MonsterSeesIt>().Length <= 1) {
			gameObject.GetComponent<Tile>().Floor.GetComponent<MeshRenderer>().materials = Game.Me.StandardMaterial;
		}
	}

	internal void Prepare(GameObject monster, float distance, float timeActive, Material[] whenHeSeesIt) {

		if (!gameObject.GetComponent<MonsterSeesIt>()) {
			Destroy(this);
			return;
		}
		Monster = monster;
		MeshRenderer mr = gameObject.GetComponent<Tile>().Floor.GetComponent<MeshRenderer>();
		WhenHeSeesIt = whenHeSeesIt;
		Distance = distance;
		TimeActive = timeActive ;
		SawTime = Time.time;
		mr.materials = WhenHeSeesIt;
	}
}
