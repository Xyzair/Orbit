using UnityEngine;
using UnityEngine.UI;

public class Orbit : MonoBehaviour
{
    public float radius = 20f;
    public float xSpread;
    public float zSpread;
    public float yOffset;
    public Transform centerPoint;
    public float speedScaler;
    public bool RotateClockwise;
    private float rotSpeed;
    private float timer = 0;
    private int score = 0;
    private int planetNumber;

        // Start is called before the first frame update
    void Start()
    {
        if(centerPoint == null){
            //take spawn location and make it center.
            GameObject sun = GameObject.Find("ExoSun");
            centerPoint = sun.transform;

            this.transform.SetParent(sun.transform);
            planetNumber = sun.transform.childCount;
            this.setRadius(radius * planetNumber);
            
            this.rotSpeed = radius / planetNumber;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 2.0f * Mathf.PI) {

            if(PlayerPrefs.HasKey("Score")){
                score = PlayerPrefs.GetInt("Score");
                PlayerPrefs.SetInt("Score", score + planetNumber);
                //Debug.Log("Score updated " + score + 1, null);
            }
            timer %= 2.0f * Mathf.PI;
        }
        
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
