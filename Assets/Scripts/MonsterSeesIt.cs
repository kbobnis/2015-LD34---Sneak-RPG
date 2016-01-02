using UnityEngine;
using System.Collections;

public class MonsterSeesIt : MonoBehaviour {

	private Material[] WhenHeSeesIt;
	private Material[] OldMat;
	private Attributes MonstersAttributes;
	private float Distance;
	private float TimeActive;
	private float SawTime;

	void Update () {
		if (Time.time > SawTime + TimeActive) {
			Destroy(this);
		}
	}

	void OnDestroy() {
		if (gameObject.GetComponents<MonsterSeesIt>().Length <= 1) {
			gameObject.GetComponent<Tile>().Floor.GetComponent<MeshRenderer>().materials = Game.Me.StandardMaterial;
		}
	}

	internal void Prepare(Attributes monstersAttributes, float distance, float timeActive, Material[] whenHeSeesIt) {

		if (!gameObject.GetComponent<MonsterSeesIt>()) {
			Destroy(this);
			return;
		}

		MeshRenderer mr = gameObject.GetComponent<Tile>().Floor.GetComponent<MeshRenderer>();
		OldMat = mr.materials;
	
		WhenHeSeesIt = whenHeSeesIt;
		MonstersAttributes = monstersAttributes;
		Distance = distance;
		TimeActive = timeActive ;
		SawTime = Time.time;
		
		
		mr.materials = WhenHeSeesIt;
	}
}
