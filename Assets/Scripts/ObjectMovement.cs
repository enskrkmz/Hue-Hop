using UnityEngine;
public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int rotateDirection;
    void Update()
    {
        transform.Rotate(0, 0, 30 * rotateDirection * rotationSpeed * Time.deltaTime);
    }
}
