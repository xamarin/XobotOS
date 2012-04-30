#include <libxobotos.h>
#include <CanvasGlue.h>
#include "XobotWindow.h"
#include <SkGraphics.h>
#include <SkPaint.h>
#include <SkGpuDevice.h>
#include <GL/glx.h>
#include <GL/gl.h>
#include <GL/glu.h>

XobotWindow::XobotWindow(Window window, OnDrawFunc on_draw, bool init_gl) : SkWindow()
{
	this->display = XOpenDisplay(NULL);
	this->window = window;
	this->gc = XCreateGC(display, window, 0, NULL);

	this->on_draw = on_draw;
	this->setConfig(SkBitmap::kARGB_8888_Config);
	this->setVisibleP(true);
	this->setClipToBounds(false);

        gr_render_target = NULL;
        gr_context = NULL;
        gl = NULL;
        null_gr_context = NULL;
        null_gr_render_target = NULL;

	gl_attached = false;
	gl_created = false;

	if (init_gl) {
		// Attempt to create a window that supports GL
		GLint att[] = { GLX_RGBA, GLX_DEPTH_SIZE, 24, GLX_DOUBLEBUFFER,
				GLX_STENCIL_SIZE, 8, None };
		vi = glXChooseVisual(display, DefaultScreen(display), att);
		if (!vi)
			fprintf(stderr, "Failed to initialize OpenGL!\n");

		initialize();
	}
}

XobotWindow::~XobotWindow(void)
{
        SkSafeUnref(gr_render_target);
        SkSafeUnref(gr_context);
        SkSafeUnref(gl);
        SkSafeUnref(null_gr_context);
        SkSafeUnref(null_gr_render_target);
}

bool XobotWindow::attachGL()
{
	if (gl_attached) return true;
	if (!display || !vi) return false;

	if (!gl_created) {
		gl_context = glXCreateContext(display, vi, NULL, GL_TRUE);
		gl_created = true;
		glXMakeCurrent(display, window, gl_context);
		glViewport(0, 0, SkScalarRound(this->width()), SkScalarRound(this->height()));
		glClearColor(0, 0, 0, 0);
		glClearStencil(0);
		glStencilMask(0xffffffff);
		glDisable(GL_SCISSOR_TEST);
		glClear(GL_COLOR_BUFFER_BIT | GL_STENCIL_BUFFER_BIT);
	} else
		glXMakeCurrent(display, window, gl_context);
	gl_attached = true;

	return true;
}

void XobotWindow::detachGL()
{
	if (!display || !gl_attached) return;
	gl_attached = false;
	// Returns back to normal drawing.
	glXMakeCurrent(display, None, NULL);
	// Ensure that we redraw when switching back to raster.
	this->inval(NULL);
}

void XobotWindow::presentGL()
{
	if (display && gl_attached) {
		glXSwapBuffers(display, window);
	}
}

void XobotWindow::onDraw(SkCanvas* canvas)
{
	on_draw(canvas);
	SkWindow::onDraw(canvas);
}

void XobotWindow::resize()
{
	XWindowAttributes windowattr;
	Status ret;

	ret = XGetWindowAttributes(display, window, &windowattr);
	if (ret == 0) {
		fprintf(stderr, "CANNOT GET WINDOW ATTRIBUTES: %d\n", ret);
		return;
	}

	SkWindow::resize(windowattr.width, windowattr.height);

        if (gr_context) {
		attachGL();

		GrPlatformRenderTargetDesc desc;
		desc.fWidth = SkScalarRound(width());
		desc.fHeight = SkScalarRound(height());
		desc.fConfig = kSkia8888_PM_GrPixelConfig;
		GR_GL_GetIntegerv(gl, GR_GL_SAMPLES, &desc.fSampleCnt);
		GR_GL_GetIntegerv(gl, GR_GL_STENCIL_BITS, &desc.fStencilBits);
		GrGLint buffer;
		GR_GL_GetIntegerv(gl, GR_GL_FRAMEBUFFER_BINDING, &buffer);
		desc.fRenderTargetHandle = buffer;

		SkSafeUnref(gr_render_target);
		gr_render_target = gr_context->createPlatformRenderTarget(desc);
        }
        if (NULL != null_gr_context) {
		GrPlatformRenderTargetDesc desc;
		desc.fWidth = SkScalarRound(width());
		desc.fHeight = SkScalarRound(height());
		desc.fConfig = kSkia8888_PM_GrPixelConfig;
		desc.fStencilBits = 8;
		desc.fSampleCnt = 0;
		desc.fRenderTargetHandle = 0;
		null_gr_render_target = null_gr_context->createPlatformRenderTarget(desc);
        }

	if (!size_initialized) {
		if (supportsDeviceType(kGPU_DeviceType))
			device_type = kGPU_DeviceType;
		else
			device_type = kRaster_DeviceType;

		size_initialized = true;
	}
}

