using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public GUISkin layout;

    private bool started;

    GameObject theBall;

    public static void Score(string wallID)
    {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
        }
        else
        {
            PlayerScore2++;
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && !started)
        {
            started = true;
            theBall.SendMessage("GoBall", null, SendMessageOptions.RequireReceiver);
        }

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnGUI()
    {
        GUI.skin = layout;

        GUI.Label(new Rect(Screen.width * .25f - 25, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width * .75f - 25, 20, 100, 100), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width * .5f - 60, 20, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width * .5f - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width * .5f - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (!started)
        {
            GUI.TextArea(new Rect(Screen.width / 2 - 300, 100, 600, 300), "Welcome to Ben's Unity Pong\nLeft paddle is controlled with W and S\nRight paddle controlled with UP and DOWN\n\nPress any key to begin\n" +
                "\nPress ESC when you are ready to quit");

        }
    }
}
