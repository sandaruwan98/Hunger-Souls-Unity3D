using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{


	public float posY = 1f;
	public float startY = 0f;

	private bool Up = true;
	private bool Down = false;

	void Start ()
	{

		startY = transform.position.y;

	}


	void OnTriggerEnter (Collider PlayerCollision)
	{
	
		if (PlayerCollision.gameObject.tag.Equals ("Player")) {
		
			PlayerStat plHealth = PlayerCollision.gameObject.GetComponent<PlayerStat> ();
            plHealth.getMediPack(40);
            Destroy (this.gameObject);
        }


	}

	void FixedUpdate ()
	{

		transform.Rotate (0f, 30f * Time.deltaTime, 0f);

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
