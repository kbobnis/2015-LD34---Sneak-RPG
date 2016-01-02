using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public static Game Me;

	public Material StandardMaterial;
	public Material HighlightMaterial;
	public Material CanGoThereMaterial;
	public Material[] MonsterSeesMaterial;

	public GameObject EnemiesParent;
	public GameObject Hero;
	public GameObject GameTilesParent;

	// Use this for initialization
	void Start () {
		Me = this;
	}
	
}
