using UnityEngine;

public class CarmeraMovement : MonoBehaviour
{
    [SerializeField] private Transform ballPos;
    [SerializeField] private float transformTime = 5f;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - ballPos.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Slerp(transform.position,ballPos.position + offset, Time.deltaTime * transformTime);
    }

}
