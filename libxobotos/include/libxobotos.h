#ifndef LIBXOBOTOS_H
#define LIBXOBOTOS_H

#include <SkRect.h>
#include <SkBitmap.h>
#include <SkCanvas.h>
#include <SkPaint.h>
#include <SkPicture.h>
#include <SkPath.h>
#include <SkMatrix.h>

#include <MarshalHelper.h>
using namespace XobotOS;

#if WINDOWS
#define DLL_EXPORT __declspec(dllexport)
#else
#define DLL_EXPORT
#endif

#endif
