using UnityEngine;
using System.Collections;

public class Goall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c)
	{
		Debug.Log ("Goal !!!");
		c.SendMessage ("OnGoal");
	}
}
