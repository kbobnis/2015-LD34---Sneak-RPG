using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	public GameObject ActualTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)){
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(r, out hit)){
				Debug.Log("touched object: " + hit.collider.gameObject.name);
				if (ActualTarget != null) {
					Destroy(ActualTarget.GetComponent<Highlight>());
				}
				ActualTarget = hit.collider.gameObject;
				hit.collider.gameObject.AddComponent<Highlight>();
			}
			Debug.Log("Left clicked at " + Input.mousePosition );
		}
	}
}
