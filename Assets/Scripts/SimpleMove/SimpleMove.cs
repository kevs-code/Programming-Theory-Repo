using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    [field: SerializeField] public GameObject Goal { get; private set; }
    [field: SerializeField] public float Speed { get; private set; } = 5f;
    private float _stoppingDistanceSqr = 4f;
    private Vector3 _direction;



    void LateUpdate()
    {
        _direction = Goal.transform.position - transform.position;
        transform.LookAt(Goal.transform.position);

        if (_direction.sqrMagnitude > _stoppingDistanceSqr)
        {
            Vector3 velocity = _direction.normalized * Speed * Time.deltaTime;
            transform.position = transform.position + velocity;
        }
    }
}
