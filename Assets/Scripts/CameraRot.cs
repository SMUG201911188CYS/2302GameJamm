using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{
    [SerializeField] private float mouseSpeed=8f; //회전속도
    private float mouseY=0f; //위아래 회전값을 담을 변수
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerMove.isDead)
        {
            mouseY += Input.GetAxis("Mouse Y")*mouseSpeed;

            mouseY = Mathf.Clamp(mouseY, -50f, 30f);

            this.transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
        }
        else
        {
            mouseY = -30f;
        }
    }
}