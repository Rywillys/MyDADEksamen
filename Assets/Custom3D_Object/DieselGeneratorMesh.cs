using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class FrustumMesh : MonoBehaviour
{
    public float nearClipDistance = 1f;
    public float farClipDistance = 10f;
    public float fieldOfView = 60f;
    public float aspectRatio = 16 / 9f;

    void Start()
    {
        CreateFrustumMesh();
    }

    void CreateFrustumMesh()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        float nearHeight = 2 * Mathf.Tan(fieldOfView * 0.5f * Mathf.Deg2Rad) * nearClipDistance;
        float farHeight = 2 * Mathf.Tan(fieldOfView * 0.5f * Mathf.Deg2Rad) * farClipDistance;

        Vector3[] vertices = new Vector3[8];

        vertices[0] = new Vector3(-nearHeight * 0.5f * aspectRatio, nearHeight * 0.5f, nearClipDistance);
        vertices[1] = new Vector3(nearHeight * 0.5f * aspectRatio, nearHeight * 0.5f, nearClipDistance);
        vertices[2] = new Vector3(nearHeight * 0.5f * aspectRatio, -nearHeight * 0.5f, nearClipDistance);
        vertices[3] = new Vector3(-nearHeight * 0.5f * aspectRatio, -nearHeight * 0.5f, nearClipDistance);

        vertices[4] = new Vector3(-farHeight * 0.5f * aspectRatio, farHeight * 0.5f, farClipDistance);
        vertices[5] = new Vector3(farHeight * 0.5f * aspectRatio, farHeight * 0.5f, farClipDistance);
        vertices[6] = new Vector3(farHeight * 0.5f * aspectRatio, -farHeight * 0.5f, farClipDistance);
        vertices[7] = new Vector3(-farHeight * 0.5f * aspectRatio, -farHeight * 0.5f, farClipDistance);

        int[] triangles = {
            0, 1, 2, 2, 3, 0, // Near plane
            4, 5, 6, 6, 7, 4, // Far plane
            0, 4, 7, 7, 3, 0, // Left side
            1, 5, 6, 6, 2, 1  // Right side
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}