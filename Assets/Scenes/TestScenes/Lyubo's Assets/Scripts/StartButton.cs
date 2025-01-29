using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    private MemoryGameLogic memoryGameLogic;

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, GlobalSettings.maxClickDistance))
        {
            if (hit.transform == transform)
            {
                if (memoryGameLogic != null)
                {
                    if (memoryGameLogic.turn == 1)
                        memoryGameLogic.StartGame();
                }
            }
        }
    }
}
