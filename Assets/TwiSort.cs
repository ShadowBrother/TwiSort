using UnityEngine;
using System.Collections;

public class TwiSort : MonoBehaviour {

    //enumeration for Belt Location/Color to PD #
   public enum Belt { NotFound, TopBlack , TopYellow, TopWhite, MiddleYellow, BottomRed, MiddleWhite, TopGreen, MiddleRed, TopRed, Orange,
        BottomYellow, TopBlue, MiddleBlack }

	// Use this for initialization
	void Start () {

        UnityEngine.Random.seed = (int)Time.time;//seed Random
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Belt sort(int zip)
    {

        //TopBlack - PD1
        if (zip == 43 || zip == 44 || zip == 46 || zip == 47 || zip == 49 || (zip >= 100 && zip <= 102) || (zip >= 320 && zip <= 349))
        {
            return Belt.TopBlack;
        }//TopYellow
        else if ((zip >= 51 && zip <= 57 && zip != 55) || (zip >= 70 && zip <= 79) || (zip >= 85 && zip <= 89 && zip != 87) ||
           (zip >= 103 && zip <= 119 && zip != 109))
        {
            return Belt.TopYellow;
        }//TopWhite
        else if ((zip >= 14 && zip <= 17) || zip == 60 || zip == 67 || zip == 109 || (zip >= 120 && zip <= 149))
        {
            return Belt.TopWhite;
        }//MiddleYellow
        else if ((zip >= 23 && zip <= 27 && zip != 24) || (zip >= 900 && zip <= 935) || (zip >= 967 && zip <= 969))
        {
            return Belt.MiddleYellow;
        }//BottomRed
        else if ((zip >= 39 && zip <= 42) || zip == 45 || zip == 48 || (zip >= 570 && zip <= 599) || (zip >= 630 && zip <= 639) ||
            (zip >= 650 && zip <= 659) || (zip >= 832 && zip <= 839) || (zip >= 870 && zip <= 889) || (zip >= 936 && zip <= 966) ||
            (zip >= 970 && zip <= 994))
        {
            return Belt.BottomRed;
        }//MiddleWhite
        else if (zip == 30 || zip == 31 || zip == 33 || (zip >= 150 && zip <= 188) || zip == 254 || (zip >= 260 && zip <= 269 && zip != 262 && zip != 266)
            || (zip >= 640 && zip <= 649) || (zip >= 660 && zip <= 679) || (zip >= 750 && zip <= 779))
        {
            return Belt.MiddleWhite;
        }//TopGreen
        else if ((zip >= 32 && zip <= 38 && zip != 33) || zip == 50 || zip == 58 || zip == 59 || (zip >= 200 && zip <= 223) || (zip >= 233 && zip <= 238)
            || (zip >= 370 && zip <= 385))
        {
            return Belt.TopGreen;
        }//MiddleRed
        else if ((zip >= 10 && zip <= 13) || zip == 62 || zip == 63 || (zip >= 80 && zip <= 84) | zip == 87 || (zip >= 189 && zip <= 199) ||
            (zip >= 530 && zip <= 569) || (zip >= 609 && zip <= 629) || (zip >= 716 && zip <= 729) || (zip >= 840 && zip <= 869))
        {
            return Belt.MiddleRed;
        }//TopRed
        else if (zip == 61 || (zip >= 64 && zip <= 69 && zip != 67) || (zip >= 386 && zip <= 397) || (zip >= 489 && zip <= 529) || (zip >= 680 && zip <= 715) || (zip >= 730 && zip <= 749) || (zip >= 780 && zip <= 831) || (zip >= 890 && zip <= 899))
        {
            return Belt.TopRed;
        }//Orange
        else if (zip == 19 || zip == 21 || zip == 22 || zip == 24 || (zip >= 224 && zip <= 232) || (zip >= 239 && zip <= 259 && zip != 250 && zip != 254) ||
            zip == 262 || zip == 266 || (zip >= 300 && zip <= 319) || (zip >= 350 && zip <= 369) || (zip >= 398 && zip <= 399))
            {
            return Belt.Orange;
        }//Bottom Yellow
        else if (zip == 20 || (zip >= 270 && zip <= 299) || (zip >= 460 && zip <= 479) || (zip >= 600 && zip <= 608))
        {
            return Belt.BottomYellow;
        }//TopBlue
        else if (zip == 28 || zip == 29 || (zip >= 400 && zip <= 459) || (zip >= 480 && zip <= 488) || (zip >= 995 && zip <= 999))
        {
            return Belt.TopBlue;
        }//MiddleBlack
        else if (zip == 18 || zip == 55)
        {
            return Belt.MiddleBlack;
        }
        else
        {
            return Belt.NotFound;
        }

    }

    //testSort, test to make sure there is a return in sort for each possible zip
    public void testSort()
    {
        for(int i = 10; i <= 999; i++)
        {
            if (sort(i) == Belt.NotFound)
                Debug.Log("No sort found for zip " + i);
        }
    }

    public int randomZip(int low = 10, int high = 999)
    {
        int rand = 0;
        do
        {
            rand = UnityEngine.Random.Range(low, high);//get random zip between low and high
        } while (rand == 250 || (rand >= 90 && rand <= 99));//exclude these values
        //Debug.Log(rand);
        return rand;
    }

    public void randomZipHandler()
    {
        int rand = randomZip();
        Debug.Log(rand);
    }
}
