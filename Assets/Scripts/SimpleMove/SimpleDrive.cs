using UnityEngine;

public class SimpleDrive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public GameObject enemyTarget;
    private float _stoppingDistanceSqr = 4f;
    bool autoPilot = false;

    Vector3 CalculateDistance() // Distance between positions
    {   
        Vector3 enemyTargetPosition = new Vector3(enemyTarget.transform.position.x, 0f, enemyTarget.transform.position.z);
        Vector3 position = new Vector3(transform.position.x, 0f, transform.position.z);

        Vector3 vector = (enemyTargetPosition - position);
        return vector;
        // return Vector3.Distance(enemyTargetPosition, position);
    }

    float CalculateAngle() // Angle Between Vectors
    {
        Vector3 transformForward = transform.forward;
        transformForward.y = 0f; 

        Vector3 enemyTargetPosition = new Vector3(enemyTarget.transform.position.x, 0f, enemyTarget.transform.position.z);
        Vector3 position = new Vector3(transform.position.x, 0f, transform.position.z);
        Vector3 enemyTargetVector = (enemyTargetPosition - position);


        float dot = (transformForward.x * enemyTargetVector.x) + (transformForward.z * enemyTargetVector.z);
        float angle = Mathf.Acos(dot / (transformForward.magnitude * enemyTargetVector.magnitude));

        float degrees = Mathf.Rad2Deg * angle;

        Vector3 crossProduct = Cross(transformForward, enemyTargetVector);
        Debug.Log($"CrossProduct: {crossProduct}");
        int clockwise = 1;

        if (crossProduct.y < 0)
        {
            clockwise = -1;
        }

        return degrees * clockwise;
        // return Vector3.SignedAngle(transformForward, enemyTargetVector, Vector3.up);
    }

    Vector3 Cross(Vector3 v, Vector3 w)
    {
        float crossX = v.y * w.z - v.z * w.y;
        float crossY = v.z * w.x - v.x * w.z;
        float crossZ = v.x * w.y - v.y * w.x;  
        
        return new Vector3(crossX, crossY, crossZ);
    }

    void LateUpdate()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);

        transform.Rotate(0, rotation, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float angle = CalculateAngle();
            transform.Rotate(0, angle, 0);
            autoPilot = !autoPilot;
        }
        

        if (autoPilot)
        {

            Vector3 enemyTargetDistance = CalculateDistance(); 
            Vector3 velocity = enemyTargetDistance.normalized * speed * Time.deltaTime;
            transform.position = transform.position + velocity;
            if (enemyTargetDistance.sqrMagnitude < _stoppingDistanceSqr)
            {
                autoPilot = !autoPilot;
            }
        }
    }
}