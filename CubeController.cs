using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{   
    public Ore myOre;// from the Ore enum, myOre stores either bronze,silver, or gold onto each individual cube
    public Color initialColor;
    void Start()
    {
        initialColor = GetComponent<Renderer>().material.color;//the material of the cube in unity is the initial color
    }

    // Update is called once per frame
    void Update()
    {
       
    }
     void OnMouseOver()
     {
         if (myOre == Ore.Bronze)
         {
            GetComponent<Renderer>().material.color = Color.red;
         }
        if (myOre == Ore.Gold)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (myOre == Ore.Silver)
        {
            GetComponent<Renderer>().material.color = Color.gray;
        }
    }
    void OnMouseExit()
    {
            GetComponent<Renderer>().material.color = initialColor;
    }
    void OnMouseDown() {
        Destroy (gameObject); //destroys the object in the game and not the components of the object
        //this is on every cube object
        if (myOre == Ore.Bronze)//if from the ore enum list, a cube is bronze, and it its destroyed, then subjtract 1 from the ammount of bronze onscreen
        {
            GameControl.bronze--;
            GameControl.bronzeSupply--;
            GameControl.Score += GameControl.bronzePoints;
        } 
        else if (myOre == Ore.Silver)
        {
            GameControl.silver--;
            GameControl.silverSupply--;
            GameControl.Score += GameControl.silverPoints;
        }

        if (myOre == Ore.Gold)
        {
            GameControl.gold--;
            GameControl.goldSupply--;
            GameControl.Score += GameControl.goldPoints;
        }//this is what indicates that the current ammount of cubes out should be subbtracted by 1 every time one is destroyed
        
    }
}
