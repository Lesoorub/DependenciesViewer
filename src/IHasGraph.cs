using Microsoft.Msagl.Drawing;

namespace DependenciesViewer
{
    public interface IHasGraph
    {
        Graph GenerateGraph();
    }
}