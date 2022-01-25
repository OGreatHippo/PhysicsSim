using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaverCannonball : MonoBehaviour
{
	private Vector3 velocity = new Vector3(15, 15, 0);
	
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
		velocity.y += -9.81f * Time.deltaTime;
		transform.position += velocity * Time.deltaTime;
    }
}
