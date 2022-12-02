using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.Core.ProjectionSolver;

namespace DependenciesViewer
{
    public class CSProjectSLN : IHasGraph
    {
        public List<CSSolve> Solves = new List<CSSolve>();

        public CSProjectSLN(string slnFilePath) 
        {
            string[] slnFileLines = File.ReadAllLines(slnFilePath);
            foreach (var line in slnFileLines)
            {
                if (line.StartsWith("Project"))
                {
                    string[] split = line.Split(' ');
                    string name = split[2].TrimEnd(',').Trim('"');
                    string path = split[3].TrimEnd(',').Trim('"');
                    Solves.Add(new CSSolve(name, Path.Combine(new FileInfo(slnFilePath).Directory.FullName, path)));
                }
            }
        }

        public Graph GenerateGraph()
        {
            return GraphCombiner.GenerateGraph(Solves);
        }
    }
}
