﻿using Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class SalaryVariable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? DisplayName { get; set; }

        [Required]
        [DefaultValue("0")]
        public string? Value { get; set; }

        [Required]
        [DefaultValue(VariableDataType.Number)]
        public VariableDataType DataType { get; set; }
        public string? Description { get; set; }
    }
}
