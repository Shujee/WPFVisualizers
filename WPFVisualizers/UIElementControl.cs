using System.Windows.Forms;
using System.Windows.Media;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Windows;

[assembly: System.Diagnostics.DebuggerVisualizer(
  typeof(WPFVisualizers.UIElementVisualizer),
  typeof(WPFVisualizers.XamlObjectSource),
  Target = typeof(UIElement),
  Description = "WPF Visualizer (UIElement)")]
namespace WPFVisualizers
{
  public partial class UIElementControl : Control, IXamlContainer
  {
    public UIElementControl()
    {
      InitializeComponent();
    }

    public object XamlContent
    {
      set
      {
        elementHost1.Child = new System.Windows.Controls.Viewbox()
        {
          Child = value as UIElement,
          StretchDirection = System.Windows.Controls.StretchDirection.DownOnly,
          Stretch = System.Windows.Media.Stretch.Uniform
        };
      }
    }
  }

  public class UIElementVisualizer : VisualizerBase<UIElement, UIElementControl>
  {
    public static void TestShowVisualizer(object objectToVisualize)
    {
      VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(UIElementVisualizer), typeof(XamlObjectSource));
      visualizerHost.ShowVisualizer();
    }
  }
}