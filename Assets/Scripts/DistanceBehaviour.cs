using System;
using UnityEngine;

public class DistanceBehaviour : MonoBehaviour
{
    public GameObject[] targets;
    public Color success = Color.green;
    public Color intervalStart = Color.yellow;
    public Color intervalEnd = Color.blue;
    public float maxDistance = 3f;
    public float distanceThreshold = 0.01f;

    private int nextTarget = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < nextTarget && nextTarget <= targets.Length; i++) {
            targets[i].GetComponent<Renderer>().material.color = success;
        }

        if (nextTarget >= targets.Length || nextTarget < 0) {
            return;
        }

        GameObject next = targets[nextTarget];

        float distance = Vector3.Distance(transform.position, next.transform.position);
        Console.WriteLine(distance);
        if (distance < distanceThreshold) {
            Console.WriteLine("Reached Target, Go to next");
            nextTarget++;
            return;
        }

        float t = Mathf.Clamp01(distance / maxDistance);

        next.GetComponent<Renderer>().material.color = Color.Lerp(intervalStart, intervalEnd, t);
    }
}
