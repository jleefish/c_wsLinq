using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Linq;
using System.Configuration;
using System.Data.SqlClient;

//1.insert 2.update 3.delete

public partial class linq2 : System.Web.UI.Page
{

    //==============global elements
    DataContext dc = null;
    Table<entityUsers> table = null;
    //==============global elements



    protected void Page_Load(object sender, EventArgs e)
    {
        getData();
        //5.wire up rowCommand event
        GridView1.RowCommand += GridView1_RowCommand;
    }

    //button action in GridView1 row
    void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rowIndex = Convert.ToInt32(e.CommandArgument); //capture index
        txtUName.Text = GridView1.Rows[rowIndex].Cells[0].Text; //reference user name data in grid view
        txtPWord.Text = GridView1.Rows[rowIndex].Cells[1].Text;
    }

    private void getData()
    {
        //1.create closed connection instance
        string connStr = ConfigurationManager.ConnectionStrings["connStr_Users"].ConnectionString;
        SqlConnection conn = new SqlConnection(connStr);
        //2.create main entry point for linq to sql
        dc = new DataContext(conn);
        //3.create generic linq table. dc gets schema and loaded into table with data!!!
        table = dc.GetTable<entityUsers>();
        //4.bind and display
        GridView1.DataSource = table;
        GridView1.DataBind(); // error!!!!
    }

    protected void cmdInsert_Click(object sender, EventArgs e)
    {
        //string sql = "INSERT INTO [tUsers] ([username],[password]) VALUES ('"
        //    + txtUName.Text + "','" + txtPWord.Text + "')";
        //dc.ExecuteCommand(sql);

        //8.new way to insert record
        table.InsertOnSubmit(new entityUsers(txtUName.Text, txtPWord.Text));
        
        //6.update database with object defined by entityUsers class
        dc.SubmitChanges();

        //7.show changes
        getData();
        clearText();
    }
    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        //get matched row to update. query is collection
        IQueryable<entityUsers> query =
            from row in table
            where row.Username.Equals(txtUName.Text)
            //where row.Username.Equals("abc") will make an error
            select row;

        //update selected row....cannot change PrimaryKey value!!!
        foreach (entityUsers row in query)
        {
            row.Username = txtUName.Text;
            row.Password = txtPWord.Text;
        }
        //6.update database with object defined by entityUsers class
        dc.SubmitChanges();

        //7.show changes
        getData();
        clearText();
    }
    protected void cmdDelete_Click(object sender, EventArgs e)
    {
        //get row ot delete
        IQueryable<entityUsers> query =
            from row in table
            where row.Username == txtUName.Text
            select row;

        foreach (entityUsers row in query)
        {
            table.DeleteOnSubmit(row);
        }
        //6.update database with object defined by entityUsers class
        dc.SubmitChanges();

        //7.show changes
        getData();
        clearText();
    }

    private void clearText()
    {
        txtUName.Text = "";
        txtPWord.Text = "";
        txtUName.Focus();
    }
}