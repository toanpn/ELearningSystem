﻿using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.Repository
{
    public interface ITestRepository : IGenericRepository<Test>
    {
        Test GetTestByChapter(int id);
    }
}
