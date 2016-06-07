using System;

//enumeration for Belt Location/Color to PD #
public enum Belt
{
    NotFound, TopBlack, TopYellow, TopWhite, MiddleYellow, BottomRed, MiddleWhite, TopGreen, MiddleRed, TopRed, Orange,
    BottomYellow, TopBlue, MiddleBlack
}

//enumeration for State abbreviations
public enum State { NotFound, MA, RI, NH, ME, VT, CT, NJ, NY, PA, DE, DC, MD, VA, WV, NC, SC, GA, FL, AL, TN, MS, KY, OH, IN, MI, IA, WI, MN, SD, ND, MT, IL, MO, KS, NE, LA, AR, OK,
    TX, CO, WY, ID, UT, AZ, NM, NV, CA, HI, OR, WA, AK}

//enumeration for package delivery types
public enum DeliveryType { Ground, NextDayAir, SecondDayAir, ThreeDayAir, International}

//Package class
public class Package
{
    public int fullZip {get; private set; }//full 5 digit zip code
    public int humanReadable {  get; private set; }//3 digit human readable code
    public State state {  get; private set; }//state abbreviation
    public DeliveryType deliveryType {  get; private set; }//type of delivery
    public bool exception;//if true, no human readable, must sort based on exception table for full zip
    public Belt belt;//belt package should be sorted to

    //returns random HumanReadable code between low and high
    public static int randomHumanReadable(int low = 10, int high = 999)
    {
        int rand = 0;
        do
        {
            rand = UnityEngine.Random.Range(low, high);//get random zip between low and high
        } while (rand == 250 || (rand >= 90 && rand <= 99));//exclude these values
        //Debug.Log(rand);
        return rand;
    }


