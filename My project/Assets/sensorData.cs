using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Accel : MonoBehaviour
{
    string filename = "";
    public bool playing;
    [System.Serializable]


    public class Player
    {
        public float x;

        public float y;

        public float z;

    }
    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    }

    public PlayerList myPlayerList = new PlayerList();

    private void Start()
    {
        filename = Application.dataPath + "/test.csv";


        TextWriter tw = new StreamWriter(filename, false);

        tw.WriteLine("Y");

        tw.Close();

    }


    private void Update()
    {
        if (playing == true)
        {
            WriteCSV();
        }
    }

    public void StartStop()
    {

        if (playing == true)
        {
            playing = false;
        }

        else if (playing == false)
        {
            playing = true;
        }


    }


    public void WriteCSV()
    {
        if (myPlayerList.player.Length > 0)
        {
            TextWriter tw = new StreamWriter(filename, true);



            tw.Close();

            tw = new StreamWriter(filename, true);

            for (int i = 0; i < myPlayerList.player.Length; i++)
            {
                //myPlayerList.player[i].x = Input.acceleration.x;
                myPlayerList.player[i].y = Input.acceleration.y;
                // myPlayerList.player[i].z = Input.acceleration.z;
                //tw.WriteLine(myPlayerList.player[i].x + "," + myPlayerList.player[i].y + "," + myPlayerList.player[i].z);
                tw.WriteLine(myPlayerList.player[i].y);
            }
            tw.Close();

            Debug.Log("Splurge");
        }

    }


}