using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHit, jumpSound, DeathSound, DashSound, SkillSound, PotionSound, CoinSound, HurtSound;
    static AudioSource audioSrc;
    void Start()
    {
        playerHit = Resources.Load<AudioClip>("Hit");
        jumpSound = Resources.Load<AudioClip>("Jump");
        DeathSound = Resources.Load<AudioClip>("Die");
        DashSound = Resources.Load<AudioClip>("Dash");
        SkillSound = Resources.Load<AudioClip>("Skill");
        PotionSound = Resources.Load<AudioClip>("Potion");
        CoinSound = Resources.Load<AudioClip>("Coin");
        HurtSound = Resources.Load<AudioClip>("Hurt");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Playsound(string clip)
    {
        switch(clip)
        {
            case "Hit":
                audioSrc.PlayOneShot(playerHit);
                break;

            case "Jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "Die":
                audioSrc.PlayOneShot(DeathSound);
                break;
            case "Dash":
                audioSrc.PlayOneShot(DashSound);
                break;
            case "Skill":
                audioSrc.PlayOneShot(SkillSound);
                break;
            case "Coin":
                audioSrc.PlayOneShot(CoinSound);
                break;
            case "Hurt":
                audioSrc.PlayOneShot(HurtSound);
                break;
            case "Potion":
                audioSrc.PlayOneShot(PotionSound);
                break;
        }
    }
}
