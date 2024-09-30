using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tiroBullet : MonoBehaviour
{
    //Gun Status
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletPerTap;
    public bool allowButtonhold;
    int bulletLeft, bulletsShot;

    //Bools
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    public GameObject bulletHoleGraphic;
    //public GameObject muzzleFlash;
    public TextMeshProUGUI text;

    private void Start()
    {
        bulletLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyIput();

        //SetText
        text.SetText(bulletLeft + " / " + magazineSize);
    }
    private void MyIput()
    {
        if (allowButtonhold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletLeft < magazineSize && !reloading)
        {
            Reload();
        }

        //Shoot
        if(readyToShoot && shooting && !reloading && bulletLeft > 0)
        {
            bulletsShot = bulletPerTap;
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if(Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            //Debug.Log(rayHit.collider.name);

            if(rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponent<moveNPC>().TakeDamage(damage);
            }
        }

        //Graphics
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        //Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 && bulletLeft > 0)
        Invoke("Shoot", timeBetweenShooting);
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    
    private void ReloadFinished()
    {
        bulletLeft = magazineSize;
        reloading = false;
    }

}