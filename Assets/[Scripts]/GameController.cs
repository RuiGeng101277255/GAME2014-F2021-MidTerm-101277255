using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public EnemyController enemy1;
    public EnemyController enemy2;

    public RectTransform Label1;
    public RectTransform Label2;

    private Rect screen;
    private Rect screenSafeArea;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckOrientation();
    }
    private void CheckOrientation()
    {
        screenSafeArea = Screen.safeArea;
        screen = new Rect(0.0f, 0.0f, Screen.width, Screen.height);

        //Adjustment based on screen orientation changes
        switch (Screen.orientation)
        {
            case ScreenOrientation.LandscapeLeft:
                player.transform.position = new Vector3(-8.0f, player.transform.position.y, 0.0f);
                enemy1.transform.position = new Vector3(8.0f, enemy1.transform.position.y, 0.0f);
                enemy2.transform.position = new Vector3(7.5f, enemy2.transform.position.y, 0.0f);

                Label1.anchoredPosition = new Vector3(450.0f, -250.0f, 0.0f);
                Label2.anchoredPosition = new Vector3(-450.0f, -250.0f, 0.0f);
                Label1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                Label2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                break;
            case ScreenOrientation.LandscapeRight:
                player.transform.position = new Vector3(-8.0f, player.transform.position.y, 0.0f);
                enemy1.transform.position = new Vector3(8.0f, enemy1.transform.position.y, 0.0f);
                enemy2.transform.position = new Vector3(7.5f, enemy2.transform.position.y, 0.0f);

                Label1.anchoredPosition = new Vector3(450.0f, -250.0f, 0.0f);
                Label2.anchoredPosition = new Vector3(-450.0f, -250.0f, 0.0f);
                Label1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                Label2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                break;
            case ScreenOrientation.Portrait:
                player.transform.position = new Vector3(-1.5f, player.transform.position.y, 0.0f);
                enemy1.transform.position = new Vector3(1.5f, enemy1.transform.position.y, 0.0f);
                enemy2.transform.position = new Vector3(1.0f, enemy2.transform.position.y, 0.0f);

                Label1.anchoredPosition = new Vector3(550.0f, -700.0f, 0.0f);
                Label2.anchoredPosition = new Vector3(-550.0f, -700.0f, 0.0f);
                Label1.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
                Label2.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
                Debug.Log(screenSafeArea.width);
                break;
            default:
                break;
        }
    }
}
