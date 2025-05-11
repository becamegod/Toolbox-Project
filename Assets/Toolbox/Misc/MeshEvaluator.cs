using UnityEngine;

public class MeshEvaluator : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter;

    [Header("Vertex")]
    [SerializeField] Color vertexColor = Color.white;
    [SerializeField] float vertexRadius = .1f;

    [Header("Normal")]
    [SerializeField] Color normalColor = Color.green;
    [SerializeField] float normalLength = .5f;

    [Header("Tangent")]
    [SerializeField] Color tangentColor = Color.blue;
    [SerializeField] float tangentLength = .25f;

    [Header("Readonly values")]
    [SerializeField, ReadOnly] int vertexCount;
    [SerializeField, ReadOnly] int triangleCount;

    private Mesh mesh;

    private void Reset() => meshFilter = GetComponent<MeshFilter>();

    private void Start()
    {
        mesh = meshFilter.mesh;
        vertexCount = mesh.vertexCount;
        triangleCount = mesh.triangles.Length;
    }

    private void OnDrawGizmosSelected()
    {
        if (!mesh) return;
        for (int i = 0; i < mesh.vertexCount; i++)
        {
            // vertex
            var vertex = mesh.vertices[i];
            Gizmos.color = vertexColor;
            Gizmos.DrawSphere(vertex, vertexRadius);

            // normal
            var normal = mesh.normals[i];
            Gizmos.color = normalColor;
            Gizmos.DrawLine(vertex, vertex + normal * normalLength);

            // tangent
            var tangent4 = mesh.tangents[i];
            var tangent = new Vector3(tangent4.x, tangent4.y, tangent4.z);
            //if (tangent4.w != 1) Debug.LogWarning($"Tangent {i} w = {tangent4.w}");
            Gizmos.color = tangentColor;
            Gizmos.DrawLine(vertex, vertex + tangent * tangentLength);
        }
    }
}
