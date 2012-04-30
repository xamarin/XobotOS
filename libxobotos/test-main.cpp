// -*- c-basic-offset: 8 -*-
#define LOG_TAG "TEST"
#include <AssetManagerGlue.h>
#include <utils/Log.h>
#include <sys/stat.h>
#include <sys/mman.h>
#include <fcntl.h>

class Test
{
public:
	void test_assets();
};

int
main(int, const char* argv[])
{
	Test* test = new Test();
	test->test_assets();
	// AssetManagerGlue::test();
	return -1;
}

void
application_init(void)
{ }

void
application_term(void)
{ }

void
create_sk_window(void*, int, char**)
{ }

static const void*
read_asset(size_t *out_size)
{
	const char* path = "/work/test/XobotOS/android/system-root/framework/framework-res.apk";
	android::Asset* asset;
	size_t size;
	int fd;
	void* map;

	fd = open(path, O_RDONLY);
	size = lseek(fd, 0, SEEK_END);
	lseek(fd, 0, SEEK_SET);

	map = mmap(NULL, size, PROT_READ, MAP_PRIVATE, fd, 0);

	LOGI("READ ASSET: %d,%d - %p\n", fd, size, map);

	*out_size = size;
	return map;
}

void
Test::test_assets()
{
	const void* map;
	size_t size;

	LOGI("Hello World!\n");

	map = read_asset(&size);

	AssetManagerGlue* def = new AssetManagerGlue ();
	const char* path = "/work/test/XobotOS/build/Debug/TestActivity.exe";
	int ok = def->addAssetPath(path);
	def->getResources(true);

	LOGI("READ ASSETS: %d\n", ok);


	LOGI("Read assets: %d\n", def->getGlobalCount());

	const android::ResTable& res = def->getResources(true);
}
