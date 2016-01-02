﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IHaveEyes : MonoBehaviour {

	public float HowOften = 0.01f;
	public float LastUpdate;

	// Use this for initialization
	void Start () {
		LastUpdate = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if (LastUpdate + HowOften < Time.time) {
			LastUpdate = Time.time;

			Vector3 start = transform.position + transform.up * 1.3f;
			Vector3 finish = transform.forward - transform.up * 1.3f;
			Debug.DrawRay(start, finish);

			List<Ray> rays = new List<Ray>();
			rays.Add(new Ray(start, finish));

			foreach (Ray r in rays) {
				RaycastHit hit;
				if (Physics.Raycast(r, out hit)) {

					GameObject goHit = hit.collider.gameObject.transform.parent.gameObject;
					if (goHit.GetComponent<Tile>() != null) {
						goHit.AddComponent<MonsterSeesIt>().Prepare(GetComponent<Attributes>(), hit.distance, HowOften, Game.Me.MonsterSeesMaterial);
					}
				}
			}
		}

	}
}
