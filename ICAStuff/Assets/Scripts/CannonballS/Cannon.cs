using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
	public GameObject Cannonball;
	public GameObject NCannonball;
	// Update is called once per frame
	void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(Cannonball, transform.position, transform.rotation);
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			Instantiate(NCannonball, transform.position, transform.rotation);
		}
	}
}
