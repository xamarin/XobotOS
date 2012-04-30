#ifndef XOBOT_WINDOW_H
#define XOBOT_WINDOW_H

#include <libxobotos.h>
#include <CanvasGlue.h>
#include <SkWindow.h>
#include <SkBitmap.h>
#include <SkCanvas.h>
#include <GrContext.h>
#include <GrGLInterface.h>
#include <X11/Xlib.h>
#include <GL/glx.h>

class XobotWindow;

typedef void (*OnDrawFunc)(SkCanvas* canvas);

extern "C" {

	int libxobotos_init(void);

	XobotWindow* libxobotos_window_new(Window window, OnDrawFunc on_draw, bool init_gl);

	bool libxobotos_window_event(XobotWindow* window, Window hWnd, uint message, int wParam, int lParam);

}

class XobotWindow : private SkWindow
{
public:
	XobotWindow(Window window, OnDrawFunc on_draw, bool init_gl);
	~XobotWindow(void);

	enum DeviceType {
		kRaster_DeviceType,
		kPicture_DeviceType,
		kGPU_DeviceType,
		kNullGPU_DeviceType
	};

	bool wndProc(Window window, uint message, int wParam, int lParam);

protected:
	bool attachGL();
	void detachGL();
	void presentGL();
	void onDraw(SkCanvas* canvas);

	void initialize();

	bool supportsDeviceType(DeviceType dType);

	bool prepareCanvas(SkCanvas* canvas);

	void publishCanvas(SkCanvas* canvas);

	GrContext *getGrContext(DeviceType dType);

private:
	Display* display;
	Window window;
	GC gc;

	XVisualInfo* vi;

	DeviceType device_type;

	GLXContext gl_context;
	bool size_initialized;
	bool gl_attached;
	bool gl_created;

	GrContext* gr_context;
	const GrGLInterface* gl;
	GrRenderTarget* gr_render_target;
	GrContext* null_gr_context;
	GrRenderTarget* null_gr_render_target;

	OnDrawFunc on_draw;

	void resize();
	void paint();
};

#endif
