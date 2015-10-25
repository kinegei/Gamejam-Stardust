using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{

    public Texture2D pageOne;

    public float letterPause = 0.001f;

    string message;
    private string message2;
    public Text textComp;

    float changeImageSpeed = 0.2f;

    private Texture2D swImage;
    float changeImageTime;
    private bool started = false;
    // Use this for initialization
    void Start()
    {
        swImage = pageOne;

        //textComp = GetComponent<Text>();
        message = "The starchildren had journeyed across time and space for eons unknown.\n" +
                  "Their songs brought new life to the systems they passed, and in return filled them with joy and laughter.\n\n" +

                  "Never stopping, never resting, on and on, never released from the wonder the universe showed them.\n" +

                  "But one day...one curious little starchild ventured a little too close to a particularly interesting moon.\n";

        message2 = "His little heart was filled with wonder as he gazed upon its beauty, and so he began to sing...\n" +
                  "The moon burst into life with such force that it rocked the planet underneath its womb.\n" +
                  "The starchild was flung onto the planet.Lost, trapped, unable to return to the others who would abandon it there for all time if it could not return in time.\n\n" +

                  "Time...\n\n" +

                  "Its only hope is to regain its powers from its shattered song and restore the world as it once was.";

        textComp.text = "";
        StartCoroutine(TypeText(message));
    }

    IEnumerator TypeText(string msg)
    {
        foreach (char letter in msg.ToCharArray())
        {
            textComp.text += letter;
            yield return new WaitForFixedUpdate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        changeImageTime += Time.smoothDeltaTime * changeImageSpeed;
        //Debug.Log(changeImageTime);
        if (changeImageTime >= 4 && !started)
        {
            started = true;
            textComp.text = "";
            StartCoroutine(TypeText(message2));
        }

        if (changeImageTime >= 8)
        {
            Application.LoadLevel("JanOle");
        }

    }
}
