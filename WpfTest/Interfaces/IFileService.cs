﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTest.Interfaces
{
    public interface IFileService
    {
        List<string> Open(string filename);
    }
}