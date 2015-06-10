using UnityEngine;
using System.Collections;

public class EnemyControlloer : MonoBehaviour {

	public GameObject hitEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DeathEnemy()
	{
		GetComponent<Animator> ().SetTrigger ("Down");
	}
}
