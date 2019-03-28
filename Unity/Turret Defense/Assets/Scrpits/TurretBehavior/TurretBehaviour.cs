using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    public Transform target;
    public Transform turretHead;
    [SerializeField] float targetRange;

    [SerializeField] private GameObject bulletDemo;
    [SerializeField] private GameObject Muzz_MachineGun;
    //[SerializeField] private GameObject Muzz_Point_MachineGun;
    public GameObject weapeonRange;
  
    [SerializeField] private Transform firePoint;
    private float fireCountDown = 0f;
    private float fireRate = 1f;

   

    void SearchTarget()
    {
        GameObject []enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject enemyInRange = null;
        float enemyDistance = Mathf.Infinity;
        for (int i = 0; i < enemies.Length; i++)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemies[i].transform.position);
            if(distanceToEnemy < enemyDistance)
            {
                enemyDistance = distanceToEnemy;
                enemyInRange = enemies[i];

            }
        }

        if (enemyInRange != null && enemyDistance <= targetRange)
        {
            target = enemyInRange.transform;
        }
        else
        {
            target = null;
        }

       

    }

    void Shoot()
    {
        //Debug.Log("Shoot!");
        GameObject cloneMuzz = (GameObject)Instantiate(Muzz_MachineGun,firePoint.position,firePoint.rotation);
        Destroy(cloneMuzz,0.3f);
        
        GameObject bullet =(GameObject)Instantiate(bulletDemo, firePoint.position, firePoint.rotation);

        if (bullet != null)
        {
            bullet.GetComponent<BulletBehaviour>().ChaseTarget(target);
        }
    }

   

    private void OnMouseOver()
    {
        Debug.Log("In Range");
        weapeonRange.SetActive(true);
             
    }

    private void OnMouseExit()
    {
        Debug.Log("Out Range");
        weapeonRange.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SearchTarget", 0f, 0.5f);
        Vector3 change = targetRange * new Vector3(1, 1, 1);
        weapeonRange.transform.localScale += change;

    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 targetDir = target.position - transform.position;
        Vector3 targetRotation =
        Quaternion.Lerp(turretHead.rotation, Quaternion.LookRotation(targetDir), Time.deltaTime * 5f).eulerAngles;
        turretHead.rotation = Quaternion.Euler(0f, targetRotation.y, 0f);

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }
}
