using UnityEngine;

[CreateAssetMenu(menuName = "Commands/Activate GodMode")]
public class ActivateGodModeCmd : Command
{
    public override void Execute()
    {
        PlayerService playerService = ServiceLocator.GetService<PlayerService>();
        Player player = playerService?.GetPlayer()?.GetComponent<Player>();
        
        if (player != null)
        {
            player.health = 9999999;
            Debug.Log("GodMode activated: Infinite HP.");
        }
    }

    public override void Execute(string[] args)
    {
        Execute();
    }
}