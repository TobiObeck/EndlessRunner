using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGround : MonoBehaviour
{
    public Transform prefab;
    public int numberOfObjects;
    public float recycleOffset;
    public Vector3 startPosition;
    private Vector3 nextPosition;
    private Queue<Transform> objectQueue;

    void Start()
    {
        objectQueue = new Queue<Transform>(numberOfObjects);
        nextPosition = startPosition;
        for (int i = 0; i < numberOfObjects; i++)
        {
            Transform o = (Transform)Instantiate(prefab);

            this.lineUpAtBack(o);
        }
    }

    void Update()
    {
        if (objectQueue.Peek().localPosition.x + recycleOffset < Runner.distanceTraveled)
        {
            Transform o = objectQueue.Dequeue();

            this.lineUpAtBack(o);
        }
    }

    void lineUpAtBack(Transform o)
    {
        o.localPosition = nextPosition;
        nextPosition.x += o.localScale.x;
        objectQueue.Enqueue(o);
    }    
}
