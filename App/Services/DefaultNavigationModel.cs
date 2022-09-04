

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DefaultNavigationModel: NavigationModel
{
    public DefaultNavigationModel():base()
    { }
    protected  string GetIndex()
    {
        return "/AdminFace/Admin/AdminHome";
    }

    protected  string GetNotFound( )
    {
        return $"/NotFound";
    }

        
}
