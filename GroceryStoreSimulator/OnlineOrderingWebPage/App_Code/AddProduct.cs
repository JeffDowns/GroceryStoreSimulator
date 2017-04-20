/*
 * Group Project for IT3047
 * Bill Nicholson
 * nicholdw@ucmauil.uc.edu
 * 
 * /***********************************************************************************************************************************************************************************************
 * Assignment 12
 * Jake Reilman (reilmajb@mail.uc.edu) and Justin Meyer (meyer3js@mail.uc.edu)
 * IT3047C Web Server App Dev
 * Due Date: 4/19/2017
 *
 **********************************************************************************************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for AddProduct
/// </summary>
public class AddProduct
{
    public AddProduct()
    {

    }
    public void addProduct(TextBox qty, ListBox orderList)
    {
        ListItem productAndQty = new ListItem(orderList.SelectedItem.Text.PadRight(1, ':').PadRight(10, ' ') + qty.Text);
        orderList.Items.Add(productAndQty);
    }
}