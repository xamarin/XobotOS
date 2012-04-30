#include <SkWindow.h>
#include <SkBitmap.h>
#include <SkCanvas.h>

class XobotWindow;

typedef void (*OnDrawFunc)(SkCanvas *canvas);

extern "C" {

	__declspec(dllexport)
	int libxobotos_init(void);

	__declspec(dllexport)
	XobotWindow *libxobotos_window_new(HWND wnd, OnDrawFunc on_draw);

	__declspec(dllexport)
	bool libxobotos_window_event(XobotWindow *window, HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);

}

#pragma once
class XobotWindow : private SkOSWindow
{
public:
	XobotWindow(HWND hwnd, OnDrawFunc on_draw);
	~XobotWindow();
	friend bool libxobotos_window_event(XobotWindow *window, HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);
protected:
	void onDraw(SkCanvas *canvas);
	bool wndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);
private:
	OnDrawFunc on_draw;
};

