using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class WaterwheelCylinder : MonoBehaviour
{
    public int n = 16;
    public float radius = 0.5f;
    public float height = 1f;

    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.name = "Waterwheel_Axis_Closed";

        // 1. Á¤Á¡(Vertices)
        Vector3[] vertices = new Vector3[n * 2 + 2];

        for (int i = 0; i < n; i++)
        {
            float angle = (360f / n * i) * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            vertices[i] = new Vector3(x, height / 2f, z);
            vertices[i + n] = new Vector3(x, -height / 2f, z);
        }

        int topCenter = n * 2;
        int bottomCenter = n * 2 + 1;
        vertices[topCenter] = new Vector3(0, height / 2f, 0);
        vertices[bottomCenter] = new Vector3(0, -height / 2f, 0);

        // 2. »ï°¢Çü(Triangles) 
        int[] triangles = new int[n * 12];

        for (int i = 0; i < n; i++)
        {
            int next = (i + 1) % n;

            int currentTop = i;
            int nextTop = next;
            int currentBottom = i + n;
            int nextBottom = next + n;

            triangles[i * 12 + 0] = currentTop;
            triangles[i * 12 + 1] = nextTop; 
            triangles[i * 12 + 2] = currentBottom;

            triangles[i * 12 + 3] = nextTop;
            triangles[i * 12 + 4] = nextBottom; 
            triangles[i * 12 + 5] = currentBottom;

            triangles[i * 12 + 6] = topCenter;
            triangles[i * 12 + 7] = nextTop;
            triangles[i * 12 + 8] = currentTop;

            triangles[i * 12 + 9] = bottomCenter;
            triangles[i * 12 + 10] = currentBottom;
            triangles[i * 12 + 11] = nextBottom;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;

    }
}