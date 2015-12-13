using UnityEngine;
using System.Collections;

public class WalkAroundController : MonoBehaviour {

	private InGamePosition TargetPos;
	private Highlight TheHighlight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//get the next move
		try {
			//check if he is not already moving or turning
			if (!gameObject.GetComponent<TurnAround>() && !gameObject.GetComponent<MoveAhead>() && TargetPos != null) {

				//to turn?
				Side actualSide = gameObject.GetComponent<InGamePosition>().Side;
				Side howTurn = actualSide.GetDiff(gameObject.GetComponent<InGamePosition>().GetDirection(TargetPos));
				if (howTurn != Side.Up) {
					gameObject.AddComponent<TurnAround>().TurnBy(howTurn, GetComponent<Attributes>().Speed);
				} else {
					//whatever just go
					gameObject.AddComponent<MoveAhead>().MoveTo(TargetPos, GetComponent<Attributes>().Speed);
					TargetPos = null;
				}
			}

			if (TargetPos == null) {
				Destroy(this);
			}
		} catch (WrongTouchException e) {
			TargetPos = null;
			if (TheHighlight != null) {
				Destroy(TheHighlight);
				TheHighlight = null;
			}
			Debug.Log("Wrong touch exception: " + e.Message);
		}
	}

	void OnDestroy() {
		Destroy(TheHighlight);
	}

	internal void WalkTo(InGamePosition targetTile) {

		InGamePosition myPos = gameObject.GetComponent<InGamePosition>();
		TargetPos = targetTile.GetComponent<InGamePosition>();

		//only moving to direct neighbours for now 
		if (!myPos.IsNeighbour(TargetPos)) {
			throw new WrongTouchException("Moving only to direct neighbours.");
		}

		TheHighlight = TargetPos.gameObject.transform.GetChild(0).gameObject.AddComponent<Highlight>();
	}
}
