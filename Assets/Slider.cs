using UnityEngine;
using System.Collections;

public class Slider : MonoBehaviour {

	Vector3 initPosition;

	// Use this for initialization
	void Start () {
		initPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 diff = new Vector3(0, 0, 3f * (1 + Mathf.Cos(Time.time*2 + Mathf.PI)));
		this.transform.position = initPosition + diff;
	}
}
