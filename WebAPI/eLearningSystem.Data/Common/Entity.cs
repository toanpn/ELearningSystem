﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Data.Common
{
    public abstract class BaseEntity    
    {
        public BaseEntity()
        {
            CreateDate = DateTime.Now.ToString("dd/MM/yyyy");
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CreateDate { get; set; }
    }
}
