using UnityEngine;
using System.Collections;

public class GameManege : MonoBehaviour {
	public GameObject block;
	public int rx, lx;
	public int ry, ly;
	// Use this for initialization
	void Start () {
		for (int i = rx; i < lx; i++) {
			for (int j = ry; j < ly; j++) {
				Instantiate(block, new Vector3(i * 1.0f, 0.5f, j * 1.0f), Quaternion.identity);
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
