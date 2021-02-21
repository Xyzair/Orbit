using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float radius;
    public float yOffset;
    public Transform focusedObject;

    public float rotSpeed;
    public bool rotateClockwise;

    private float timer = 0;
    private float mouseX, mouseY;

    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        if(focusedObject == null){
            //take spawn location and make it center.
            GameObject sun = GameObject.Find("ExoSun");
            focusedObject = sun.transform;

            this.radius = 20.0f;
        }

        //The camera is attached to an empty game object
        //And is used to rotate the camera around an object without rotating said object
        target = new GameObject();
        target.transform.SetPositionAndRotation(focusedObject.transform.position, Quaternion.Euler(0,0,0));
        target.name = "Target";
        this.transform.SetParent(target.transform);

        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButton(1)) {
            CamControl();
        }
        else {
            //Chill on the perpetual spinning =D
            mouseX = 0;
            mouseY = 0;
        }

        ZoomControl();
        
        transform.LookAt(focusedObject);
    }

    void CamControl() {
        timer += Time.deltaTime;
        
        mouseX += Input.GetAxis("Mouse X") * timer;
        mouseX = Mathf.Clamp(mouseX, -rotSpeed, rotSpeed);

        mouseY -= Input.GetAxis("Mouse Y") * timer;
        mouseY = Mathf.Clamp(mouseY, -rotSpeed, rotSpeed);

        target.transform.Rotate(mouseY, mouseX, 0);
    }

    void ZoomControl() {
        timer += Time.deltaTime * rotSpeed;
        float scroll = Input.mouseScrollDelta.y;
        //Ability to zoom in and out with the scroll wheel
        this.transform.Translate(0,0, scroll);
        scroll = 0;
    }

    void Rotate()
    {
        if (rotateClockwise)
        {
            float x = -Mathf.Cos(timer) * radius;
            float z = Mathf.Sin(timer) * radius;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + focusedObject.position;
        } else
        {
            float x = Mathf.Cos(timer) * radius;
            float z = Mathf.Sin(timer) * radius;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + focusedObject.position;
        }
    }
}
