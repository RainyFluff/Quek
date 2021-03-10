
using UnityEngine;
using System.Collections;
public class Shooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public float fireRate = 15f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime;
    private bool IsReloading = false;

    private float nextTimeToFire = 0f;

    public ParticleSystem muzzleflash;
    public AudioSource GunSound;
    public float Noise;

    void Start()
    {
        currentAmmo = maxAmmo;
    }
    // Update is called once per frame
    void Update()
    {
        if (IsReloading)
        {
            return;
        }


        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            GunSound.PlayOneShot(GunSound.clip, Noise);
        }
    

    }

    IEnumerator Reload()
    {
        Debug.Log("Reloading");
        IsReloading = true;
        yield return new WaitForSeconds(reloadTime);
        
        currentAmmo = maxAmmo;
        IsReloading = false;
    }
    void Shoot ()
    {
        muzzleflash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

    }
}
