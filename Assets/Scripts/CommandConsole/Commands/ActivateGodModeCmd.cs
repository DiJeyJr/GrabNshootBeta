using UnityEngine;

[CreateAssetMenu(menuName = "Commands/Activate GodMode")]
public class ActivateGodModeCmd : Command
{
    public override void Execute()
    {
        Player player = ServiceLocator.Get<ICharactersService>().GetPlayerCharacter().GetComponent<Player>();
        
        if (player != null)
        {
            player.GetComponent<HealthManager>().GetHeal(999999999999999);
            //Debug.Log("GodMode activated: Infinite HP.");
        }
    }

    public override void Execute(string[] args)
    {
        Execute();
    }
}