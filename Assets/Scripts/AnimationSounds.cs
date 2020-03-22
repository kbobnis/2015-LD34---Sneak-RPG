using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationSounds : MonoBehaviour {

	public Dictionary<string, AudioClip> Sounds = new Dictionary<string,AudioClip>();
	public AudioClip Roar;

	void Start() {
		Sounds.Add("roar", Roar);
	}

	void Update() {
		return;
		foreach(string soundName in Sounds.Keys ){
			if ((GetComponent<Animator>().GetFloat(soundName) > 0 || GetComponent<Animator>().GetBool(soundName)) 
				&& (!GetComponent<AudioSource>().isPlaying )) {
				GetComponent<AudioSource>().clip = Sounds[soundName];
				GetComponent<AudioSource>().Play();
			}
		}
	}

	public void Play(string name) {
		Debug.Log("play " + name);
		GetComponent<AudioSource>().clip = Sounds[name];
		GetComponent<AudioSource>().Play();
	}
}
