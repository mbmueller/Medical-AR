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
        Debug.Log(distance);
        if (distance < distanceThreshold) {
            Debug.Log("Reached Target, Go to next");
            nextTarget++;
            return;
        }

        float t = Mathf.InverseLerp(0f, maxDistance, distance);

        Color nextColor = Color.Lerp(intervalEnd, intervalStart, t);
        Debug.Log(nextColor);
        next.GetComponent<Renderer>().material.color = nextColor;
    }
}
