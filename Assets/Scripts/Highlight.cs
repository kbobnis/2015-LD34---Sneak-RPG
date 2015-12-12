using UnityEngine;
using System.Collections;

public class Highlight : MonoBehaviour {

	private Material[] OldMaterials;

	// Use this for initialization
	void Start () {
		OldMaterials = gameObject.GetComponent<MeshRenderer>().materials;
		Material[] m = new Material[1];
		m[0] = Game.Me.HighlightMaterial;
		gameObject.GetComponent<MeshRenderer>().materials = m;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy() {
		gameObject.GetComponent<MeshRenderer>().materials = OldMaterials;
	}
}
