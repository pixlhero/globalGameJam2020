using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safetyline : MonoBehaviour
{
    public Rigidbody2D rigi;
    public GameObject chainLinkPrefab;
    public float chainLinkSize = 0.15f;

    static float[] lengths = new float[] { 10, 8, 6 };
    float Length { get { return lengths[PlayerOrganiser.instance.PlayerCount - 1]; } }

    public Rigidbody2D chainEnd;

    void Awake()
    {
        int chainLinkCount = Mathf.RoundToInt(Length / chainLinkSize);

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
