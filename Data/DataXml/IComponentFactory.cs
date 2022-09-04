using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IComponentFactory
{
    public object Create(InputParams parameters, ComponentModel Parent, global::ReportItem Root);
}