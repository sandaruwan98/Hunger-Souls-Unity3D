using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChangingGunSystem;

public class ArmoredBox : MonoBehaviour
{

	public float posY = 1f;
	public float startY = 0f;
    public int value = 40;
    public gun gunobj;


	private bool Up = true;
	private bool Down = false;

	void Start ()
	{

		startY = this.transform.position.y;

	}

	void OnTriggerEnter (Collider PlayerCollision)
	{

		if (PlayerCollision.gameObject.tag.Equals ("Player")) {


            gunobj.totalBullts = value;
            gunobj.DisplayBulletCount();
			Destroy (this.gameObject);

		}


	}

	void FixedUpdate ()
	{

		this.transform.Rotate (0f, 30f * Time.deltaTime, 0f);

		if (Up) {

			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + posY * Time.deltaTime, this.transform.position.z); 

			if (this.transform.position.y >= (startY + posY)) {

				Up = false;
				Down = true;
			}

		}

		if (Down) {

			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - posY * Time.deltaTime, this.transform.position.z); 

			if (this.transform.position.y <= startY) {
				Up = true;
				Down = false;

			}

		}

	}

}
