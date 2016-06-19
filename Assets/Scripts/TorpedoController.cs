using UnityEngine;
using System.Collections;

public class TorpedoController : MonoBehaviour {

	public float torpedoSpeed;
	public float destroyDelay;
	private float totalTime;

	void Start () {
		totalTime = 0;
		GetComponent<Rigidbody> ().AddForce (transform.forward * torpedoSpeed);
	}

	void Update () {
		totalTime = totalTime + Time.deltaTime;
		if (totalTime > destroyDelay) {
			Destroy (this.gameObject);
		}
	}
}
