using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float xSpread;
    public float zSpread;
    public float yOffset;
    public Transform centerPoint;
    public float speedScaler;
    public bool RotateClockwise;
    private float rotSpeed;
    private float timer = 0;

        // Start is called before the first frame update
    void Start()
    {
        if(centerPoint == null){
            //take spawn location and make it center.
            GameObject sun = GameObject.Find("ExoSun");
            centerPoint = sun.transform;

            this.transform.SetParent(sun.transform);

            this.setRadius(20.0f * sun.transform.childCount);
            
            this.rotSpeed = 20.0f / sun.transform.childCount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * rotSpeed * speedScaler;
        Rotate();
        transform.LookAt(centerPoint);
    }

    void Rotate()
    {
        if (RotateClockwise)
        {
            float x = -Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + centerPoint.position;
        } else
        {
            float x = Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + centerPoint.position;
        }
    }

    void Initialize(string gobj, float radius) {
        this.centerPoint = GameObject.Find(gobj).transform;
    }

    void setRadius(float radius) {
        xSpread = radius;
        zSpread = radius;
    }
}
