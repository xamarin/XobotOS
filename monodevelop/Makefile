BUILDDIR = $(CURDIR)/../build/Debug
TARGET = /work/INSTALL
ARCH = x86_64
INSTALL = install

all: install

mpack_file = MonoDevelop.XobotOS.XobotOS_0.1.mpack
script_sources = XobotOS.pc.in setenv.sh.in XobotOS.config.in

install: XobotOS.pc setenv.sh $(mpack_file) XobotOS.exe.config $(script_sources)
	$(INSTALL) -d $(TARGET)/XobotOS
	$(INSTALL) XobotOS.pc $(TARGET)
	$(INSTALL) setenv.sh $(TARGET)
	$(INSTALL) $(mpack_file) $(TARGET)
	$(INSTALL) $(BUILDDIR)/XobotOS.exe $(TARGET)
	$(INSTALL) XobotOS.exe.config $(TARGET)
	$(INSTALL) $(BUILDDIR)/libxobotos.so $(TARGET)/libxobotos-$(ARCH).so
	$(INSTALL) $(BUILDDIR)/xorpt $(TARGET)/XobotOS
	$(INSTALL) $(BUILDDIR)/msbuild/framework-res.apk $(TARGET)/XobotOS
	$(INSTALL) $(BUILDDIR)/MonoDevelop.XobotBinding.dll $(TARGET)/XobotOS
	$(INSTALL) $(BUILDDIR)/msbuild/XobotOS.targets $(TARGET)/XobotOS

$(mpack_file):
	mdtool setup pack $(BUILDDIR)/XobotBinding.addin.xml

XobotOS.pc: XobotOS.pc.in
	sed -e 's%@TARGET@%$(TARGET)%g' $< > $@

setenv.sh: setenv.sh.in
	sed -e 's%@TARGET@%$(TARGET)%g' $< > $@

XobotOS.exe.config: XobotOS.config.in
	sed -e 's%@ARCH@%$(ARCH)%g' $< > $@

