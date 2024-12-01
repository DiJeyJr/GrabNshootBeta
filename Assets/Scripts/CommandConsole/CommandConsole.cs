using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommandConsole : MonoBehaviour
{
    public InputField commandInputField;
    public Text consoleOutputText;
    [SerializeField] private List<Command> commands;

    private Player player;

    private void Start()
    {
        PlayerService playerService = ServiceLocator.GetService<PlayerService>();
        player = playerService?.GetPlayer()?.GetComponent<Player>();

        if (player == null)
        {
            Debug.LogError("Player not found or PlayerService is not registered.");
        }

        if (commandInputField == null)
        {
            Debug.LogError("Command Input Field is not assigned.");
        }
        else
        {
            commandInputField.gameObject.SetActive(false);
        }

        if (consoleOutputText == null)
        {
            Debug.LogError("Console Output Text is not assigned.");
        }
        else
        {
            consoleOutputText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            ToggleConsole();
        }

        if (commandInputField != null && commandInputField.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            ExecuteCommand(commandInputField.text);
            commandInputField.text = string.Empty;
        }
    }

    // Open/Close console function
    private void ToggleConsole()
    {
        if (commandInputField == null || consoleOutputText == null || player == null)
        {
            Debug.LogError("One or more required components are not assigned or initialized.");
            return;
        }

        bool isActive = commandInputField.gameObject.activeSelf;
        commandInputField.gameObject.SetActive(!isActive);
        consoleOutputText.gameObject.SetActive(!isActive);
        player.GetComponent<CursorLock>().enabled = isActive;
        player.GetComponent<PlayerInputManager>().enabled = isActive;
    }

    // Execute command
    private void ExecuteCommand(string input)
    {
        string[] args = input.Split(' ');
        string commandName = args[0];
        Command command = commands.FirstOrDefault(c => c.Name == commandName || c.Aliases.Contains(commandName));

        if (command != null)
        {
            command.Execute(args.Skip(1).ToArray());
        }
        else
        {
            Debug.LogError($"Command '{commandName}' not found!");
        }
    }
}
