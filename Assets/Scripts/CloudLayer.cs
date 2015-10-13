using UnityEngine;
using System.Collections;

public class CloudLayer : MonoBehaviour {

    [Tooltip("Amount of time in milliseconds it takes the screen to fade")]
    public int fadeTimeMS = 1600;
    [Tooltip("How quickly the background scrolls")]
    public float scrollSpeed = 10;
    [Tooltip("Amount of time in milliseconds level goes before fadeout")]
    public int levelTimeMS = 20000;
    
    private Color currentColor = Color.white;
    private float backgroundAlpha = 0f;

    private float yScroll = 0;
    
    private bool inLevel = true;
    public GameObject[] clouds;
    public float avTimeBetweenClouds = 1000;

    private float timeMark;
    private float timeBetweenClouds;

	// Use this for initialization
	void Start () {
        timeMark = Time.timeSinceLevelLoad;
        timeBetweenClouds = Random.Range(avTimeBetweenClouds * 0.5f, avTimeBetweenClouds * 1.5f);
    }

    // Update is called once per frame
    void Update() {
        float timeSinceLastCloud = Time.timeSinceLevelLoad - timeMark;
        if (timeSinceLastCloud > timeBetweenClouds / 1000)
        {
            GameObject cloud = Instantiate(clouds[Random.Range(0, clouds.Length)], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity) as GameObject;
            //cloud.transform.parent = GameObject.Find("Cloud Layer").transform;
            cloud.transform.parent = this.transform;
            timeMark = Time.timeSinceLevelLoad;
            timeBetweenClouds = Random.Range(avTimeBetweenClouds * 0.5f, avTimeBetweenClouds * 1.5f);
        }

        yScroll -= scrollSpeed * Time.deltaTime / 10;
        transform.position = new Vector3(0, yScroll, 10);        
    }
}