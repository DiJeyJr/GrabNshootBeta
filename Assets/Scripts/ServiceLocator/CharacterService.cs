using UnityEngine;

public class CharactersService : ICharactersService
{
    private GameObject player;

    public void RegisterPlayerCharacter(GameObject player)
    {
        this.player = player;
    }

    public GameObject GetPlayerCharacter()
    {
        return player;
    }
}