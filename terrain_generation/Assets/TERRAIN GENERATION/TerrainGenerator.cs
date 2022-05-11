using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
[RequireComponent(typeof(MeshFilter))]
public class TerrainGenerator : MonoBehaviour
{
    public int Resolution;
    Vector3[] Directions => TerrainHelper.GetDirections(Resolution);

    Mesh mesh;

    Vector3[] verticies;
    int[] triangles;

    /*public Vector2Int Size = new Vector2Int(20, 20);

    [Button]
    public void Generate()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }
    void CreateShape()
    {
        verticies = new Vector3[(Size.x + 1) * (Size.y + 1)];

        for (int y = 0; y < Size.y; y++)
        {

        }
    }
    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = verticies;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }*/

    private void OnDrawGizmos()
    {
        Quaternion startRot = transform.rotation;
        for (int i = 0; i < Directions.Length; i++)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawSphere(transform.position - Directions[i], 0.01f);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position - Directions[i], transform.position - Directions[i + 1 >= Directions.Length ? 0 : i + 1]);
        }
        transform.rotation = startRot;
    }
}

public static class TerrainHelper
{
    static Vector3[] Directions = new Vector3[0];

    //this function returns an array of positions, evenly distributed on a sphere
    public static Vector3[] GetDirections(int numViewDirections)
    {
        //for optimalization, we only regenerate this array, when nesesary
        if (Directions.Length != numViewDirections)
        {
            Directions = new Vector3[numViewDirections];

            float goldenRatio = (1 + Mathf.Sqrt(5)) / 2;
            float angleIncrement = Mathf.PI * 2 * goldenRatio;

            for (int i = 0; i < numViewDirections; i++)
            {
                float t = (float)i / numViewDirections;
                float inclination = Mathf.Acos(1 - 2 * t);
                float azimuth = angleIncrement * i;

                float x = Mathf.Sin(inclination) * Mathf.Cos(azimuth);
                float y = Mathf.Sin(inclination) * Mathf.Sin(azimuth);
                float z = Mathf.Cos(inclination);
                Directions[i] = new Vector3(x, y, z);
            }
        }
        return Directions;
    }
}
