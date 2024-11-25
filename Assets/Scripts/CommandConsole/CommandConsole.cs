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

        // Aseguramos que la consola no esté visible al principio
        commandInputField.gameObject.SetActive(false);
        consoleOutputText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            ToggleConsole();
        }

        // Si la consola está abierta, comprobar si se presiona "Enter" para ejecutar el comando
        if (commandInputField.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            ExecuteCommand(commandInputField.text);
            commandInputField.text = "";
        }
    }

    // Alterna la visibilidad de la consola
    private void ToggleConsole()
    {
        bool isActive = commandInputField.gameObject.activeSelf;
        commandInputField.gameObject.SetActive(!isActive);
        consoleOutputText.gameObject.SetActive(!isActive);
        player.GetComponent<CursorLock>().enabled = isActive;
        player.GetComponent<PlayerInputManager>().enabled = isActive;
    }

    // Ejecuta el comando que el jugador ingresa
    private void ExecuteCommand(string command)
    {
        if (command.ToLower() == "godmode")
        {
            ActivateGodMode();
        }
        else if (command.ToLower() == "flash")
        {
            ActivateFlash();
        }
        else
        {
            consoleOutputText.text = "Comando no reconocido.";
        }
    }

    // Habilita el modo Dios (vida infinita)
    private void ActivateGodMode()
    {
        player.health = 9999999; // Vida infinita
        consoleOutputText.text = "GodMode activado: Vida infinita.";
    }

    // Habilita la velocidad altísima (Flash)
    private void ActivateFlash()
    {
        player.GetComponent<PlayerMotor>().speed = 50f; // Aumenta la velocidad
        consoleOutputText.text = "Flash activado: Velocidad altísima.";
    }
}
