using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CytoSNPToAffymetrix
{
    public partial class Form1 : Form
    {
        Dictionary<int, SNPData[]> data = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReferenceFile_Click(object sender, EventArgs e)
        {
            string filename = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Select the manifest file", "*.csv|*.csv");
            if (System.IO.File.Exists(filename)== false) { return; }

            string formText = Text;
            Text = "Counting SNPs";
            Application.DoEvents();

            System.IO.StreamReader fs = null;
            try
            {
                fs = new System.IO.StreamReader(filename);
                int[] counts = new int[27];
                string line = null;
                while (fs.Peek() > 0)
                {
                    line = fs.ReadLine();
                    if (line.StartsWith("rs") == true)
                    {
                        SNPData s = new SNPData(line);
                        if (s.Good== true)
                        { counts[s.Chromosome]++; }
                    }
                } 
                
                ResetDataObject(counts);
                counts = new int[27];

                fs = new System.IO.StreamReader(filename);
                Text = "Storing SNPs";
                Application.DoEvents();

                while (fs.Peek() > 0)
                {
                    line = fs.ReadLine();
                    if (line.StartsWith("rs") == true)
                    {
                        SNPData s = new SNPData(line);
                        if (s.Good == true)
                        {                            
                            data[s.Chromosome][counts[s.Chromosome]] = s;
                            counts[s.Chromosome]++;
                        }
                    }
                }
                Text = "Sorting SNPs";
                Application.DoEvents();

                SNPData_Sorter SDS = new SNPData_Sorter();
                foreach(SNPData[] SD in data.Values)
                {
                    Array.Sort(SD, SDS);
                }
                Text = formText;

                btnDataFolder.Enabled = true;
            }
            catch(Exception ex)
            { }
            finally
            { if (fs != null) { fs.Close(); } }
            
        }

        private void ResetDataObject(int[] counts)
        {
            data = new Dictionary<int, SNPData[]>();
            for (int index = 1; index < 26; index++)
            {
                SNPData[] chromoData = new SNPData[counts[index]] ;
                data.Add(index, chromoData);
            }
        }

        private void btnDataFolder_Click(object sender, EventArgs e)
        {
            string folderName = FileAccessClass.FileString(FileAccessClass.FileJob.Directory, "Select the folder containing the cytoSNP dtat files", "");
            if (System.IO.Directory.Exists(folderName) == false) { return; }

            string[] files = System.IO.Directory.GetFiles(folderName, "*.csv");
            if (files.Length == 0)
            {
                MessageBox.Show("No *.csv files in the selected foled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (string f in files)
            { MakeXLSFile(f); }

        }

        private void MakeXLSFile(string fileName)
        {

            System.IO.StreamReader fs = null;

            string resultsFilename = fileName.Substring(0, fileName.Length - 3) + "xls";
            System.IO.StreamWriter fw = null;

            try 
            {
                fs = new System.IO.StreamReader(fileName);
                fw = new System.IO.StreamWriter(resultsFilename);

                fw.WriteLine("SNP Index\tSNP ID\tdbSNP RS ID\tChromosome\tPhysical Position\tCall");

                string line = null;
                string[] items = null;

                SNPData_Search SDS = new SNPData_Search();

                line = fs.ReadLine();
                int[] indexes = GetIndexes(line);
                int runningCount = 1;
                while (fs.Peek()>0)
                { 
                    line = fs.ReadLine();
                    items = line.Split(',');
                    int chromosome = GetChromosome(items[indexes[5]]);
                    if (data.ContainsKey(chromosome) == true)
                    {
                        int index = Array.BinarySearch(data[chromosome], items[indexes[4]],SDS);

                        if (index > -1)
                        {
                            SNPData sd = data[chromosome][index];
                            string call = GetCall(items, indexes);
                            //"SNP Index\tSNP ID\tdbSNP RS ID\tChromosome\tPhysical Position\tCall"
                            fw.WriteLine(runningCount.ToString() + "\t" + sd.Name + "\t" + sd.Name + "\t" + GetChromosomename(chromosome) + "\t" + sd.Location + "\t" + GetCall(items, indexes));
                            runningCount++;
                        }
                    }
                }

            
            }
            catch (Exception ex) { }
            finally
            {
                if (fs != null) { fs.Close(); }
                if (fw != null) { fw.Close(); }
            }
        }

        private int[] GetIndexes(string line)
        {
            int[] indexes = new int[6];
            line = line.ToLower();
            string[] items = line.Split(',');

            bool i = items[1].Contains("name");

            for (int index = 0;index < items.Length;index++)
            {
                switch (items[index])
                {
                    case "call freq":
                        {
                            indexes[0] = index;
                            break;
                        }
                    case "aa freq":
                        {
                            indexes[1] = index;
                            break;
                        }
                    case "ab freq":
                        {
                            indexes[2] = index;
                            break;
                        }
                    case "bb freq":
                        {
                            indexes[3] = index;
                            break;
                        }
                    case "name":
                        {
                            indexes[4] = index;
                            break;
                        }
                    case "chr":
                        {
                            indexes[5] = index;
                            break;
                        }
                }
            }
       
            
            return indexes;
        }

        private string GetChromosomename(int chromosome)
        {
            if (chromosome==24)
            { return "X"; }
            else if (chromosome==25)
            { return "Y"; }
            else
            { return chromosome.ToString(); }
        }

        private int GetChromosome(string chromo)
        {
            try
            {
                if (chromo == "X")
                { return 24; }
                else if (chromo == "Y")
                { return 25; }
                else
                { return Convert.ToInt32(chromo); }
            }
            catch
            {
                return 0;
            }
        }

        private string GetCall(string[] items, int[] indexes)
        {
            if (items[indexes[0]] == "1")
            {
                if (items[indexes[1]] == "1")
                { return "AA"; }
                else if (items[indexes[2]] == "1")
                { return "AB"; }
                else if (items[indexes[3]] == "1")
                { return "BB"; }
                else
                { return "NoCall"; }
            }
            else { return "NoCall"; }
        }
    }
}
