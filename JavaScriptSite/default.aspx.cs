using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ListItemCollection lic = new ListItemCollection(); // list(array) of listitem
        ListItem[] li = new ListItem[1]; // primitive array of type listitem
        List<ListItem> thisli = new List<ListItem>(); // list(array) of type listitem

        // used to create connection to the database
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBString"].ConnectionString))
        {
            conn.Open(); // opens the connection to the databases
            // creates command(s) with parameters of the table
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Production.Product(NOLOCK);", conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())// executes the select comm and stores the results in the reader(table)
                {
                    if (reader.HasRows) // makes sure it has records
                    {
                        while (reader.Read()) // loops through all of the results until their are none
                        {
                            // reader["COLUMN_NAME"].tostring is the current tables record column value being made (or converted) into a string
                            // reader[0].tostring is the current table reccord column index value being made (or converted) into a string
                            lic.Add(new ListItem(reader["Name"].ToString(), reader[0].ToString())); // adds a record to the list collection
                        }
                    }
                }
            }
        }

        ddlErrorInformation.DataSource = lic; // sets the asp.net(drop down list) list source to the listitemcollection list
        ddlErrorInformation.DataTextField = "text"; // sets the text field that is displayed to the user to the text field of the listitem
        ddlErrorInformation.DataValueField = "value"; // sets the <option value=''> to the values from the listitem
        ddlErrorInformation.DataBind(); // sets it in stone
    }
}