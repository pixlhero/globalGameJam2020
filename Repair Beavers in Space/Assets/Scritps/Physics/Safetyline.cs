using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safetyline : MonoBehaviour
{
    public Rigidbody2D rigi;
    public GameObject chainLinkPrefab;
    public float chainLinkSize = 0.15f;

    public float length = 3;

    public Rigidbody2D chainEnd;

    void Awake()
    {
        int chainLinkCount = Mathf.RoundToInt(length / chainLinkSize);

        GameObject firstLink = Instantiate(chainLinkPrefab, transform.position, Quaternion.identity, transform);
        DistanceJoint2D joint = firstLink.GetComponent<DistanceJoint2D>();

        joint.connectedBody = rigi;
        joint.distance = chainLinkSize;

        Rigidbody2D priorJointRigidbody = firstLink.GetComponent<Rigidbody2D>();

        for (int i = 1; i < chainLinkCount; i++)
        {
            GameObject link = Instantiate(chainLinkPrefab, transform.position, Quaternion.identity, transform);
            joint = link.GetComponent<DistanceJoint2D>();

            joint.connectedBody = priorJointRigidbody;
            joint.distance = chainLinkSize;

            priorJointRigidbody = link.GetComponent<Rigidbody2D>();
        }

        chainEnd = priorJointRigidbody;
    }
}
