using UnityEngine;

public class EnergyController : MonoBehaviour, IPoolable
{
    private int amount;

    public GameObject GetGameObject
    {
        get
        {
            return gameObject;
        }
    }
	
	private void Update ()
    {
        //transform.Rotate(Vector3.up * Time.deltaTime * 50, Space.World);
	}

    public void Initialize()
    {
        amount = Random.Range(1, 6);                            //max 5
        Material mat = GetComponent<Renderer>().material;
        Color cur = mat.color;
        float colorMod = amount / 10f;
        cur.r = .5f + colorMod;
        mat.color = cur;
    }

    public void Interact(Controller controller)
    {
        controller.Energy.IncrementEnergy(5);
        EnergyManager.Instance.DisableEnergy(this);
    }
}
