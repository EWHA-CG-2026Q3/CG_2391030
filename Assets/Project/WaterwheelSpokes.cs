using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class WaterwheelSpokes : MonoBehaviour
{
    public int n = 8; // 바퀴살의 개수
    public float innerRadius = 1f; // 중심축과 닿는 시작 지점
    public float outerRadius = 1.7f; // 테두리와 닿는 끝 지점
    public float thickness = 0.1f; // 바퀴살의 두께
    public float height = 0.2f; // 바퀴살의 폭

    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.name = "Waterwheel_Spokes";

        Vector3[] vertices = new Vector3[n * 8];
        int[] triangles = new int[n * 36];

        for (int i = 0; i < n; i++)
        {
            float angle = (360f / n * i) * Mathf.Deg2Rad;
            float cos = Mathf.Cos(angle);
            float sin = Mathf.Sin(angle);

            int vOffset = i * 8;

            float x0 = innerRadius, x1 = outerRadius;
            float y0 = -height / 2f, y1 = height / 2f;
            float z0 = -thickness / 2f, z1 = thickness / 2f;

            Vector3[] baseVerts = new Vector3[8]
            {
                new Vector3(x0, y0, z0), new Vector3(x1, y0, z0),
                new Vector3(x1, y0, z1), new Vector3(x0, y0, z1),
                new Vector3(x0, y1, z0), new Vector3(x1, y1, z0),
                new Vector3(x1, y1, z1), new Vector3(x0, y1, z1)
            };

            for (int v = 0; v < 8; v++)
            {
                float rx = baseVerts[v].x * cos - baseVerts[v].z * sin;
                float rz = baseVerts[v].x * sin + baseVerts[v].z * cos;
                vertices[vOffset + v] = new Vector3(rx, baseVerts[v].y, rz);
            }

            int tOffset = i * 36;
            int[] boxTris = new int[36]
            {
                0, 4, 1, 1, 4, 5, 
                1, 5, 2, 2, 5, 6, 
                2, 6, 3, 3, 6, 7,
                3, 7, 0, 0, 7, 4,
                4, 7, 5, 5, 7, 6,
                0, 1, 3, 3, 1, 2 
            };

            for (int t = 0; t < 36; t++)
            {
                triangles[tOffset + t] = vOffset + boxTris[t];
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;

    }
}