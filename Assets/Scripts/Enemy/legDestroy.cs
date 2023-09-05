using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legDestroy : MonoBehaviour
{
    public bool isDead;

    private void Update()
    {
        if(isDead)
        {
            Destroy(this.gameObject);
        }
    }
}
