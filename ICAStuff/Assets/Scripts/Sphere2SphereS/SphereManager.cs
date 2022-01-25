using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    [SerializeField] private GameObject[] balls;
    private sphere[] spheres;
    //private GameObject[] planes;

    struct sphere
    {
        public Vector3 position;
        public Vector3 speedyboi;
        public float radius;
    }

    // Start is called before the first frame update
    void Start()
    {
        balls = GameObject.FindGameObjectsWithTag("Sphere");
        spheres = new sphere[balls.Length];

        for (int i = 0; i < balls.Length; i++)
        {
            spheres[i].position = balls[i].transform.position;
            spheres[i].speedyboi = balls[i].GetComponent<Velocity>().velocity;
            spheres[i].radius = balls[i].transform.localScale.x / 2;
        }

       // planes = GameObject.FindGameObjectsWithTag("Plane");
    }

    // Update is called once per frame
    void Update()
    {
        SphereCollision();
        PlaneCollision();
    }

    private void SphereCollision()
    {
        float A;
        float B;
        float C;

        float t;
        float sqrt;

        Vector3 deltaV;
        Vector3 deltaP;

        for (int i = 0; i < balls.Length - 1; i++)
        {
            for (int j = i + 1; j < balls.Length; j++)
            {
                Vector3 P1 = balls[i].transform.position;
                Vector3 V1 = balls[i].GetComponent<Velocity>().velocity;

                Vector3 P2 = balls[j].transform.position;
                Vector3 V2 = balls[j].GetComponent<Velocity>().velocity;

                deltaV = (V1 - V2) * Time.deltaTime;
                deltaP = P1 - P2;

                A = (deltaV).sqrMagnitude;
                B = Vector3.Dot(deltaP, deltaV) * 2;
                C = deltaP.sqrMagnitude - ((balls[i].transform.localScale.x + balls[i].transform.localScale.x) * (balls[j].transform.localScale.x + balls[j].transform.localScale.x) / 4);

                if ((B * B) - (4 * (A * C)) < 0)
                {
                    return;
                }

                sqrt = Mathf.Sqrt((B * B) - (4 * (A * C)));

                t = (-B - sqrt) / (2 * A);

                if (t < 1 && t > 0)
                {
                    print("collision");
                    balls[i].GetComponent<Velocity>().velocity *= 0;
                    balls[j].GetComponent<Velocity>().velocity *= 0;
                }
            }
        }
    }

    private void PlaneCollision()
    {
        Vector3 N;
        Vector3 k;
        Vector3 P;
        float q1;
        float q2;
        float angleyballs;

        //for (int i = 0; i < planes.Length; i++)
        //{
        //    N = planes[i].transform.localPosition.normalized;
        //    angleyballs = Vector3.Angle(N, balls[i].GetComponent<velocity>().velocity);
        //    k = planes[i].transform.
        //}

        //if ()
        //{

        //}
    }
}
