using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRamp : MonoBehaviour
{
    [SerializeField] float jumpForce;
    Vector3 addForceVec;
    float cubeHeight = 0.50f;
    Mesh mesh;
    Vector3[] vertices;

    void Start()
    {
        addForceVec = transform.up;

        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;

        if (vertices[0].y < 0)
        {
            vertices[0].y = -vertices[0].y;
        }

        cubeHeight = vertices[0].y;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint[] contact = new ContactPoint[10];
            int numContacts = collision.GetContacts(contact);
            Vector3[] worldHitPosition = new Vector3[numContacts];
            Vector3 localHitPosition;

            for (int i = 0; i < numContacts; i++)
            {
                worldHitPosition[i] = contact[i].point;
            }

            localHitPosition = transform.InverseTransformPoint(worldHitPosition[0]);

            if (localHitPosition.y >= cubeHeight - 0.01f)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(addForceVec.normalized * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
