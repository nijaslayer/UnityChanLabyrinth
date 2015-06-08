using UnityEngine;
using System.Collections;

namespace UnityChan
{

public class PlayerController : MonoBehaviour {

	public GameObject unityChan;
	public Camera camera;
	
	Animator anime;
	UnityChanControlScriptWithRgidBody unitychan;


	// Use this for initialization
	void Start () {
		anime = GetComponent<Animator> ();
		unitychan = GetComponent<UnityChanControlScriptWithRgidBody> ();
	}
	
	// Update is called once per frame
	void Update () {

			if (Input.GetKeyDown (KeyCode.Z))
			{
				anime.SetTrigger("Attack");
				anime.SetBool("AttackUnity", true);

				Invoke ("AttackEnd", 0.5F);
			}
	
	}


	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag == "Floor")
		{
				gameObject.transform.SetParent(c.transform);

				for ( int count = 0; count < 50; count++)
				{
					//camera.transform.
				}
		}
	}
	
	void OnGoal()
	{
		unitychan.enabled = false;
		anime.SetBool ("Win", true);
	}


	public void AttackEnd()
	{
		anime.SetBool("AttackUnity", false);
	}



}

}
