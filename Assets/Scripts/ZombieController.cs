using UnityEngine;

[RequireComponent(typeof(Controller))]
public class ZombieController : MonoBehaviour
{
    private Controller controller;
    private Vector3 targetPosition;

    private float nextUpdate = 0f;

    private void Start ()
    {
        controller = GetComponent<Controller>();
        UpdateBehaviour();
	}
	
	private void Update ()
    {
        if (Time.time > nextUpdate)
        {
            UpdateBehaviour();
        }
        Move();
	}

    private void FixedUpdate()
    {
        
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, targetPosition) < .2f)
            return;

        float x = targetPosition.x - transform.position.x;
        float z = targetPosition.z - transform.position.z;
        controller.Move(x, z);
    }

    private void UpdateBehaviour()
    {
        int rand = Random.Range(0, 100);

        if (rand < 15)
        {
            Vector3 pos = GetRandomPosition();
            targetPosition.Set(pos.x, transform.position.y, pos.z);
        }
        else if (rand < 85)
        {
            EnergyController controller = EnergyManager.Instance.GetRandomEnergy();
            Vector3 pos = (controller == null ? transform.position : controller.transform.position);
            
            targetPosition.Set(pos.x, transform.position.y, pos.z);
        }
        else
        {
            targetPosition = transform.position;
        }

        nextUpdate = GetNextUpdateTime();
    }

    private float GetNextUpdateTime()
    {
        return Time.time + Random.Range(3, 7);
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-30, 30);
        float z = Random.Range(-30, 30);
        return new Vector3(x, 1, z);
    }
}
