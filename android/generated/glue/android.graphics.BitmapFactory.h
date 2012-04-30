#ifndef ANDROID_GRAPHICS_BITMAPFACTORY_GLUE_H
#define ANDROID_GRAPHICS_BITMAPFACTORY_GLUE_H 1

#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <BitmapFactoryGlue.h>
#include <AssetManagerGlue.h>
#include "android.graphics.Rect.h"
#include <BitmapGlue.h>

struct Options_Struct;

class Options_Helper
{
public:
	static void unwrap(BitmapFactoryGlue::Options& from, Options_Struct* to);
	static Options_Struct* unwrap(BitmapFactoryGlue::Options* src);
	static void marshalOut(const BitmapFactoryGlue::Options& from, Options_Struct* to);
	static void wrap(const Options_Struct& from, BitmapFactoryGlue::Options* to);
	static BitmapFactoryGlue::Options* wrap(const Options_Struct* src);
	static const BitmapFactoryGlue::Options* wrapConst(const Options_Struct* src);
	static void freeMembers(Options_Struct& obj);
	static void destructor(Options_Struct* obj);

private:
	Options_Helper();

};



#endif
