// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;

string nameFromDate(DateTime d)
{
    return d.Year.ToString() + d.Month.ToString("00") + d.Day.ToString("00");
}

string todayName = nameFromDate(DateTime.Now);

string currentDirectory = Directory.GetCurrentDirectory();

// List all files in the current directory
string[] files = Directory.GetFiles(currentDirectory);

// Print the list of files
foreach (string file in files)
{
    FileInfo fileInfo = new FileInfo(file);

    if (fileInfo.Name.Contains("move2date")) continue;

    DateTime created_at = fileInfo.CreationTime;
    string dir_name = nameFromDate( created_at );

    if (todayName == dir_name) continue; // exclude today files

    string dir_full_name = currentDirectory + "/" + dir_name;
    if (!Directory.Exists(dir_full_name)) Directory.CreateDirectory(dir_full_name);
    fileInfo.MoveTo(  dir_full_name + "/" + fileInfo.Name );
}
