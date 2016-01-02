using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Walker : MonoBehaviour {

	public List<Action> Actions;
	private int Index;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//check if he is not already moving or turning
		if (!gameObject.GetComponent<TurnAround>() && !gameObject.GetComponent<MoveAhead>() ) {

			Action action = Actions[Index];

			Index++;
			if (Index >= Actions.Count) {
				Index = 0;
			}

			switch (action) {
				case Action.MoveForward:
					gameObject.AddComponent<MoveAhead>().Move(gameObject.GetComponent<Attributes>().Speed);
					break;
				case Action.TurnLeft:
					gameObject.AddComponent<TurnAround>().TurnBy(Side.Left, gameObject.GetComponent<Attributes>().Speed);
					break;
				case Action.TurnRight:
					gameObject.AddComponent<TurnAround>().TurnBy(Side.Right, gameObject.GetComponent<Attributes>().Speed);
					break;
				case Action.TurnAround:
					gameObject.AddComponent<TurnAround>().TurnBy(Side.Down, gameObject.GetComponent<Attributes>().Speed);
					break;
				default:
					throw new System.Exception("There is no action " + action + ".");
			}
		}
	}
}

