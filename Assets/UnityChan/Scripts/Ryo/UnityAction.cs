using UnityEngine;
using System.Collections;

public class UnityAction : MonoBehaviour {
	public GameObject unityChan;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AttackEnd()
	{
		unityChan.GetComponent<Animator> ().SetTrigger ("RemoveIdle");
	}
}
