/* This file is auto-generated.  DO NOT MODIFY.
 * Source file: frameworks/base/core/java/android/content/EventLogTags.logtags
 */

package android.content;;

/**
 * @hide
 */
public class EventLogTags {
  private EventLogTags() { }  // don't instantiate

  /** 52002 content_query_sample (uri|3),(projection|3),(selection|3),(sortorder|3),(time|1|3),(blocking_package|3),(sample_percent|1|6) */
  public static final int CONTENT_QUERY_SAMPLE = 52002;

  /** 52003 content_update_sample (uri|3),(operation|3),(selection|3),(time|1|3),(blocking_package|3),(sample_percent|1|6) */
  public static final int CONTENT_UPDATE_SAMPLE = 52003;

  /** 52004 binder_sample (descriptor|3),(method_num|1|5),(time|1|3),(blocking_package|3),(sample_percent|1|6) */
  public static final int BINDER_SAMPLE = 52004;

  public static void writeContentQuerySample(String uri, String projection, String selection, String sortorder, int time, String blockingPackage, int samplePercent) {
    android.util.EventLog.writeEvent(CONTENT_QUERY_SAMPLE, uri, projection, selection, sortorder, time, blockingPackage, samplePercent);
  }

  public static void writeContentUpdateSample(String uri, String operation, String selection, int time, String blockingPackage, int samplePercent) {
    android.util.EventLog.writeEvent(CONTENT_UPDATE_SAMPLE, uri, operation, selection, time, blockingPackage, samplePercent);
  }

  public static void writeBinderSample(String descriptor, int methodNum, int time, String blockingPackage, int samplePercent) {
    android.util.EventLog.writeEvent(BINDER_SAMPLE, descriptor, methodNum, time, blockingPackage, samplePercent);
  }
}
