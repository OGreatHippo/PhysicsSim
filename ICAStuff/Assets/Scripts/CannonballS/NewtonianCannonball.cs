using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonianCannonball : MonoBehaviour
{
    private Vector3 velocity = new Vector3(15, 15, 0);
    private Vector3 gravity = new Vector3(0, -9.81f, 0);
    private Vector3 startPos;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.position = startPos + (velocity * time) + gravity * (time * time) / 2;
    }
}
