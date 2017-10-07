using System.Collections;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    private Transform target;
    //private float nextAction = 0f;

	private void Start ()
    {
        //nextAction = GetNextActionTime();
        //DoAction();
	}
	
	private void Update ()
    {
        /*
        if (Time.time > nextAction)
        {
            DoAction();
        }
        */
        if (target != null)
            LookAtTarget();
	}

    private void LookAtTarget()
    {
        Vector3 direction = transform.position - target.position;
        direction.y = transform.position.y;

        Quaternion rt = Quaternion.LookRotation(direction);
        Quaternion sRt = Quaternion.Slerp(transform.rotation, rt, Time.deltaTime * 10);
        transform.rotation = sRt;
    }

    private void DoAction()
    {
        /*
        int rand = Random.Range(0, 100);
        nextAction = GetNextActionTime();

        if (rand < 100)
        {
            
        }
        */
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    /*
    private float GetNextActionTime()
    {
        return Time.time + Random.Range(5, 8);
    }
    */
}
