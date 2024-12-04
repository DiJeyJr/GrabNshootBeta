using UnityEngine;

[CreateAssetMenu(menuName = "Commands/Activate Flash")]
public class ActivateFlashCmd : Command
{
    public override void Execute()
    {
        Player player = ServiceLocator.Get<ICharactersService>().GetPlayerCharacter().GetComponent<Player>();
        
        if (player != null)
        {
            player.GetComponent<PlayerMotor>().speed = 50f;
            //Debug.Log("Flash activated: Super Speed.");
        }
    }

    public override void Execute(string[] args)
    {
        Execute();
    }
}