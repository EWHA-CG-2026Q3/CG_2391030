using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class WaterwheelPaddles : MonoBehaviour
{
    public int n = 12; // 물받이 판의 개수
    public float innerRadius = 1.5f; // 테두리 안쪽부터 시작
    public float outerRadius = 2.3f; // 테두리 바깥으로 삐져나오는 길이
    public float width = 1.2f; // 물받이 판의 폭
    public float thickness = 0.05f; // 나무 판자의 두께

    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.name = "Waterwheel_Paddles";

        Vector3[] vertices = new Vector3[n * 8];
        int[] triangles = new int[n * 36];

        for (int i = 0; i < n; i++)
        {
            float angle = (360f / n * i) * Mathf.Deg2Rad;
            float cos = Mathf.Cos(angle);
            float sin = Mathf.Sin(angle);

            int vOffset = i * 8;

            float x0 = innerRadius, x1 = outerRadius;
            float y0 = -width / 2f, y1 = width / 2f;
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