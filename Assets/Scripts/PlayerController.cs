using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
public class PlayerController : MonoBehaviour
{
    private Controller controller;
    [SerializeField]
    private List<KeyCode> keys = new List<KeyCode>();

    private float shuffleTime = 0;

    private void Start()
    {
        controller = GetComponent<Controller>();
        //ShuffleKeys();
    }

    private void Update()
    {
        if (Time.time > shuffleTime)
        {
            ShuffleKeys();
        }
        Control();
    }

    private void Control()
    {
        int horizontal = 0;
        int vertical = 0;

        if (Input.GetKey(keys[0]))
        {
            horizontal -= 1;
        }
        if (Input.GetKey(keys[1]))
        {
            horizontal += 1;
        }
        if (Input.GetKey(keys[2]))
        {
            vertical += 1;
        }
        if (Input.GetKey(keys[3]))
        {
            vertical -= 1;
        }
        controller.Move(horizontal, vertical);
    }

    private void ShuffleKeys()
    {
        if (!GameManager.Instance.IsHardCore())
        {
            shuffleTime = Mathf.Infinity;
            return;
        }

        Debug.Log(name + ": shuffling keys!");
        int count = keys.Count;
        for (int i = 0; i < count; i++)
        {
            int rand = Random.Range(0, count);
            KeyCode temp = keys[rand];
            keys[rand] = keys[i];
            keys[i] = temp;
        }
        shuffleTime = GetNextShuffleTime();
    }

    public Controller GetController()
    {
        return controller;
    }

    private float GetNextShuffleTime()
    {
        return Time.time + Random.Range(10, 20);
    }
}
