/* Richard McDonald & Daniel Kroeger
// creating a file to generate and populate a DropDownList with Loyalty Numbers



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
public class PopulateLoyaltyNumber {
    private static SqlDataReader reader;
    SqlCommand comm;
    SqlConnection conn = new SqlConnection("GroceryStoreSimulator");
    int loyaltyID;
    string loyaltyNumber;
    public PopulateLoyaltyNumber() {
        
        }
    // creating a method to populate ddlLoyaltyNumbers
    public DropDownList GetLoyaltyNumbers(DropDownList ddlLoyaltyNumbers) {
        ListItem loyaltyItem;
        comm = new SqlCommand("SELECT LoyaltyID, LoyaltyNumber FROM dbo.tLoyalty", conn);

        try {
            reader.Close();
            }
        catch(Exception ex) {
            
            }
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