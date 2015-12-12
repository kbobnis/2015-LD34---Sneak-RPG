using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	public GameObject ActualTargetTile;
	public GameObject Hero;

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(r, out hit)){

				ActualTargetTile = hit.collider.gameObject.transform.parent.gameObject;
				if (ActualTargetTile != null && !Hero.GetComponent<Mover>()) {
					Hero.AddComponent<Mover>().MoveTo(ActualTargetTile.GetComponent<InGamePosition>(), Hero.GetComponent<Attributes>().Speed);
				}
			}
		}
	}
}
