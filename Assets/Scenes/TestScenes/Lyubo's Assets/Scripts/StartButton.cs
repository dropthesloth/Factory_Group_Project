using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    private MemoryGameLogic memoryGameLogic;

    private void OnMouseDown()
    {
        if (memoryGameLogic != null)
        {
            if(memoryGameLogic.turn == 1)
            memoryGameLogic.StartGame();
        }
    }
}
