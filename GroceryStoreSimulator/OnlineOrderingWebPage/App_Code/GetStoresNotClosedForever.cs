/*********************************************************
Web Server App Dev
4/19/2017
Tom Martin
Jeff Downs

Group Assignment
Get Stores that are not closed forever
**********************************************************/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for GetStoresNotClosedForever
/// </summary>
public class GetStoresNotClosedForever {


    public GetStoresNotClosedForever() {
    }

    private static SqlDataReader reader;
    SqlCommand comm;
    private static SqlConnection conn;


    private void OpenConnection() {
        //creates a configuration setting object for the connection string
        System.Configuration.ConnectionStringSettings strConn;
        //sets the value of the connections setting object to the connection string
        strConn = ReadConnectionString();

        //initializes the connection object with the value of our connection string
        conn = new System.Data.SqlClient.SqlConnection(strConn.ConnectionString);
        // This could go wrong in so many ways...
        try {
            conn.Open();
        } catch (Exception ex) {
            // Miserable error handling...
            Console.Write(ex.Message);
        }
    }

    /**
     * Returns a settings object that holds the connection string for the database
     */
    private System.Configuration.ConnectionStringSettings ReadConnectionString() {
        //string to store the path so the web.config file
        String strPath;
        strPath = HttpContext.Current.Request.ApplicationPath + "/web.config";

        //creates an object that points to the web.config file
        System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(strPath);

        System.Configuration.ConnectionStringSettings connString = null;

        //if the connection string is present, sets the object to equal the connection string in the web.config file
        if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0) {
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["GroceryStoreSimulator"];
        }

        //returns our connection string settings object
        return connString;
    }




    public void GetAllStoresNotClosedForever(DropDownList ddlLoyaltyNumbers) {
    int storeID;
    string storeName;
        // open the connection
        OpenConnection();
        //a variable to hold stores
        ListItem store;
        comm = new SqlCommand(@"SELECT tStore.StoreID, tStore.Store, tStoreStatus.IsClosedForever
                               FROM tStore INNER JOIN tStoreHistory ON tStore.StoreID = tStoreHistory.StoreID INNER JOIN
                                tStoreStatus ON tStoreHistory.StoreStatusID = tStoreStatus.StoreStatusID", conn);

        try { reader.Close(); } catch (Exception ex) { }
        reader = comm.ExecuteReader();
        while (reader.Read()) {
            //holds the primary key of stores from query         
            storeID = reader.GetInt32(0);
            //hold the store name
            storeName = reader.GetString(1);
            //list to hold the stores 
            store = new ListItem(storeName, storeID.ToString());
            //adds items to the drop down list
            ddlLoyaltyNumbers.Items.Add(store);
        }

    }
}