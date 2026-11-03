using UnityEngine;
public class CameraSettings : MonoBehaviour
{
    [SerializeField] private Transform ballPos;
    [SerializeField] private float camSpeed;
    private void LateUpdate()
    {

        Vector3 newCamPos = Vector3.Lerp(transform.position, ballPos.transform.position, camSpeed * Time.deltaTime);
        if (transform.position.y < newCamPos.y)
        {
            transform.position = new Vector3(transform.position.x, newCamPos.y, transform.position.z);
        }
    }
}
