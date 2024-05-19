using UnityEngine;

public class PlaneDeformer : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _amplitude = 0.2f;

    [SerializeField] private Vector3[] _vertices;
    private Mesh _mesh;

    private void Awake()
    {
        _mesh = GetComponent<MeshFilter>().mesh;
        _vertices = _mesh.vertices;
    }

    private void FixedUpdate()
    {
        Deform();
    }

    private void Deform()
    {
        for (int i = 0; i < _vertices.Length; i++)
        {
            Vector3 position = _vertices[i];
            position.y = Displacement(position, Time.time, _speed, _amplitude);
            _vertices[i] = position;
        }
        _mesh.MarkDynamic(); // надо использовать до SetVertices!!!!
        _mesh.SetVertices(_vertices);
        _mesh.RecalculateNormals();
        _mesh.RecalculateBounds();
    }

    private float Displacement(Vector3 position, float time, float speed, float amplitude)
    {
        var distance = 6f - Vector3.Distance(position, Vector3.zero);
        return Mathf.Sin(time * speed + distance) * amplitude;
    }
}