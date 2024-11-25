using UnityEngine;
using UnityEngine.UI;

public class CommandConsole : MonoBehaviour
{
    public InputField commandInputField;
    public Text consoleOutputText;

    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        commandInputField.gameObject.SetActive(false);
        consoleOutputText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            ToggleConsole();
        }

        //Open console
        if (commandInputField.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            ExecuteCommand(commandInputField.text);
            commandInputField.text = "";
        }
    }

    //Open/Close console function
    private void ToggleConsole()
    {
        bool isActive = commandInputField.gameObject.activeSelf;
        commandInputField.gameObject.SetActive(!isActive);
        consoleOutputText.gameObject.SetActive(!isActive);
        player.GetComponent<CursorLock>().enabled = isActive;
        player.GetComponent<PlayerInputManager>().enabled = isActive;
    }

    // Execute command
    private void ExecuteCommand(string command)
    {
        if (command.ToLower() == "help")
        {
            consoleOutputText.text = "Command list:\n-godmode: Infinite HP\n-flash: Super speed\n-coolweapon: disable weapon overheat\n \n+Push F10 to Exit";
        }
        else if (command.ToLower() == "godmode")
        {
            ActivateGodMode();
        }
        else if (command.ToLower() == "flash")
        {
            ActivateFlash();
        }
        else if (command.ToLower() == "coolweapon")
        {
            DisableOverHeat();
        }
        else
        {
            consoleOutputText.text = "Unknown command";
        }
    }

    // Godmode
    private void ActivateGodMode()
    {
        player.health = 9999999;
        consoleOutputText.text = "GodMode activated: Infinite HP.";
    }

    // Super speed
    private void ActivateFlash()
    {
        player.GetComponent<PlayerMotor>().speed = 50f;
        consoleOutputText.text = "Flash activated: Super Speed.";
    }

    private void DisableOverHeat()
    {
        player.transform.GetChild(1).GetComponent<ShootFunction>().overHeatCheat = true;
        consoleOutputText.text = "CoolMode activado: disabled weapon overheat.";
    }
}
