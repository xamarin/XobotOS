#include <RegexMatcherGlue.h>
#include <utils/String16.h>

using namespace android;

RegexMatcher*
RegexMatcherGlue::open(const RegexPattern& pattern)
{
	UErrorCode status = U_ZERO_ERROR;
	return pattern.matcher(status);
}

/**
 * We use ICU4C's RegexMatcher class, but our input is on the Java heap and potentially moving
 * around between calls. This wrapper class ensures that our RegexMatcher is always pointing at
 * the current location of the char[]. Earlier versions of Android simply copied the data to the
 * native heap, but that's wasteful and hides allocations from the garbage collector.
 */
class Accessor
{
public:
	Accessor(RegexMatcher& matcher, const NativeString* input, bool reset)
		: mMatcher(matcher)
	{
		if (!input)
			return;

		mUText = utext_openUChars(NULL, (String16)*input, input->length(), &mStatus);
		if (!mUText)
			return;

		if (reset)
			matcher.reset(mUText);
		else
			matcher.refreshInputText(mUText, mStatus);
        }

	Accessor(RegexMatcher& matcher)
		: mMatcher(matcher)
	{ }

	~Accessor()
	{
		utext_close(mUText);
	}

	UErrorCode& status()
	{
		return mStatus;
	}

	void updateOffsets(NativeArray<int>* offsets)
	{
		if (!offsets)
			return;

		for (size_t i = 0, groupCount = mMatcher.groupCount(); i <= groupCount; ++i) {
			offsets->item(2*i + 0) = mMatcher.start(i, mStatus);
			offsets->item(2*i + 1) = mMatcher.end(i, mStatus);
		}
	}

private:
	RegexMatcher& mMatcher;
	const char16_t* mChars;
	UErrorCode mStatus;
	UText* mUText;

	// Disallow copy and assignment.
	Accessor(const Accessor&);
	void operator=(const Accessor&);
};

bool
RegexMatcherGlue::find(RegexMatcher& matcher, const NativeString* text, int start_idx, NativeArray<int>* offsets)
{
	Accessor accessor(matcher, text, false);
	UBool result = matcher.find(start_idx, accessor.status());
	if (result)
		accessor.updateOffsets(offsets);
	return result;
}

int
RegexMatcherGlue::findNext(RegexMatcher& matcher, const NativeString* text, NativeArray<int>* offsets)
{
	Accessor accessor(matcher, text, false);
	if (accessor.status() != U_ZERO_ERROR)
		return -1;
	UBool result = matcher.find();
	if (result)
		accessor.updateOffsets(offsets);
	return result;
}

int
RegexMatcherGlue::lookingAt(RegexMatcher& matcher, const NativeString* text,NativeArray<int>* offsets)
{
	Accessor accessor(matcher, text, false);
	UBool result = matcher.lookingAt(accessor.status());
	if (result)
		accessor.updateOffsets(offsets);
	return result;
}

int
RegexMatcherGlue::matches(RegexMatcher& matcher, const NativeString* text, NativeArray<int>* offsets)
{
	Accessor accessor(matcher, text, false);
	UBool result = matcher.matches(accessor.status());
	if (result)
		accessor.updateOffsets(offsets);
	return result;
}

void
RegexMatcherGlue::setInput(RegexMatcher& matcher, const NativeString* text, int start, int end)
{
	Accessor accessor(matcher, text, true);
	matcher.region(start, end, accessor.status());
}
