using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoomManager : MonoBehaviour {

    [Tooltip("Amount of time in milliseconds it takes the screen to fade")]
    public int fadeTimeMS = 1600;
    [Tooltip("How quickly the background scrolls")]
    public float scrollSpeed = 10;
    [Tooltip("Amount of time in milliseconds level goes before fadeout")]
    public int levelTimeMS = 20000;

    private float fadeTime, levelTime;
    private Image fadeCanvas;
    private Color currentColor = Color.black;
    private float backgroundAlpha = 1f;

    private float yScroll = 0;
    private float timeSinceRoomLoad = 0;

    private int room = 0;
    private bool inLevel = true;

	// Use this for initialization
	void Start () {
        fadeCanvas = FindObjectOfType<Canvas>().GetComponentInChildren<Image>();
        fadeTime = fadeTimeMS / 1000;
        levelTime = levelTimeMS / 1000;
	}    
	
	// Update is called once per frame
	void Update () {
        if (inLevel)
        {
            if (Time.timeSinceLevelLoad < fadeTime)
            {
                backgroundAlpha -= Time.deltaTime / fadeTime;
                currentColor.a = backgroundAlpha;
                fadeCanvas.color = currentColor;
            }

            if (Time.timeSinceLevelLoad > levelTime - fadeTime)
            {
                backgroundAlpha += Time.deltaTime / fadeTime;
                currentColor.a = backgroundAlpha;
                fadeCanvas.color = currentColor;
                inLevel = backgroundAlpha < 1f;
            }

            yScroll -= scrollSpeed * Time.deltaTime / 10;
            transform.position = new Vector3(0, yScroll, 10);
        }
	}
}