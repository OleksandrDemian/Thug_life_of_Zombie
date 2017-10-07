public delegate void OnEnergyValueChange(float value);

public class Energy
{
    private float value;
    private float maxValue;

    private OnEnergyValueChange onEnergyValueChange;

    public Energy(float value, float maxValue, OnEnergyValueChange onEnergyValueChange)
    {
        this.onEnergyValueChange = onEnergyValueChange;
        this.value = value;
        this.maxValue = maxValue;
    }

    public float Value
    {
        get
        {
            return value;
        }
    }

    public float GetPercents()
    {
        return value / maxValue;
    }

    public void IncrementEnergy(float amount)
    {
        value += amount;
        if (value > maxValue)
            value = maxValue;

        onEnergyValueChange(value);
    }

    public void ConsumeEnergy(float amount)
    {
        value -= amount;
        onEnergyValueChange(value);
    }
}