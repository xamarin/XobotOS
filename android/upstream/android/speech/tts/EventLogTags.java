/* This file is auto-generated.  DO NOT MODIFY.
 * Source file: frameworks/base/core/java/android/speech/tts/EventLogTags.logtags
 */

package android.speech.tts;;

/**
 * @hide
 */
public class EventLogTags {
  private EventLogTags() { }  // don't instantiate

  /** 76001 tts_speak_success (engine|3),(caller|3),(length|1),(locale|3),(rate|1),(pitch|1),(engine_latency|2|3),(engine_total|2|3),(audio_latency|2|3) */
  public static final int TTS_SPEAK_SUCCESS = 76001;

  /** 76002 tts_speak_failure (engine|3),(caller|3),(length|1),(locale|3),(rate|1),(pitch|1) */
  public static final int TTS_SPEAK_FAILURE = 76002;

  public static void writeTtsSpeakSuccess(String engine, String caller, int length, String locale, int rate, int pitch, long engineLatency, long engineTotal, long audioLatency) {
    android.util.EventLog.writeEvent(TTS_SPEAK_SUCCESS, engine, caller, length, locale, rate, pitch, engineLatency, engineTotal, audioLatency);
  }

  public static void writeTtsSpeakFailure(String engine, String caller, int length, String locale, int rate, int pitch) {
    android.util.EventLog.writeEvent(TTS_SPEAK_FAILURE, engine, caller, length, locale, rate, pitch);
  }
}
