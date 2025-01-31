using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MemoryGameLogic : MonoBehaviour
{
    [SerializeField]
    Simon simonPlayer;

    [SerializeField]
    Player player;

    [SerializeField]
    List<GameObject> buttons = new List<GameObject>();

    [SerializeField]
    GameObject startButton; // Reference to the start button

    int currentLevel = 1;
    public int turn = 1; // 0 for Simon's turn, 1 for Player's turn
    public int numberOfPresses = 2;
    public int pressIncrement;
    public int maxLevels = 10; // Set the maximum number of levels

    int playerButtonPress = 0;

    [SerializeField]
    private UnityEvent OnWin;

    [SerializeField]
    private UnityEvent OnGameOver;

    [SerializeField]
    TextMeshProUGUI levelText;

    // Use this for initialization
    void Start()
    {
        turn = 1;
        foreach (GameObject b in buttons)
        {
            b.GetComponent<ButtonHandler>().OnButtonPressed += HandleButtonPressed;
            b.GetComponent<Renderer>().material.color = Color.red; // Set initial color to red
        }
    }

    public void StartGame()
    {
        currentLevel = 1;
        numberOfPresses = 2;
        turn = 0; // Start with Simon's turn
        Debug.Log("Starting game. Simon's turn.");
        levelText.text = "Level " + currentLevel;
        simonPlayer.TakeTurn(numberOfPresses, buttons);
        Invoke(nameof(SwitchTurn), 3f); // Switch to player's turn after Simon's turn
    }

    private void HandleButtonPressed(GameObject obj)
    {
        if (turn == 1) // Only handle button presses during the player's turn
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                StartCoroutine(HandleButtonPressWithFlash(renderer, obj));
            }
            else
            {
                Debug.LogError("Renderer component not found on the button object.");
                return;
            }
        }
    }

    private IEnumerator HandleButtonPressWithFlash(Renderer renderer, GameObject obj)
    {
        // Flash the button
        yield return StartCoroutine(FlashButton(renderer));

        // Handle the game logic after the button flash
        string buttonName = simonPlayer.GetButtonPress(playerButtonPress);
        Debug.Log($"Expected button: {buttonName}, Pressed button: {obj.name}");

        if (buttonName != null && buttonName.Equals(obj.name))
        {
            Debug.Log("You hit the right button!");
            playerButtonPress++;

            if (playerButtonPress == numberOfPresses)
            {
                IncreaseLevel();
            }
        }
        else
        {
            GameOver();
        }
    }

    private IEnumerator FlashButton(Renderer renderer)
    {
        Color originalColor = renderer.material.color;
        renderer.material.color = Color.green; // Change color to green on click
        yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds
        renderer.material.color = originalColor; // Revert to original color
    }

    void IncreaseLevel()
    {
        if (currentLevel >= maxLevels)
        {
            Debug.Log("You've reached the maximum level!");
            WinGame();
            return;
        }

        Debug.Log("Great job! You successfully repeated Simon's pattern!");
        currentLevel++;
        levelText.text = "Level " + currentLevel;
        numberOfPresses += pressIncrement;
        turn = 0; // Switch to Simon's turn

        // Reset button colors
        foreach (GameObject b in buttons)
        {
            b.GetComponent<Renderer>().material.color = Color.red;
        }

        simonPlayer.TakeTurn(numberOfPresses, buttons);
        Invoke(nameof(SwitchTurn), 3f); // Switch to player's turn after Simon's turn
    }

    void GameOver()
    {
        Debug.Log("You hit the wrong button! Game OVER!");
        currentLevel = 1;
        numberOfPresses = 2;
        turn = 0; // Switch to Simon's turn
        simonPlayer.TakeTurn(numberOfPresses, buttons);
        Invoke(nameof(SwitchTurn), 4f); // Switch to player's turn after Simon's turn

        // Reset button colors
        foreach (GameObject b in buttons)
        {
            b.GetComponent<Renderer>().material.color = Color.red;
        }
        OnGameOver?.Invoke(); // Invoke the game over event
    }

    void SwitchTurn()
    {
        Debug.Log("Switching to player's turn");
        turn = 1; // Switch to Player's turn
        player.isOurTurn = true;
        playerButtonPress = 0;
    }

    void WinGame()
    {
        Debug.Log("You won the game!");
        foreach (GameObject b in buttons)
        {
            b.GetComponent<Renderer>().material.color = Color.yellow; // Light up all buttons
            b.GetComponent<ButtonHandler>().enabled = false; // Disable button handler
        }
        if (startButton != null)
        {
            startButton.GetComponent<Collider>().enabled = false; // Disable start button collider
        }
        OnWin?.Invoke(); // Invoke the win event
    }
}
