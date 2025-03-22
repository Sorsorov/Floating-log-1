using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floatinglog : MonoBehaviour
{
    public int currentVertex = -1;
    public int previousVertex = -1;
    public float angle = 0;
    public float speed = 2.0f;
    public float maxAngle = 10f;

    void Start()
    {
        ChooseNextVertex();
    }

    void Update()
    {
        angle += speed * Time.deltaTime;
        float rotation = Mathf.Sin(angle) * maxAngle;

        if (currentVertex == 0) transform.rotation = Quaternion.Euler(rotation, 0, 0);
        else if (currentVertex == 1) transform.rotation = Quaternion.Euler(-rotation, 0, 0);
        else if (currentVertex == 2) transform.rotation = Quaternion.Euler(0, 0, rotation);
        else if (currentVertex == 3) transform.rotation = Quaternion.Euler(0, 0, -rotation);
        //G
        else if (currentVertex == 4) transform.rotation = Quaternion.Euler(rotation, 0, rotation);
        else if (currentVertex == 5) transform.rotation = Quaternion.Euler(rotation, 0, -rotation);
        else if (currentVertex == 6) transform.rotation = Quaternion.Euler(-rotation, 0, rotation);
        else if (currentVertex == 7) transform.rotation = Quaternion.Euler(-rotation, 0, -rotation);
        //D
        if (angle >= Mathf.PI)
        {
            angle = 0;
            ChooseNextVertex();
        }
    }

    void ChooseNextVertex()
    {
        do
        {
            currentVertex = Random.Range(0, 8);
        } while (currentVertex == previousVertex);

        previousVertex = currentVertex;
    }
}