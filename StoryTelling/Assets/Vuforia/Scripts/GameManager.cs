using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Target;

    public static GameManager Instance;

    public ParticleSystem CelebParticles;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = -Target.up * 10;
    }

    public void CorrectBox()
    {
        
    }

    public void WrongeBox()
    {
        
    }

    public void GameWon()
    {
        print("aaaa");
        CelebParticles.Play();
    }
}
