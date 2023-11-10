using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class DieselGeneratorMesh : MonoBehaviour
{
    void Start()
    {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        // Define vertices
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-1, -1, -1),
            new Vector3(1, -1, -1),
            new Vector3(1, 1, -1),
            new Vector3(-1, 1, -1),
            new Vector3(-1, -1, 1),
            new Vector3(1, -1, 1),
            new Vector3(1, 1, 1),
            new Vector3(-1, 1, 1),
        };

        // Define triangles
        int[] triangles = new int[]
        {
            0, 2, 1,
            0, 3, 2,
            4, 5, 6,
            4, 6, 7,
            0, 1, 5,
            0, 5, 4,
            2, 3, 7,
            2, 7, 6,
            0, 4, 7,
            0, 7, 3,
            1, 2, 6,
            1, 6, 5,
        };

        // Define normals (optional)
        Vector3[] normals = new Vector3[]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            Vector3.forward,
            Vector3.forward,
            Vector3.forward,
            Vector3.forward,
        };

        // Define UV coordinates (optional)
        Vector2[] uv = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),
        };

        // Assign the data to the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        // Set up material (you may need to adjust this based on your project)
        meshRenderer.material = new Material(Shader.Find("Standard"));
    }
}