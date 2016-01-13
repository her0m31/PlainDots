using UnityEngine;
using System.Collections;

public class PlainDots : MonoBehaviour {
	public Transform DotPrefab;
	private Vector3 lastDotPosition;
	private bool lastPointExists;

	private GameObject parent;

	void Start() {
		lastPointExists = true;
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 clickp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 newDotPosition = new Vector3(clickp.x, clickp.y, 0.0f);
			parent = new GameObject("parent");
			parent.transform.position = newDotPosition;
		}

		if (Input.GetMouseButton(0)) {
			Vector3 clickp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 newDotPosition = new Vector3(clickp.x, clickp.y, 0.0f);

			if(newDotPosition != lastDotPosition) {
				MakeDot(newDotPosition);
			}
		}

		if (Input.GetMouseButtonUp(0)) {
			parent.AddComponent<Rigidbody2D>();
		}
	}

	void MakeDot(Vector3 newDotPosition) {
		Transform dot = (Transform) Instantiate(DotPrefab, newDotPosition, Quaternion.identity);
		dot.parent = parent.transform;

		lastDotPosition = newDotPosition;
	}
}
