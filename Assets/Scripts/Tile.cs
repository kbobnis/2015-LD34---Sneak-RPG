using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public GameObject Floor, Wall;

	void Start() {
		InitFromScene();
	}

	private void InitFromScene() {
		Floor = transform.GetChild(0).gameObject;
		Wall = transform.GetChild(1).gameObject;
	}

}
