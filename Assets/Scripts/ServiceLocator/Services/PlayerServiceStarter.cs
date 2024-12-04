using UnityEngine;

public class PlayerServiceStarter : MonoBehaviour
{
    private void Start()
    {
        // Register CharactersService in ServiceLocator
        CharactersService charactersService = new CharactersService();
        ServiceLocator.Register<ICharactersService>(charactersService);
        
        //Register PLayer
        ServiceLocator.Get<ICharactersService>().RegisterPlayerCharacter(this.gameObject);
    }
}