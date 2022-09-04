using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class IntRandomExtensions
{
    private static Random R = new Random();
 
  
    /// <summary>
    /// пример: (2.1f).Floor()
    /// </summary>
    public static int Floor(this float v) => (int)Math.Floor(v);
    public static int Floor(this decimal v) => (int)Math.Floor(v);

    
} 