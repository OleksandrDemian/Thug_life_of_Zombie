using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    private Text winnerText;

    public static GameOverPanel Instance
    {
        get;
        private set;
    }

	private void Awake ()
    {
        Instance = this;
        gameObject.SetActive(false);
	}

    public void ShowWinner(string name)
    {
        if (gameObject.activeInHierarchy)
            return;

        winnerText.text = "Winner is: " + name;
        switch (name.ToLower())
        {
            case "blue":
                winnerText.color = new Color(25/255f, 120/255f, 1, 1);
                break;
            case "red":
                winnerText.color = new Color(1, 25/255f, 60/255f, 1);
                break;
            case "green":
                winnerText.color = new Color(25/255f, 1, 120/255f, 1);
                break;
            case "yellow":
                winnerText.color = new Color(1, 1, 25/255f, 1);
                break;
            default:
                float value = 150f / 255f;
                winnerText.color = new Color(value, value, value, 1);
                break;
        }
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
