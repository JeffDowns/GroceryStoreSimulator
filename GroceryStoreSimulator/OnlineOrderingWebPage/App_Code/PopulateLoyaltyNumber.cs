/* Richard McDonald & Daniel Kroeger
 * creating a file to generate and populate a DropDownList with Loyalty Numbers



*/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for PopulateLoyaltyNumber
/// </summary>
/// 
// create a sqlDataReader, sqlConnection, and sqlCommand
public class PopulateLoyaltyNumber {
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
            }
        catch (Exception ex) {
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


    int loyaltyID;
    string loyaltyNumber;
    public PopulateLoyaltyNumber() {
        
        }
    // creating a method to populate ddlLoyaltyNumbers
    public void GetLoyaltyNumbers(DropDownList ddlLoyaltyNumbers) {
        // open the connection
        OpenConnection();
        ListItem loyaltyItem;
        comm = new SqlCommand("SELECT LoyaltyID, LoyaltyNumber FROM dbo.tLoyalty", conn);

        try { reader.Close(); } catch(Exception ex) { }
        // use the reader object to execute the query 
        reader = comm.ExecuteReader();
        
        //iterate through the dataset line by line
        while (reader.Read()) {

            // stores the primary key of the LoyaltyNumber
            loyaltyID = reader.GetInt32(0);
            // stores the loyaltyNumber
            loyaltyNumber = reader.GetString(1);
            // create list item with the text and value of the store
            loyaltyItem = new ListItem(loyaltyNumber, loyaltyID.ToString());
            // add the item to the dropDownList
            ddlLoyaltyNumbers.Items.Add(loyaltyItem);
            }

        }
    }