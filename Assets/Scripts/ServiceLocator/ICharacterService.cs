using UnityEngine;

public interface ICharactersService
{
    void RegisterPlayerCharacter(GameObject player);
    GameObject GetPlayerCharacter();
}