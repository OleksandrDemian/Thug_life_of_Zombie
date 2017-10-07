using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get;
        private set;
    }

    private bool isHardcore = false;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        PlayersManager.Instance.FindPlayers();
        InitializeHumans();
        EnergyManager.Instance.StartGenerating();
    }

    private void InitializeHumans()
    {
        HumanController[] humans = FindObjectsOfType<HumanController>();
        int qty = humans.Length;
        PlayersManager manager = PlayersManager.Instance;

        for (int i = 0; i < qty; i++)
        {
            humans[i].SetTarget(manager.GetRandom().transform);
        }
    }

    public void GameOver(Controller winner)
    {
        EnergyManager.Instance.EnableGenerating(false);
        string toShow = (winner == null ? "solidarity" : winner.name);
        GameOverPanel.Instance.ShowWinner(toShow);
    }

    public void SetHardcoreMode(bool action)
    {
        isHardcore = action;
    }

    public bool IsHardCore()
    {
        return isHardcore;
    }
}
