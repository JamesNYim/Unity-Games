using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float rateOfFire = 15f;
    public float impactForce = 4f;

    public MeshRenderer muzzleFlash; 
    public Camera fpsCam;
    public GameObject impactEffect;
    private float nextTimeToFire = 0f;
    // Update is called once per frame
    async void Update()
    {
       
       if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1f / rateOfFire;
            Shoot();
            await Task.Delay(TimeSpan.FromSeconds(.1f));
            muzzleFlash.enabled = false;
       } 
       
    }
    
    void Shoot () {
        RaycastHit hit;
        muzzleFlash.enabled = true;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null) {
                target.TakeDamage(damage);
                if (hit.rigidbody != null) {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, .12f);
        }
        
    }
}
