﻿using System;
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
    public partial class Form1 : Form
    {
        MainBody mainbody;
        Library library;
         
        public Form1()
        {
            InitializeComponent();
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Data"));
            var domainsLibrary = Path.Combine(Directory.GetCurrentDirectory(), "Data\\domains.csv");
            using (var stream = File.Open(domainsLibrary, FileMode.OpenOrCreate))
            {
            }
            mainbody = new MainBody();
            library = Library.getInstance();
            numericDoc.Maximum = library.MaxNumberOfDocs;
        }

        private void getText_Click(object sender, EventArgs e)
        {
            
            Run();
        }

        private void numericDoc_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericYearExp_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Run()
        {
            mainbody.NumberOfDocs = (int)numericDoc.Value;
            mainbody.YearsOfExperience = (int)numericYearExp.Value;
            var desiredDomains = domains.Text.LineToArray();
            var header = new Header((int)numericYearExp.Value);
            if (library.isInputValid(desiredDomains))
            {
                finalText.Text = mainbody.getMainBodyText(desiredDomains);
            }
            else
            {
                MessageBox.Show("Please insert at least one valid domain or more separated by comma and space");
            }
            
        }
    }
}
