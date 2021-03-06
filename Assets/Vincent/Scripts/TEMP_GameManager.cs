﻿using UnityEngine;
using System.Collections;

public class TEMP_GameManager : MonoBehaviour {

	private SfxPlayer sfxPlayer;
	private bool calledTheCoroutine;

	// Use this for initialization
	void Start () {
		calledTheCoroutine = false;
		sfxPlayer = GetComponentInChildren<SfxPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!calledTheCoroutine) {
			calledTheCoroutine = true;
			StartCoroutine(TEST_playSfx());
		}
	}

	private IEnumerator TEST_playSfx() {
		sfxPlayer.PlaySoundEffect("cello damaged 1");
		yield return new WaitForSeconds(1.0f);
		sfxPlayer.PlaySoundEffect("cello select 1");
		yield return new WaitForSeconds(1.0f);
		sfxPlayer.PlaySoundEffect("cello shoot wave 1");
	}
}
