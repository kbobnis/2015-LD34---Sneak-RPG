using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchController : MonoBehaviour {

	public GameObject ActualTargetTile;
	public GameObject Hero;

	public List<Action> Actions = new List<Action>();

	void Update () {

		try {
			if (Input.GetMouseButtonDown(0)) {
				Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(r, out hit)) {

					ActualTargetTile = hit.collider.gameObject.transform.parent.gameObject;
					if (ActualTargetTile != null && !ActualTargetTile.GetComponent<InGamePosition>().IsTheSame(Hero.GetComponent<InGamePosition>())) {

						if (Hero.GetComponent<WalkAroundController>() != null) {
							Destroy(Hero.GetComponent<WalkAroundController>());
						}

						Hero.AddComponent<WalkAroundController>().WalkTo(ActualTargetTile.GetComponent<InGamePosition>());
					}
				}
			}
		} catch (WrongTouchException e) {
			ActualTargetTile = null;
			Debug.Log("Wrong touch: " + e.Message);
		}
	}
}

public enum Action {
	Turn, Move
}