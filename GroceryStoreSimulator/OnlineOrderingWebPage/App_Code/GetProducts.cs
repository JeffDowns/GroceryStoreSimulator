/*
 * Group Project for IT3047
 * Bill Nicholson
 * nicholdw@ucmauil.uc.edu
 * 
 * /***********************************************************************************************************************************************************************************************
 * Assignment 12
 * Adam Ralston (ralstoat@mail.uc.edu) and Matthew Frank (frankmj@mail.uc.edu)
 * IT3047C Web Server App Dev
 * The purpose of our portion of the assignment was to create a method that returned a list of products based on the store ID passed and store them
 * into a listbox that is also passed to the method.
 * Due Date: 4/19/2017
 *
 **********************************************************************************************************************************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

/// <summary>
/// Defines a template for an object that can utilize a method which returns a list of products for a given store in a given listbox.
/// </summary>
public class GetProducts
{

    private static SqlConnection connection;
    private static SqlCommand command;
    private static SqlDataReader reader;


    // Defines the method to obtain the connection string from the web.config file.
    private System.Configuration.ConnectionStringSettings GetConnectionString(string nameOfString)
    {
        String path;
        // Establishes the path to the file.
        path = "/Web.config";
        // Obtains the connection string.
        System.Configuration.Configuration webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(path);
        // Returns the connection string.
        return webConfig.ConnectionStrings.ConnectionStrings[nameOfString];
    }

    public void GetProductsFromStore(int StoreID, ListBox LbProducts)
    {
        // Opens the connection to the database.
        openConnection();

        // Defines the query.
        string query = "SELECT DISTINCT tProduct.ProductID, tManufacturer.Manufacturer, tBrand.Brand, tName.Name, tProduct.Description" +
                        " FROM tProduct" +
                        " INNER JOIN tProductPriceHist" +
                        " ON tProduct.ProductID = tProductPriceHist.ProductID" +
                        " INNER JOIN tStore" +
                        " ON tStore.StoreID = tProductPriceHist.StoreID" +
                        " INNER JOIN tManufacturer" +
                        " ON tManufacturer.ManufacturerID = tProduct.ManufacturerID" +
                        " INNER JOIN tBrand" +
                        " ON tBrand.BrandID = tProduct.BrandID" +
                        " INNER JOIN tName" +
                        " ON tName.NameID = tProduct.NameID" +
                        " WHERE tStore.StoreID = " + StoreID;

        // Stores the results of the query.
        int id = 0;
        string manufacturer;
        string brand;
        string name;
        string description;
        ListItem item;

        // Establishes the command for the given query on the connection.
        command = new SqlCommand(query, connection);

        // Attempts to read from the database.
        try
        {
            // Reads from the database.
            reader = command.ExecuteReader();

            // Loops through all items that match the query in the database.
            while (reader.Read())
            {
                // Stores the returns.
                id = reader.GetInt32(0);
                manufacturer = reader.GetString(1);
                brand = reader.GetString(2);
                name = reader.GetString(3);
                description = reader.GetString(4);
                item = new ListItem(manufacturer.Trim() + " | " + brand.Trim() + " | " + name.Trim() + " | " + description.Trim(), id.ToString());
                LbProducts.Items.Add(item);

            }

            // Attempts to close the reader.
            try { reader.Close(); }
            // Eats any exceptions if there is an issue closing the reader.
            catch (Exception ex)
            {
            }
        }
        // Eats any exceptions if there was an issue reading from the database.
        catch (Exception ex)
        {

        }
    }


    // Defines the method to open a connection to the database.
    private void openConnection()
    {
        try
        {
            // Creates a connection to the database that can be opened or closed by utilizing the connection string.
            connection = new System.Data.SqlClient.SqlConnection(GetConnectionString("GroceryStoreSimulator").ConnectionString);
            // Opens the connection to execute queries on the database.
            connection.Open();
        }
        // Eats any exceptions.
        catch (Exception ex)
        {

        }

    }
}