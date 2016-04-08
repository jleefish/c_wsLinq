using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//=====================
using System.Data.Linq.Mapping;
//=====================

[Table (Name = "tUsers")]
public class entityUsers
{
    private string _uname;
    private string _pword;

    //new constructor, no arg first then with arg!!
    public entityUsers()
    {

    }
    public entityUsers(string un, string pw)
    {
        Username = un;
        Password = pw;
    }

    //set primary key!! essential!!
    [Column(IsPrimaryKey = true, Storage = "_uname")]
    public string Username
    {
        get
        {
            return _uname;
        }
        set
        {
            _uname = value;
        }

    }

    [Column(Storage = "_pword")]
    public string Password
    {
        get
        {
            return _pword;
        }
        set
        {
            _pword = value;
        }
    }
}