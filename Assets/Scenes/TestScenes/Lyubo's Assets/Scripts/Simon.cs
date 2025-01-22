using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon : MonoBehaviour
{
    private List<string> buttonPresses = new List<string>();

    public void AddButtonPress(string buttonName)
    {
        buttonPresses.Add(buttonName);
    }

    public string GetButtonPress(int index)
    {
        if (index >= 0 && index < buttonPresses.Count)
        {
            return buttonPresses[index];
        }
        return null;
    }

    public void ClearButtonPresses()
    {
        buttonPresses.Clear();
    }

    public void TakeTurn(int numberOfPresses, List<GameObject> buttons)
    {
        StartCoroutine(LightUpButtons(numberOfPresses, buttons));
    }

    private IEnumerator LightUpButtons(int numberOfPresses, List<GameObject> buttons)
    {
        buttonPresses.Clear();
        for (int i = 0; i < numberOfPresses; i++)
        {
            int index = Random.Range(0, buttons.Count);
            buttonPresses.Add(buttons[index].name);
            Debug.Log($"Simon lights up: {buttons[index].name}");
            buttons[index].GetComponent<Renderer>().material.color = Color.yellow; // Light up the button
            yield return new WaitForSeconds(1f); // Wait for 1 second
            buttons[index].GetComponent<Renderer>().material.color = Color.red; // Turn off the light
            yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds before the next button
        }
        Debug.Log("Simon's sequence: " + string.Join(", ", buttonPresses));
    }
}
