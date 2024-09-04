using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject Bulletprefab;
    [SerializeField] Transform SpawnPosition;
    [SerializeField] float BulletForce = 50f;
    private float angle;
    Rigidbody2D Rb;
    [SerializeField] AudioClip shootsound;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 AIM = MousePosition - Rb.position;
        //Vector3 MouseAim = (MousePosition - transform.position).normalized;
        angle = Mathf.Atan2(AIM.y, AIM.x) * Mathf.Rad2Deg - 90;
        Rb.rotation = -angle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (Input.GetMouseButtonDown(0))
        {
            shoot(AIM);
        }

    }
    
    private void shoot(Vector2 AIM)
    {
        GameObject NewBullet = Instantiate(Bulletprefab, SpawnPosition.position, Quaternion.AngleAxis(angle, Vector3.forward));
        Rigidbody2D NewBulletRb = NewBullet.GetComponent<Rigidbody2D>();
        NewBulletRb.AddForce(AIM.normalized * BulletForce, ForceMode2D.Impulse);
        Destroy(NewBullet, 2);
 
       SoundManager.Instance.PlaySound(shootsound, this.transform.position);
    }
}