    //returns State abbreviation based on humanReadable code
    public static State findStateFromHumanReadable( int humanReadable)
    {
        if ((humanReadable >= 10 && humanReadable <= 27) || humanReadable == 55)
        {
            return State.MA;
        }
        else if (humanReadable == 28 || humanReadable == 29)
        {
            return State.RI;
        }
        else if (humanReadable >= 30 && humanReadable <= 38)
        {
            return State.NH;
        }
        else if (humanReadable >= 39 && humanReadable <= 49)
        {
            return State.ME;
        }
        else if (humanReadable >= 50 && humanReadable <= 59)
        {
            return State.VT;
        }
        else if (humanReadable >= 60 && humanReadable <= 69)
        {
            return State.CT;
        }
        else if (humanReadable >= 70 && humanReadable <= 89)
        {
            return State.NJ;
        }
        else if (humanReadable >= 100 && humanReadable <= 149)
        {
            return State.NY;
        }
        else if (humanReadable >= 150 && humanReadable <= 196)
        {
            return State.PA;
        }
        else if (humanReadable >= 197 && humanReadable <= 199)
        {
            return State.DE;
        }
        else if (humanReadable >= 200 && humanReadable <= 205)
        {
            return State.DC;
        }
        else if (humanReadable >= 206 && humanReadable <= 219)
        {
            return State.MD;
        }
        else if (humanReadable >= 220 && humanReadable <= 249)
        {
            return State.VA;
        }
        else if (humanReadable >= 250 && humanReadable <= 269)
        {
            return State.WV;
        }
        else if (humanReadable >= 270 && humanReadable <= 289)
        {
            return State.NC;
        }
        else if (humanReadable >= 290 && humanReadable <= 299)
        {
            return State.SC;
        }
        else if ((humanReadable >= 300 && humanReadable <= 319) || (humanReadable >= 398 && humanReadable <= 399))
        {
            return State.GA;
        }
        else if (humanReadable >= 320 && humanReadable <= 349)
        {
            return State.FL;
        }
        else if (humanReadable >= 350 && humanReadable <= 369)
        {
            return State.AL;
        }
        else if (humanReadable >= 370 && humanReadable <= 385)
        {
            return State.TN;
        }
        else if (humanReadable >= 386 && humanReadable <= 397)
        {
            return State.MS;
        }
        else if (humanReadable >= 400 && humanReadable <= 429)
        {
            return State.KY;
        }
        else if (humanReadable >= 430 && humanReadable <= 459)
        {
            return State.OH;
        }
        else if (humanReadable >= 460 && humanReadable <= 479)
        {
            return State.IN;
        }
        else if (humanReadable >= 480 && humanReadable <= 499)
        {
            return State.MI;
        }
        else if (humanReadable >= 500 && humanReadable <= 529)
        {
            return State.IA;
        }
        else if (humanReadable >= 530 && humanReadable <= 549)
        {
            return State.WI;
        }
        else if (humanReadable >= 550 && humanReadable <= 569)
        {
            return State.MN;
        }
        else if (humanReadable >= 570 && humanReadable <= 579)
        {
            return State.SD;
        }
        else if (humanReadable >= 580 && humanReadable <= 589)
        {
            return State.ND;
        }
        else if (humanReadable >= 590 && humanReadable <= 599)
        {
            return State.MT;
        }
        else if (humanReadable >= 600 && humanReadable <= 629)
        {
            return State.IL;
        }
        else if (humanReadable >= 630 && humanReadable <= 659)
        {
            return State.MO;
        }
        else if (humanReadable >= 660 && humanReadable <= 679)
        {
            return State.KS;
        }
        else if (humanReadable >= 680 && humanReadable <= 699)
        {
            return State.NE;
        }
        else if (humanReadable >= 700 && humanReadable <= 715)
        {
            return State.LA;
        }
        else if (humanReadable >= 716 && humanReadable <= 729)
        {
            return State.AR;
        }
        else if (humanReadable >= 730 && humanReadable <= 749)
        {
            return State.OK;
        }
        else if (humanReadable >= 750 && humanReadable <= 799)
        {
            return State.TX;
        }
        else if (humanReadable >= 800 && humanReadable <= 819)
        {
            return State.CO;
        }
        else if (humanReadable >= 820 && humanReadable <= 831)
        {
            return State.WY;
        }
        else if (humanReadable >= 832 && humanReadable <= 839)
        {
            return State.ID;
        }
        else if (humanReadable >= 840 && humanReadable <= 849)
        {
            return State.UT;
        }
        else if (humanReadable >= 850 && humanReadable <= 869)
        {
            return State.AZ;
        }
        else if (humanReadable >= 870 && humanReadable <= 889)
        {
            return State.NM;
        }
        else if (humanReadable >= 890 && humanReadable <= 899)
        {
            return State.NV;
        }
        else if (humanReadable >= 900 && humanReadable <= 966)
        {
            return State.CA;
        }
        else if (humanReadable >= 967 && humanReadable <= 969)
        {
            return State.HI;
        }
        else if (humanReadable >= 970 && humanReadable <= 979)
        {
            return State.OR;
        }
        else if (humanReadable >= 980 && humanReadable <= 994)
        {
            return State.WA;
        }
        else if (humanReadable >= 995 && humanReadable <= 999)
        {
            return State.AK;
        }
        else
        {
            return State.NotFound;
        }
    }

    //returns the Belt a package with zip should be sorted to
    public static Belt sort(int zip)
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

    //check if package is an exception
    public static bool checkIfException(int fullZip)
    {
        //Check if fullZip is in list of exceptions
        return false;
    }

    public Package()
    {
        humanReadable = randomHumanReadable();
        state = findStateFromHumanReadable(humanReadable);
        exception = checkIfException(fullZip);
        belt = sort(humanReadable);
    }

    public Package(int low, int high)
    {
        humanReadable = randomHumanReadable(low, high);
        state = findStateFromHumanReadable(humanReadable);
        exception = checkIfException(fullZip);
        belt = sort(humanReadable);
    }

}