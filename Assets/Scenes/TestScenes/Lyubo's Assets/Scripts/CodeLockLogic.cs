using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CodeLockLogic : MonoBehaviour
{
    [SerializeField]
    private string correctCode = "1234";

    [SerializeField]
    private UnityEvent<string> onRightAnswer;

    [SerializeField]
    private UnityEvent onWrongAnswer;

    [SerializeField]
    private TMP_Text codeDisplay; // Reference to the TextMeshPro component

    private string enteredCode = "";
    
    public void AddDigit(string number)
    {
        enteredCode += number;
        UpdateCodeDisplay();
        CheckCode();
    }

    private void UpdateCodeDisplay()
    {
        if (codeDisplay != null && enteredCode != "OPEN")
        {
            codeDisplay.text = enteredCode;
        }
    }

    private void CheckCode()
    {
        if (enteredCode.Length >= correctCode.Length)
        {
            if (enteredCode == correctCode)
            {
                onRightAnswer.Invoke(enteredCode);
                Debug.Log("Correct code entered!");
                codeDisplay.text = "OPEN";
                // Do not clear the entered code if it is correct
            }
            else
            {
                onWrongAnswer.Invoke();
                enteredCode = ""; // Reset the entered code after checking
                UpdateCodeDisplay(); // Clear the display
            }
        }
    }
}
