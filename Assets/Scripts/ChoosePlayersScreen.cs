using UnityEngine.UI;
using UnityEngine;

public class ChoosePlayersScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject[] players;
    [SerializeField]
    private Toggle[] toggles;
    [SerializeField]
    private Toggle hardCoreMode;

	private void Start ()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(false);
        }
	}

    public void StartGame()
    {
        if (SelectedPlayersCount < 2)
            return;

        int players = this.players.Length;
        int toggles = this.toggles.Length;

        for (int i = 0; i < players || i < toggles; i++)
        {
            this.players[i].SetActive(this.toggles[i].isOn);
        }

        gameObject.SetActive(false);
        GameManager.Instance.SetHardcoreMode(hardCoreMode.isOn);
        GameManager.Instance.StartGame();
    }

    private int SelectedPlayersCount
    {
        get
        {
            int counter = 0;
            for (int i = 0; i < toggles.Length; i++)
            {
                if (toggles[i].isOn)
                    counter++;
            }
            return counter;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
