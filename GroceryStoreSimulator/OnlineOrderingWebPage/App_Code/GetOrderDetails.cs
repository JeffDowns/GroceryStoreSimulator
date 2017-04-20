using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GetOrderDetails
/// </summary>
public class GetOrderDetails {
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

    // Returns a settings object that holds the connection string for the database
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
    public GetOrderDetails() {
        
        }
    }