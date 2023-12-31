using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour
{

    private Camera cam;
    public bool playaDead=false;
    
    void Start()
    {
        cam=Camera.main;
    }
    void Update()
    {
        Aim();
    }

    private void Aim()
    {
        if(!playaDead){
            Vector3 mouse=Input.mousePosition;
            Vector3 screenPoint=Camera.main.WorldToScreenPoint(transform.position);
            Vector2 offset=new Vector2 (mouse.x-screenPoint.x, mouse.y-screenPoint.y);
            float angle=Mathf.Atan2(offset.y, offset.x)*Mathf.Rad2Deg;
            transform.rotation=Quaternion.Euler(0f,0f,angle);
        }


    }
}
