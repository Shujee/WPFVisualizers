using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.IO;
using System.Windows.Media;

namespace WPFVisualizers
{
  /// <summary>
  /// A Visualizer for WPF Visual.  
  /// </summary>
  public class VisualizerBase<T,U> : DialogDebuggerVisualizer where T:class where U: System.Windows.Forms.Control, IXamlContainer, new()
  {
    protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
    {
      if (windowService == null)
        throw new ArgumentNullException(nameof(windowService));
      if (objectProvider == null)
        throw new ArgumentNullException(nameof(objectProvider));

      using (var stream = objectProvider.GetData())
      {
        using (var xmlReader = System.Xml.XmlReader.Create(stream))
        {
          var DI = System.Windows.Markup.XamlReader.Load(xmlReader);

          using (var displayForm = new U())
          {
            displayForm.XamlContent = DI;
            windowService.ShowDialog(displayForm);
          }
        }
      }
    }
  }

  public class XamlObjectSource : VisualizerObjectSource
  {
    public override void GetData(object target, Stream outgoingData)
    {
      var writer = new StreamWriter(outgoingData);
      System.Windows.Markup.XamlWriter.Save(target, outgoingData);
      writer.Flush();
    }
  }
}