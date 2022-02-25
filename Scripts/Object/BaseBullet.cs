using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    public int type;
    // Start is called before the first frame update
    void Start()
    {
        type = transform.parent.GetComponent<FirePos>().type;
        Destroy(gameObject, DataManager.Instance.BulletsInfo.bullets[type-1].destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * DataManager.Instance.BulletsInfo.bullets[type - 1].moveSpeed);
    }
    
}
