using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TwiSort : MonoBehaviour {

    

    public Package package;//package to sort

    public int zip;//zip code to sort
    public Text textbox;//textbox to display info
    public Text accuracyDisplay;//textbox to display accuracy info
    public int low;//low range for zip
    public int high;//high range for zip

    public int numTries { get; private set; }//Number of zip codes user has tried to sort
    public int numCorrect { get; private set; }//Number of zip codes user has correctly sorted
    public float timeStart { get; private set; }//Time when random zip is shown, for calculating time to sort
    public float timeTotal { get; private set; }//Total time spent sorting, for calculating average time to sort

	// Use this for initialization
	void Start () {
        Debug.Log("Start");
        UnityEngine.Random.seed = (int)Time.time * (int)Time.frameCount;//seed Random
        //Debug.Log(Time.time);
        //Debug.Log(Time.frameCount);
        //Debug.Log(UnityEngine.Random.seed);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Update");
        UnityEngine.Random.seed = (int)Time.time * (int)Time.frameCount;//seed Random
        Debug.Log(Time.time);
        Debug.Log(Time.frameCount);
        Debug.Log(UnityEngine.Random.seed);
    }

    

    //testSort, test to make sure there is a return in sort for each possible zip
    public void testSort()
    {
        for(int i = 10; i <= 999; i++)
        {
            if (Package.sort(i) == Belt.NotFound)
                Debug.Log("No sort found for zip " + i);
        }
    }

    
    //get random Package with human readable between low and high
    public void randomPackage(int low = 10, int high = 999)
    {
        package = new Package(low, high);//create new random package with human readable between low and high
    }


    //button handler for getting random package
    public void randomPackageHandler()
    {
        randomPackage(low, high);//get random zip between low and high
        textbox.GetComponent<Text>().text = "Zip Code: " + package.humanReadable + "  " + package.state.ToString();//show zip code in textbox
        timeStart = Time.time;
    }

    
    //button handler for guessing the belt to sort the package, checks if correct or not and updates displays
    public void guess(string theGuess)
    {


        float timeToGuess = Time.time - timeStart;//calculate how long it took to sort
        timeTotal += timeToGuess;//increment timeTotal

        //Belt answer = Package.sort(zip);
        //if(answer == (Belt)Belt.Parse(typeof(Belt),theGuess))//correct guess
        if((Belt)Belt.Parse(typeof(Belt), theGuess) == package.belt)//correct guess
        {
            textbox.GetComponent<Text>().text = "Correct! " + package.belt.ToString();
            numCorrect++;//increment number of correctly sorted zips
        }
        else
        {
            textbox.GetComponent<Text>().text = "Wrong! Correct Belt was " + package.belt.ToString();
        }

        numTries++;//increment number of zips attempted
        updateAccuracyDisplay();
    }


    //calculate averages and update display
    void updateAccuracyDisplay()
    {
        float averageCorrect = (float)numCorrect / (float)numTries * 100;
        float averageTime = timeTotal / numTries;
        accuracyDisplay.GetComponent<Text>().text = string.Format("Sorting Accuracy: {0}%\n Average time to sort: {1} seconds",averageCorrect, averageTime);
    }
}
