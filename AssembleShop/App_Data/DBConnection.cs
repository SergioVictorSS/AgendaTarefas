using AgendaTarefas;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class SDBC
{
    public SDBC()
    { }

    public static MyDBContext Instance
    {
        get
        {
            if (HttpContext.Current.Items["MyDBContext"] == null)
                HttpContext.Current.Items["MyDBContext"] = MyDBContext.Instance();
            return (MyDBContext)HttpContext.Current.Items["MyDBContext"];
        }
    }
}