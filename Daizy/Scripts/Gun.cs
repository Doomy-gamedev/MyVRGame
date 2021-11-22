using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

     


public class Gun : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField] private GameObject muzzleFlashPrefab;
    [SerializeField] private Transform barrel;
    [SerializeField] private Transform slideject;
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private float destroyTimer = 2f;

    [Header("Mag Settings")]
    public Magazine magazine;
    public XRSocketInteractor socketInteractor;
    [SerializeField] private bool hasSlide = true;
    //[SerializeField] private bool hasAmmo = true;
    [SerializeField] private float ammoCount = 6;
    
    [Header("Bullet Settings")]
    public GameObject bullet;
    [SerializeField] private float bulletspeed = 500f;

    [Header("Casing Settings")]
    public GameObject casing; 
    [SerializeField] private float casingspeed = 150f;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip shoot;
    public AudioClip noAmmo;
    public AudioClip reload;

    
    void Start()
    {
        if (barrel == null)
            barrel = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    
    //socketInteractor.selectEntered.AddListener(AddMagazine);
    //socketInteractor.selectExited.AddListener(RemoveMagazine);
    }

    public void AddMagazine(XRBaseInteractable interactable)
    {
        magazine = GetComponent<Magazine>();
        audioSource.PlayOneShot(reload);
        hasSlide = false;
    }
   public void RemoveMagazine(XRBaseInteractable interactable)
    {
        magazine = null;
        audioSource.PlayOneShot(reload);
    }
    public void Slide()
    {
        hasSlide = true;
        audioSource.PlayOneShot(reload);
    }
    public void FiringGun()
    {
       if ( ammoCount >= 0 )
       {
           Fire();
           gunAnimator.SetTrigger("Fire");
           Casing();
       }
       else
       {
         audioSource.PlayOneShot(noAmmo); 
       }
    }
   
    public void Fire()
    {
        audioSource.PlayOneShot(shoot);
        ammoCount --;

        if (muzzleFlashPrefab)
        {
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrel.position, barrel.rotation);

            Destroy(tempFlash, destroyTimer);
        }
        if (!bullet)
        {return; }
        
        Instantiate(bullet, barrel.position, barrel.rotation).GetComponent<Rigidbody>().AddForce(barrel.forward * bulletspeed);
             
    }
     void Casing()
    {
        if (!slideject || !casing)
        { return; }

        GameObject tempCasing;
        tempCasing = Instantiate(casing, slideject.position, slideject.rotation) as GameObject;
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(casingspeed * 0.7f, casingspeed), (slideject.position - slideject.right * 0.3f - slideject.up * 0.6f), 1f);
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);
        Destroy(tempCasing, destroyTimer);
    }

  
}