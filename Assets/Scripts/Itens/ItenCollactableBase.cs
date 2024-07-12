using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItenCollactableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    public float timeToHide = 3;
    public GameObject graphicIten;

    [Header("Sounds")]
    public AudioSource audioSource;


    private void Awake()
    {
        //if (particleSystem != null) particleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(compareTag))
        {
            Collect();
        }
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void Collect()
    {
        if (graphicIten != null) graphicIten.SetActive(false); 
        Invoke("HideObject", timeToHide);
        OnCollect();
    }

    /*protected virtual void Collect2()
    {
        gameObject.SetActive(false);
        OnCollect();
    }*/

    protected virtual void OnCollect()
    {
        if (particleSystem != null) particleSystem.Play();
        if (audioSource != null) audioSource.Play();
    }
}
