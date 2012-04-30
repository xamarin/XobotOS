/* This file is auto-generated.  DO NOT MODIFY.
 * Source file: frameworks/base/core/java/android/webkit/EventLogTags.logtags
 */

package android.webkit;;

/**
 * @hide
 */
public class EventLogTags {
  private EventLogTags() { }  // don't instantiate

  /** 70101 browser_zoom_level_change (start level|1|5),(end level|1|5),(time|2|3) */
  public static final int BROWSER_ZOOM_LEVEL_CHANGE = 70101;

  /** 70102 browser_double_tap_duration (duration|1|3),(time|2|3) */
  public static final int BROWSER_DOUBLE_TAP_DURATION = 70102;

  /** 70150 browser_snap_center */
  public static final int BROWSER_SNAP_CENTER = 70150;

  /** 70151 browser_text_size_change (oldSize|1|5), (newSize|1|5) */
  public static final int BROWSER_TEXT_SIZE_CHANGE = 70151;

  public static void writeBrowserZoomLevelChange(int startLevel, int endLevel, long time) {
    android.util.EventLog.writeEvent(BROWSER_ZOOM_LEVEL_CHANGE, startLevel, endLevel, time);
  }

  public static void writeBrowserDoubleTapDuration(int duration, long time) {
    android.util.EventLog.writeEvent(BROWSER_DOUBLE_TAP_DURATION, duration, time);
  }

  public static void writeBrowserSnapCenter() {
    android.util.EventLog.writeEvent(BROWSER_SNAP_CENTER);
  }

  public static void writeBrowserTextSizeChange(int oldsize, int newsize) {
    android.util.EventLog.writeEvent(BROWSER_TEXT_SIZE_CHANGE, oldsize, newsize);
  }
}
