using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

namespace Assets.Script.DB
{
    public class DBmanager
    {
        public static DBmanager instance;
        
        //DB
        IDbConnection connection;
        IDbCommand command;
        IDataReader reader;

        private DBmanager()
        {
            connectDB();
        }

        public static DBmanager getInstance()
        {
            if(instance == null)
            {
                instance = new DBmanager();
            }
            
            return instance;
        }

        public void connectDB()
        {
            connection = new SqliteConnection("URI=file:" + Application.streamingAssetsPath + "/PTP_Database.db");

            if (connection == null) { Debug.Log("connection is null"); return; }
            
            connection.Open();
            
            command = connection.CreateCommand();
        }
        
        // All
        public IDataReader loadDirectory()
        {
            command.CommandText = "SELECT * FROM Character";
            reader = command.ExecuteReader();
            
            return reader;
        }
    }
}