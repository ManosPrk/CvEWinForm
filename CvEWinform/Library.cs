using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CvECommon;

namespace CvEWinform
{
    public abstract class Library
    {
        internal StreamReader sr;
        public abstract void Set();
        public Library()
        {

        }

    }
}