using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    [Range(5, 20)]
    private float speed = 10;
    [SerializeField]
    private Transform target;
    private Vector3 offset = Vector3.zero;

	private void Start ()
    {
        offset = transform.position - target.position;
	}
	
	private void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * speed);
	}
}
