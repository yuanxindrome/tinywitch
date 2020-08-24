using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class Servo : MonoBehaviour
{
    public bool serOn;
    SerialPort sp = new SerialPort("COM3", 9600);
    public static Servo instance;

    private void Awake()
    {
        instance = this;
    }

    public void Send1()
    {
        sp.Open();
        sp.Write("1");
        sp.Close();
        serOn = true;
        Debug.Log("Open");
        

    }
    public void Send2()
    {
        sp.Open();
        sp.Write("2");
        sp.Close();
        serOn = false;
        Debug.Log("Close");
    }

}
