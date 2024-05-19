using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(yAngle: gameObject.transform.position.y * _speed * Time.deltaTime, xAngle: 0, zAngle: 0);
    }
}