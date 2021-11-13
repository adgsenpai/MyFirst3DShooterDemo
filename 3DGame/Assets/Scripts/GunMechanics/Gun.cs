using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;

    public float range = 100f;

    public float impactForce = 30f;

    public Camera fpsCam;

    public ParticleSystem muzzleFlash;

    public AudioSource gunAudio;

    public GameObject impactEffect;

    public GameObject impactAudio;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        muzzleFlash.Play();
        gunAudio.Play();
        if (
            Physics
                .Raycast(fpsCam.transform.position,
                fpsCam.transform.forward,
                out hit,
                range)
        )
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage (damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactAudioGO =
                Instantiate(impactAudio,
                hit.point,
                Quaternion.LookRotation(hit.normal));

            GameObject impactGO =
                Instantiate(impactEffect,
                hit.point,
                Quaternion.LookRotation(hit.normal));
            impactAudio.GetComponent<AudioSource>().Play();
            Destroy(impactGO, 0.5f);
            Destroy(impactAudioGO, 0.5f);
        }
    }
}
