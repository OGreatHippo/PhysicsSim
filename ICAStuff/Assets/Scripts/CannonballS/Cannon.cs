using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
	[SerializeField] private GameObject Cannonball;
	[SerializeField] private GameObject NCannonball;
	[SerializeField] private AudioSource cannon;

	// Update is called once per frame
	void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
		{
			cannon.Play(1);
			Instantiate(Cannonball, transform.position, transform.rotation);
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			cannon.Play(1);
			Instantiate(NCannonball, transform.position, transform.rotation);
		}
	}
}
