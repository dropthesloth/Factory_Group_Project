using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    private MemoryGameLogic memoryGameLogic;

    private void OnMouseDown()
    {
        if (memoryGameLogic != null)
        {
            memoryGameLogic.StartGame();
        }
    }
}
