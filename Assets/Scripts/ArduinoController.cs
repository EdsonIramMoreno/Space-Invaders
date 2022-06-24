using System;
using UnityEngine;
using System.IO.Ports;
using System.Collections;
using UnityScript.Steps;

public class ArduinoController : MonoBehaviour
{
    //Se crea una variable serialport
    SerialPort serialPort = new SerialPort("COM3", 9600);
    bool Connected = true;

    // Start is called before the first frame update
    void Start(){
        //Se usa un try para checar excepciones y que el programa no truene
        try
        {
            serialPort.Open();
            serialPort.ReadTimeout = 150;
            Connected = true;

        }
        catch (System.Exception ex)
        {
            ex = new Exception();
            Connected = false;
        }

    }
    
    void Update(){
        //Se usa un try para checar excepciones y que el programa no truene
        try {
            if (serialPort.IsOpen){
                //Se recibe una linea de caracteres del arduino
                //data puede contener 2 tipos de valores "Shot" y numreico
                string data = serialPort.ReadLine();
                Debug.Log(data);
                if (data == "Shot"){
                    //Simplemente se dispara
                    FindObjectOfType<PlayerS>().setShooting(true);
                }
                else {
                    //Converitmos la string a int el número en la posision (0,0) es 500
                    int mov = int.Parse(data);
                    if (mov < 300){
                        FindObjectOfType<PlayerS>().getOutsideMov(2);
                    }
                    else if (mov > 800){
                        FindObjectOfType<PlayerS>().getOutsideMov(1);
                    }
                    else{
                        FindObjectOfType<PlayerS>().getOutsideMov(0);
                    }
                }
            }
        }
        catch(System.Exception ex){
            ex = new Exception();
        }
    }

    //Se manda una letra al arduino si es "A" el Led se enciende
    public void LedOn(){
        if (serialPort.IsOpen){
            serialPort.Write("A");
        }
        serialPort.Write("F");
    }

    //Para poder verificar si esta conectado en todas las demás clases
    public bool isConnected(){
        return Connected;
    }
}
