using System.Collections.Generic;
using Microsoft.Msagl.Drawing;
using static DependenciesViewer.CSSolve;

namespace DependenciesViewer
{
    public static class GraphCombiner
    {
        public static bool AddLineToNamespace = false;
        public static string LineToNamespaceText = "namespace";
        public static Graph GenerateGraph(IEnumerable<CSSolve> Solves)
        {
            var graph = new Graph()
            {
                Directed = true
            };

            List<Namespace> namespaces = new List<Namespace>();

            foreach (var solve in Solves)
                namespaces.AddRange(solve.ParseNamespaces());

            foreach (var @namespace in namespaces)
            {
                foreach (var @class in @namespace.Classes)
                    graph.AddNode(@class.name);
                if (AddLineToNamespace)
                    graph.AddNode(@namespace.name);

                foreach (var @class in @namespace.Classes)
                {
                    foreach (var extend in @class.extends)
                        graph.AddEdge(@class.name, extend);
                    if (AddLineToNamespace)
                        graph.AddEdge(@class.name, LineToNamespaceText, @namespace.name);
                }


            }

            return graph;
        }
    }
}
