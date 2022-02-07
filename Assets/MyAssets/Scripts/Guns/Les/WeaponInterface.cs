using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WeaponInterface
{

    Transform bulletOrigin { get; set; }
    int currentAmmo { get; set; }
    int maxAmmo { get; set; }
    float impactForce { get; set; }
    bool hitScan { get; set; }
    LayerMask hitMask { get; set; }
  



    void FireBullet();
    void SetAmmoAmount(int removeAmmoAmount);



}
