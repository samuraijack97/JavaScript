using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public static class Database
{
    private static string _connection = null;

    public static string Connection
    {
        get
        {
            if (_connection == null)
            {
                Connection = ConfigurationManager.ConnectionStrings["DBString"].ConnectionString;
            }
            return _connection;
        }
        private set { _connection = value; }
    }

    /// <summary>
    /// Executes an sql statement and fills a list of type listitemcollect(object array of type listitem) with the text and value fields you specify
    /// </summary>
    /// <param name="sql">The sql statement to execute ('select * from table_name')</param>
    /// <param name="text">The column you want to be displayed as text in a drop down menu</param>
    /// <param name="value">The column you want to be displayed as value in a drop down menu</param>
    /// <returns>The filled listtemcollection</returns>
    public static ListItemCollection ExecuteSQL(string sql = "", string text = "", string value = "")
    {
        return ExecuteSQL(sql, text, value, null);
    }

    /// <summary>
    /// Executes an sql statement and fills a list of type listitemcollect(object array of type listitem) with the text and value fields you specify
    /// </summary>
    /// <param name="sql">The sql statement to execute ('select * from table_name')</param>
    /// <param name="text">The column you want to be displayed as text in a drop down menu</param>
    /// <param name="value">The column you want to be displayed as value in a drop down menu</param>
    /// <param name="parameters">The list of type sqlparameter, an object that holds a filter id and value, for the sql statement ('select * from table_name where column_name = value')</param>
    /// <returns>The filled listtemcollection</returns>
    public static ListItemCollection ExecuteSQL(string sql = "", string text = "", string value = "",
        List<SqlParameter> parameters = null)
    {
        ListItemCollection lic = new ListItemCollection(); // the list to be filled and returned
        using (SqlConnection conn = new SqlConnection(Connection))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    // if there are parameters(filters) then add them to the command object
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows) // if there are returned records from the database
                    {
                        while (reader.Read()) // loop through all the records till there are no more
                        {
                            // adding a record value to the list by creating a new listitem that takes a string text and string value in the constructor and adding that to the list collection
                            // reader is an object that contains all the rows and for each row it has a column and that column value is an object type. in this instance we are casting it to
                            // string by using .ToString()
                            // you are getting the column by doing reader["column_name"]
                            lic.Add(new ListItem(reader[text].ToString(),
                                reader[value].ToString()));
                        }
                    }
                }
            }
        }

        return lic; // returning list
    }

    // List<string> columnNames is a non primitive array columnNames.Count
    // string[] columnNames is a primitive array columnNames.Length
    /// <summary>
    /// Exxecutes a SQL statement that fills a list will all of the columns that are passed in
    /// </summary>
    /// <param name="sql">The sql statement to execute</param>
    /// <param name="columnNames">The columns to retreive from the data</param>
    /// <returns></returns>
    public static List<List<string>> ExecuteSQL(string sql, List<string> columnNames)
    {
        return ExecuteSQL(sql, columnNames, null);
    }

    public static List<List<string>> ExecuteSQL(string sql, List<string> columnNames,
        List<SqlParameter> parameters)
    {
        // multi-dimensional array [[], [], [], ....]
        List<List<string>> records = new List<List<string>>();
        using (SqlConnection conn = new SqlConnection(Connection))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // list that holds the column values for the current row
                            List<string> columnValues = new List<string>();

                            // loops through all of the columns that we want to pull data from
                            foreach (var column in columnNames)
                            {
                                // adds the column value to the list
                                columnNames.Add(reader[column].ToString());
                            }

                            // adds this whole current records values to list of records
                            records.Add(columnValues);
                        }
                    }
                }
            }
        }

        return records;
    }

    /// <summary>
    /// Executes a stored procedure without returning a value
    /// </summary>
    /// <param name="procedureName">The procedure name to execture</param>
    public static void ExecuteStoredProcedure(string procedureName)
    {
        using (SqlConnection conn = new SqlConnection(Connection))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(procedureName, conn))
            {
                // tell the command what type of command you want to execute. in this case stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // executing the procedure without getting results back (nonquery means no select)
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static object ExecuteSQL(string sql, params SqlParameter[] sqlParameters)
    {
        using (SqlConnection conn = new SqlConnection(Connection))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (sqlParameters != null)
                {
                    cmd.Parameters.AddRange(sqlParameters);
                }

                return cmd.ExecuteScalar();
            }
        }
    }
}