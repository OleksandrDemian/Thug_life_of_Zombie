using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager Instance
    {
        get;
        private set;
    }
    
    private List<EnergyController> energy = new List<EnergyController>();
    private float nextGenerate;
    private bool generate = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (!generate)
            return;

        if (Time.time > nextGenerate)
        {
            Generate();
        }
    }

    private void Generate()
    {
        EnergyController controller = ObjectPool.Get<EnergyController>();
        controller.Initialize();
        controller.transform.position = GetRandomPosition();

        energy.Add(controller);
        nextGenerate = GetNextGenerationTime();
    }

    public void DisableEnergy(EnergyController energy)
    {
        this.energy.Remove(energy);
        ObjectPool.Add(energy);
    }

    private float GetNextGenerationTime()
    {
        return Time.time + Random.Range(3, 8);
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-33, 33);
        float z = Random.Range(-33, 33);
        return new Vector3(x, 25, z);
    }

    public void EnableGenerating(bool action)
    {
        generate = action;
    }

    public void StartGenerating()
    {
        nextGenerate = GetNextGenerationTime();
        generate = true;

        for (int i = 0; i < 7; i++)
        {
            Generate();
        }
    }

    public EnergyController GetRandomEnergy()
    {
        if (energy.Count < 1)
            return null;

        int rand = Random.Range(0, energy.Count);
        return energy[rand];
    }
}