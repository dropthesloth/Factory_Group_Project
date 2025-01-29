using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
public class ObjectVanisher : MonoBehaviour
{
    [SerializeField] List<ParticleSystem> obstacleParticles;
    [SerializeField] GameObject obstacle;
    [SerializeField] TextMeshProUGUI obstacleText;
    bool obstacleVanished;
    [SerializeField] float fadeSpeed;
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
            foreach (ParticleSystem particle in obstacleParticles)
            {
                if (particle.emissionRate > 0)
                {
                    ParticleSystem.Burst[] bursts = new ParticleSystem.Burst[particle.emission.burstCount];
                    particle.emissionRate -= Time.deltaTime * fadeSpeed;
                    for (int i = 0; i < bursts.Length; i++)
                    {
                        bursts[i].count = 0;
                    }
                    particle.emission.SetBursts(bursts);
                }
                else
                    obstacle.SetActive(false);
            }

            if (obstacleText != null)
                obstacleText.text = "Obstacle inactive";
        }
    }
    public void RemoveObstacle()
    {
        obstacleVanished = true;

    }
}
