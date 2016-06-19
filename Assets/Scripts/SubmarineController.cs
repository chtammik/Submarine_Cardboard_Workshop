using UnityEngine;
using System.Collections;

public class SubmarineController : MonoBehaviour {

	//int number = 1;

	public float moveSpeed = 10;
	public float rotateSpeed = 10;

	public GameObject submarine;
	public GameObject gvrCamera;

	public GameObject torpedoPrefab;
	public AudioClip fireSound;

	public Transform leftFirePosition;
	public Transform rightFirePosition;
	public Transform convergencePoint;
	private bool fireLeftTorpedo = true;

	//public AudioClip metalImpact;
	//private AudioSource source;
    //private float lowPitchRange = .75F;
    //private float highPitchRange = 1.5F;

	void Start () {
	
	}

	/*
	 * void Awake () {
		source = GetComponent<AudioSource>();
	}
	*/

	// Update is called once per frame
	void Update () {
		UpdateRotation ();
		UpdateMovement ();
	}

	void UpdateRotation () {
		Quaternion cameraLookRotation = Quaternion.LookRotation(gvrCamera.transform.forward, gvrCamera.transform.up);
		submarine.transform.localRotation = Quaternion.RotateTowards (submarine.transform.rotation, cameraLookRotation, rotateSpeed * Time.deltaTime);
	}

	void UpdateMovement () {
		GetComponent<CharacterController>().Move(submarine.transform.forward * moveSpeed * Time.deltaTime);
	}

	public void FireTorpedo () {
		Vector3 torpedoFirePosistion;
		if (fireLeftTorpedo == true) {
			torpedoFirePosistion = leftFirePosition.position;
			fireLeftTorpedo = false;
		} else {
			torpedoFirePosistion = rightFirePosition.position;
			fireLeftTorpedo = true;
		}
		AudioSource.PlayClipAtPoint (fireSound, torpedoFirePosistion);
		GameObject topedoObject = Instantiate (torpedoPrefab, torpedoFirePosistion, Quaternion.identity) as GameObject;
		topedoObject.transform.forward = (convergencePoint.position - topedoObject.transform.position).normalized;
	}

    /*void OnCollisionEnter (Collision coll)
    {
		source.PlayOneShot(metalImpact);
    }
    */

}
