using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public static Game Me;

	public Material HighlightMaterial;
	public Material CanGoThereMaterial;
	public Material MonsterSeesMaterial;

	public GameObject EnemiesParent;
	public GameObject Hero;
	public GameObject GameTilesParent;

	// Use this for initialization
	void Start () {
		Me = this;
		DrawColorsOnBottom();
	}
	
	// Update is called once per frame
	void Update () {
		DrawColorsOnBottom();
	}

	private void DrawColorsOnBottom() {

		GameObject monster = EnemiesParent.transform.GetChild(1).gameObject;

		//for (int i = 0; i < GameTilesParent.transform.childCount; i += 2 ) {
//			GameObject tile = GameTilesParent.transform.GetChild(i).gameObject;
			//GameObject bottom = tile.transform.GetChild(0).gameObject;
			
			//each tile, one monster
			//Debug.DrawLine(monster.transform.position, bottom.transform.position);
			Ray r = new Ray(monster.transform.position + monster.transform.up*1.3f, monster.transform.forward-monster.transform.up*1.3f);
			RaycastHit hit;
			Material[] mat = new Material[1];
			mat[0] = MonsterSeesMaterial;
			if (Physics.Raycast(r, out hit)) {

				GameObject goHit = hit.collider.gameObject;
				goHit.GetComponent<MeshRenderer>().materials = mat;
			}
	}
}
