using UnityEngine;
using System.Collections;

namespace UnityChan
{

public class PlayerController : MonoBehaviour {

	public GameObject unityChan;
	public Camera camera;
	
	Animator anime;
	UnityChanControlScriptWithRgidBody unitychan;

		bool startGame = false;


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

			if (startGame == false)
			{
				startGame = true;

				StartCoroutine("RollCamera");
				
				//camera.transform.localRotation.y = camera.transform.localRotation.y + 175;
				//camera.transform.LookAt(unityChan.transform);


			}
		}
	}

	IEnumerator RollCamera()
	{
		for (int count = 0; count < 40; count++)
		{
			camera.transform.localPosition = new Vector3 (camera.transform.localPosition.x + ((20 - count) * 0.003F),
				                                             camera.transform.localPosition.y,
				                                             camera.transform.localPosition.z - (40 - Mathf.Abs (20 - count)) * 0.003F);

			camera.transform.LookAt (unityChan.transform);
			yield return new WaitForSeconds (0.01F);
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
