#include "XobotWindow.h"
#include <SkGraphics.h>

XobotWindow::XobotWindow(HWND hwnd, OnDrawFunc on_draw) : SkOSWindow(hwnd)
{
	this->on_draw = on_draw;
	this->setConfig(SkBitmap::kARGB_8888_Config);
	this->setVisibleP(true);
	this->setClipToBounds(true);
}

XobotWindow::~XobotWindow()
{
}

void XobotWindow::onDraw(SkCanvas *canvas)
{
	on_draw(canvas);
	SkOSWindow::onDraw(canvas);
}

bool XobotWindow::wndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	return SkOSWindow::wndProc(hWnd, message, wParam, lParam);
}

int libxobotos_init(void)
{
	SkGraphics::Init();
	SkEvent::Init();
	return 0;
}

XobotWindow *libxobotos_window_new(HWND hwnd, OnDrawFunc on_draw)
{
	return new XobotWindow(hwnd, on_draw);
}

bool libxobotos_window_event(XobotWindow *window, HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	return window->wndProc(hWnd, message, wParam, lParam);
}
