using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    private static int startEnergy = 7;
    private static int maxEnergy = 10;

    [SerializeField]
    [Range(5, 20)]
    private float speed = 10;
    private CharacterController controller;
    private Vector3 targetDirection = Vector3.zero;

    [SerializeField]
    private Image energyIndicator;
    //private SpriteRenderer energyIndicator;

    private Energy energy;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        energy = new Energy(startEnergy, maxEnergy, EnergyListener);
        //energyIndicator = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        energy.ConsumeEnergy(Time.deltaTime);
    }

    public void Move(float h, float v)
    {
        if (h == 0 && v == 0)
            return;

        //Movement
        targetDirection.Set(h, 0, v);
        targetDirection.Normalize();
        controller.Move(targetDirection * Time.deltaTime * speed);
        //rb.MovePosition(transform.position + (targetDirection * Time.deltaTime * speed));

        //Rotation
        Quaternion rt = Quaternion.LookRotation(targetDirection);
        Quaternion sRt = Quaternion.Slerp(transform.rotation, rt, Time.deltaTime * 10);
        transform.rotation = sRt;
    }

    public Energy Energy
    {
        get
        {
            return energy;
        }
    }

    private void EnergyListener(float value)
    {
        if (value < 0)
        {
            gameObject.SetActive(false);
            PlayersManager.Instance.PlayerDeath(this);
            return;
        }

        //Color temp = energyIndicator.color;
        //temp.a = energy.GetPercents();
        //energyIndicator.color = temp;
        energyIndicator.fillAmount = energy.GetPercents();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        EnergyController ec = hit.gameObject.GetComponent<EnergyController>();
        if(ec != null)
            ec.Interact(this);
    }
}
