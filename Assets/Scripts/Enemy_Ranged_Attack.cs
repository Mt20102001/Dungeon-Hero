using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ranged_Attack : MonoBehaviour
{
    #region Public Values
    public GameObject bullet;
    public Transform AttackPoint;
    public Animator anim;
    public AnimationClip AttackAnimation;
    public AnimationClip HurtAnimation;
    #endregion

    #region Private Values
    private float fireRate;
    private float nextFire;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        fireRate = AttackAnimation.length;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("Attack"))
        {
            Invoke("CheckIfTimeToFire", AttackAnimation.length - 0.4f);
        }
    }

    private void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, AttackPoint.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
