﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APICore.DataModelService
{
    public class CartModel
    {
        public int ItemCount { get; set; }

        public IList<CourseModel> Courses { get; set; }
    }
}
