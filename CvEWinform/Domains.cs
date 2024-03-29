﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CvECommon;

namespace CvEWinform
{
    public class Domains : Library
    {
        static Dictionary<string, string[]> DomainDict;
        public int MaxNumberOfDocs => maxNumberOfDocs;
        private int maxNumberOfDocs;
        private static Domains instance;

        public int currentNumberOfDocs { get; set; }
        
        private Domains()
        {
            var domainLibrary = Path.Combine(Directory.GetCurrentDirectory(), "Data\\domains.csv");
            sr = new StreamReader(domainLibrary);
            DomainDict = new Dictionary<string, string[]>();
            Set();
            setMaxNumberOfDocs();
        }

        public static Domains getInstance()
        {
            if (instance == null)
            {
                instance = new Domains();
            }
            return instance;
        }

        public string[] getDocs(string domain)
        {
            var formatDomain = domain;
            return DomainDict[formatDomain];
        }

        public bool isInputValid(string[] input)
        {
            var isValid = true;
            foreach (string item in input)
            {
                if (!DomainDict.ContainsKey(item) || string.IsNullOrEmpty(item))
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        void setMaxNumberOfDocs()
        {
            foreach (string[] entry in DomainDict.Values)
            {
                if (entry.Length > maxNumberOfDocs)
                {
                    maxNumberOfDocs = entry.Length;
                }
            }
        }

        public override void Set()
        {
            using (sr)
            {
                if (sr.Peek() == -1)
                {
                    MessageBox.Show($"{nameof(Domains)} library is empty, please populate it");
                }
                else
                {
                    while (!sr.EndOfStream)
                    {
                        var domain = sr.ReadLine().Trim();
                        var docs = sr.ReadLine().LineToArray();
                        DomainDict.Add(domain, docs);
                    }
                }

            }
        }
    }
}
