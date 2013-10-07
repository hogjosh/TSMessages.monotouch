XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
MONOBUILD=/Library/Frameworks/Mono.Framework/Commands/xbuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
ROOT=.
XCODE_PROJECT_ROOT=$(ROOT)
XCODE_PROJECT=$(XCODE_PROJECT_ROOT)/TSMessages.monotouch.xcodeproj
XCODE_TARGET=TSMessages.monotouch
MONO_PROJECT_ROOT=$(ROOT)/TSMessages.binding
MONO_PROJECT=$(MONO_PROJECT_ROOT)/TSMessages.binding.csproj

all: clean TSMessages.dll

libTSMessages.monotouch-i386.a:
	$(XBUILD) -project $(XCODE_PROJECT) -target $(XCODE_TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(XCODE_PROJECT_ROOT)/build/Release-iphonesimulator/lib$(XCODE_TARGET).a $@

libTSMessages.monotouch-ios.a:
	$(XBUILD) -project $(XCODE_PROJECT) -target $(XCODE_TARGET) -sdk iphoneos -configuration Release clean build
	-mv $(XCODE_PROJECT_ROOT)/build/Release-iphoneos/lib$(XCODE_TARGET).a $@

libTSMessages.monotouch.a: libTSMessages.monotouch-i386.a libTSMessages.monotouch-ios.a
	lipo -create -output $@ $^

TSMessages.dll: libTSMessages.monotouch.a
	$(MONOBUILD) /p:Configuration=Release $(MONO_PROJECT)
	-mv $(MONO_PROJECT_ROOT)/bin/Release/TSMessages.dll $(ROOT)

clean:
	-rm -rf build *.a *.dll *.mdb
