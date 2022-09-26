using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public GameObject bullet;
	public int speed;
	public GameObject bulletExit;

	public GameObject mine;
	public int mineSpeed;
    public GameObject mineExit;



    void Update()
	{		
		if (Input.GetMouseButtonDown(0))
		{
			//anim.SetTrigger("hit");
			GameObject bul = (GameObject)Instantiate(bullet, bulletExit.transform.position, Quaternion.identity);
			bul.gameObject.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * speed;
		}

        RaycastHit hitInfo;

		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, 100))
		{

			if (Input.GetKeyDown(KeyCode.E))
			{
                GameObject min = Instantiate(mine, transform.position + Vector3.Normalize(hitInfo.point - transform.position), transform.rotation);
                Rigidbody rig = min.GetComponentInChildren<Rigidbody>();
                rig.velocity = Vector3.Normalize(hitInfo.point - transform.position) * mineSpeed;

            }
		}
	}
}
