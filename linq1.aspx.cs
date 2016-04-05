using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Linq;
using System.Data.OleDb;
using System.Data;

public partial class linq1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmdGet_Click(object sender, EventArgs e)
    {
        //need to fix this part!!!
        TabelFactory myTable = new TabelFactory();
        //create CLOSED connection instance
        string path = Server.MapPath("/");
        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + path + "App_Data\\Nwind.mdb"; //driver detail , path to the DB file !!Quiz4!!
        OleDbConnection conn = new OleDbConnection(connStr);
        //create main entry point for Linq to Sql framework !!Quiz4!!
        DataContext dc = new DataContext(conn);
        //create Generic LINQ table
        Table<entitySuppliers> table = dc.GetTable<entitySuppliers>();
        //creaet LINQ query
        IQueryable<entitySuppliers> query =
            from row in table
            where row.SupplierID == Convert.ToInt32(txtSid.Text)
            select row;

        //iterate through query
        foreach (entitySuppliers row in query)
        {
            DataRow dr = myTable.NewRow();
            dr["SupplireID"] = row.SupplierID;
            dr["CompanyName"] = row.CompanyName;
            dr["City"] = row.City;
            dr["Country"] = row.Country;
            myTable.Rows.Add(dr);
        }
        //bind and display
        //DataSource may be query, linq table or DataTable
        GridView1.DataSource = myTable;
        GridView1.DataBind();
    }
}