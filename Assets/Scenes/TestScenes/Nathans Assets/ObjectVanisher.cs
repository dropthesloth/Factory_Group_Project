using UnityEngine;
using TMPro;
public class ObjectVanisher : MonoBehaviour
{
    [SerializeField] ParticleSystem obstacleParticle;
    [SerializeField] GameObject obstacle;
    [SerializeField] TextMeshProUGUI obstacleText;
    bool obstacleVanished;
    // Start is called before the first frame update
    void Start()
    {
        if (obstacleText != null)
            obstacleText.text = "Obstacle active";
        obstacleVanished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (obstacleVanished)
        {
            Debug.Log(Time.deltaTime.ToString());
            if (obstacleParticle.emissionRate > 0)
            {
                obstacleParticle.emissionRate -= Time.deltaTime * 5;
            }
            else
            obstacle.SetActive(false);
            if (obstacleText != null)
                obstacleText.text = "Obstacle inactive";
        }
    }
    public void RemoveObstacle()
    {
        obstacleVanished = true;

    }
}
