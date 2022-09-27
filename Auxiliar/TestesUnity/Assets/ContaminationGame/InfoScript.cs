using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScript : MonoBehaviour
{
    public int nucleotides;
    public int grossFee;
    public int netFee;
    public int cureFee;
    public int stateControl = 0;


    void Start()
    {
        netFee = grossFee - cureFee;
    }

    
    void Update()
    {
        
    }
}
