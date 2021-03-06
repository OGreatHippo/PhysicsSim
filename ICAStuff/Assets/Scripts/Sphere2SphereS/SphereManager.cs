using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    [SerializeField] private GameObject[] balls;
    [SerializeField] private GameObject[] planes;
    [SerializeField] private AudioSource ballhit;

    // Start is called before the first frame update
    void Start()
    {
       balls = GameObject.FindGameObjectsWithTag("Sphere");
       planes = GameObject.FindGameObjectsWithTag("Plane");
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

                if ((B * B) - (4 * (A * C)) > 0)
                {
                    sqrt = Mathf.Sqrt((B * B) - (4 * (A * C)));

                    t = (-B - sqrt) / (2 * A);

                    if (t < 1 && t > 0)
                    {
                        ballhit.Play(1);

                        Vector3 vr = balls[i].GetComponent<Velocity>().velocity - balls[j].GetComponent<Velocity>().velocity;

                        float vj = -(1 + 0.8f) * Vector3.Dot(vr, deltaP.normalized);

                        float m1i = 1 / balls[i].GetComponent<Velocity>().mass;
                        float m2i = 1 / balls[j].GetComponent<Velocity>().mass;

                        float J = vj / (m1i + m2i);

                        balls[i].GetComponent<Velocity>().velocity += m1i * J * deltaP.normalized;
                        balls[j].GetComponent<Velocity>().velocity -= m2i * J * deltaP.normalized;
                    }
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
