#if WINDOWS
    using Microsoft.UI;
    using Microsoft.UI.Windowing;
    using Windows.Graphics;
    using WinRT.Interop;
#endif

namespace MonkeyFinder;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

#if WINDOWS
        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
            var mauiWindow = handler.VirtualView;
            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate();
            IntPtr windowHandle = WindowNative.GetWindowHandle(nativeWindow);
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
            AppWindow appWindow = AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new SizeInt32(540, 1000));
        });
#endif

        MainPage = new AppShell();
	}
}
