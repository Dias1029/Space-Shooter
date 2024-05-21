using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioClip pickUp1, pickUp2;
    [SerializeField] private AudioClip destroy1, destroy2;
    [SerializeField] private AudioClip damage1, damage2;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void PickUpSound()
    {
        if (Random.Range(0, 2) > 0)
            AudioSource.PlayClipAtPoint(pickUp1, transform.position);
        else
            AudioSource.PlayClipAtPoint(pickUp2, transform.position);
    }

    public void DestroySound()
    {
        if (Random.Range(0, 2) > 0)
            AudioSource.PlayClipAtPoint(destroy1, transform.position);
        else
            AudioSource.PlayClipAtPoint(destroy2, transform.position);
    }

    public void DamageSound()
    {
        if (Random.Range(0, 2) > 0)
            AudioSource.PlayClipAtPoint(damage1, transform.position);
        else
            AudioSource.PlayClipAtPoint(damage2, transform.position);
    }
}
