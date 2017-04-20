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