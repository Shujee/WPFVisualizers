# WPFVisualizers
A set of debugger visualizers for WPF elements.

Installing the visualizers
==========================
1. Build the WPFVisualizers project (preferrably in Release mode).
2. Go to bin folder and copy WPFVisualizers.dll to %userprofile%\documents\Visual Studio 2015\Visualizers folder.
3. Restart Visual Studio 2015.

You should now see WPF Visualizers in the list of visualizers when you hover your mouse on `DrawingImage` and `UIElement` variables.

Creating a new visualizer
=========================
You can learn how to create a visualizer for a new WPF type by looking into the two sample types already available in the project. The process is as simple as this:

1. Add your visualizer class and inherit it from `VisualizerBase`.
2. Specify the WPF type that you're targeting as the first generic parameter of the class.
3. Specify the name of the Form / Control that will constitute the UI of your visualizer as the second generic parameter of the class.
4. Design your Control / Form. For WPF types, you'll want to place an `ElementHost` control to host your WPF object (Visual Studio only supports WinForms Form or Control (and not WPF Window or Control) as the main container of your visualizer).
