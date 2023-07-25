CytoSNPToAffymetrix is designed to reformat Illumina cytoSNP 850K microarray SNP genotype data to a format originally used by Affymetrix for their microarray SNP genotype data. The fromat was subsequently replace by their birdseed text file format, however, some applications such as AutoSNPa still use this format.

Requirements:

The Illumina data files for this array don't appear to contain any positional data, consequently, this has to be obtained from a secondary source suce as the linked manifest file (for example: https://emea.support.illumina.com/array/array_kits/cytosnp-850k_beadchip_kit/downloads.html?_gl=1*1fh33tw*_ga*NzI0NzIyNzUyLjE2OTAyNzk0NjI.*_ga_VVVPY8BDYL*MTY5MDI4NDkxOC4yLjEuMTY5MDI4NTA2NC4xMC4wLjA.) 

Data format:

The genotype data must be saved as an Excel CSV text file and conatain the "Name", "Chr", "Call Freq", "AA Freq",	"AB Freq" and	"BB Freq" columns.

Discription:

1) press the 'Manifest' button and select the required manifest file. This file will be read once and the required SNP data in the file retained
2) Press the 'Data' button and select the folder containing all your data files in the "\*.csv" format. The application will then determine the location of each of the required columns and use the RS ID value to link the data row to a SNP in the manifest file. If SNP is found to be located on a chromosome (1-22, X or Y), the application checks the value in the "Call Freq" column, if this is less than one (not all the probes for this SNP gave a result) the SNP will be scored as "No Call". Next the program will check the "AA Freq",	"AB Freq" and	"BB Freq" columns, if one contains the value of "1" a genotype will be given for that SNP. For example if "AA Freq" = 0,	"AB Freq" = 1 and	"BB Freq" = 0, the SNP will be given a genotype call of AB.
3) The SNP data will be saved in a "\*.xls" file with the same name and path as the original "\*.csv" file. 


Precompiled binaries: The repro contains the compiled program (CytoSNPToAffymetrix.exe) which can be downloaded and run on any Windows machine with an uptodate version of the .NET frame work installed. However, Windows will nag you about it been a posible secruity risk: ignore.
