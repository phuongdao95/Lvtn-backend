using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Formula
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Define { get; set; }

        public List<DeductionAllowanceBonusTemplate>? Templates { get; set; }
        public List<Constant>? Constants { get; set; }
        public List<Input>? Inputs { get; set; }
    }
}
