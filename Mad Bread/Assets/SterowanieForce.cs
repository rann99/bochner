using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SterowanieForce : MonoBehaviour {

	public float speed = 20f;
	public int turnSpeed = 70;

	private Rigidbody graczrb;
	// Use this for initialization
	void Start () 
	{
		graczrb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void FixedUpdate()
	{

		float horizontal = Input.GetAxis ("Horizontal");
		float veritcal = Input.GetAxis ("Vertical");

		Vector3 ver = new Vector3 (0, -veritcal * speed, 0);
		graczrb.AddRelativeForce (ver);

		transform.Rotate (transform.forward, turnSpeed * Time.deltaTime*horizontal, Space.World);

		Debug.Log (graczrb.velocity.magnitude);

		if (graczrb.velocity.magnitude > 20)
			speed *= -1;
		else
			speed = 20f;
	}
		
}
