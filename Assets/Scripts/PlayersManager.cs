using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public static PlayersManager Instance
    {
        get;
        private set;
    }

    private PlayerController[] players;

    private void Awake()
    {
        Instance = this;
    }

	private void Start ()
    {
        
	}
	
	private void Update ()
    {
		
	}

    public void PlayerDeath(Controller player)
    {
        if (AlivePlayersCount < 2)
        {
            GameManager.Instance.GameOver(GetWinner());
        }
    }

    public void FindPlayers()
    {
        players = FindObjectsOfType<PlayerController>();
        Debug.Log("Players: " + players.Length);
    }

    private Controller GetWinner()
    {
        int count = players.Length;
        for (int i = 0; i < count; i++)
        {
            if (players[i].gameObject.activeInHierarchy)
            {
                return players[i].GetController();
            }
        }
        return null;
    }

    public PlayerController GetRandom()
    {
        int rand = Random.Range(0, players.Length);
        return players[rand];
    }

    private int AlivePlayersCount
    {
        get
        {
            int total = players.Length;
            int alive = 0;

            for (int i = 0; i < total; i++)
            {
                if (players[i].gameObject.activeInHierarchy)
                    alive++;
            }
            return alive;
        }
    }
}
