using UnityEngine;

public class ServicesStarter : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void Start()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player"); //Would this be a correct use? Meanwhile I assigned it manually to avoid using fondGameObject
        if (player != null)
        {
            PlayerService playerService = new PlayerService(player);
            ServiceLocator.Register<PlayerService>(playerService);
            Debug.Log("PlayerService registered successfully.");
        }
        else
        {
            Debug.LogError("Player GameObject not found! Make sure there is a GameObject tagged as 'Player' in the scene.");
        }
    }
}