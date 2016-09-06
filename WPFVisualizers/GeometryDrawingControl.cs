using System.Windows.Forms;
using System.Windows.Media;
using Microsoft.VisualStudio.DebuggerVisualizers;

[assembly: System.Diagnostics.DebuggerVisualizer(
  typeof(WPFVisualizers.GeometryDrawingVisualizer),
  typeof(WPFVisualizers.XamlObjectSource),
  Target = typeof(DrawingImage),
  Description = "WPF Visualizer (GeometryDrawing)")]
namespace WPFVisualizers
{
  public partial class GeometryDrawingControl : Control, IXamlContainer
  {
    public GeometryDrawingControl()
    {
      InitializeComponent();
    }

    public object XamlContent
    {
      set
      {
        elementHost1.Child = new System.Windows.Controls.Viewbox()
        {
          Child = new System.Windows.Controls.Image()
          {
            Source = value as DrawingImage,
            Stretch = Stretch.None,
            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch
          },
          StretchDirection = System.Windows.Controls.StretchDirection.DownOnly,
          Stretch = System.Windows.Media.Stretch.Uniform
        };
      }
    }
  }

  public class GeometryDrawingVisualizer : VisualizerBase<GeometryDrawing, GeometryDrawingControl>
  {
    public static void TestShowVisualizer(object objectToVisualize)
    {
      VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(GeometryDrawingVisualizer), typeof(XamlObjectSource));
      visualizerHost.ShowVisualizer();
    }
  }
}