using UnityEngine;

public class SimpleDriveFPS : MonoBehaviour
{
    public float speed = 10.0f;
    public float mouseSensitivity = 100f;
    // public float rotationSpeed = 100f;
    public GameObject enemyTarget;
    private float _stoppingDistanceSqr = 4f;
    bool autoPilot = false;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void LateUpdate()
    {
        // move code
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        // float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        // homing code initiate
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float angle = CalculateAngle();
            transform.Rotate(0, angle, 0);
            autoPilot = !autoPilot;
        }


        // homing code
        if (autoPilot)
        {

            Vector3 enemyTargetDistance = CalculateEnemyDistanceVector();
            Vector3 velocity = enemyTargetDistance.normalized * speed * Time.deltaTime;
            transform.position = transform.position + velocity;
            if (enemyTargetDistance.sqrMagnitude < _stoppingDistanceSqr)
            {
                autoPilot = !autoPilot;
            }
        }
    }

    // homing methods
    Vector3 CalculateEnemyDistanceVector()
    {
        Vector3 enemyTargetPosition = new Vector3(enemyTarget.transform.position.x, 0f, enemyTarget.transform.position.z);
        Vector3 position = new Vector3(transform.position.x, 0f, transform.position.z);

        return enemyTargetPosition - position;
    }

    float CalculateAngle()
    {
        Vector3 transformForward = transform.forward;
        transformForward.y = 0f;

        Vector3 enemyTargetVector = CalculateEnemyDistanceVector();

        return Vector3.SignedAngle(transformForward, enemyTargetVector, Vector3.up);
    }
}