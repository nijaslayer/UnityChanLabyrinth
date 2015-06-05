using UnityEngine;
using System.Collections;

namespace UnityChan
{

public class PlayerController : MonoBehaviour {

	Animator anime;
	UnityChanControlScriptWithRgidBody unitychan;


	// Use this for initialization
	void Start () {
		anime = GetComponent<Animator> ();
		unitychan = GetComponent<UnityChanControlScriptWithRgidBody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGoal()
	{
		unitychan.enabled = false;
		anime.SetBool ("Win", true);
	}


}

}
