using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        Instance = this;
    }
    
    private void Start () {
		
	}
}
