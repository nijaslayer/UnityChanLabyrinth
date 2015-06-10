using UnityEngine;
using System.Collections;

namespace UnityChan
{

public class PlayerController : MonoBehaviour {

	public GameObject unityChan;
	public Camera camera;

	public GameObject hitEffect;

	public Animator ownAnimator;
	
	public static bool AnimationOn { get; set; }


	
	Animator anime;
	UnityChanControlScriptWithRgidBody unitychan;

	bool startGame = false;


	bool attackOn = false;


	// Use this for initialization
	void Start () {
		ownAnimator = GetComponent<Animator> ();

		AnimationOn = true;

		anime = GetComponent<Animator> ();
		unitychan = GetComponent<UnityChanControlScriptWithRgidBody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (AnimationOn == false)
		{
			if (Input.GetKeyDown (KeyCode.Z)) 
			{
				AnimationOn = true;

				attackOn = true;

				
				anime.SetTrigger("Attack");

				Invoke ("AttackEnd", 0.5F);
			}
		}
	
	}




	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag == "Enemy")
		{
			print ("おい");
		}


		if (startGame == false)
		{
			if (c.gameObject.tag == "Floor")
			{
				gameObject.transform.SetParent(c.transform);


				startGame = true;
				AnimationOn = false;
				StartCoroutine("RollCamera");
				
				//camera.transform.localRotation.y = camera.transform.localRotation.y + 175;
				//camera.transform.LookAt(unityChan.transform);
			}
		}
	}

	IEnumerator OnCollisionStay(Collision c)
	{
		if (( c.gameObject.tag == "Enemy") && (attackOn == true) )
		{
				//CancelInvoke ();

				attackOn = false;

				yield return new WaitForSeconds(0.3F);
				c.gameObject.GetComponent<EnemyControlloer>().DeathEnemy();

				Vector3 cCenter = new Vector3(c.transform.position.x, c.transform.position.y + 1, c.transform.position.z);
				GameObject hit = Instantiate(hitEffect, cCenter, c.transform.rotation) as GameObject;

				yield return new WaitForSeconds(0.1F);

				//animation stop
				//particle
				hit.transform.GetComponent<ParticleSystem>().Pause ();
				//enemy
				c.transform.GetComponent<Animator>().enabled = false;
				c.transform.GetComponent<SpringManager>().enabled = false;
				c.transform.GetComponent<FaceUpdate>().enabled = false;
				//plagyer
				GetComponent<Animator> ().enabled = false;
				GetComponent<SpringManager>().enabled = false;
				GetComponent<FaceUpdate>().enabled = false;

				//save
				Vector3 originCameraPos = camera.transform.localPosition;

				//one camera
				camera.transform.localPosition = new Vector3(-0.8F, 0.5F, 1F);
				camera.transform.LookAt (unityChan.transform);

				yield return new WaitForSeconds(0.5F);

				//two camera
				camera.transform.localPosition = new Vector3(0.8F, 2, -0.5F);
				camera.transform.LookAt (unityChan.transform);


				yield return new WaitForSeconds(0.5F);
				
				//two camera
				camera.transform.localPosition = new Vector3(-1.5F, 0.5F, -0.2F);
				camera.transform.LookAt (unityChan.transform);
				camera.transform.localPosition = new Vector3(-1F, 0.5F, 0.1F);

				yield return new WaitForSeconds(0.5F);

				//animation stop
				//particle
				hit.transform.GetComponent<ParticleSystem>().Play ();
				//enemy
				c.transform.GetComponent<Animator>().enabled = true;
				c.transform.GetComponent<SpringManager>().enabled = true;
				c.transform.GetComponent<FaceUpdate>().enabled = true;
				//plagyer
				GetComponent<Animator> ().enabled = true;
				GetComponent<SpringManager>().enabled = true;
				GetComponent<FaceUpdate>().enabled = true;

				//four camera
				camera.transform.localPosition = new Vector3(0.8F, 0.5F, 1F);
				camera.transform.LookAt (unityChan.transform);
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

		for (int count = 0; count < 10; count++)
		{
			camera.transform.Translate(0, 0.1F, 0);
			camera.transform.Translate(0, 0, -0.1F);
			camera.transform.LookAt (unityChan.transform);
			yield return new WaitForSeconds (0.01F);
		}
	}

	
	//Attack aniamtion
	void AttackEnd()
	{

		attackOn = false;
		anime.SetTrigger ("ToLocomotion");
		Invoke ("ActionEnd", 0.3F);
	}
	void ActionEnd()
	{
		AnimationOn = false;
	}


	void OnGoal()
	{
		//unitychan.enabled = false;
		//anime.SetBool ("Win", true);
	}






}

}