static bool convertBitmapToXImage(XImage& image, const SkBitmap& bitmap)
{
	sk_bzero(&image, sizeof(image));

	int bitsPerPixel = bitmap.bytesPerPixel() * 8;
	image.width = bitmap.width();
	image.height = bitmap.height();
	image.format = ZPixmap;
	image.data = (char*) bitmap.getPixels();
	image.byte_order = LSBFirst;
	image.bitmap_unit = bitsPerPixel;
	image.bitmap_bit_order = LSBFirst;
	image.bitmap_pad = bitsPerPixel;
	image.depth = 24;
	image.bytes_per_line = bitmap.rowBytes() - bitmap.width() * bitmap.bytesPerPixel();
	image.bits_per_pixel = bitsPerPixel;
	return XInitImage(&image);
}

void XobotWindow::paint() {
	const SkBitmap& bitmap = getBitmap();
	SkCanvas* canvas = new SkCanvas(bitmap);
	int width = bitmap.width();
	int height = bitmap.height();

	if (!prepareCanvas(canvas))
		return;

	onDraw(canvas);

	if (gr_context) {
		publishCanvas(canvas);
		return;
	}

	XImage image;
	if (!convertBitmapToXImage(image, bitmap))
		return;

	XPutImage(display, window, gc, &image, 0, 0, 0, 0, width, height);
}

bool XobotWindow::wndProc(Window window, uint message, int wParam, int lParam)
{
	if (message == 0x47) { // WM_WINDOWPOSCHANGED
		resize();
		return true;
	}

	if (message == 0x0f) { // WM_PAINT
		paint();
		// Must invoke the parent's handler on Linux.
		return false;
	}

	return false;
}

int libxobotos_init(void)
{
	SkGraphics::Init();
	SkEvent::Init();
	return 0;
}

XobotWindow* libxobotos_window_new(Window window, OnDrawFunc on_draw, bool init_gl)
{
	return new XobotWindow(window, on_draw, init_gl);
}

bool libxobotos_window_event(XobotWindow* window, Window hWnd, uint message, int wParam, int lParam)
{
	return window->wndProc(hWnd, message, wParam, lParam);
}

void
XobotWindow::initialize()
{
        if (!attachGL()) {
		SkDebugf("Failed to initialize GL");
        }
        if (NULL == gl) {
		gl = GrGLCreateNativeInterface();
		GrAssert(NULL == gr_context);
		gr_context = GrContext::Create(kOpenGL_Shaders_GrEngine,
					       (GrPlatform3DContext) gl);
        }
        if (NULL == gr_context || NULL == gl) {
		SkSafeUnref(gr_context);
		SkSafeUnref(gl);
		SkDebugf("Failed to setup 3D");
		detachGL();
        }
        if (NULL == null_gr_context) {
		const GrGLInterface* nullGL = GrGLCreateNullInterface();
		null_gr_context = GrContext::Create(kOpenGL_Shaders_GrEngine,
						    (GrPlatform3DContext) nullGL);
		nullGL->unref();
        }
}

bool
XobotWindow::supportsDeviceType(DeviceType dType)
{
        switch (dType) {
	case kRaster_DeviceType:
	case kPicture_DeviceType: // fallthru
                return true;
	case kGPU_DeviceType:
                return NULL != gr_context && NULL != gr_render_target;
	case kNullGPU_DeviceType:
                return NULL != null_gr_context && NULL != null_gr_render_target;
	default:
                return false;
        }
}

bool
XobotWindow::prepareCanvas(SkCanvas* canvas)
{
        switch (device_type) {
	case kGPU_DeviceType:
		if (gr_context) {
			canvas->setDevice(new SkGpuDevice(gr_context,
							  gr_render_target))->unref();
                } else {
			return false;
                }
                break;
	case kNullGPU_DeviceType:
                if (null_gr_context) {
			canvas->setDevice(new SkGpuDevice(null_gr_context,
							  null_gr_render_target))->unref();
                } else {
			return false;
                }
                break;
	case kRaster_DeviceType:
	case kPicture_DeviceType:
                break;
        }
        return true;
}

void
XobotWindow::publishCanvas(SkCanvas* canvas)
{
        if (gr_context) {
		// in case we have queued drawing calls
		gr_context->flush();
		if (NULL != null_gr_context) {
			null_gr_context->flush();
		}
		if (device_type != kGPU_DeviceType &&
		    device_type != kNullGPU_DeviceType) {
			// need to send the raster bits to the (gpu) window
			gr_context->setRenderTarget(gr_render_target);
			const SkBitmap& bm = getBitmap();
			gr_render_target->writePixels(0, 0, bm.width(), bm.height(),
						     kSkia8888_PM_GrPixelConfig,
						     bm.getPixels(),
						     bm.rowBytes());
		}
		presentGL();
        }
}

GrContext*
XobotWindow::getGrContext(DeviceType dType)
{
        if (kNullGPU_DeviceType == dType) {
		return null_gr_context;
        } else {
		return gr_context;
        }
}
