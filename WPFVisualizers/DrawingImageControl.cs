using System.Windows.Forms;
using System.Windows.Media;
using Microsoft.VisualStudio.DebuggerVisualizers;

[assembly: System.Diagnostics.DebuggerVisualizer(
  typeof(WPFVisualizers.DrawingImageVisualizer),
  typeof(WPFVisualizers.XamlObjectSource),
  Target = typeof(DrawingImage),
  Description = "WPF Visualizer (DrawingImage)")]
namespace WPFVisualizers
{
  public partial class DrawingImageControl : Control, IXamlContainer
  {
    public DrawingImageControl()
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

  public class DrawingImageVisualizer : VisualizerBase<DrawingImage, DrawingImageControl>
  {
    public static void TestShowVisualizer(object objectToVisualize)
    {
      VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(DrawingImageVisualizer), typeof(XamlObjectSource));
      visualizerHost.ShowVisualizer();
    }
  }
}