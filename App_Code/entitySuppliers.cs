using System;
using System.Collections.Generic;
using System.Linq;


using System.Data;
using System.Data.Linq.Mapping;

//class represents SCHEMA for retrived data
//stores data for 1 ROW !!!!!!!!!!!!!!!!!!!
//class MUST be MAPPED to database table
[Table (Name="Suppliers")]
public class entitySuppliers
{
	//create private field for each column
    private int _supplierID;
    private string _companyName;
    private string _city;
    private string _country;

    //map each property as a COLUMN
    [Column(IsPrimaryKey = true, Storage = "_supplierID")]
    public int SupplierID
    {
        get
        {
            return _supplierID;
        }
        set
        {
            _supplierID = value;
        }
    }

    [Column(Storage = "_companyName")]
    public string CompanyName
    {
        get
        {
            return _companyName;
        }
        set
        {
            _companyName = value;
        }
    }

    [Column(Storage = "_city")]
    public string City
    {
        get
        {
            return _city;
        }
        set
        {
            _city = value;
        }
    }

    [Column(Storage = "_country")]
    public string Country
    {
        get
        {
            return _country;
        }
        set
        {
            _country = value;
        }
    }
}