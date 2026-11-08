using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class WaterwheelRim : MonoBehaviour
{
    public int n = 24; // 테두리의 각 수
    public float outerRadius = 2f; // 바깥쪽 반지름
    public float innerRadius = 1.7f; // 안쪽 반지름 
    public float thickness = 0.2f; // 나무 판의 두께

    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.name = "Waterwheel_Rim";

        // 1. 정점(Vertices)
        Vector3[] vertices = new Vector3[n * 4];

        for (int i = 0; i < n; i++)
        {
            float angle = (360f / n * i) * Mathf.Deg2Rad;
            float cos = Mathf.Cos(angle);
            float sin = Mathf.Sin(angle);

            float halfThick = thickness / 2f;

            vertices[i] = new Vector3(cos * outerRadius, halfThick, sin * outerRadius);
            vertices[i + n] = new Vector3(cos * innerRadius, halfThick, sin * innerRadius);

            vertices[i + n * 2] = new Vector3(cos * outerRadius, -halfThick, sin * outerRadius);
            vertices[i + n * 3] = new Vector3(cos * innerRadius, -halfThick, sin * innerRadius);
        }

        // 2. 삼각형(Triangles)
        int[] triangles = new int[n * 24];

        for (int i = 0; i < n; i++)
        {
            int next = (i + 1) % n;

            int outTop = i, nextOutTop = next;
            int inTop = i + n, nextInTop = next + n;
            int outBot = i + n * 2, nextOutBot = next + n * 2;
            int inBot = i + n * 3, nextInBot = next + n * 3;

            int offset = i * 24;

            triangles[offset + 0] = outTop; triangles[offset + 1] = nextOutTop; triangles[offset + 2] = inTop;
            triangles[offset + 3] = nextOutTop; triangles[offset + 4] = nextInTop; triangles[offset + 5] = inTop;

            triangles[offset + 6] = outBot; triangles[offset + 7] = inBot; triangles[offset + 8] = nextOutBot;
            triangles[offset + 9] = nextOutBot; triangles[offset + 10] = inBot; triangles[offset + 11] = nextInBot;

            triangles[offset + 12] = outTop; triangles[offset + 13] = outBot; triangles[offset + 14] = nextOutTop;
            triangles[offset + 15] = nextOutTop; triangles[offset + 16] = outBot; triangles[offset + 17] = nextOutBot;

            triangles[offset + 18] = inTop; triangles[offset + 19] = nextInTop; triangles[offset + 20] = inBot;
            triangles[offset + 21] = nextInTop; triangles[offset + 22] = nextInBot; triangles[offset + 23] = inBot;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;

    }
}