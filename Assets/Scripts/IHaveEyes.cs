using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IHaveEyes : MonoBehaviour {

	private float HowOften = 0.01f;
	private float LastUpdate;

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
			Vector3 finish2 = transform.forward * 2 - transform.up * 1.3f;
			Debug.DrawRay(start, finish2);

			List<Ray> rays = new List<Ray>();
			rays.Add(new Ray(start, finish));
			rays.Add(new Ray(start, finish2));

			foreach (Ray r in rays) {
				RaycastHit hit;
				if (Physics.Raycast(r, out hit)) {

					GameObject goHit = hit.collider.gameObject.transform.parent.gameObject;
					if (goHit.GetComponent<Tile>() != null) {
						goHit.AddComponent<MonsterSeesIt>().Prepare(gameObject, hit.distance, HowOften, Game.Me.MonsterSeesMaterial);
					}
				}
			}
		}

	}
}
