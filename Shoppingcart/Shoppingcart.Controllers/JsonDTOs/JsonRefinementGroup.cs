using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Controllers.JsonDTOs
{
    public class JsonRefinementGroup
    {
        public int GroupId { get; set; }
        public int[] SelectedRefinements { get; set; }
    }
}
