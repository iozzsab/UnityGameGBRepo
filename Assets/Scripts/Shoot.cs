using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public GameObject bullet;
	public int speed;
	public GameObject bulletExit;


	void Update()
	{		
		if (Input.GetMouseButtonDown(0))
		{
			//anim.SetTrigger("hit");
			GameObject bul = (GameObject)Instantiate(bullet, bulletExit.transform.position, Quaternion.identity);
			bul.gameObject.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * speed;

		}
	}
}
