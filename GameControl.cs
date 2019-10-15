using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
	public static int bronze, silver, gold;// i will reference these integers later and in other scripts, keeps track of all all in the world
	float miningSpeed, MineTime;
	public static int bronzeSupply, silverSupply, goldSupply;
    public GameObject BronzecubePrefab, SilvercubePrefab, GoldcubePrefab;
    GameObject myCube;
    Vector3 cubePosition;
    float yPos, xPos;
    Ore recentOre;
    int space = 0;
    public static int Score, bronzePoints, silverPoints, goldPoints;

    // Start is called before the first frame update
    void Start()
    {   
		miningSpeed = 3;//how many seconds pass before mining again
        MineTime = miningSpeed; //a variable to act as a way to continuously mine at the miningSpeed
        bronzeSupply = 0;
		silverSupply = 0;
		goldSupply = 0;
        yPos = -3;
        xPos = -8;
        recentOre = Ore.Bronze;
        bronzePoints = 1;
        silverPoints = 10;
        goldPoints = 100;
       // cubePosition = new Vector3(xPos, yPos, 0);
    }

    // Update is called once per frame
    void Update()
    {
		if(Time.time>MineTime)
        {
			MineTime += miningSpeed;//if 1 sec pass, MineTime will activate and begin the taking from the supply, this will occur again after another miningSpeed seconds has passed

            if (bronzeSupply == 2 && silverSupply == 2 && recentOre != Ore.Gold)
            {
                goldSupply++;
                cubePosition = new Vector3(xPos, yPos, 0);
                myCube = Instantiate(GoldcubePrefab, cubePosition, Quaternion.identity);
                myCube.GetComponent<CubeController>().myOre = Ore.Gold;// when calling GenerateCube, You call on a type of ore from Ore enum and specify in the parameters which kind of Ore it is with generateOre
                xPos += 2;
                recentOre = Ore.Gold;
            }

            else if (bronzeSupply < 4)
            {
				bronzeSupply ++;
                cubePosition = new Vector3(xPos, yPos, 0);
                myCube = Instantiate(BronzecubePrefab, cubePosition, Quaternion.identity);
                myCube.GetComponent<CubeController>().myOre = Ore.Bronze;// when calling GenerateCube, You call on a type of ore from Ore enum and specify in the parameters which kind of Ore it is with generateOre
                xPos += 2;
                recentOre = Ore.Bronze;
            }

			else
            {	silverSupply ++;
                cubePosition = new Vector3(xPos, yPos, 0);
                myCube = Instantiate(SilvercubePrefab, cubePosition, Quaternion.identity);
                myCube.GetComponent<CubeController>().myOre = Ore.Silver;// when calling GenerateCube, You call on a type of ore from Ore enum and specify in the parameters which kind of Ore it is with generateOre
                xPos += 2;
                recentOre = Ore.Silver;

               if (xPos > 8 && space == 0)
                {
                    xPos = -7;
                    yPos += 1;
                    space = 1;
                }
               else if (xPos > 8 && space == 1)
                {
                    xPos = -8;
                    yPos += 1;
                    space = 0;
                }
            }

            print("Total Points: " +Score);
        }
    }
}