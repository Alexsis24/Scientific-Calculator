﻿#if WINDOWS
	using Microsoft.UI;
	using Microsoft.UI.Windowing;
	using Microsoft.Graphics;
#endif

namespace Scientific_Calculator;

public partial class App : Application
{
	const int WindowsWidth = 540;
	const int WindowsHeight = 1000;
	
	public App()
	{
		InitializeComponent();


		#if WINDOWS
			Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
			{			
				var mauiWindow = handler.VirtualView;
				var nativeWindow = handler.PlatformView;
				nativeWindow.Activate();
				IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
				WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
				AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
				appWindow.Resize(new SizeInt32(WindowsWidth, WindowsHeight));			
			});
		#endif


		MainPage = new AppShell();
	}
}