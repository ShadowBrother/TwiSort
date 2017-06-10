using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;

public class DatabaseInitialization : MonoBehaviour {

    //private IDbConnection dbcon;
    //private IDbCommand dbcmd;

    private SqliteConnection sqlcon;
    private SqliteCommand sqlcmd;



    public Text textBox;

	// Use this for initialization
	void Start () {
        
     

	}

    //dbTest tests reading/writing to a db
   public void dbTest()
    {

        //set up connection to database
        string con = "URI=file:" + Application.dataPath + "/Databases/TwiSort";//path to db
        Debug.Log(con);
        sqlcon = new SqliteConnection(con);
        sqlcon.Open();
        sqlcmd = sqlcon.CreateCommand();

        string sqlQuery = "SELECT HR, sort From [2Day]";
        string sqlInsert = "INSERT INTO [2Day](HR, sort) VALUES(270, 'BottomGreen')";

        sqlcmd.CommandText = sqlQuery;
        SqliteDataReader reader = sqlcmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                textBox.text += reader[0] + "\n";
            }
        }
        else
        {
            Debug.Log("No rows Found.");
            reader.Close();
            sqlcmd.CommandText = sqlInsert;
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = sqlQuery;
            reader = sqlcmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    textBox.text += reader[0] + "\n";
                }
            }
            else
            {
                textBox.text = "Something's wrong!";
            }
        }
        reader.Close();
    }
	

    public void twiInit()
    {
        //initialize twi database
        string con = "URI=file:" + Application.dataPath + "/Databases/TwiSort";//path to db
        
        sqlcon = new SqliteConnection(con);
        sqlcon.Open();
        sqlcmd = sqlcon.CreateCommand();

        //delete and repopulate tables
        sqlcmd.CommandText =
            "DELETE FROM FullZipExceptions; ";
        sqlcmd.ExecuteNonQuery();



        sqlcmd.Dispose();
        sqlcmd = null;
        sqlcon.Close();
        sqlcon = null;

    }

	// Update is called once per frame
	void Update () {
		
	}

    //Clean up
    private void OnDestroy()
    {
        sqlcmd.Dispose();
        sqlcmd = null;
        sqlcon.Close();
        sqlcon = null;
    }
}