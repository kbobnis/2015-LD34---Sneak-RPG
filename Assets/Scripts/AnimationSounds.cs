using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationSounds : MonoBehaviour {

	public Dictionary<string, AudioClip> Sounds = new Dictionary<string,AudioClip>();

	void Update() {

		foreach(string soundName in Sounds.Keys ){
			if (GetComponent<Animator>().GetFloat(soundName) > 0 && !GetComponent<AudioSource>().isPlaying) {
				GetComponent<AudioSource>().clip = Sounds[soundName];
				GetComponent<AudioSource>().Play();
			}
		}
	}
}
