using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	public void exit() {
		Application.Quit();
	}

	public void jump(string scene) {
		Application.LoadLevel(scene);
	}

}
