  using UnityEngine;

  [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
  public class S03_CustomPolygonMesh_Star : MonoBehaviour
  {
      void Start()
      {
          // TODO 1: 원하는 다각형의 정점 좌표를 채우세요 (최소 4개)
          Vector3[] vertices = new Vector3[]
          {
              new Vector3(0f, 0.7f, 0f), //0
              new Vector3(0.9f, 0f, 0f), //1
              new Vector3(-0.9f, 0f, 0f), //2
              new Vector3(-0.5f, -1f, 0f), //3
              new Vector3(0.5f, -1f, 0f), //4

              new Vector3(-0.5f, 0.5f, 0f), //5
              new Vector3(0.5f, 0.5f, 0f), //6
              new Vector3(-0.2f, -0.5f, 0f), //7
              new Vector3(0.2f, -0.5f, 0f), //8
              new Vector3(0f, -0.5f, 0f), //9
          };

          // TODO 2: 정점 3개씩 묶어 삼각형들을 구성하세요
          int[] triangles = new int[]
          {
              1, 2, 9,
              0, 3, 8,
              0, 7, 4,
          };

          Mesh mesh = new Mesh();
          mesh.vertices = vertices;
          mesh.triangles = triangles;
          mesh.RecalculateNormals();

          GetComponent<MeshFilter>().mesh = mesh;
          GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
      }
  }