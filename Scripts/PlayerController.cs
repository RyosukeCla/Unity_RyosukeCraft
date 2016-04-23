using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	public string blockTag;
	public string blockTagWithNoDestroy;
	public string exitToScene;
	private Vector3 screenPos;
	public GameObject block;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Screen.lockCursor = true;

	}

	// Update is called once per frame
	void Update () {
		Vector3 vecMouse = new Vector3(Screen.width/2.0f, Screen.height/2.0f, 0.0f);
		screenPos = Camera.main.ScreenToWorldPoint(vecMouse);
		//Debug.Log(screenPos);
		Ray ray = Camera.main.ScreenPointToRay(vecMouse);
		RaycastHit hit = new RaycastHit();
		Vector3 vecTarget = screenPos - transform.position;
		if (Physics.Raycast(ray, out hit, 10.0f)) {
			//Debug.Log(hit.collider.tag);
			Vector3 hoge0 = SetNewBlock(hit.point, hit.collider.transform.position);
			if (Vector3.Magnitude(hoge0) != 0.0f && (hit.collider.tag == blockTag || hit.collider.tag == blockTagWithNoDestroy)) {
				if (Input.GetMouseButtonDown(0)) {
					Instantiate(block, hit.collider.transform.position + hoge0, Quaternion.identity);
				}
			}
		  if (Input.GetMouseButtonDown(1) && hit.collider.tag == blockTag){
				Destroy(hit.collider.gameObject);
			}
		}

		if (Input.GetKey(KeyCode.Escape)) {
			Application.LoadLevel(exitToScene);
		}
	}

	Vector3 SetNewBlock(Vector3 mousePos, Vector3 targetPos) {
		Vector3 hoge = mousePos - targetPos;
		//Debug.Log(hoge);
		List<float> a = new List<float>();
		string axis = "";
		if (Mathf.Abs(hoge.x) >= 0.45f) {
			//Debug.Log("x");
			a.Add(hoge.x);
			axis = "x";
		}
		if (Mathf.Abs(hoge.y) >= 0.45f) {
			//Debug.Log("y");
			a.Add(hoge.y);
			axis = "y";
		}
		if (Mathf.Abs(hoge.z) >= 0.45f) {
			//Debug.Log("z");
			a.Add(hoge.z);
			axis = "z";
		}
		if (a.Count > 1) {
			return new Vector3(0.0f, 0.0f, 0.0f);
		}
		if (axis == "x") return new Vector3 (a[0] * 2.0f, 0.0f, 0.0f);
		if (axis == "y") return new Vector3 (0.0f, a[0] * 2.0f, 0.0f);
		if (axis == "z") return new Vector3 (0.0f, 0.0f, a[0] * 2.0f);
		return new Vector3(0.0f, 0.0f, 0.0f);
	}
}
