using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data
{
    public enum MovieCategory
    {
        Action = 1, //By default, action will have a value of 0. If we were to give Action a value of 1, then the rest of these categories will have values of 2,3,4,5 etc. Note that they are also used as start indexes for identifiers
        Comedy, //2
        Drama, //3
        Documentary, //4 
        Cartoon, //5
        Horror //6
    }
}
