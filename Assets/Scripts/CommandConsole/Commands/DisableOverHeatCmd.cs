using UnityEngine;

[CreateAssetMenu(menuName = "Commands/Disable OverHeat")]
public class DisableOverHeatCmd : Command
{
    public override void Execute()
    {
        PlayerService playerService = ServiceLocator.GetService<PlayerService>();
        Player player = playerService?.GetPlayer()?.GetComponent<Player>();
        
        if (player != null)
        {
            player.transform.GetChild(1).GetComponent<ShootFunction>().overHeatCheat = true;
            Debug.Log("CoolMode activado: disabled weapon overheat.");
        }
    }

    public override void Execute(string[] args)
    {
        Execute();
    }
}