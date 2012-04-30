using Sharpen;

namespace android.content
{
	/// <summary>An intent is an abstract description of an operation to be performed.</summary>
	/// <remarks>
	/// An intent is an abstract description of an operation to be performed.  It
	/// can be used with
	/// <see cref="Context.startActivity(Intent)">startActivity</see>
	/// to
	/// launch an
	/// <see cref="android.app.Activity">android.app.Activity</see>
	/// ,
	/// <see cref="Context.sendBroadcast(Intent)">broadcastIntent</see>
	/// to
	/// send it to any interested
	/// <see cref="BroadcastReceiver">BroadcastReceiver</see>
	/// components,
	/// and
	/// <see cref="Context.startService(Intent)">Context.startService(Intent)</see>
	/// or
	/// <see cref="Context.bindService(Intent, ServiceConnection, int)">Context.bindService(Intent, ServiceConnection, int)
	/// 	</see>
	/// to communicate with a
	/// background
	/// <see cref="android.app.Service">android.app.Service</see>
	/// .
	/// <p>An Intent provides a facility for performing late runtime binding between the code in
	/// different applications. Its most significant use is in the launching of activities, where it
	/// can be thought of as the glue between activities. It is basically a passive data structure
	/// holding an abstract description of an action to be performed.</p>
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For information about how to create and resolve intents, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/intents/intents-filters.html"&gt;Intents and Intent Filters</a>
	/// developer guide.</p>
	/// </div>
	/// <a name="IntentStructure"></a>
	/// <h3>Intent Structure</h3>
	/// <p>The primary pieces of information in an intent are:</p>
	/// <ul>
	/// <li> <p><b>action</b> -- The general action to be performed, such as
	/// <see cref="ACTION_VIEW">ACTION_VIEW</see>
	/// ,
	/// <see cref="ACTION_EDIT">ACTION_EDIT</see>
	/// ,
	/// <see cref="ACTION_MAIN">ACTION_MAIN</see>
	/// ,
	/// etc.</p>
	/// </li>
	/// <li> <p><b>data</b> -- The data to operate on, such as a person record
	/// in the contacts database, expressed as a
	/// <see cref="System.Uri">System.Uri</see>
	/// .</p>
	/// </li>
	/// </ul>
	/// <p>Some examples of action/data pairs are:</p>
	/// <ul>
	/// <li> <p><b>
	/// <see cref="ACTION_VIEW">ACTION_VIEW</see>
	/// <i>content://contacts/people/1</i></b> -- Display
	/// information about the person whose identifier is "1".</p>
	/// </li>
	/// <li> <p><b>
	/// <see cref="ACTION_DIAL">ACTION_DIAL</see>
	/// <i>content://contacts/people/1</i></b> -- Display
	/// the phone dialer with the person filled in.</p>
	/// </li>
	/// <li> <p><b>
	/// <see cref="ACTION_VIEW">ACTION_VIEW</see>
	/// <i>tel:123</i></b> -- Display
	/// the phone dialer with the given number filled in.  Note how the
	/// VIEW action does what what is considered the most reasonable thing for
	/// a particular URI.</p>
	/// </li>
	/// <li> <p><b>
	/// <see cref="ACTION_DIAL">ACTION_DIAL</see>
	/// <i>tel:123</i></b> -- Display
	/// the phone dialer with the given number filled in.</p>
	/// </li>
	/// <li> <p><b>
	/// <see cref="ACTION_EDIT">ACTION_EDIT</see>
	/// <i>content://contacts/people/1</i></b> -- Edit
	/// information about the person whose identifier is "1".</p>
	/// </li>
	/// <li> <p><b>
	/// <see cref="ACTION_VIEW">ACTION_VIEW</see>
	/// <i>content://contacts/people/</i></b> -- Display
	/// a list of people, which the user can browse through.  This example is a
	/// typical top-level entry into the Contacts application, showing you the
	/// list of people. Selecting a particular person to view would result in a
	/// new intent { <b>
	/// <see cref="ACTION_VIEW">ACTION_VIEW</see>
	/// <i>content://contacts/N</i></b> }
	/// being used to start an activity to display that person.</p>
	/// </li>
	/// </ul>
	/// <p>In addition to these primary attributes, there are a number of secondary
	/// attributes that you can also include with an intent:</p>
	/// <ul>
	/// <li> <p><b>category</b> -- Gives additional information about the action
	/// to execute.  For example,
	/// <see cref="CATEGORY_LAUNCHER">CATEGORY_LAUNCHER</see>
	/// means it should
	/// appear in the Launcher as a top-level application, while
	/// <see cref="CATEGORY_ALTERNATIVE">CATEGORY_ALTERNATIVE</see>
	/// means it should be included in a list
	/// of alternative actions the user can perform on a piece of data.</p>
	/// <li> <p><b>type</b> -- Specifies an explicit type (a MIME type) of the
	/// intent data.  Normally the type is inferred from the data itself.
	/// By setting this attribute, you disable that evaluation and force
	/// an explicit type.</p>
	/// <li> <p><b>component</b> -- Specifies an explicit name of a component
	/// class to use for the intent.  Normally this is determined by looking
	/// at the other information in the intent (the action, data/type, and
	/// categories) and matching that with a component that can handle it.
	/// If this attribute is set then none of the evaluation is performed,
	/// and this component is used exactly as is.  By specifying this attribute,
	/// all of the other Intent attributes become optional.</p>
	/// <li> <p><b>extras</b> -- This is a
	/// <see cref="android.os.Bundle">android.os.Bundle</see>
	/// of any additional information.
	/// This can be used to provide extended information to the component.
	/// For example, if we have a action to send an e-mail message, we could
	/// also include extra pieces of data here to supply a subject, body,
	/// etc.</p>
	/// </ul>
	/// <p>Here are some examples of other operations you can specify as intents
	/// using these additional parameters:</p>
	/// <ul>
	/// <li> <p><b>
	/// <see cref="ACTION_MAIN">ACTION_MAIN</see>
	/// with category
	/// <see cref="CATEGORY_HOME">CATEGORY_HOME</see>
	/// </b> --
	/// Launch the home screen.</p>
	/// </li>
	/// <li> <p><b>
	/// <see cref="ACTION_GET_CONTENT">ACTION_GET_CONTENT</see>
	/// with MIME type
	/// <i>
	/// <see cref="android.provider.Contacts.Phones.CONTENT_URI">vnd.android.cursor.item/phone
	/// 	</see>
	/// </i></b>
	/// -- Display the list of people's phone numbers, allowing the user to
	/// browse through them and pick one and return it to the parent activity.</p>
	/// </li>
	/// <li> <p><b>
	/// <see cref="ACTION_GET_CONTENT">ACTION_GET_CONTENT</see>
	/// with MIME type
	/// <i>
	/// <literal>/</literal>
	/// *</i> and category
	/// <see cref="CATEGORY_OPENABLE">CATEGORY_OPENABLE</see>
	/// </b>
	/// -- Display all pickers for data that can be opened with
	/// <see cref="ContentResolver.openInputStream(System.Uri)">ContentResolver.openInputStream()
	/// 	</see>
	/// ,
	/// allowing the user to pick one of them and then some data inside of it
	/// and returning the resulting URI to the caller.  This can be used,
	/// for example, in an e-mail application to allow the user to pick some
	/// data to include as an attachment.</p>
	/// </li>
	/// </ul>
	/// <p>There are a variety of standard Intent action and category constants
	/// defined in the Intent class, but applications can also define their own.
	/// These strings use java style scoping, to ensure they are unique -- for
	/// example, the standard
	/// <see cref="ACTION_VIEW">ACTION_VIEW</see>
	/// is called
	/// "android.intent.action.VIEW".</p>
	/// <p>Put together, the set of actions, data types, categories, and extra data
	/// defines a language for the system allowing for the expression of phrases
	/// such as "call john smith's cell".  As applications are added to the system,
	/// they can extend this language by adding new actions, types, and categories, or
	/// they can modify the behavior of existing phrases by supplying their own
	/// activities that handle them.</p>
	/// <a name="IntentResolution"></a>
	/// <h3>Intent Resolution</h3>
	/// <p>There are two primary forms of intents you will use.
	/// <ul>
	/// <li> <p><b>Explicit Intents</b> have specified a component (via
	/// <see cref="setComponent(ComponentName)">setComponent(ComponentName)</see>
	/// or
	/// <see cref="setClass(Context, System.Type{T})">setClass(Context, System.Type&lt;T&gt;)
	/// 	</see>
	/// ), which provides the exact
	/// class to be run.  Often these will not include any other information,
	/// simply being a way for an application to launch various internal
	/// activities it has as the user interacts with the application.
	/// <li> <p><b>Implicit Intents</b> have not specified a component;
	/// instead, they must include enough information for the system to
	/// determine which of the available components is best to run for that
	/// intent.
	/// </ul>
	/// <p>When using implicit intents, given such an arbitrary intent we need to
	/// know what to do with it. This is handled by the process of <em>Intent
	/// resolution</em>, which maps an Intent to an
	/// <see cref="android.app.Activity">android.app.Activity</see>
	/// ,
	/// <see cref="BroadcastReceiver">BroadcastReceiver</see>
	/// , or
	/// <see cref="android.app.Service">android.app.Service</see>
	/// (or sometimes two or
	/// more activities/receivers) that can handle it.</p>
	/// <p>The intent resolution mechanism basically revolves around matching an
	/// Intent against all of the &lt;intent-filter&gt; descriptions in the
	/// installed application packages.  (Plus, in the case of broadcasts, any
	/// <see cref="BroadcastReceiver">BroadcastReceiver</see>
	/// objects explicitly registered with
	/// <see cref="Context.registerReceiver(BroadcastReceiver, IntentFilter)">Context.registerReceiver(BroadcastReceiver, IntentFilter)
	/// 	</see>
	/// .)  More
	/// details on this can be found in the documentation on the
	/// <see cref="IntentFilter">IntentFilter</see>
	/// class.</p>
	/// <p>There are three pieces of information in the Intent that are used for
	/// resolution: the action, type, and category.  Using this information, a query
	/// is done on the
	/// <see cref="android.content.pm.PackageManager">android.content.pm.PackageManager</see>
	/// for a component that can handle the
	/// intent. The appropriate component is determined based on the intent
	/// information supplied in the <code>AndroidManifest.xml</code> file as
	/// follows:</p>
	/// <ul>
	/// <li> <p>The <b>action</b>, if given, must be listed by the component as
	/// one it handles.</p>
	/// <li> <p>The <b>type</b> is retrieved from the Intent's data, if not
	/// already supplied in the Intent.  Like the action, if a type is
	/// included in the intent (either explicitly or implicitly in its
	/// data), then this must be listed by the component as one it handles.</p>
	/// <li> For data that is not a <code>content:</code> URI and where no explicit
	/// type is included in the Intent, instead the <b>scheme</b> of the
	/// intent data (such as <code>http:</code> or <code>mailto:</code>) is
	/// considered. Again like the action, if we are matching a scheme it
	/// must be listed by the component as one it can handle.
	/// <li> <p>The <b>categories</b>, if supplied, must <em>all</em> be listed
	/// by the activity as categories it handles.  That is, if you include
	/// the categories
	/// <see cref="CATEGORY_LAUNCHER">CATEGORY_LAUNCHER</see>
	/// and
	/// <see cref="CATEGORY_ALTERNATIVE">CATEGORY_ALTERNATIVE</see>
	/// , then you will only resolve to components
	/// with an intent that lists <em>both</em> of those categories.
	/// Activities will very often need to support the
	/// <see cref="CATEGORY_DEFAULT">CATEGORY_DEFAULT</see>
	/// so that they can be found by
	/// <see cref="Context.startActivity(Intent)">Context.startActivity()</see>
	/// .</p>
	/// </ul>
	/// <p>For example, consider the Note Pad sample application that
	/// allows user to browse through a list of notes data and view details about
	/// individual items.  Text in italics indicate places were you would replace a
	/// name with one specific to your own package.</p>
	/// <pre> &lt;manifest xmlns:android="http://schemas.android.com/apk/res/android"
	/// package="<i>com.android.notepad</i>"&gt;
	/// &lt;application android:icon="@drawable/app_notes"
	/// android:label="@string/app_name"&gt;
	/// &lt;provider class=".NotePadProvider"
	/// android:authorities="<i>com.google.provider.NotePad</i>" /&gt;
	/// &lt;activity class=".NotesList" android:label="@string/title_notes_list"&gt;
	/// &lt;intent-filter&gt;
	/// &lt;action android:name="android.intent.action.MAIN" /&gt;
	/// &lt;category android:name="android.intent.category.LAUNCHER" /&gt;
	/// &lt;/intent-filter&gt;
	/// &lt;intent-filter&gt;
	/// &lt;action android:name="android.intent.action.VIEW" /&gt;
	/// &lt;action android:name="android.intent.action.EDIT" /&gt;
	/// &lt;action android:name="android.intent.action.PICK" /&gt;
	/// &lt;category android:name="android.intent.category.DEFAULT" /&gt;
	/// &lt;data android:mimeType="vnd.android.cursor.dir/<i>vnd.google.note</i>" /&gt;
	/// &lt;/intent-filter&gt;
	/// &lt;intent-filter&gt;
	/// &lt;action android:name="android.intent.action.GET_CONTENT" /&gt;
	/// &lt;category android:name="android.intent.category.DEFAULT" /&gt;
	/// &lt;data android:mimeType="vnd.android.cursor.item/<i>vnd.google.note</i>" /&gt;
	/// &lt;/intent-filter&gt;
	/// &lt;/activity&gt;
	/// &lt;activity class=".NoteEditor" android:label="@string/title_note"&gt;
	/// &lt;intent-filter android:label="@string/resolve_edit"&gt;
	/// &lt;action android:name="android.intent.action.VIEW" /&gt;
	/// &lt;action android:name="android.intent.action.EDIT" /&gt;
	/// &lt;category android:name="android.intent.category.DEFAULT" /&gt;
	/// &lt;data android:mimeType="vnd.android.cursor.item/<i>vnd.google.note</i>" /&gt;
	/// &lt;/intent-filter&gt;
	/// &lt;intent-filter&gt;
	/// &lt;action android:name="android.intent.action.INSERT" /&gt;
	/// &lt;category android:name="android.intent.category.DEFAULT" /&gt;
	/// &lt;data android:mimeType="vnd.android.cursor.dir/<i>vnd.google.note</i>" /&gt;
	/// &lt;/intent-filter&gt;
	/// &lt;/activity&gt;
	/// &lt;activity class=".TitleEditor" android:label="@string/title_edit_title"
	/// android:theme="@android:style/Theme.Dialog"&gt;
	/// &lt;intent-filter android:label="@string/resolve_title"&gt;
	/// &lt;action android:name="<i>com.android.notepad.action.EDIT_TITLE</i>" /&gt;
	/// &lt;category android:name="android.intent.category.DEFAULT" /&gt;
	/// &lt;category android:name="android.intent.category.ALTERNATIVE" /&gt;
	/// &lt;category android:name="android.intent.category.SELECTED_ALTERNATIVE" /&gt;
	/// &lt;data android:mimeType="vnd.android.cursor.item/<i>vnd.google.note</i>" /&gt;
	/// &lt;/intent-filter&gt;
	/// &lt;/activity&gt;
	/// &lt;/application&gt;
	/// &lt;/manifest&gt;</pre>
	/// <p>The first activity,
	/// <code>com.android.notepad.NotesList</code>, serves as our main
	/// entry into the app.  It can do three things as described by its three intent
	/// templates:
	/// <ol>
	/// <li><pre>
	/// &lt;intent-filter&gt;
	/// &lt;action android:name="
	/// <see cref="ACTION_MAIN">android.intent.action.MAIN</see>
	/// " /&gt;
	/// &lt;category android:name="
	/// <see cref="CATEGORY_LAUNCHER">android.intent.category.LAUNCHER</see>
	/// " /&gt;
	/// &lt;/intent-filter&gt;</pre>
	/// <p>This provides a top-level entry into the NotePad application: the standard
	/// MAIN action is a main entry point (not requiring any other information in
	/// the Intent), and the LAUNCHER category says that this entry point should be
	/// listed in the application launcher.</p>
	/// <li><pre>
	/// &lt;intent-filter&gt;
	/// &lt;action android:name="
	/// <see cref="ACTION_VIEW">android.intent.action.VIEW</see>
	/// " /&gt;
	/// &lt;action android:name="
	/// <see cref="ACTION_EDIT">android.intent.action.EDIT</see>
	/// " /&gt;
	/// &lt;action android:name="
	/// <see cref="ACTION_PICK">android.intent.action.PICK</see>
	/// " /&gt;
	/// &lt;category android:name="
	/// <see cref="CATEGORY_DEFAULT">android.intent.category.DEFAULT</see>
	/// " /&gt;
	/// &lt;data mimeType:name="vnd.android.cursor.dir/<i>vnd.google.note</i>" /&gt;
	/// &lt;/intent-filter&gt;</pre>
	/// <p>This declares the things that the activity can do on a directory of
	/// notes.  The type being supported is given with the &lt;type&gt; tag, where
	/// <code>vnd.android.cursor.dir/vnd.google.note</code> is a URI from which
	/// a Cursor of zero or more items (<code>vnd.android.cursor.dir</code>) can
	/// be retrieved which holds our note pad data (<code>vnd.google.note</code>).
	/// The activity allows the user to view or edit the directory of data (via
	/// the VIEW and EDIT actions), or to pick a particular note and return it
	/// to the caller (via the PICK action).  Note also the DEFAULT category
	/// supplied here: this is <em>required</em> for the
	/// <see cref="Context.startActivity(Intent)">Context.startActivity</see>
	/// method to resolve your
	/// activity when its component name is not explicitly specified.</p>
	/// <li><pre>
	/// &lt;intent-filter&gt;
	/// &lt;action android:name="
	/// <see cref="ACTION_GET_CONTENT">android.intent.action.GET_CONTENT</see>
	/// " /&gt;
	/// &lt;category android:name="
	/// <see cref="CATEGORY_DEFAULT">android.intent.category.DEFAULT</see>
	/// " /&gt;
	/// &lt;data android:mimeType="vnd.android.cursor.item/<i>vnd.google.note</i>" /&gt;
	/// &lt;/intent-filter&gt;</pre>
	/// <p>This filter describes the ability return to the caller a note selected by
	/// the user without needing to know where it came from.  The data type
	/// <code>vnd.android.cursor.item/vnd.google.note</code> is a URI from which
	/// a Cursor of exactly one (<code>vnd.android.cursor.item</code>) item can
	/// be retrieved which contains our note pad data (<code>vnd.google.note</code>).
	/// The GET_CONTENT action is similar to the PICK action, where the activity
	/// will return to its caller a piece of data selected by the user.  Here,
	/// however, the caller specifies the type of data they desire instead of
	/// the type of data the user will be picking from.</p>
	/// </ol>
	/// <p>Given these capabilities, the following intents will resolve to the
	/// NotesList activity:</p>
	/// <ul>
	/// <li> <p><b>{ action=android.app.action.MAIN }</b> matches all of the
	/// activities that can be used as top-level entry points into an
	/// application.</p>
	/// <li> <p><b>{ action=android.app.action.MAIN,
	/// category=android.app.category.LAUNCHER }</b> is the actual intent
	/// used by the Launcher to populate its top-level list.</p>
	/// <li> <p><b>{ action=android.intent.action.VIEW
	/// data=content://com.google.provider.NotePad/notes }</b>
	/// displays a list of all the notes under
	/// "content://com.google.provider.NotePad/notes", which
	/// the user can browse through and see the details on.</p>
	/// <li> <p><b>{ action=android.app.action.PICK
	/// data=content://com.google.provider.NotePad/notes }</b>
	/// provides a list of the notes under
	/// "content://com.google.provider.NotePad/notes", from which
	/// the user can pick a note whose data URL is returned back to the caller.</p>
	/// <li> <p><b>{ action=android.app.action.GET_CONTENT
	/// type=vnd.android.cursor.item/vnd.google.note }</b>
	/// is similar to the pick action, but allows the caller to specify the
	/// kind of data they want back so that the system can find the appropriate
	/// activity to pick something of that data type.</p>
	/// </ul>
	/// <p>The second activity,
	/// <code>com.android.notepad.NoteEditor</code>, shows the user a single
	/// note entry and allows them to edit it.  It can do two things as described
	/// by its two intent templates:
	/// <ol>
	/// <li><pre>
	/// &lt;intent-filter android:label="@string/resolve_edit"&gt;
	/// &lt;action android:name="
	/// <see cref="ACTION_VIEW">android.intent.action.VIEW</see>
	/// " /&gt;
	/// &lt;action android:name="
	/// <see cref="ACTION_EDIT">android.intent.action.EDIT</see>
	/// " /&gt;
	/// &lt;category android:name="
	/// <see cref="CATEGORY_DEFAULT">android.intent.category.DEFAULT</see>
	/// " /&gt;
	/// &lt;data android:mimeType="vnd.android.cursor.item/<i>vnd.google.note</i>" /&gt;
	/// &lt;/intent-filter&gt;</pre>
	/// <p>The first, primary, purpose of this activity is to let the user interact
	/// with a single note, as decribed by the MIME type
	/// <code>vnd.android.cursor.item/vnd.google.note</code>.  The activity can
	/// either VIEW a note or allow the user to EDIT it.  Again we support the
	/// DEFAULT category to allow the activity to be launched without explicitly
	/// specifying its component.</p>
	/// <li><pre>
	/// &lt;intent-filter&gt;
	/// &lt;action android:name="
	/// <see cref="ACTION_INSERT">android.intent.action.INSERT</see>
	/// " /&gt;
	/// &lt;category android:name="
	/// <see cref="CATEGORY_DEFAULT">android.intent.category.DEFAULT</see>
	/// " /&gt;
	/// &lt;data android:mimeType="vnd.android.cursor.dir/<i>vnd.google.note</i>" /&gt;
	/// &lt;/intent-filter&gt;</pre>
	/// <p>The secondary use of this activity is to insert a new note entry into
	/// an existing directory of notes.  This is used when the user creates a new
	/// note: the INSERT action is executed on the directory of notes, causing
	/// this activity to run and have the user create the new note data which
	/// it then adds to the content provider.</p>
	/// </ol>
	/// <p>Given these capabilities, the following intents will resolve to the
	/// NoteEditor activity:</p>
	/// <ul>
	/// <li> <p><b>{ action=android.intent.action.VIEW
	/// data=content://com.google.provider.NotePad/notes/<var>{ID}</var> }</b>
	/// shows the user the content of note <var>{ID}</var>.</p>
	/// <li> <p><b>{ action=android.app.action.EDIT
	/// data=content://com.google.provider.NotePad/notes/<var>{ID}</var> }</b>
	/// allows the user to edit the content of note <var>{ID}</var>.</p>
	/// <li> <p><b>{ action=android.app.action.INSERT
	/// data=content://com.google.provider.NotePad/notes }</b>
	/// creates a new, empty note in the notes list at
	/// "content://com.google.provider.NotePad/notes"
	/// and allows the user to edit it.  If they keep their changes, the URI
	/// of the newly created note is returned to the caller.</p>
	/// </ul>
	/// <p>The last activity,
	/// <code>com.android.notepad.TitleEditor</code>, allows the user to
	/// edit the title of a note.  This could be implemented as a class that the
	/// application directly invokes (by explicitly setting its component in
	/// the Intent), but here we show a way you can publish alternative
	/// operations on existing data:</p>
	/// <pre>
	/// &lt;intent-filter android:label="@string/resolve_title"&gt;
	/// &lt;action android:name="<i>com.android.notepad.action.EDIT_TITLE</i>" /&gt;
	/// &lt;category android:name="
	/// <see cref="CATEGORY_DEFAULT">android.intent.category.DEFAULT</see>
	/// " /&gt;
	/// &lt;category android:name="
	/// <see cref="CATEGORY_ALTERNATIVE">android.intent.category.ALTERNATIVE</see>
	/// " /&gt;
	/// &lt;category android:name="
	/// <see cref="CATEGORY_SELECTED_ALTERNATIVE">android.intent.category.SELECTED_ALTERNATIVE
	/// 	</see>
	/// " /&gt;
	/// &lt;data android:mimeType="vnd.android.cursor.item/<i>vnd.google.note</i>" /&gt;
	/// &lt;/intent-filter&gt;</pre>
	/// <p>In the single intent template here, we
	/// have created our own private action called
	/// <code>com.android.notepad.action.EDIT_TITLE</code> which means to
	/// edit the title of a note.  It must be invoked on a specific note
	/// (data type <code>vnd.android.cursor.item/vnd.google.note</code>) like the previous
	/// view and edit actions, but here displays and edits the title contained
	/// in the note data.
	/// <p>In addition to supporting the default category as usual, our title editor
	/// also supports two other standard categories: ALTERNATIVE and
	/// SELECTED_ALTERNATIVE.  Implementing
	/// these categories allows others to find the special action it provides
	/// without directly knowing about it, through the
	/// <see cref="android.content.pm.PackageManager.queryIntentActivityOptions(ComponentName, Intent[], Intent, int)
	/// 	">android.content.pm.PackageManager.queryIntentActivityOptions(ComponentName, Intent[], Intent, int)
	/// 	</see>
	/// method, or
	/// more often to build dynamic menu items with
	/// <see cref="android.view.Menu.addIntentOptions(int, int, int, ComponentName, Intent[], Intent, int, android.view.MenuItem[])
	/// 	">android.view.Menu.addIntentOptions(int, int, int, ComponentName, Intent[], Intent, int, android.view.MenuItem[])
	/// 	</see>
	/// .  Note that in the intent
	/// template here was also supply an explicit name for the template
	/// (via <code>android:label="@string/resolve_title"</code>) to better control
	/// what the user sees when presented with this activity as an alternative
	/// action to the data they are viewing.
	/// <p>Given these capabilities, the following intent will resolve to the
	/// TitleEditor activity:</p>
	/// <ul>
	/// <li> <p><b>{ action=com.android.notepad.action.EDIT_TITLE
	/// data=content://com.google.provider.NotePad/notes/<var>{ID}</var> }</b>
	/// displays and allows the user to edit the title associated
	/// with note <var>{ID}</var>.</p>
	/// </ul>
	/// <h3>Standard Activity Actions</h3>
	/// <p>These are the current standard actions that Intent defines for launching
	/// activities (usually through
	/// <see cref="Context.startActivity(Intent)">Context.startActivity(Intent)</see>
	/// .  The most
	/// important, and by far most frequently used, are
	/// <see cref="ACTION_MAIN">ACTION_MAIN</see>
	/// and
	/// <see cref="ACTION_EDIT">ACTION_EDIT</see>
	/// .
	/// <ul>
	/// <li>
	/// <see cref="ACTION_MAIN">ACTION_MAIN</see>
	/// <li>
	/// <see cref="ACTION_VIEW">ACTION_VIEW</see>
	/// <li>
	/// <see cref="ACTION_ATTACH_DATA">ACTION_ATTACH_DATA</see>
	/// <li>
	/// <see cref="ACTION_EDIT">ACTION_EDIT</see>
	/// <li>
	/// <see cref="ACTION_PICK">ACTION_PICK</see>
	/// <li>
	/// <see cref="ACTION_CHOOSER">ACTION_CHOOSER</see>
	/// <li>
	/// <see cref="ACTION_GET_CONTENT">ACTION_GET_CONTENT</see>
	/// <li>
	/// <see cref="ACTION_DIAL">ACTION_DIAL</see>
	/// <li>
	/// <see cref="ACTION_CALL">ACTION_CALL</see>
	/// <li>
	/// <see cref="ACTION_SEND">ACTION_SEND</see>
	/// <li>
	/// <see cref="ACTION_SENDTO">ACTION_SENDTO</see>
	/// <li>
	/// <see cref="ACTION_ANSWER">ACTION_ANSWER</see>
	/// <li>
	/// <see cref="ACTION_INSERT">ACTION_INSERT</see>
	/// <li>
	/// <see cref="ACTION_DELETE">ACTION_DELETE</see>
	/// <li>
	/// <see cref="ACTION_RUN">ACTION_RUN</see>
	/// <li>
	/// <see cref="ACTION_SYNC">ACTION_SYNC</see>
	/// <li>
	/// <see cref="ACTION_PICK_ACTIVITY">ACTION_PICK_ACTIVITY</see>
	/// <li>
	/// <see cref="ACTION_SEARCH">ACTION_SEARCH</see>
	/// <li>
	/// <see cref="ACTION_WEB_SEARCH">ACTION_WEB_SEARCH</see>
	/// <li>
	/// <see cref="ACTION_FACTORY_TEST">ACTION_FACTORY_TEST</see>
	/// </ul>
	/// <h3>Standard Broadcast Actions</h3>
	/// <p>These are the current standard actions that Intent defines for receiving
	/// broadcasts (usually through
	/// <see cref="Context.registerReceiver(BroadcastReceiver, IntentFilter)">Context.registerReceiver(BroadcastReceiver, IntentFilter)
	/// 	</see>
	/// or a
	/// &lt;receiver&gt; tag in a manifest).
	/// <ul>
	/// <li>
	/// <see cref="ACTION_TIME_TICK">ACTION_TIME_TICK</see>
	/// <li>
	/// <see cref="ACTION_TIME_CHANGED">ACTION_TIME_CHANGED</see>
	/// <li>
	/// <see cref="ACTION_TIMEZONE_CHANGED">ACTION_TIMEZONE_CHANGED</see>
	/// <li>
	/// <see cref="ACTION_BOOT_COMPLETED">ACTION_BOOT_COMPLETED</see>
	/// <li>
	/// <see cref="ACTION_PACKAGE_ADDED">ACTION_PACKAGE_ADDED</see>
	/// <li>
	/// <see cref="ACTION_PACKAGE_CHANGED">ACTION_PACKAGE_CHANGED</see>
	/// <li>
	/// <see cref="ACTION_PACKAGE_REMOVED">ACTION_PACKAGE_REMOVED</see>
	/// <li>
	/// <see cref="ACTION_PACKAGE_RESTARTED">ACTION_PACKAGE_RESTARTED</see>
	/// <li>
	/// <see cref="ACTION_PACKAGE_DATA_CLEARED">ACTION_PACKAGE_DATA_CLEARED</see>
	/// <li>
	/// <see cref="ACTION_UID_REMOVED">ACTION_UID_REMOVED</see>
	/// <li>
	/// <see cref="ACTION_BATTERY_CHANGED">ACTION_BATTERY_CHANGED</see>
	/// <li>
	/// <see cref="ACTION_POWER_CONNECTED">ACTION_POWER_CONNECTED</see>
	/// <li>
	/// <see cref="ACTION_POWER_DISCONNECTED">ACTION_POWER_DISCONNECTED</see>
	/// <li>
	/// <see cref="ACTION_SHUTDOWN">ACTION_SHUTDOWN</see>
	/// </ul>
	/// <h3>Standard Categories</h3>
	/// <p>These are the current standard categories that can be used to further
	/// clarify an Intent via
	/// <see cref="addCategory(string)">addCategory(string)</see>
	/// .
	/// <ul>
	/// <li>
	/// <see cref="CATEGORY_DEFAULT">CATEGORY_DEFAULT</see>
	/// <li>
	/// <see cref="CATEGORY_BROWSABLE">CATEGORY_BROWSABLE</see>
	/// <li>
	/// <see cref="CATEGORY_TAB">CATEGORY_TAB</see>
	/// <li>
	/// <see cref="CATEGORY_ALTERNATIVE">CATEGORY_ALTERNATIVE</see>
	/// <li>
	/// <see cref="CATEGORY_SELECTED_ALTERNATIVE">CATEGORY_SELECTED_ALTERNATIVE</see>
	/// <li>
	/// <see cref="CATEGORY_LAUNCHER">CATEGORY_LAUNCHER</see>
	/// <li>
	/// <see cref="CATEGORY_INFO">CATEGORY_INFO</see>
	/// <li>
	/// <see cref="CATEGORY_HOME">CATEGORY_HOME</see>
	/// <li>
	/// <see cref="CATEGORY_PREFERENCE">CATEGORY_PREFERENCE</see>
	/// <li>
	/// <see cref="CATEGORY_TEST">CATEGORY_TEST</see>
	/// <li>
	/// <see cref="CATEGORY_CAR_DOCK">CATEGORY_CAR_DOCK</see>
	/// <li>
	/// <see cref="CATEGORY_DESK_DOCK">CATEGORY_DESK_DOCK</see>
	/// <li>
	/// <see cref="CATEGORY_LE_DESK_DOCK">CATEGORY_LE_DESK_DOCK</see>
	/// <li>
	/// <see cref="CATEGORY_HE_DESK_DOCK">CATEGORY_HE_DESK_DOCK</see>
	/// <li>
	/// <see cref="CATEGORY_CAR_MODE">CATEGORY_CAR_MODE</see>
	/// <li>
	/// <see cref="CATEGORY_APP_MARKET">CATEGORY_APP_MARKET</see>
	/// </ul>
	/// <h3>Standard Extra Data</h3>
	/// <p>These are the current standard fields that can be used as extra data via
	/// <see cref="putExtra(string, bool)">putExtra(string, bool)</see>
	/// .
	/// <ul>
	/// <li>
	/// <see cref="EXTRA_ALARM_COUNT">EXTRA_ALARM_COUNT</see>
	/// <li>
	/// <see cref="EXTRA_BCC">EXTRA_BCC</see>
	/// <li>
	/// <see cref="EXTRA_CC">EXTRA_CC</see>
	/// <li>
	/// <see cref="EXTRA_CHANGED_COMPONENT_NAME">EXTRA_CHANGED_COMPONENT_NAME</see>
	/// <li>
	/// <see cref="EXTRA_DATA_REMOVED">EXTRA_DATA_REMOVED</see>
	/// <li>
	/// <see cref="EXTRA_DOCK_STATE">EXTRA_DOCK_STATE</see>
	/// <li>
	/// <see cref="EXTRA_DOCK_STATE_HE_DESK">EXTRA_DOCK_STATE_HE_DESK</see>
	/// <li>
	/// <see cref="EXTRA_DOCK_STATE_LE_DESK">EXTRA_DOCK_STATE_LE_DESK</see>
	/// <li>
	/// <see cref="EXTRA_DOCK_STATE_CAR">EXTRA_DOCK_STATE_CAR</see>
	/// <li>
	/// <see cref="EXTRA_DOCK_STATE_DESK">EXTRA_DOCK_STATE_DESK</see>
	/// <li>
	/// <see cref="EXTRA_DOCK_STATE_UNDOCKED">EXTRA_DOCK_STATE_UNDOCKED</see>
	/// <li>
	/// <see cref="EXTRA_DONT_KILL_APP">EXTRA_DONT_KILL_APP</see>
	/// <li>
	/// <see cref="EXTRA_EMAIL">EXTRA_EMAIL</see>
	/// <li>
	/// <see cref="EXTRA_INITIAL_INTENTS">EXTRA_INITIAL_INTENTS</see>
	/// <li>
	/// <see cref="EXTRA_INTENT">EXTRA_INTENT</see>
	/// <li>
	/// <see cref="EXTRA_KEY_EVENT">EXTRA_KEY_EVENT</see>
	/// <li>
	/// <see cref="EXTRA_PHONE_NUMBER">EXTRA_PHONE_NUMBER</see>
	/// <li>
	/// <see cref="EXTRA_REMOTE_INTENT_TOKEN">EXTRA_REMOTE_INTENT_TOKEN</see>
	/// <li>
	/// <see cref="EXTRA_REPLACING">EXTRA_REPLACING</see>
	/// <li>
	/// <see cref="EXTRA_SHORTCUT_ICON">EXTRA_SHORTCUT_ICON</see>
	/// <li>
	/// <see cref="EXTRA_SHORTCUT_ICON_RESOURCE">EXTRA_SHORTCUT_ICON_RESOURCE</see>
	/// <li>
	/// <see cref="EXTRA_SHORTCUT_INTENT">EXTRA_SHORTCUT_INTENT</see>
	/// <li>
	/// <see cref="EXTRA_STREAM">EXTRA_STREAM</see>
	/// <li>
	/// <see cref="EXTRA_SHORTCUT_NAME">EXTRA_SHORTCUT_NAME</see>
	/// <li>
	/// <see cref="EXTRA_SUBJECT">EXTRA_SUBJECT</see>
	/// <li>
	/// <see cref="EXTRA_TEMPLATE">EXTRA_TEMPLATE</see>
	/// <li>
	/// <see cref="EXTRA_TEXT">EXTRA_TEXT</see>
	/// <li>
	/// <see cref="EXTRA_TITLE">EXTRA_TITLE</see>
	/// <li>
	/// <see cref="EXTRA_UID">EXTRA_UID</see>
	/// </ul>
	/// <h3>Flags</h3>
	/// <p>These are the possible flags that can be used in the Intent via
	/// <see cref="setFlags(int)">setFlags(int)</see>
	/// and
	/// <see cref="addFlags(int)">addFlags(int)</see>
	/// .  See
	/// <see cref="setFlags(int)">setFlags(int)</see>
	/// for a list
	/// of all possible flags.
	/// </remarks>
	[Sharpen.Sharpened]
	public class Intent : android.os.Parcelable, System.ICloneable
	{
		/// <summary>
		/// Activity Action: Start as a main entry point, does not expect to
		/// receive data.
		/// </summary>
		/// <remarks>
		/// Activity Action: Start as a main entry point, does not expect to
		/// receive data.
		/// <p>Input: nothing
		/// <p>Output: nothing
		/// </remarks>
		public const string ACTION_MAIN = "android.intent.action.MAIN";

		/// <summary>Activity Action: Display the data to the user.</summary>
		/// <remarks>
		/// Activity Action: Display the data to the user.  This is the most common
		/// action performed on data -- it is the generic action you can use on
		/// a piece of data to get the most reasonable thing to occur.  For example,
		/// when used on a contacts entry it will view the entry; when used on a
		/// mailto: URI it will bring up a compose window filled with the information
		/// supplied by the URI; when used with a tel: URI it will invoke the
		/// dialer.
		/// <p>Input:
		/// <see cref="getData()">getData()</see>
		/// is URI from which to retrieve data.
		/// <p>Output: nothing.
		/// </remarks>
		public const string ACTION_VIEW = "android.intent.action.VIEW";

		/// <summary>
		/// A synonym for
		/// <see cref="ACTION_VIEW">ACTION_VIEW</see>
		/// , the "standard" action that is
		/// performed on a piece of data.
		/// </summary>
		public static readonly string ACTION_DEFAULT = ACTION_VIEW;

		/// <summary>
		/// Used to indicate that some piece of data should be attached to some other
		/// place.
		/// </summary>
		/// <remarks>
		/// Used to indicate that some piece of data should be attached to some other
		/// place.  For example, image data could be attached to a contact.  It is up
		/// to the recipient to decide where the data should be attached; the intent
		/// does not specify the ultimate destination.
		/// <p>Input:
		/// <see cref="getData()">getData()</see>
		/// is URI of data to be attached.
		/// <p>Output: nothing.
		/// </remarks>
		public const string ACTION_ATTACH_DATA = "android.intent.action.ATTACH_DATA";

		/// <summary>Activity Action: Provide explicit editable access to the given data.</summary>
		/// <remarks>
		/// Activity Action: Provide explicit editable access to the given data.
		/// <p>Input:
		/// <see cref="getData()">getData()</see>
		/// is URI of data to be edited.
		/// <p>Output: nothing.
		/// </remarks>
		public const string ACTION_EDIT = "android.intent.action.EDIT";

		/// <summary>Activity Action: Pick an existing item, or insert a new item, and then edit it.
		/// 	</summary>
		/// <remarks>
		/// Activity Action: Pick an existing item, or insert a new item, and then edit it.
		/// <p>Input:
		/// <see cref="getType()">getType()</see>
		/// is the desired MIME type of the item to create or edit.
		/// The extras can contain type specific data to pass through to the editing/creating
		/// activity.
		/// <p>Output: The URI of the item that was picked.  This must be a content:
		/// URI so that any receiver can access it.
		/// </remarks>
		public const string ACTION_INSERT_OR_EDIT = "android.intent.action.INSERT_OR_EDIT";

		/// <summary>Activity Action: Pick an item from the data, returning what was selected.
		/// 	</summary>
		/// <remarks>
		/// Activity Action: Pick an item from the data, returning what was selected.
		/// <p>Input:
		/// <see cref="getData()">getData()</see>
		/// is URI containing a directory of data
		/// (vnd.android.cursor.dir/*) from which to pick an item.
		/// <p>Output: The URI of the item that was picked.
		/// </remarks>
		public const string ACTION_PICK = "android.intent.action.PICK";

		/// <summary>Activity Action: Creates a shortcut.</summary>
		/// <remarks>
		/// Activity Action: Creates a shortcut.
		/// <p>Input: Nothing.</p>
		/// <p>Output: An Intent representing the shortcut. The intent must contain three
		/// extras: SHORTCUT_INTENT (value: Intent), SHORTCUT_NAME (value: String),
		/// and SHORTCUT_ICON (value: Bitmap) or SHORTCUT_ICON_RESOURCE
		/// (value: ShortcutIconResource).</p>
		/// </remarks>
		/// <seealso cref="EXTRA_SHORTCUT_INTENT">EXTRA_SHORTCUT_INTENT</seealso>
		/// <seealso cref="EXTRA_SHORTCUT_NAME">EXTRA_SHORTCUT_NAME</seealso>
		/// <seealso cref="EXTRA_SHORTCUT_ICON">EXTRA_SHORTCUT_ICON</seealso>
		/// <seealso cref="EXTRA_SHORTCUT_ICON_RESOURCE">EXTRA_SHORTCUT_ICON_RESOURCE</seealso>
		/// <seealso cref="ShortcutIconResource">ShortcutIconResource</seealso>
		public const string ACTION_CREATE_SHORTCUT = "android.intent.action.CREATE_SHORTCUT";

		/// <summary>The name of the extra used to define the Intent of a shortcut.</summary>
		/// <remarks>The name of the extra used to define the Intent of a shortcut.</remarks>
		/// <seealso cref="ACTION_CREATE_SHORTCUT">ACTION_CREATE_SHORTCUT</seealso>
		public const string EXTRA_SHORTCUT_INTENT = "android.intent.extra.shortcut.INTENT";

		/// <summary>The name of the extra used to define the name of a shortcut.</summary>
		/// <remarks>The name of the extra used to define the name of a shortcut.</remarks>
		/// <seealso cref="ACTION_CREATE_SHORTCUT">ACTION_CREATE_SHORTCUT</seealso>
		public const string EXTRA_SHORTCUT_NAME = "android.intent.extra.shortcut.NAME";

		/// <summary>The name of the extra used to define the icon, as a Bitmap, of a shortcut.
		/// 	</summary>
		/// <remarks>The name of the extra used to define the icon, as a Bitmap, of a shortcut.
		/// 	</remarks>
		/// <seealso cref="ACTION_CREATE_SHORTCUT">ACTION_CREATE_SHORTCUT</seealso>
		public const string EXTRA_SHORTCUT_ICON = "android.intent.extra.shortcut.ICON";

		/// <summary>The name of the extra used to define the icon, as a ShortcutIconResource, of a shortcut.
		/// 	</summary>
		/// <remarks>The name of the extra used to define the icon, as a ShortcutIconResource, of a shortcut.
		/// 	</remarks>
		/// <seealso cref="ACTION_CREATE_SHORTCUT">ACTION_CREATE_SHORTCUT</seealso>
		/// <seealso cref="ShortcutIconResource">ShortcutIconResource</seealso>
		public const string EXTRA_SHORTCUT_ICON_RESOURCE = "android.intent.extra.shortcut.ICON_RESOURCE";

		/// <summary>Represents a shortcut/live folder icon resource.</summary>
		/// <remarks>Represents a shortcut/live folder icon resource.</remarks>
		/// <seealso cref="Intent.ACTION_CREATE_SHORTCUT">Intent.ACTION_CREATE_SHORTCUT</seealso>
		/// <seealso cref="Intent.EXTRA_SHORTCUT_ICON_RESOURCE">Intent.EXTRA_SHORTCUT_ICON_RESOURCE
		/// 	</seealso>
		/// <seealso cref="android.provider.LiveFolders.ACTION_CREATE_LIVE_FOLDER">android.provider.LiveFolders.ACTION_CREATE_LIVE_FOLDER
		/// 	</seealso>
		/// <seealso cref="android.provider.LiveFolders.EXTRA_LIVE_FOLDER_ICON">android.provider.LiveFolders.EXTRA_LIVE_FOLDER_ICON
		/// 	</seealso>
		public class ShortcutIconResource : android.os.Parcelable
		{
			/// <summary>The package name of the application containing the icon.</summary>
			/// <remarks>The package name of the application containing the icon.</remarks>
			public string packageName;

			/// <summary>The resource name of the icon, including package, name and type.</summary>
			/// <remarks>The resource name of the icon, including package, name and type.</remarks>
			public string resourceName;

			// ---------------------------------------------------------------------
			// ---------------------------------------------------------------------
			// Standard intent activity actions (see action variable).
			/// <summary>
			/// Creates a new ShortcutIconResource for the specified context and resource
			/// identifier.
			/// </summary>
			/// <remarks>
			/// Creates a new ShortcutIconResource for the specified context and resource
			/// identifier.
			/// </remarks>
			/// <param name="context">The context of the application.</param>
			/// <param name="resourceId">The resource idenfitier for the icon.</param>
			/// <returns>
			/// A new ShortcutIconResource with the specified's context package name
			/// and icon resource idenfitier.
			/// </returns>
			public static android.content.Intent.ShortcutIconResource fromContext(android.content.Context
				 context, int resourceId)
			{
				android.content.Intent.ShortcutIconResource icon = new android.content.Intent.ShortcutIconResource
					();
				icon.packageName = context.getPackageName();
				icon.resourceName = context.getResources().getResourceName(resourceId);
				return icon;
			}

			private sealed class _Creator_749 : android.os.ParcelableClass.Creator<android.content.Intent
				.ShortcutIconResource>
			{
				public _Creator_749()
				{
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.content.Intent.ShortcutIconResource createFromParcel(android.os.Parcel
					 source)
				{
					android.content.Intent.ShortcutIconResource icon = new android.content.Intent.ShortcutIconResource
						();
					icon.packageName = source.readString();
					icon.resourceName = source.readString();
					return icon;
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.content.Intent.ShortcutIconResource[] newArray(int size)
				{
					return new android.content.Intent.ShortcutIconResource[size];
				}
			}

			/// <summary>Used to read a ShortcutIconResource from a Parcel.</summary>
			/// <remarks>Used to read a ShortcutIconResource from a Parcel.</remarks>
			public static readonly android.os.ParcelableClass.Creator<android.content.Intent.
				ShortcutIconResource> CREATOR = new _Creator_749();

			/// <summary>No special parcel contents.</summary>
			/// <remarks>No special parcel contents.</remarks>
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				return 0;
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				dest.writeString(packageName);
				dest.writeString(resourceName);
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return resourceName;
			}
		}

		/// <summary>
		/// Activity Action: Display an activity chooser, allowing the user to pick
		/// what they want to before proceeding.
		/// </summary>
		/// <remarks>
		/// Activity Action: Display an activity chooser, allowing the user to pick
		/// what they want to before proceeding.  This can be used as an alternative
		/// to the standard activity picker that is displayed by the system when
		/// you try to start an activity with multiple possible matches, with these
		/// differences in behavior:
		/// <ul>
		/// <li>You can specify the title that will appear in the activity chooser.
		/// <li>The user does not have the option to make one of the matching
		/// activities a preferred activity, and all possible activities will
		/// always be shown even if one of them is currently marked as the
		/// preferred activity.
		/// </ul>
		/// <p>
		/// This action should be used when the user will naturally expect to
		/// select an activity in order to proceed.  An example if when not to use
		/// it is when the user clicks on a "mailto:" link.  They would naturally
		/// expect to go directly to their mail app, so startActivity() should be
		/// called directly: it will
		/// either launch the current preferred app, or put up a dialog allowing the
		/// user to pick an app to use and optionally marking that as preferred.
		/// <p>
		/// In contrast, if the user is selecting a menu item to send a picture
		/// they are viewing to someone else, there are many different things they
		/// may want to do at this point: send it through e-mail, upload it to a
		/// web service, etc.  In this case the CHOOSER action should be used, to
		/// always present to the user a list of the things they can do, with a
		/// nice title given by the caller such as "Send this photo with:".
		/// <p>
		/// As a convenience, an Intent of this form can be created with the
		/// <see cref="createChooser(Intent, java.lang.CharSequence)">createChooser(Intent, java.lang.CharSequence)
		/// 	</see>
		/// function.
		/// <p>Input: No data should be specified.  get*Extra must have
		/// a
		/// <see cref="EXTRA_INTENT">EXTRA_INTENT</see>
		/// field containing the Intent being executed,
		/// and can optionally have a
		/// <see cref="EXTRA_TITLE">EXTRA_TITLE</see>
		/// field containing the
		/// title text to display in the chooser.
		/// <p>Output: Depends on the protocol of
		/// <see cref="EXTRA_INTENT">EXTRA_INTENT</see>
		/// .
		/// </remarks>
		public const string ACTION_CHOOSER = "android.intent.action.CHOOSER";

		/// <summary>
		/// Convenience function for creating a
		/// <see cref="ACTION_CHOOSER">ACTION_CHOOSER</see>
		/// Intent.
		/// </summary>
		/// <param name="target">
		/// The Intent that the user will be selecting an activity
		/// to perform.
		/// </param>
		/// <param name="title">Optional title that will be displayed in the chooser.</param>
		/// <returns>
		/// Return a new Intent object that you can hand to
		/// <see cref="Context.startActivity(Intent)">Context.startActivity()</see>
		/// and
		/// related methods.
		/// </returns>
		public static android.content.Intent createChooser(android.content.Intent target, 
			java.lang.CharSequence title)
		{
			android.content.Intent intent = new android.content.Intent(ACTION_CHOOSER);
			intent.putExtra(EXTRA_INTENT, target);
			if (title != null)
			{
				intent.putExtra(EXTRA_TITLE, title);
			}
			return intent;
		}

		/// <summary>
		/// Activity Action: Allow the user to select a particular kind of data and
		/// return it.
		/// </summary>
		/// <remarks>
		/// Activity Action: Allow the user to select a particular kind of data and
		/// return it.  This is different than
		/// <see cref="ACTION_PICK">ACTION_PICK</see>
		/// in that here we
		/// just say what kind of data is desired, not a URI of existing data from
		/// which the user can pick.  A ACTION_GET_CONTENT could allow the user to
		/// create the data as it runs (for example taking a picture or recording a
		/// sound), let them browser over the web and download the desired data,
		/// etc.
		/// <p>
		/// There are two main ways to use this action: if you want an specific kind
		/// of data, such as a person contact, you set the MIME type to the kind of
		/// data you want and launch it with
		/// <see cref="Context.startActivity(Intent)">Context.startActivity(Intent)</see>
		/// .
		/// The system will then launch the best application to select that kind
		/// of data for you.
		/// <p>
		/// You may also be interested in any of a set of types of content the user
		/// can pick.  For example, an e-mail application that wants to allow the
		/// user to add an attachment to an e-mail message can use this action to
		/// bring up a list of all of the types of content the user can attach.
		/// <p>
		/// In this case, you should wrap the GET_CONTENT intent with a chooser
		/// (through
		/// <see cref="createChooser(Intent, java.lang.CharSequence)">createChooser(Intent, java.lang.CharSequence)
		/// 	</see>
		/// ), which will give the proper interface
		/// for the user to pick how to send your data and allow you to specify
		/// a prompt indicating what they are doing.  You will usually specify a
		/// broad MIME type (such as image/* or
		/// <literal>*</literal>
		/// /*), resulting in a
		/// broad range of content types the user can select from.
		/// <p>
		/// When using such a broad GET_CONTENT action, it is often desireable to
		/// only pick from data that can be represented as a stream.  This is
		/// accomplished by requiring the
		/// <see cref="CATEGORY_OPENABLE">CATEGORY_OPENABLE</see>
		/// in the Intent.
		/// <p>
		/// Callers can optionally specify
		/// <see cref="EXTRA_LOCAL_ONLY">EXTRA_LOCAL_ONLY</see>
		/// to request that
		/// the launched content chooser only return results representing data that
		/// is locally available on the device.  For example, if this extra is set
		/// to true then an image picker should not show any pictures that are available
		/// from a remote server but not already on the local device (thus requiring
		/// they be downloaded when opened).
		/// <p>
		/// Input:
		/// <see cref="getType()">getType()</see>
		/// is the desired MIME type to retrieve.  Note
		/// that no URI is supplied in the intent, as there are no constraints on
		/// where the returned data originally comes from.  You may also include the
		/// <see cref="CATEGORY_OPENABLE">CATEGORY_OPENABLE</see>
		/// if you can only accept data that can be
		/// opened as a stream.  You may use
		/// <see cref="EXTRA_LOCAL_ONLY">EXTRA_LOCAL_ONLY</see>
		/// to limit content
		/// selection to local data.
		/// <p>
		/// Output: The URI of the item that was picked.  This must be a content:
		/// URI so that any receiver can access it.
		/// </remarks>
		public const string ACTION_GET_CONTENT = "android.intent.action.GET_CONTENT";

		/// <summary>Activity Action: Dial a number as specified by the data.</summary>
		/// <remarks>
		/// Activity Action: Dial a number as specified by the data.  This shows a
		/// UI with the number being dialed, allowing the user to explicitly
		/// initiate the call.
		/// <p>Input: If nothing, an empty dialer is started; else
		/// <see cref="getData()">getData()</see>
		/// is URI of a phone number to be dialed or a tel: URI of an explicit phone
		/// number.
		/// <p>Output: nothing.
		/// </remarks>
		public const string ACTION_DIAL = "android.intent.action.DIAL";

		/// <summary>Activity Action: Perform a call to someone specified by the data.</summary>
		/// <remarks>
		/// Activity Action: Perform a call to someone specified by the data.
		/// <p>Input: If nothing, an empty dialer is started; else
		/// <see cref="getData()">getData()</see>
		/// is URI of a phone number to be dialed or a tel: URI of an explicit phone
		/// number.
		/// <p>Output: nothing.
		/// <p>Note: there will be restrictions on which applications can initiate a
		/// call; most applications should use the
		/// <see cref="ACTION_DIAL">ACTION_DIAL</see>
		/// .
		/// <p>Note: this Intent <strong>cannot</strong> be used to call emergency
		/// numbers.  Applications can <strong>dial</strong> emergency numbers using
		/// <see cref="ACTION_DIAL">ACTION_DIAL</see>
		/// , however.
		/// </remarks>
		public const string ACTION_CALL = "android.intent.action.CALL";

		/// <summary>
		/// Activity Action: Perform a call to an emergency number specified by the
		/// data.
		/// </summary>
		/// <remarks>
		/// Activity Action: Perform a call to an emergency number specified by the
		/// data.
		/// <p>Input:
		/// <see cref="getData()">getData()</see>
		/// is URI of a phone number to be dialed or a
		/// tel: URI of an explicit phone number.
		/// <p>Output: nothing.
		/// </remarks>
		/// <hide></hide>
		public const string ACTION_CALL_EMERGENCY = "android.intent.action.CALL_EMERGENCY";

		/// <summary>
		/// Activity action: Perform a call to any number (emergency or not)
		/// specified by the data.
		/// </summary>
		/// <remarks>
		/// Activity action: Perform a call to any number (emergency or not)
		/// specified by the data.
		/// <p>Input:
		/// <see cref="getData()">getData()</see>
		/// is URI of a phone number to be dialed or a
		/// tel: URI of an explicit phone number.
		/// <p>Output: nothing.
		/// </remarks>
		/// <hide></hide>
		public const string ACTION_CALL_PRIVILEGED = "android.intent.action.CALL_PRIVILEGED";

		/// <summary>Activity Action: Send a message to someone specified by the data.</summary>
		/// <remarks>
		/// Activity Action: Send a message to someone specified by the data.
		/// <p>Input:
		/// <see cref="getData()">getData()</see>
		/// is URI describing the target.
		/// <p>Output: nothing.
		/// </remarks>
		public const string ACTION_SENDTO = "android.intent.action.SENDTO";

		/// <summary>Activity Action: Deliver some data to someone else.</summary>
		/// <remarks>
		/// Activity Action: Deliver some data to someone else.  Who the data is
		/// being delivered to is not specified; it is up to the receiver of this
		/// action to ask the user where the data should be sent.
		/// <p>
		/// When launching a SEND intent, you should usually wrap it in a chooser
		/// (through
		/// <see cref="createChooser(Intent, java.lang.CharSequence)">createChooser(Intent, java.lang.CharSequence)
		/// 	</see>
		/// ), which will give the proper interface
		/// for the user to pick how to send your data and allow you to specify
		/// a prompt indicating what they are doing.
		/// <p>
		/// Input:
		/// <see cref="getType()">getType()</see>
		/// is the MIME type of the data being sent.
		/// get*Extra can have either a
		/// <see cref="EXTRA_TEXT">EXTRA_TEXT</see>
		/// or
		/// <see cref="EXTRA_STREAM">EXTRA_STREAM</see>
		/// field, containing the data to be sent.  If
		/// using EXTRA_TEXT, the MIME type should be "text/plain"; otherwise it
		/// should be the MIME type of the data in EXTRA_STREAM.  Use
		/// <literal>*</literal>
		/// /
		/// if the MIME type is unknown (this will only allow senders that can
		/// handle generic data streams).
		/// <p>
		/// Optional standard extras, which may be interpreted by some recipients as
		/// appropriate, are:
		/// <see cref="EXTRA_EMAIL">EXTRA_EMAIL</see>
		/// ,
		/// <see cref="EXTRA_CC">EXTRA_CC</see>
		/// ,
		/// <see cref="EXTRA_BCC">EXTRA_BCC</see>
		/// ,
		/// <see cref="EXTRA_SUBJECT">EXTRA_SUBJECT</see>
		/// .
		/// <p>
		/// Output: nothing.
		/// </remarks>
		public const string ACTION_SEND = "android.intent.action.SEND";

		/// <summary>Activity Action: Deliver multiple data to someone else.</summary>
		/// <remarks>
		/// Activity Action: Deliver multiple data to someone else.
		/// <p>
		/// Like ACTION_SEND, except the data is multiple.
		/// <p>
		/// Input:
		/// <see cref="getType()">getType()</see>
		/// is the MIME type of the data being sent.
		/// get*ArrayListExtra can have either a
		/// <see cref="EXTRA_TEXT">EXTRA_TEXT</see>
		/// or
		/// <see cref="EXTRA_STREAM">EXTRA_STREAM</see>
		/// field, containing the data to be sent.
		/// <p>
		/// Multiple types are supported, and receivers should handle mixed types
		/// whenever possible. The right way for the receiver to check them is to
		/// use the content resolver on each URI. The intent sender should try to
		/// put the most concrete mime type in the intent type, but it can fall
		/// back to
		/// <literal><type>/*</literal>
		/// or
		/// <literal>*</literal>
		/// /* as needed.
		/// <p>
		/// e.g. if you are sending image/jpg and image/jpg, the intent's type can
		/// be image/jpg, but if you are sending image/jpg and image/png, then the
		/// intent's type should be image/*.
		/// <p>
		/// Optional standard extras, which may be interpreted by some recipients as
		/// appropriate, are:
		/// <see cref="EXTRA_EMAIL">EXTRA_EMAIL</see>
		/// ,
		/// <see cref="EXTRA_CC">EXTRA_CC</see>
		/// ,
		/// <see cref="EXTRA_BCC">EXTRA_BCC</see>
		/// ,
		/// <see cref="EXTRA_SUBJECT">EXTRA_SUBJECT</see>
		/// .
		/// <p>
		/// Output: nothing.
		/// </remarks>
		public const string ACTION_SEND_MULTIPLE = "android.intent.action.SEND_MULTIPLE";

		/// <summary>Activity Action: Handle an incoming phone call.</summary>
		/// <remarks>
		/// Activity Action: Handle an incoming phone call.
		/// <p>Input: nothing.
		/// <p>Output: nothing.
		/// </remarks>
		public const string ACTION_ANSWER = "android.intent.action.ANSWER";

		/// <summary>Activity Action: Insert an empty item into the given container.</summary>
		/// <remarks>
		/// Activity Action: Insert an empty item into the given container.
		/// <p>Input:
		/// <see cref="getData()">getData()</see>
		/// is URI of the directory (vnd.android.cursor.dir/*)
		/// in which to place the data.
		/// <p>Output: URI of the new data that was created.
		/// </remarks>
		public const string ACTION_INSERT = "android.intent.action.INSERT";

		/// <summary>
		/// Activity Action: Create a new item in the given container, initializing it
		/// from the current contents of the clipboard.
		/// </summary>
		/// <remarks>
		/// Activity Action: Create a new item in the given container, initializing it
		/// from the current contents of the clipboard.
		/// <p>Input:
		/// <see cref="getData()">getData()</see>
		/// is URI of the directory (vnd.android.cursor.dir/*)
		/// in which to place the data.
		/// <p>Output: URI of the new data that was created.
		/// </remarks>
		public const string ACTION_PASTE = "android.intent.action.PASTE";

		/// <summary>Activity Action: Delete the given data from its container.</summary>
		/// <remarks>
		/// Activity Action: Delete the given data from its container.
		/// <p>Input:
		/// <see cref="getData()">getData()</see>
		/// is URI of data to be deleted.
		/// <p>Output: nothing.
		/// </remarks>
		public const string ACTION_DELETE = "android.intent.action.DELETE";

		/// <summary>Activity Action: Run the data, whatever that means.</summary>
		/// <remarks>
		/// Activity Action: Run the data, whatever that means.
		/// <p>Input: ?  (Note: this is currently specific to the test harness.)
		/// <p>Output: nothing.
		/// </remarks>
		public const string ACTION_RUN = "android.intent.action.RUN";

		/// <summary>Activity Action: Perform a data synchronization.</summary>
		/// <remarks>
		/// Activity Action: Perform a data synchronization.
		/// <p>Input: ?
		/// <p>Output: ?
		/// </remarks>
		public const string ACTION_SYNC = "android.intent.action.SYNC";

		/// <summary>
		/// Activity Action: Pick an activity given an intent, returning the class
		/// selected.
		/// </summary>
		/// <remarks>
		/// Activity Action: Pick an activity given an intent, returning the class
		/// selected.
		/// <p>Input: get*Extra field
		/// <see cref="EXTRA_INTENT">EXTRA_INTENT</see>
		/// is an Intent
		/// used with
		/// <see cref="android.content.pm.PackageManager.queryIntentActivities(Intent, int)">android.content.pm.PackageManager.queryIntentActivities(Intent, int)
		/// 	</see>
		/// to determine the
		/// set of activities from which to pick.
		/// <p>Output: Class name of the activity that was selected.
		/// </remarks>
		public const string ACTION_PICK_ACTIVITY = "android.intent.action.PICK_ACTIVITY";

		/// <summary>Activity Action: Perform a search.</summary>
		/// <remarks>
		/// Activity Action: Perform a search.
		/// <p>Input:
		/// <see cref="android.app.SearchManager.QUERY">getStringExtra(SearchManager.QUERY)</see>
		/// is the text to search for.  If empty, simply
		/// enter your search results Activity with the search UI activated.
		/// <p>Output: nothing.
		/// </remarks>
		public const string ACTION_SEARCH = "android.intent.action.SEARCH";

		/// <summary>
		/// Activity Action: Start the platform-defined tutorial
		/// <p>Input:
		/// <see cref="android.app.SearchManager.QUERY">getStringExtra(SearchManager.QUERY)</see>
		/// is the text to search for.  If empty, simply
		/// enter your search results Activity with the search UI activated.
		/// <p>Output: nothing.
		/// </summary>
		public const string ACTION_SYSTEM_TUTORIAL = "android.intent.action.SYSTEM_TUTORIAL";

		/// <summary>Activity Action: Perform a web search.</summary>
		/// <remarks>
		/// Activity Action: Perform a web search.
		/// <p>
		/// Input:
		/// <see cref="android.app.SearchManager.QUERY">getStringExtra(SearchManager.QUERY)</see>
		/// is the text to search for. If it is
		/// a url starts with http or https, the site will be opened. If it is plain
		/// text, Google search will be applied.
		/// <p>
		/// Output: nothing.
		/// </remarks>
		public const string ACTION_WEB_SEARCH = "android.intent.action.WEB_SEARCH";

		/// <summary>
		/// Activity Action: List all available applications
		/// <p>Input: Nothing.
		/// </summary>
		/// <remarks>
		/// Activity Action: List all available applications
		/// <p>Input: Nothing.
		/// <p>Output: nothing.
		/// </remarks>
		public const string ACTION_ALL_APPS = "android.intent.action.ALL_APPS";

		/// <summary>
		/// Activity Action: Show settings for choosing wallpaper
		/// <p>Input: Nothing.
		/// </summary>
		/// <remarks>
		/// Activity Action: Show settings for choosing wallpaper
		/// <p>Input: Nothing.
		/// <p>Output: Nothing.
		/// </remarks>
		public const string ACTION_SET_WALLPAPER = "android.intent.action.SET_WALLPAPER";

		/// <summary>Activity Action: Show activity for reporting a bug.</summary>
		/// <remarks>
		/// Activity Action: Show activity for reporting a bug.
		/// <p>Input: Nothing.
		/// <p>Output: Nothing.
		/// </remarks>
		public const string ACTION_BUG_REPORT = "android.intent.action.BUG_REPORT";

		/// <summary>Activity Action: Main entry point for factory tests.</summary>
		/// <remarks>
		/// Activity Action: Main entry point for factory tests.  Only used when
		/// the device is booting in factory test node.  The implementing package
		/// must be installed in the system image.
		/// <p>Input: nothing
		/// <p>Output: nothing
		/// </remarks>
		public const string ACTION_FACTORY_TEST = "android.intent.action.FACTORY_TEST";

		/// <summary>
		/// Activity Action: The user pressed the "call" button to go to the dialer
		/// or other appropriate UI for placing a call.
		/// </summary>
		/// <remarks>
		/// Activity Action: The user pressed the "call" button to go to the dialer
		/// or other appropriate UI for placing a call.
		/// <p>Input: Nothing.
		/// <p>Output: Nothing.
		/// </remarks>
		public const string ACTION_CALL_BUTTON = "android.intent.action.CALL_BUTTON";

		/// <summary>Activity Action: Start Voice Command.</summary>
		/// <remarks>
		/// Activity Action: Start Voice Command.
		/// <p>Input: Nothing.
		/// <p>Output: Nothing.
		/// </remarks>
		public const string ACTION_VOICE_COMMAND = "android.intent.action.VOICE_COMMAND";

		/// <summary>
		/// Activity Action: Start action associated with long pressing on the
		/// search key.
		/// </summary>
		/// <remarks>
		/// Activity Action: Start action associated with long pressing on the
		/// search key.
		/// <p>Input: Nothing.
		/// <p>Output: Nothing.
		/// </remarks>
		public const string ACTION_SEARCH_LONG_PRESS = "android.intent.action.SEARCH_LONG_PRESS";

		/// <summary>Activity Action: The user pressed the "Report" button in the crash/ANR dialog.
		/// 	</summary>
		/// <remarks>
		/// Activity Action: The user pressed the "Report" button in the crash/ANR dialog.
		/// This intent is delivered to the package which installed the application, usually
		/// the Market.
		/// <p>Input: No data is specified. The bug report is passed in using
		/// an
		/// <see cref="EXTRA_BUG_REPORT">EXTRA_BUG_REPORT</see>
		/// field.
		/// <p>Output: Nothing.
		/// </remarks>
		/// <seealso cref="EXTRA_BUG_REPORT">EXTRA_BUG_REPORT</seealso>
		public const string ACTION_APP_ERROR = "android.intent.action.APP_ERROR";

		/// <summary>Activity Action: Show power usage information to the user.</summary>
		/// <remarks>
		/// Activity Action: Show power usage information to the user.
		/// <p>Input: Nothing.
		/// <p>Output: Nothing.
		/// </remarks>
		public const string ACTION_POWER_USAGE_SUMMARY = "android.intent.action.POWER_USAGE_SUMMARY";

		/// <summary>Activity Action: Setup wizard to launch after a platform update.</summary>
		/// <remarks>
		/// Activity Action: Setup wizard to launch after a platform update.  This
		/// activity should have a string meta-data field associated with it,
		/// <see cref="METADATA_SETUP_VERSION">METADATA_SETUP_VERSION</see>
		/// , which defines the current version of
		/// the platform for setup.  The activity will be launched only if
		/// <see cref="android.provider.Settings.Secure.LAST_SETUP_SHOWN">android.provider.Settings.Secure.LAST_SETUP_SHOWN
		/// 	</see>
		/// is not the
		/// same value.
		/// <p>Input: Nothing.
		/// <p>Output: Nothing.
		/// </remarks>
		/// <hide></hide>
		public const string ACTION_UPGRADE_SETUP = "android.intent.action.UPGRADE_SETUP";

		/// <summary>
		/// Activity Action: Show settings for managing network data usage of a
		/// specific application.
		/// </summary>
		/// <remarks>
		/// Activity Action: Show settings for managing network data usage of a
		/// specific application. Applications should define an activity that offers
		/// options to control data usage.
		/// </remarks>
		public const string ACTION_MANAGE_NETWORK_USAGE = "android.intent.action.MANAGE_NETWORK_USAGE";

		/// <summary>Activity Action: Launch application installer.</summary>
		/// <remarks>
		/// Activity Action: Launch application installer.
		/// <p>
		/// Input: The data must be a content: or file: URI at which the application
		/// can be retrieved.  You can optionally supply
		/// <see cref="EXTRA_INSTALLER_PACKAGE_NAME">EXTRA_INSTALLER_PACKAGE_NAME</see>
		/// ,
		/// <see cref="EXTRA_NOT_UNKNOWN_SOURCE">EXTRA_NOT_UNKNOWN_SOURCE</see>
		/// ,
		/// <see cref="EXTRA_ALLOW_REPLACE">EXTRA_ALLOW_REPLACE</see>
		/// , and
		/// <see cref="EXTRA_RETURN_RESULT">EXTRA_RETURN_RESULT</see>
		/// .
		/// <p>
		/// Output: If
		/// <see cref="EXTRA_RETURN_RESULT">EXTRA_RETURN_RESULT</see>
		/// , returns whether the install
		/// succeeded.
		/// </remarks>
		/// <seealso cref="EXTRA_INSTALLER_PACKAGE_NAME">EXTRA_INSTALLER_PACKAGE_NAME</seealso>
		/// <seealso cref="EXTRA_NOT_UNKNOWN_SOURCE">EXTRA_NOT_UNKNOWN_SOURCE</seealso>
		/// <seealso cref="EXTRA_RETURN_RESULT">EXTRA_RETURN_RESULT</seealso>
		public const string ACTION_INSTALL_PACKAGE = "android.intent.action.INSTALL_PACKAGE";

		/// <summary>
		/// Used as a string extra field with
		/// <see cref="ACTION_INSTALL_PACKAGE">ACTION_INSTALL_PACKAGE</see>
		/// to install a
		/// package.  Specifies the installer package name; this package will receive the
		/// <see cref="ACTION_APP_ERROR">ACTION_APP_ERROR</see>
		/// intent.
		/// </summary>
		public const string EXTRA_INSTALLER_PACKAGE_NAME = "android.intent.extra.INSTALLER_PACKAGE_NAME";

		/// <summary>
		/// Used as a boolean extra field with
		/// <see cref="ACTION_INSTALL_PACKAGE">ACTION_INSTALL_PACKAGE</see>
		/// to install a
		/// package.  Specifies that the application being installed should not be
		/// treated as coming from an unknown source, but as coming from the app
		/// invoking the Intent.  For this to work you must start the installer with
		/// startActivityForResult().
		/// </summary>
		public const string EXTRA_NOT_UNKNOWN_SOURCE = "android.intent.extra.NOT_UNKNOWN_SOURCE";

		/// <summary>
		/// Used as a boolean extra field with
		/// <see cref="ACTION_INSTALL_PACKAGE">ACTION_INSTALL_PACKAGE</see>
		/// to install a
		/// package.  Tells the installer UI to skip the confirmation with the user
		/// if the .apk is replacing an existing one.
		/// </summary>
		public const string EXTRA_ALLOW_REPLACE = "android.intent.extra.ALLOW_REPLACE";

		/// <summary>
		/// Used as a boolean extra field with
		/// <see cref="ACTION_INSTALL_PACKAGE">ACTION_INSTALL_PACKAGE</see>
		/// or
		/// <see cref="ACTION_UNINSTALL_PACKAGE">ACTION_UNINSTALL_PACKAGE</see>
		/// .  Specifies that the installer UI should
		/// return to the application the result code of the install/uninstall.  The returned result
		/// code will be
		/// <see cref="android.app.Activity.RESULT_OK">android.app.Activity.RESULT_OK</see>
		/// on success or
		/// <see cref="android.app.Activity.RESULT_FIRST_USER">android.app.Activity.RESULT_FIRST_USER
		/// 	</see>
		/// on failure.
		/// </summary>
		public const string EXTRA_RETURN_RESULT = "android.intent.extra.RETURN_RESULT";

		/// <summary>Package manager install result code.</summary>
		/// <remarks>
		/// Package manager install result code.  @hide because result codes are not
		/// yet ready to be exposed.
		/// </remarks>
		public const string EXTRA_INSTALL_RESULT = "android.intent.extra.INSTALL_RESULT";

		/// <summary>Activity Action: Launch application uninstaller.</summary>
		/// <remarks>
		/// Activity Action: Launch application uninstaller.
		/// <p>
		/// Input: The data must be a package: URI whose scheme specific part is
		/// the package name of the current installed package to be uninstalled.
		/// You can optionally supply
		/// <see cref="EXTRA_RETURN_RESULT">EXTRA_RETURN_RESULT</see>
		/// .
		/// <p>
		/// Output: If
		/// <see cref="EXTRA_RETURN_RESULT">EXTRA_RETURN_RESULT</see>
		/// , returns whether the install
		/// succeeded.
		/// </remarks>
		public const string ACTION_UNINSTALL_PACKAGE = "android.intent.action.UNINSTALL_PACKAGE";

		/// <summary>
		/// A string associated with a
		/// <see cref="ACTION_UPGRADE_SETUP">ACTION_UPGRADE_SETUP</see>
		/// activity
		/// describing the last run version of the platform that was setup.
		/// </summary>
		/// <hide></hide>
		public const string METADATA_SETUP_VERSION = "android.SETUP_VERSION";

		/// <summary>Broadcast Action: Sent after the screen turns off.</summary>
		/// <remarks>
		/// Broadcast Action: Sent after the screen turns off.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_SCREEN_OFF = "android.intent.action.SCREEN_OFF";

		/// <summary>Broadcast Action: Sent after the screen turns on.</summary>
		/// <remarks>
		/// Broadcast Action: Sent after the screen turns on.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_SCREEN_ON = "android.intent.action.SCREEN_ON";

		/// <summary>
		/// Broadcast Action: Sent when the user is present after device wakes up (e.g when the
		/// keyguard is gone).
		/// </summary>
		/// <remarks>
		/// Broadcast Action: Sent when the user is present after device wakes up (e.g when the
		/// keyguard is gone).
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_USER_PRESENT = "android.intent.action.USER_PRESENT";

		/// <summary>Broadcast Action: The current time has changed.</summary>
		/// <remarks>
		/// Broadcast Action: The current time has changed.  Sent every
		/// minute.  You can <em>not</em> receive this through components declared
		/// in manifests, only by exlicitly registering for it with
		/// <see cref="Context.registerReceiver(BroadcastReceiver, IntentFilter)">Context.registerReceiver()
		/// 	</see>
		/// .
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_TIME_TICK = "android.intent.action.TIME_TICK";

		/// <summary>Broadcast Action: The time was set.</summary>
		/// <remarks>Broadcast Action: The time was set.</remarks>
		public const string ACTION_TIME_CHANGED = "android.intent.action.TIME_SET";

		/// <summary>Broadcast Action: The date has changed.</summary>
		/// <remarks>Broadcast Action: The date has changed.</remarks>
		public const string ACTION_DATE_CHANGED = "android.intent.action.DATE_CHANGED";

		/// <summary>Broadcast Action: The timezone has changed.</summary>
		/// <remarks>
		/// Broadcast Action: The timezone has changed. The intent will have the following extra values:</p>
		/// <ul>
		/// <li><em>time-zone</em> - The java.util.TimeZone.getID() value identifying the new time zone.</li>
		/// </ul>
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_TIMEZONE_CHANGED = "android.intent.action.TIMEZONE_CHANGED";

		/// <summary>
		/// Clear DNS Cache Action: This is broadcast when networks have changed and old
		/// DNS entries should be tossed.
		/// </summary>
		/// <remarks>
		/// Clear DNS Cache Action: This is broadcast when networks have changed and old
		/// DNS entries should be tossed.
		/// </remarks>
		/// <hide></hide>
		public const string ACTION_CLEAR_DNS_CACHE = "android.intent.action.CLEAR_DNS_CACHE";

		/// <summary>
		/// Alarm Changed Action: This is broadcast when the AlarmClock
		/// application's alarm is set or unset.
		/// </summary>
		/// <remarks>
		/// Alarm Changed Action: This is broadcast when the AlarmClock
		/// application's alarm is set or unset.  It is used by the
		/// AlarmClock application and the StatusBar service.
		/// </remarks>
		/// <hide></hide>
		public const string ACTION_ALARM_CHANGED = "android.intent.action.ALARM_CHANGED";

		/// <summary>
		/// Sync State Changed Action: This is broadcast when the sync starts or stops or when one has
		/// been failing for a long time.
		/// </summary>
		/// <remarks>
		/// Sync State Changed Action: This is broadcast when the sync starts or stops or when one has
		/// been failing for a long time.  It is used by the SyncManager and the StatusBar service.
		/// </remarks>
		/// <hide></hide>
		public const string ACTION_SYNC_STATE_CHANGED = "android.intent.action.SYNC_STATE_CHANGED";

		/// <summary>
		/// Broadcast Action: This is broadcast once, after the system has finished
		/// booting.
		/// </summary>
		/// <remarks>
		/// Broadcast Action: This is broadcast once, after the system has finished
		/// booting.  It can be used to perform application-specific initialization,
		/// such as installing alarms.  You must hold the
		/// <see cref="android.Manifest.permission.RECEIVE_BOOT_COMPLETED">android.Manifest.permission.RECEIVE_BOOT_COMPLETED
		/// 	</see>
		/// permission
		/// in order to receive this broadcast.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_BOOT_COMPLETED = "android.intent.action.BOOT_COMPLETED";

		/// <summary>
		/// Broadcast Action: This is broadcast when a user action should request a
		/// temporary system dialog to dismiss.
		/// </summary>
		/// <remarks>
		/// Broadcast Action: This is broadcast when a user action should request a
		/// temporary system dialog to dismiss.  Some examples of temporary system
		/// dialogs are the notification window-shade and the recent tasks dialog.
		/// </remarks>
		public const string ACTION_CLOSE_SYSTEM_DIALOGS = "android.intent.action.CLOSE_SYSTEM_DIALOGS";

		/// <summary>
		/// Broadcast Action: Trigger the download and eventual installation
		/// of a package.
		/// </summary>
		/// <remarks>
		/// Broadcast Action: Trigger the download and eventual installation
		/// of a package.
		/// <p>Input:
		/// <see cref="getData()">getData()</see>
		/// is the URI of the package file to download.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		[System.ObsoleteAttribute(@"This constant has never been used.")]
		public const string ACTION_PACKAGE_INSTALL = "android.intent.action.PACKAGE_INSTALL";

		/// <summary>
		/// Broadcast Action: A new application package has been installed on the
		/// device.
		/// </summary>
		/// <remarks>
		/// Broadcast Action: A new application package has been installed on the
		/// device. The data contains the name of the package.  Note that the
		/// newly installed package does <em>not</em> receive this broadcast.
		/// <p>My include the following extras:
		/// <ul>
		/// <li>
		/// <see cref="EXTRA_UID">EXTRA_UID</see>
		/// containing the integer uid assigned to the new package.
		/// <li>
		/// <see cref="EXTRA_REPLACING">EXTRA_REPLACING</see>
		/// is set to true if this is following
		/// an
		/// <see cref="ACTION_PACKAGE_REMOVED">ACTION_PACKAGE_REMOVED</see>
		/// broadcast for the same package.
		/// </ul>
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_PACKAGE_ADDED = "android.intent.action.PACKAGE_ADDED";

		/// <summary>
		/// Broadcast Action: A new version of an application package has been
		/// installed, replacing an existing version that was previously installed.
		/// </summary>
		/// <remarks>
		/// Broadcast Action: A new version of an application package has been
		/// installed, replacing an existing version that was previously installed.
		/// The data contains the name of the package.
		/// <p>My include the following extras:
		/// <ul>
		/// <li>
		/// <see cref="EXTRA_UID">EXTRA_UID</see>
		/// containing the integer uid assigned to the new package.
		/// </ul>
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_PACKAGE_REPLACED = "android.intent.action.PACKAGE_REPLACED";

		/// <summary>
		/// Broadcast Action: A new version of your application has been installed
		/// over an existing one.
		/// </summary>
		/// <remarks>
		/// Broadcast Action: A new version of your application has been installed
		/// over an existing one.  This is only sent to the application that was
		/// replaced.  It does not contain any additional data; to receive it, just
		/// use an intent filter for this action.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_MY_PACKAGE_REPLACED = "android.intent.action.MY_PACKAGE_REPLACED";

		/// <summary>
		/// Broadcast Action: An existing application package has been removed from
		/// the device.
		/// </summary>
		/// <remarks>
		/// Broadcast Action: An existing application package has been removed from
		/// the device.  The data contains the name of the package.  The package
		/// that is being installed does <em>not</em> receive this Intent.
		/// <ul>
		/// <li>
		/// <see cref="EXTRA_UID">EXTRA_UID</see>
		/// containing the integer uid previously assigned
		/// to the package.
		/// <li>
		/// <see cref="EXTRA_DATA_REMOVED">EXTRA_DATA_REMOVED</see>
		/// is set to true if the entire
		/// application -- data and code -- is being removed.
		/// <li>
		/// <see cref="EXTRA_REPLACING">EXTRA_REPLACING</see>
		/// is set to true if this will be followed
		/// by an
		/// <see cref="ACTION_PACKAGE_ADDED">ACTION_PACKAGE_ADDED</see>
		/// broadcast for the same package.
		/// </ul>
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_PACKAGE_REMOVED = "android.intent.action.PACKAGE_REMOVED";

		/// <summary>
		/// Broadcast Action: An existing application package has been completely
		/// removed from the device.
		/// </summary>
		/// <remarks>
		/// Broadcast Action: An existing application package has been completely
		/// removed from the device.  The data contains the name of the package.
		/// This is like
		/// <see cref="ACTION_PACKAGE_REMOVED">ACTION_PACKAGE_REMOVED</see>
		/// , but only set when
		/// <see cref="EXTRA_DATA_REMOVED">EXTRA_DATA_REMOVED</see>
		/// is true and
		/// <see cref="EXTRA_REPLACING">EXTRA_REPLACING</see>
		/// is false of that broadcast.
		/// <ul>
		/// <li>
		/// <see cref="EXTRA_UID">EXTRA_UID</see>
		/// containing the integer uid previously assigned
		/// to the package.
		/// </ul>
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_PACKAGE_FULLY_REMOVED = "android.intent.action.PACKAGE_FULLY_REMOVED";

		/// <summary>Broadcast Action: An existing application package has been changed (e.g.
		/// 	</summary>
		/// <remarks>
		/// Broadcast Action: An existing application package has been changed (e.g.
		/// a component has been enabled or disabled).  The data contains the name of
		/// the package.
		/// <ul>
		/// <li>
		/// <see cref="EXTRA_UID">EXTRA_UID</see>
		/// containing the integer uid assigned to the package.
		/// <li>
		/// <see cref="EXTRA_CHANGED_COMPONENT_NAME_LIST">EXTRA_CHANGED_COMPONENT_NAME_LIST</see>
		/// containing the class name
		/// of the changed components.
		/// <li>
		/// <see cref="EXTRA_DONT_KILL_APP">EXTRA_DONT_KILL_APP</see>
		/// containing boolean field to override the
		/// default action of restarting the application.
		/// </ul>
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_PACKAGE_CHANGED = "android.intent.action.PACKAGE_CHANGED";

		/// <hide>
		/// Broadcast Action: Ask system services if there is any reason to
		/// restart the given package.  The data contains the name of the
		/// package.
		/// <ul>
		/// <li>
		/// <see cref="EXTRA_UID">EXTRA_UID</see>
		/// containing the integer uid assigned to the package.
		/// <li>
		/// <see cref="EXTRA_PACKAGES">EXTRA_PACKAGES</see>
		/// String array of all packages to check.
		/// </ul>
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </hide>
		public const string ACTION_QUERY_PACKAGE_RESTART = "android.intent.action.QUERY_PACKAGE_RESTART";

		/// <summary>
		/// Broadcast Action: The user has restarted a package, and all of its
		/// processes have been killed.
		/// </summary>
		/// <remarks>
		/// Broadcast Action: The user has restarted a package, and all of its
		/// processes have been killed.  All runtime state
		/// associated with it (processes, alarms, notifications, etc) should
		/// be removed.  Note that the restarted package does <em>not</em>
		/// receive this broadcast.
		/// The data contains the name of the package.
		/// <ul>
		/// <li>
		/// <see cref="EXTRA_UID">EXTRA_UID</see>
		/// containing the integer uid assigned to the package.
		/// </ul>
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_PACKAGE_RESTARTED = "android.intent.action.PACKAGE_RESTARTED";

		/// <summary>Broadcast Action: The user has cleared the data of a package.</summary>
		/// <remarks>
		/// Broadcast Action: The user has cleared the data of a package.  This should
		/// be preceded by
		/// <see cref="ACTION_PACKAGE_RESTARTED">ACTION_PACKAGE_RESTARTED</see>
		/// , after which all of
		/// its persistent data is erased and this broadcast sent.
		/// Note that the cleared package does <em>not</em>
		/// receive this broadcast. The data contains the name of the package.
		/// <ul>
		/// <li>
		/// <see cref="EXTRA_UID">EXTRA_UID</see>
		/// containing the integer uid assigned to the package.
		/// </ul>
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_PACKAGE_DATA_CLEARED = "android.intent.action.PACKAGE_DATA_CLEARED";

		/// <summary>Broadcast Action: A user ID has been removed from the system.</summary>
		/// <remarks>
		/// Broadcast Action: A user ID has been removed from the system.  The user
		/// ID number is stored in the extra data under
		/// <see cref="EXTRA_UID">EXTRA_UID</see>
		/// .
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_UID_REMOVED = "android.intent.action.UID_REMOVED";

		/// <summary>
		/// Broadcast Action: Sent to the installer package of an application
		/// when that application is first launched (that is the first time it
		/// is moved out of the stopped state).
		/// </summary>
		/// <remarks>
		/// Broadcast Action: Sent to the installer package of an application
		/// when that application is first launched (that is the first time it
		/// is moved out of the stopped state).  The data contains the name of the package.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_PACKAGE_FIRST_LAUNCH = "android.intent.action.PACKAGE_FIRST_LAUNCH";

		/// <summary>
		/// Broadcast Action: Sent to the system package verifier when a package
		/// needs to be verified.
		/// </summary>
		/// <remarks>
		/// Broadcast Action: Sent to the system package verifier when a package
		/// needs to be verified. The data contains the package URI.
		/// <p class="note">
		/// This is a protected intent that can only be sent by the system.
		/// </p>
		/// </remarks>
		public const string ACTION_PACKAGE_NEEDS_VERIFICATION = "android.intent.action.PACKAGE_NEEDS_VERIFICATION";

		/// <summary>
		/// Broadcast Action: Resources for a set of packages (which were
		/// previously unavailable) are currently
		/// available since the media on which they exist is available.
		/// </summary>
		/// <remarks>
		/// Broadcast Action: Resources for a set of packages (which were
		/// previously unavailable) are currently
		/// available since the media on which they exist is available.
		/// The extra data
		/// <see cref="EXTRA_CHANGED_PACKAGE_LIST">EXTRA_CHANGED_PACKAGE_LIST</see>
		/// contains a
		/// list of packages whose availability changed.
		/// The extra data
		/// <see cref="EXTRA_CHANGED_UID_LIST">EXTRA_CHANGED_UID_LIST</see>
		/// contains a
		/// list of uids of packages whose availability changed.
		/// Note that the
		/// packages in this list do <em>not</em> receive this broadcast.
		/// The specified set of packages are now available on the system.
		/// <p>Includes the following extras:
		/// <ul>
		/// <li>
		/// <see cref="EXTRA_CHANGED_PACKAGE_LIST">EXTRA_CHANGED_PACKAGE_LIST</see>
		/// is the set of packages
		/// whose resources(were previously unavailable) are currently available.
		/// <see cref="EXTRA_CHANGED_UID_LIST">EXTRA_CHANGED_UID_LIST</see>
		/// is the set of uids of the
		/// packages whose resources(were previously unavailable)
		/// are  currently available.
		/// </ul>
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_EXTERNAL_APPLICATIONS_AVAILABLE = "android.intent.action.EXTERNAL_APPLICATIONS_AVAILABLE";

		/// <summary>
		/// Broadcast Action: Resources for a set of packages are currently
		/// unavailable since the media on which they exist is unavailable.
		/// </summary>
		/// <remarks>
		/// Broadcast Action: Resources for a set of packages are currently
		/// unavailable since the media on which they exist is unavailable.
		/// The extra data
		/// <see cref="EXTRA_CHANGED_PACKAGE_LIST">EXTRA_CHANGED_PACKAGE_LIST</see>
		/// contains a
		/// list of packages whose availability changed.
		/// The extra data
		/// <see cref="EXTRA_CHANGED_UID_LIST">EXTRA_CHANGED_UID_LIST</see>
		/// contains a
		/// list of uids of packages whose availability changed.
		/// The specified set of packages can no longer be
		/// launched and are practically unavailable on the system.
		/// <p>Inclues the following extras:
		/// <ul>
		/// <li>
		/// <see cref="EXTRA_CHANGED_PACKAGE_LIST">EXTRA_CHANGED_PACKAGE_LIST</see>
		/// is the set of packages
		/// whose resources are no longer available.
		/// <see cref="EXTRA_CHANGED_UID_LIST">EXTRA_CHANGED_UID_LIST</see>
		/// is the set of packages
		/// whose resources are no longer available.
		/// </ul>
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_EXTERNAL_APPLICATIONS_UNAVAILABLE = "android.intent.action.EXTERNAL_APPLICATIONS_UNAVAILABLE";

		/// <summary>Broadcast Action:  The current system wallpaper has changed.</summary>
		/// <remarks>
		/// Broadcast Action:  The current system wallpaper has changed.  See
		/// <see cref="android.app.WallpaperManager">android.app.WallpaperManager</see>
		/// for retrieving the new wallpaper.
		/// </remarks>
		public const string ACTION_WALLPAPER_CHANGED = "android.intent.action.WALLPAPER_CHANGED";

		/// <summary>
		/// Broadcast Action: The current device
		/// <see cref="android.content.res.Configuration">android.content.res.Configuration</see>
		/// (orientation, locale, etc) has changed.  When such a change happens, the
		/// UIs (view hierarchy) will need to be rebuilt based on this new
		/// information; for the most part, applications don't need to worry about
		/// this, because the system will take care of stopping and restarting the
		/// application to make sure it sees the new changes.  Some system code that
		/// can not be restarted will need to watch for this action and handle it
		/// appropriately.
		/// <p class="note">
		/// You can <em>not</em> receive this through components declared
		/// in manifests, only by explicitly registering for it with
		/// <see cref="Context.registerReceiver(BroadcastReceiver, IntentFilter)">Context.registerReceiver()
		/// 	</see>
		/// .
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </summary>
		/// <seealso cref="android.content.res.Configuration">android.content.res.Configuration
		/// 	</seealso>
		public const string ACTION_CONFIGURATION_CHANGED = "android.intent.action.CONFIGURATION_CHANGED";

		/// <summary>Broadcast Action: The current device's locale has changed.</summary>
		/// <remarks>
		/// Broadcast Action: The current device's locale has changed.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_LOCALE_CHANGED = "android.intent.action.LOCALE_CHANGED";

		/// <summary>
		/// Broadcast Action:  This is a <em>sticky broadcast</em> containing the
		/// charging state, level, and other information about the battery.
		/// </summary>
		/// <remarks>
		/// Broadcast Action:  This is a <em>sticky broadcast</em> containing the
		/// charging state, level, and other information about the battery.
		/// See
		/// <see cref="android.os.BatteryManager">android.os.BatteryManager</see>
		/// for documentation on the
		/// contents of the Intent.
		/// <p class="note">
		/// You can <em>not</em> receive this through components declared
		/// in manifests, only by explicitly registering for it with
		/// <see cref="Context.registerReceiver(BroadcastReceiver, IntentFilter)">Context.registerReceiver()
		/// 	</see>
		/// .  See
		/// <see cref="ACTION_BATTERY_LOW">ACTION_BATTERY_LOW</see>
		/// ,
		/// <see cref="ACTION_BATTERY_OKAY">ACTION_BATTERY_OKAY</see>
		/// ,
		/// <see cref="ACTION_POWER_CONNECTED">ACTION_POWER_CONNECTED</see>
		/// ,
		/// and
		/// <see cref="ACTION_POWER_DISCONNECTED">ACTION_POWER_DISCONNECTED</see>
		/// for distinct battery-related
		/// broadcasts that are sent and can be received through manifest
		/// receivers.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_BATTERY_CHANGED = "android.intent.action.BATTERY_CHANGED";

		/// <summary>Broadcast Action:  Indicates low battery condition on the device.</summary>
		/// <remarks>
		/// Broadcast Action:  Indicates low battery condition on the device.
		/// This broadcast corresponds to the "Low battery warning" system dialog.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_BATTERY_LOW = "android.intent.action.BATTERY_LOW";

		/// <summary>Broadcast Action:  Indicates the battery is now okay after being low.</summary>
		/// <remarks>
		/// Broadcast Action:  Indicates the battery is now okay after being low.
		/// This will be sent after
		/// <see cref="ACTION_BATTERY_LOW">ACTION_BATTERY_LOW</see>
		/// once the battery has
		/// gone back up to an okay state.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_BATTERY_OKAY = "android.intent.action.BATTERY_OKAY";

		/// <summary>Broadcast Action:  External power has been connected to the device.</summary>
		/// <remarks>
		/// Broadcast Action:  External power has been connected to the device.
		/// This is intended for applications that wish to register specifically to this notification.
		/// Unlike ACTION_BATTERY_CHANGED, applications will be woken for this and so do not have to
		/// stay active to receive this notification.  This action can be used to implement actions
		/// that wait until power is available to trigger.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_POWER_CONNECTED = "android.intent.action.ACTION_POWER_CONNECTED";

		/// <summary>Broadcast Action:  External power has been removed from the device.</summary>
		/// <remarks>
		/// Broadcast Action:  External power has been removed from the device.
		/// This is intended for applications that wish to register specifically to this notification.
		/// Unlike ACTION_BATTERY_CHANGED, applications will be woken for this and so do not have to
		/// stay active to receive this notification.  This action can be used to implement actions
		/// that wait until power is available to trigger.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_POWER_DISCONNECTED = "android.intent.action.ACTION_POWER_DISCONNECTED";

		/// <summary>Broadcast Action:  Device is shutting down.</summary>
		/// <remarks>
		/// Broadcast Action:  Device is shutting down.
		/// This is broadcast when the device is being shut down (completely turned
		/// off, not sleeping).  Once the broadcast is complete, the final shutdown
		/// will proceed and all unsaved data lost.  Apps will not normally need
		/// to handle this, since the foreground activity will be paused as well.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_SHUTDOWN = "android.intent.action.ACTION_SHUTDOWN";

		/// <summary>Activity Action:  Start this activity to request system shutdown.</summary>
		/// <remarks>
		/// Activity Action:  Start this activity to request system shutdown.
		/// The optional boolean extra field
		/// <see cref="EXTRA_KEY_CONFIRM">EXTRA_KEY_CONFIRM</see>
		/// can be set to true
		/// to request confirmation from the user before shutting down.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// <hide></hide>
		/// </remarks>
		public const string ACTION_REQUEST_SHUTDOWN = "android.intent.action.ACTION_REQUEST_SHUTDOWN";

		/// <summary>
		/// Broadcast Action:  A sticky broadcast that indicates low memory
		/// condition on the device
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </summary>
		/// <remarks>
		/// Broadcast Action:  A sticky broadcast that indicates low memory
		/// condition on the device
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_DEVICE_STORAGE_LOW = "android.intent.action.DEVICE_STORAGE_LOW";

		/// <summary>
		/// Broadcast Action:  Indicates low memory condition on the device no longer exists
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </summary>
		/// <remarks>
		/// Broadcast Action:  Indicates low memory condition on the device no longer exists
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_DEVICE_STORAGE_OK = "android.intent.action.DEVICE_STORAGE_OK";

		/// <summary>
		/// Broadcast Action:  A sticky broadcast that indicates a memory full
		/// condition on the device.
		/// </summary>
		/// <remarks>
		/// Broadcast Action:  A sticky broadcast that indicates a memory full
		/// condition on the device. This is intended for activities that want
		/// to be able to fill the data partition completely, leaving only
		/// enough free space to prevent system-wide SQLite failures.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// <hide></hide>
		/// </remarks>
		public const string ACTION_DEVICE_STORAGE_FULL = "android.intent.action.DEVICE_STORAGE_FULL";

		/// <summary>
		/// Broadcast Action:  Indicates memory full condition on the device
		/// no longer exists.
		/// </summary>
		/// <remarks>
		/// Broadcast Action:  Indicates memory full condition on the device
		/// no longer exists.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// <hide></hide>
		/// </remarks>
		public const string ACTION_DEVICE_STORAGE_NOT_FULL = "android.intent.action.DEVICE_STORAGE_NOT_FULL";

		/// <summary>
		/// Broadcast Action:  Indicates low memory condition notification acknowledged by user
		/// and package management should be started.
		/// </summary>
		/// <remarks>
		/// Broadcast Action:  Indicates low memory condition notification acknowledged by user
		/// and package management should be started.
		/// This is triggered by the user from the ACTION_DEVICE_STORAGE_LOW
		/// notification.
		/// </remarks>
		public const string ACTION_MANAGE_PACKAGE_STORAGE = "android.intent.action.MANAGE_PACKAGE_STORAGE";

		/// <summary>Broadcast Action:  The device has entered USB Mass Storage mode.</summary>
		/// <remarks>
		/// Broadcast Action:  The device has entered USB Mass Storage mode.
		/// This is used mainly for the USB Settings panel.
		/// Apps should listen for ACTION_MEDIA_MOUNTED and ACTION_MEDIA_UNMOUNTED broadcasts to be notified
		/// when the SD card file system is mounted or unmounted
		/// </remarks>
		[System.ObsoleteAttribute(@"replaced by android.os.storage.StorageEventListener")]
		public const string ACTION_UMS_CONNECTED = "android.intent.action.UMS_CONNECTED";

		/// <summary>Broadcast Action:  The device has exited USB Mass Storage mode.</summary>
		/// <remarks>
		/// Broadcast Action:  The device has exited USB Mass Storage mode.
		/// This is used mainly for the USB Settings panel.
		/// Apps should listen for ACTION_MEDIA_MOUNTED and ACTION_MEDIA_UNMOUNTED broadcasts to be notified
		/// when the SD card file system is mounted or unmounted
		/// </remarks>
		[System.ObsoleteAttribute(@"replaced by android.os.storage.StorageEventListener")]
		public const string ACTION_UMS_DISCONNECTED = "android.intent.action.UMS_DISCONNECTED";

		/// <summary>Broadcast Action:  External media has been removed.</summary>
		/// <remarks>
		/// Broadcast Action:  External media has been removed.
		/// The path to the mount point for the removed media is contained in the Intent.mData field.
		/// </remarks>
		public const string ACTION_MEDIA_REMOVED = "android.intent.action.MEDIA_REMOVED";

		/// <summary>Broadcast Action:  External media is present, but not mounted at its mount point.
		/// 	</summary>
		/// <remarks>
		/// Broadcast Action:  External media is present, but not mounted at its mount point.
		/// The path to the mount point for the removed media is contained in the Intent.mData field.
		/// </remarks>
		public const string ACTION_MEDIA_UNMOUNTED = "android.intent.action.MEDIA_UNMOUNTED";

		/// <summary>
		/// Broadcast Action:  External media is present, and being disk-checked
		/// The path to the mount point for the checking media is contained in the Intent.mData field.
		/// </summary>
		/// <remarks>
		/// Broadcast Action:  External media is present, and being disk-checked
		/// The path to the mount point for the checking media is contained in the Intent.mData field.
		/// </remarks>
		public const string ACTION_MEDIA_CHECKING = "android.intent.action.MEDIA_CHECKING";

		/// <summary>
		/// Broadcast Action:  External media is present, but is using an incompatible fs (or is blank)
		/// The path to the mount point for the checking media is contained in the Intent.mData field.
		/// </summary>
		/// <remarks>
		/// Broadcast Action:  External media is present, but is using an incompatible fs (or is blank)
		/// The path to the mount point for the checking media is contained in the Intent.mData field.
		/// </remarks>
		public const string ACTION_MEDIA_NOFS = "android.intent.action.MEDIA_NOFS";

		/// <summary>Broadcast Action:  External media is present and mounted at its mount point.
		/// 	</summary>
		/// <remarks>
		/// Broadcast Action:  External media is present and mounted at its mount point.
		/// The path to the mount point for the removed media is contained in the Intent.mData field.
		/// The Intent contains an extra with name "read-only" and Boolean value to indicate if the
		/// media was mounted read only.
		/// </remarks>
		public const string ACTION_MEDIA_MOUNTED = "android.intent.action.MEDIA_MOUNTED";

		/// <summary>Broadcast Action:  External media is unmounted because it is being shared via USB mass storage.
		/// 	</summary>
		/// <remarks>
		/// Broadcast Action:  External media is unmounted because it is being shared via USB mass storage.
		/// The path to the mount point for the shared media is contained in the Intent.mData field.
		/// </remarks>
		public const string ACTION_MEDIA_SHARED = "android.intent.action.MEDIA_SHARED";

		/// <summary>Broadcast Action:  External media is no longer being shared via USB mass storage.
		/// 	</summary>
		/// <remarks>
		/// Broadcast Action:  External media is no longer being shared via USB mass storage.
		/// The path to the mount point for the previously shared media is contained in the Intent.mData field.
		/// </remarks>
		/// <hide></hide>
		public const string ACTION_MEDIA_UNSHARED = "android.intent.action.MEDIA_UNSHARED";

		/// <summary>Broadcast Action:  External media was removed from SD card slot, but mount point was not unmounted.
		/// 	</summary>
		/// <remarks>
		/// Broadcast Action:  External media was removed from SD card slot, but mount point was not unmounted.
		/// The path to the mount point for the removed media is contained in the Intent.mData field.
		/// </remarks>
		public const string ACTION_MEDIA_BAD_REMOVAL = "android.intent.action.MEDIA_BAD_REMOVAL";

		/// <summary>Broadcast Action:  External media is present but cannot be mounted.</summary>
		/// <remarks>
		/// Broadcast Action:  External media is present but cannot be mounted.
		/// The path to the mount point for the removed media is contained in the Intent.mData field.
		/// </remarks>
		public const string ACTION_MEDIA_UNMOUNTABLE = "android.intent.action.MEDIA_UNMOUNTABLE";

		/// <summary>Broadcast Action:  User has expressed the desire to remove the external storage media.
		/// 	</summary>
		/// <remarks>
		/// Broadcast Action:  User has expressed the desire to remove the external storage media.
		/// Applications should close all files they have open within the mount point when they receive this intent.
		/// The path to the mount point for the media to be ejected is contained in the Intent.mData field.
		/// </remarks>
		public const string ACTION_MEDIA_EJECT = "android.intent.action.MEDIA_EJECT";

		/// <summary>Broadcast Action:  The media scanner has started scanning a directory.</summary>
		/// <remarks>
		/// Broadcast Action:  The media scanner has started scanning a directory.
		/// The path to the directory being scanned is contained in the Intent.mData field.
		/// </remarks>
		public const string ACTION_MEDIA_SCANNER_STARTED = "android.intent.action.MEDIA_SCANNER_STARTED";

		/// <summary>Broadcast Action:  The media scanner has finished scanning a directory.</summary>
		/// <remarks>
		/// Broadcast Action:  The media scanner has finished scanning a directory.
		/// The path to the scanned directory is contained in the Intent.mData field.
		/// </remarks>
		public const string ACTION_MEDIA_SCANNER_FINISHED = "android.intent.action.MEDIA_SCANNER_FINISHED";

		/// <summary>Broadcast Action:  Request the media scanner to scan a file and add it to the media database.
		/// 	</summary>
		/// <remarks>
		/// Broadcast Action:  Request the media scanner to scan a file and add it to the media database.
		/// The path to the file is contained in the Intent.mData field.
		/// </remarks>
		public const string ACTION_MEDIA_SCANNER_SCAN_FILE = "android.intent.action.MEDIA_SCANNER_SCAN_FILE";

		/// <summary>Broadcast Action:  The "Media Button" was pressed.</summary>
		/// <remarks>
		/// Broadcast Action:  The "Media Button" was pressed.  Includes a single
		/// extra field,
		/// <see cref="EXTRA_KEY_EVENT">EXTRA_KEY_EVENT</see>
		/// , containing the key event that
		/// caused the broadcast.
		/// </remarks>
		public const string ACTION_MEDIA_BUTTON = "android.intent.action.MEDIA_BUTTON";

		/// <summary>Broadcast Action:  The "Camera Button" was pressed.</summary>
		/// <remarks>
		/// Broadcast Action:  The "Camera Button" was pressed.  Includes a single
		/// extra field,
		/// <see cref="EXTRA_KEY_EVENT">EXTRA_KEY_EVENT</see>
		/// , containing the key event that
		/// caused the broadcast.
		/// </remarks>
		public const string ACTION_CAMERA_BUTTON = "android.intent.action.CAMERA_BUTTON";

		/// <summary>Broadcast Action: An GTalk connection has been established.</summary>
		/// <remarks>Broadcast Action: An GTalk connection has been established.</remarks>
		public const string ACTION_GTALK_SERVICE_CONNECTED = "android.intent.action.GTALK_CONNECTED";

		/// <summary>Broadcast Action: An GTalk connection has been disconnected.</summary>
		/// <remarks>Broadcast Action: An GTalk connection has been disconnected.</remarks>
		public const string ACTION_GTALK_SERVICE_DISCONNECTED = "android.intent.action.GTALK_DISCONNECTED";

		/// <summary>Broadcast Action: An input method has been changed.</summary>
		/// <remarks>Broadcast Action: An input method has been changed.</remarks>
		public const string ACTION_INPUT_METHOD_CHANGED = "android.intent.action.INPUT_METHOD_CHANGED";

		/// <summary><p>Broadcast Action: The user has switched the phone into or out of Airplane Mode.
		/// 	</summary>
		/// <remarks>
		/// <p>Broadcast Action: The user has switched the phone into or out of Airplane Mode. One or
		/// more radios have been turned off or on. The intent will have the following extra value:</p>
		/// <ul>
		/// <li><em>state</em> - A boolean value indicating whether Airplane Mode is on. If true,
		/// then cell radio and possibly other radios such as bluetooth or WiFi may have also been
		/// turned off</li>
		/// </ul>
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_AIRPLANE_MODE_CHANGED = "android.intent.action.AIRPLANE_MODE";

		/// <summary>
		/// Broadcast Action: Some content providers have parts of their namespace
		/// where they publish new events or items that the user may be especially
		/// interested in.
		/// </summary>
		/// <remarks>
		/// Broadcast Action: Some content providers have parts of their namespace
		/// where they publish new events or items that the user may be especially
		/// interested in. For these things, they may broadcast this action when the
		/// set of interesting items change.
		/// For example, GmailProvider sends this notification when the set of unread
		/// mail in the inbox changes.
		/// <p>The data of the intent identifies which part of which provider
		/// changed. When queried through the content resolver, the data URI will
		/// return the data set in question.
		/// <p>The intent will have the following extra values:
		/// <ul>
		/// <li><em>count</em> - The number of items in the data set. This is the
		/// same as the number of items in the cursor returned by querying the
		/// data URI. </li>
		/// </ul>
		/// This intent will be sent at boot (if the count is non-zero) and when the
		/// data set changes. It is possible for the data set to change without the
		/// count changing (for example, if a new unread message arrives in the same
		/// sync operation in which a message is archived). The phone should still
		/// ring/vibrate/etc as normal in this case.
		/// </remarks>
		public const string ACTION_PROVIDER_CHANGED = "android.intent.action.PROVIDER_CHANGED";

		/// <summary>Broadcast Action: Wired Headset plugged in or unplugged.</summary>
		/// <remarks>
		/// Broadcast Action: Wired Headset plugged in or unplugged.
		/// <p>The intent will have the following extra values:
		/// <ul>
		/// <li><em>state</em> - 0 for unplugged, 1 for plugged. </li>
		/// <li><em>name</em> - Headset type, human readable string </li>
		/// <li><em>microphone</em> - 1 if headset has a microphone, 0 otherwise </li>
		/// </ul>
		/// </ul>
		/// </remarks>
		public const string ACTION_HEADSET_PLUG = "android.intent.action.HEADSET_PLUG";

		/// <summary>Broadcast Action: An analog audio speaker/headset plugged in or unplugged.
		/// 	</summary>
		/// <remarks>
		/// Broadcast Action: An analog audio speaker/headset plugged in or unplugged.
		/// <p>The intent will have the following extra values:
		/// <ul>
		/// <li><em>state</em> - 0 for unplugged, 1 for plugged. </li>
		/// <li><em>name</em> - Headset type, human readable string </li>
		/// </ul>
		/// </ul>
		/// </remarks>
		/// <hide></hide>
		public const string ACTION_USB_ANLG_HEADSET_PLUG = "android.intent.action.USB_ANLG_HEADSET_PLUG";

		/// <summary>Broadcast Action: A digital audio speaker/headset plugged in or unplugged.
		/// 	</summary>
		/// <remarks>
		/// Broadcast Action: A digital audio speaker/headset plugged in or unplugged.
		/// <p>The intent will have the following extra values:
		/// <ul>
		/// <li><em>state</em> - 0 for unplugged, 1 for plugged. </li>
		/// <li><em>name</em> - Headset type, human readable string </li>
		/// </ul>
		/// </ul>
		/// </remarks>
		/// <hide></hide>
		public const string ACTION_USB_DGTL_HEADSET_PLUG = "android.intent.action.USB_DGTL_HEADSET_PLUG";

		/// <summary>
		/// Broadcast Action: A HMDI cable was plugged or unplugged
		/// <p>The intent will have the following extra values:
		/// <ul>
		/// <li><em>state</em> - 0 for unplugged, 1 for plugged.
		/// </summary>
		/// <remarks>
		/// Broadcast Action: A HMDI cable was plugged or unplugged
		/// <p>The intent will have the following extra values:
		/// <ul>
		/// <li><em>state</em> - 0 for unplugged, 1 for plugged. </li>
		/// <li><em>name</em> - HDMI cable, human readable string </li>
		/// </ul>
		/// </ul>
		/// </remarks>
		/// <hide></hide>
		public const string ACTION_HDMI_AUDIO_PLUG = "android.intent.action.HDMI_AUDIO_PLUG";

		/// <summary>
		/// <p>Broadcast Action: The user has switched on advanced settings in the settings app:</p>
		/// <ul>
		/// <li><em>state</em> - A boolean value indicating whether the settings is on or off.</li>
		/// </ul>
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </summary>
		/// <remarks>
		/// <p>Broadcast Action: The user has switched on advanced settings in the settings app:</p>
		/// <ul>
		/// <li><em>state</em> - A boolean value indicating whether the settings is on or off.</li>
		/// </ul>
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		/// <hide></hide>
		public const string ACTION_ADVANCED_SETTINGS_CHANGED = "android.intent.action.ADVANCED_SETTINGS";

		/// <summary>Broadcast Action: An outgoing call is about to be placed.</summary>
		/// <remarks>
		/// Broadcast Action: An outgoing call is about to be placed.
		/// <p>The Intent will have the following extra value:
		/// <ul>
		/// <li><em>
		/// <see cref="EXTRA_PHONE_NUMBER">EXTRA_PHONE_NUMBER</see>
		/// </em> -
		/// the phone number originally intended to be dialed.</li>
		/// </ul>
		/// <p>Once the broadcast is finished, the resultData is used as the actual
		/// number to call.  If  <code>null</code>, no call will be placed.</p>
		/// <p>It is perfectly acceptable for multiple receivers to process the
		/// outgoing call in turn: for example, a parental control application
		/// might verify that the user is authorized to place the call at that
		/// time, then a number-rewriting application might add an area code if
		/// one was not specified.</p>
		/// <p>For consistency, any receiver whose purpose is to prohibit phone
		/// calls should have a priority of 0, to ensure it will see the final
		/// phone number to be dialed.
		/// Any receiver whose purpose is to rewrite phone numbers to be called
		/// should have a positive priority.
		/// Negative priorities are reserved for the system for this broadcast;
		/// using them may cause problems.</p>
		/// <p>Any BroadcastReceiver receiving this Intent <em>must not</em>
		/// abort the broadcast.</p>
		/// <p>Emergency calls cannot be intercepted using this mechanism, and
		/// other calls cannot be modified to call emergency numbers using this
		/// mechanism.
		/// <p>You must hold the
		/// <see cref="android.Manifest.permission.PROCESS_OUTGOING_CALLS">android.Manifest.permission.PROCESS_OUTGOING_CALLS
		/// 	</see>
		/// permission to receive this Intent.</p>
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_NEW_OUTGOING_CALL = "android.intent.action.NEW_OUTGOING_CALL";

		/// <summary>Broadcast Action: Have the device reboot.</summary>
		/// <remarks>
		/// Broadcast Action: Have the device reboot.  This is only for use by
		/// system code.
		/// <p class="note">This is a protected intent that can only be sent
		/// by the system.
		/// </remarks>
		public const string ACTION_REBOOT = "android.intent.action.REBOOT";

		/// <summary>
		/// Broadcast Action:  A sticky broadcast for changes in the physical
		/// docking state of the device.
		/// </summary>
		/// <remarks>
		/// Broadcast Action:  A sticky broadcast for changes in the physical
		/// docking state of the device.
		/// <p>The intent will have the following extra values:
		/// <ul>
		/// <li><em>
		/// <see cref="EXTRA_DOCK_STATE">EXTRA_DOCK_STATE</see>
		/// </em> - the current dock
		/// state, indicating which dock the device is physically in.</li>
		/// </ul>
		/// <p>This is intended for monitoring the current physical dock state.
		/// See
		/// <see cref="android.app.UiModeManager">android.app.UiModeManager</see>
		/// for the normal API dealing with
		/// dock mode changes.
		/// </remarks>
		public const string ACTION_DOCK_EVENT = "android.intent.action.DOCK_EVENT";

		/// <summary>Broadcast Action: a remote intent is to be broadcasted.</summary>
		/// <remarks>
		/// Broadcast Action: a remote intent is to be broadcasted.
		/// A remote intent is used for remote RPC between devices. The remote intent
		/// is serialized and sent from one device to another device. The receiving
		/// device parses the remote intent and broadcasts it. Note that anyone can
		/// broadcast a remote intent. However, if the intent receiver of the remote intent
		/// does not trust intent broadcasts from arbitrary intent senders, it should require
		/// the sender to hold certain permissions so only trusted sender's broadcast will be
		/// let through.
		/// </remarks>
		/// <hide></hide>
		public const string ACTION_REMOTE_INTENT = "com.google.android.c2dm.intent.RECEIVE";

		/// <summary>Broadcast Action: hook for permforming cleanup after a system update.</summary>
		/// <remarks>
		/// Broadcast Action: hook for permforming cleanup after a system update.
		/// The broadcast is sent when the system is booting, before the
		/// BOOT_COMPLETED broadcast.  It is only sent to receivers in the system
		/// image.  A receiver for this should do its work and then disable itself
		/// so that it does not get run again at the next boot.
		/// </remarks>
		/// <hide></hide>
		public const string ACTION_PRE_BOOT_COMPLETED = "android.intent.action.PRE_BOOT_COMPLETED";

		/// <summary>
		/// Set if the activity should be an option for the default action
		/// (center press) to perform on a piece of data.
		/// </summary>
		/// <remarks>
		/// Set if the activity should be an option for the default action
		/// (center press) to perform on a piece of data.  Setting this will
		/// hide from the user any activities without it set when performing an
		/// action on some data.  Note that this is normal -not- set in the
		/// Intent when initiating an action -- it is for use in intent filters
		/// specified in packages.
		/// </remarks>
		public const string CATEGORY_DEFAULT = "android.intent.category.DEFAULT";

		/// <summary>
		/// Activities that can be safely invoked from a browser must support this
		/// category.
		/// </summary>
		/// <remarks>
		/// Activities that can be safely invoked from a browser must support this
		/// category.  For example, if the user is viewing a web page or an e-mail
		/// and clicks on a link in the text, the Intent generated execute that
		/// link will require the BROWSABLE category, so that only activities
		/// supporting this category will be considered as possible actions.  By
		/// supporting this category, you are promising that there is nothing
		/// damaging (without user intervention) that can happen by invoking any
		/// matching Intent.
		/// </remarks>
		public const string CATEGORY_BROWSABLE = "android.intent.category.BROWSABLE";

		/// <summary>
		/// Set if the activity should be considered as an alternative action to
		/// the data the user is currently viewing.
		/// </summary>
		/// <remarks>
		/// Set if the activity should be considered as an alternative action to
		/// the data the user is currently viewing.  See also
		/// <see cref="CATEGORY_SELECTED_ALTERNATIVE">CATEGORY_SELECTED_ALTERNATIVE</see>
		/// for an alternative action that
		/// applies to the selection in a list of items.
		/// <p>Supporting this category means that you would like your activity to be
		/// displayed in the set of alternative things the user can do, usually as
		/// part of the current activity's options menu.  You will usually want to
		/// include a specific label in the &lt;intent-filter&gt; of this action
		/// describing to the user what it does.
		/// <p>The action of IntentFilter with this category is important in that it
		/// describes the specific action the target will perform.  This generally
		/// should not be a generic action (such as
		/// <see cref="ACTION_VIEW">ACTION_VIEW</see>
		/// , but rather
		/// a specific name such as "com.android.camera.action.CROP.  Only one
		/// alternative of any particular action will be shown to the user, so using
		/// a specific action like this makes sure that your alternative will be
		/// displayed while also allowing other applications to provide their own
		/// overrides of that particular action.
		/// </remarks>
		public const string CATEGORY_ALTERNATIVE = "android.intent.category.ALTERNATIVE";

		/// <summary>
		/// Set if the activity should be considered as an alternative selection
		/// action to the data the user has currently selected.
		/// </summary>
		/// <remarks>
		/// Set if the activity should be considered as an alternative selection
		/// action to the data the user has currently selected.  This is like
		/// <see cref="CATEGORY_ALTERNATIVE">CATEGORY_ALTERNATIVE</see>
		/// , but is used in activities showing a list
		/// of items from which the user can select, giving them alternatives to the
		/// default action that will be performed on it.
		/// </remarks>
		public const string CATEGORY_SELECTED_ALTERNATIVE = "android.intent.category.SELECTED_ALTERNATIVE";

		/// <summary>Intended to be used as a tab inside of an containing TabActivity.</summary>
		/// <remarks>Intended to be used as a tab inside of an containing TabActivity.</remarks>
		public const string CATEGORY_TAB = "android.intent.category.TAB";

		/// <summary>Should be displayed in the top-level launcher.</summary>
		/// <remarks>Should be displayed in the top-level launcher.</remarks>
		public const string CATEGORY_LAUNCHER = "android.intent.category.LAUNCHER";

		/// <summary>
		/// Provides information about the package it is in; typically used if
		/// a package does not contain a
		/// <see cref="CATEGORY_LAUNCHER">CATEGORY_LAUNCHER</see>
		/// to provide
		/// a front-door to the user without having to be shown in the all apps list.
		/// </summary>
		public const string CATEGORY_INFO = "android.intent.category.INFO";

		/// <summary>
		/// This is the home activity, that is the first activity that is displayed
		/// when the device boots.
		/// </summary>
		/// <remarks>
		/// This is the home activity, that is the first activity that is displayed
		/// when the device boots.
		/// </remarks>
		public const string CATEGORY_HOME = "android.intent.category.HOME";

		/// <summary>This activity is a preference panel.</summary>
		/// <remarks>This activity is a preference panel.</remarks>
		public const string CATEGORY_PREFERENCE = "android.intent.category.PREFERENCE";

		/// <summary>This activity is a development preference panel.</summary>
		/// <remarks>This activity is a development preference panel.</remarks>
		public const string CATEGORY_DEVELOPMENT_PREFERENCE = "android.intent.category.DEVELOPMENT_PREFERENCE";

		/// <summary>Capable of running inside a parent activity container.</summary>
		/// <remarks>Capable of running inside a parent activity container.</remarks>
		public const string CATEGORY_EMBED = "android.intent.category.EMBED";

		/// <summary>This activity allows the user to browse and download new applications.</summary>
		/// <remarks>This activity allows the user to browse and download new applications.</remarks>
		public const string CATEGORY_APP_MARKET = "android.intent.category.APP_MARKET";

		/// <summary>This activity may be exercised by the monkey or other automated test tools.
		/// 	</summary>
		/// <remarks>This activity may be exercised by the monkey or other automated test tools.
		/// 	</remarks>
		public const string CATEGORY_MONKEY = "android.intent.category.MONKEY";

		/// <summary>To be used as a test (not part of the normal user experience).</summary>
		/// <remarks>To be used as a test (not part of the normal user experience).</remarks>
		public const string CATEGORY_TEST = "android.intent.category.TEST";

		/// <summary>To be used as a unit test (run through the Test Harness).</summary>
		/// <remarks>To be used as a unit test (run through the Test Harness).</remarks>
		public const string CATEGORY_UNIT_TEST = "android.intent.category.UNIT_TEST";

		/// <summary>
		/// To be used as an sample code example (not part of the normal user
		/// experience).
		/// </summary>
		/// <remarks>
		/// To be used as an sample code example (not part of the normal user
		/// experience).
		/// </remarks>
		public const string CATEGORY_SAMPLE_CODE = "android.intent.category.SAMPLE_CODE";

		/// <summary>
		/// Used to indicate that a GET_CONTENT intent only wants URIs that can be opened with
		/// ContentResolver.openInputStream.
		/// </summary>
		/// <remarks>
		/// Used to indicate that a GET_CONTENT intent only wants URIs that can be opened with
		/// ContentResolver.openInputStream. Openable URIs must support the columns in OpenableColumns
		/// when queried, though it is allowable for those columns to be blank.
		/// </remarks>
		public const string CATEGORY_OPENABLE = "android.intent.category.OPENABLE";

		/// <summary>To be used as code under test for framework instrumentation tests.</summary>
		/// <remarks>To be used as code under test for framework instrumentation tests.</remarks>
		public const string CATEGORY_FRAMEWORK_INSTRUMENTATION_TEST = "android.intent.category.FRAMEWORK_INSTRUMENTATION_TEST";

		/// <summary>An activity to run when device is inserted into a car dock.</summary>
		/// <remarks>
		/// An activity to run when device is inserted into a car dock.
		/// Used with
		/// <see cref="ACTION_MAIN">ACTION_MAIN</see>
		/// to launch an activity.  For more
		/// information, see
		/// <see cref="android.app.UiModeManager">android.app.UiModeManager</see>
		/// .
		/// </remarks>
		public const string CATEGORY_CAR_DOCK = "android.intent.category.CAR_DOCK";

		/// <summary>An activity to run when device is inserted into a car dock.</summary>
		/// <remarks>
		/// An activity to run when device is inserted into a car dock.
		/// Used with
		/// <see cref="ACTION_MAIN">ACTION_MAIN</see>
		/// to launch an activity.  For more
		/// information, see
		/// <see cref="android.app.UiModeManager">android.app.UiModeManager</see>
		/// .
		/// </remarks>
		public const string CATEGORY_DESK_DOCK = "android.intent.category.DESK_DOCK";

		/// <summary>An activity to run when device is inserted into a analog (low end) dock.
		/// 	</summary>
		/// <remarks>
		/// An activity to run when device is inserted into a analog (low end) dock.
		/// Used with
		/// <see cref="ACTION_MAIN">ACTION_MAIN</see>
		/// to launch an activity.  For more
		/// information, see
		/// <see cref="android.app.UiModeManager">android.app.UiModeManager</see>
		/// .
		/// </remarks>
		public const string CATEGORY_LE_DESK_DOCK = "android.intent.category.LE_DESK_DOCK";

		/// <summary>An activity to run when device is inserted into a digital (high end) dock.
		/// 	</summary>
		/// <remarks>
		/// An activity to run when device is inserted into a digital (high end) dock.
		/// Used with
		/// <see cref="ACTION_MAIN">ACTION_MAIN</see>
		/// to launch an activity.  For more
		/// information, see
		/// <see cref="android.app.UiModeManager">android.app.UiModeManager</see>
		/// .
		/// </remarks>
		public const string CATEGORY_HE_DESK_DOCK = "android.intent.category.HE_DESK_DOCK";

		/// <summary>Used to indicate that the activity can be used in a car environment.</summary>
		/// <remarks>Used to indicate that the activity can be used in a car environment.</remarks>
		public const string CATEGORY_CAR_MODE = "android.intent.category.CAR_MODE";

		/// <summary>The initial data to place in a newly created record.</summary>
		/// <remarks>
		/// The initial data to place in a newly created record.  Use with
		/// <see cref="ACTION_INSERT">ACTION_INSERT</see>
		/// .  The data here is a Map containing the same
		/// fields as would be given to the underlying ContentProvider.insert()
		/// call.
		/// </remarks>
		public const string EXTRA_TEMPLATE = "android.intent.extra.TEMPLATE";

		/// <summary>
		/// A constant CharSequence that is associated with the Intent, used with
		/// <see cref="ACTION_SEND">ACTION_SEND</see>
		/// to supply the literal data to be sent.  Note that
		/// this may be a styled CharSequence, so you must use
		/// <see cref="android.os.Bundle.getCharSequence(string)">Bundle.getCharSequence()</see>
		/// to
		/// retrieve it.
		/// </summary>
		public const string EXTRA_TEXT = "android.intent.extra.TEXT";

		/// <summary>
		/// A content: URI holding a stream of data associated with the Intent,
		/// used with
		/// <see cref="ACTION_SEND">ACTION_SEND</see>
		/// to supply the data being sent.
		/// </summary>
		public const string EXTRA_STREAM = "android.intent.extra.STREAM";

		/// <summary>A String[] holding e-mail addresses that should be delivered to.</summary>
		/// <remarks>A String[] holding e-mail addresses that should be delivered to.</remarks>
		public const string EXTRA_EMAIL = "android.intent.extra.EMAIL";

		/// <summary>A String[] holding e-mail addresses that should be carbon copied.</summary>
		/// <remarks>A String[] holding e-mail addresses that should be carbon copied.</remarks>
		public const string EXTRA_CC = "android.intent.extra.CC";

		/// <summary>A String[] holding e-mail addresses that should be blind carbon copied.</summary>
		/// <remarks>A String[] holding e-mail addresses that should be blind carbon copied.</remarks>
		public const string EXTRA_BCC = "android.intent.extra.BCC";

		/// <summary>A constant string holding the desired subject line of a message.</summary>
		/// <remarks>A constant string holding the desired subject line of a message.</remarks>
		public const string EXTRA_SUBJECT = "android.intent.extra.SUBJECT";

		/// <summary>
		/// An Intent describing the choices you would like shown with
		/// <see cref="ACTION_PICK_ACTIVITY">ACTION_PICK_ACTIVITY</see>
		/// .
		/// </summary>
		public const string EXTRA_INTENT = "android.intent.extra.INTENT";

		/// <summary>
		/// A CharSequence dialog title to provide to the user when used with a
		/// <see cref="ACTION_CHOOSER">ACTION_CHOOSER</see>
		/// .
		/// </summary>
		public const string EXTRA_TITLE = "android.intent.extra.TITLE";

		/// <summary>
		/// A Parcelable[] of
		/// <see cref="Intent">Intent</see>
		/// or
		/// <see cref="android.content.pm.LabeledIntent">android.content.pm.LabeledIntent</see>
		/// objects as set with
		/// <see cref="putExtra(string, android.os.Parcelable[])">putExtra(string, android.os.Parcelable[])
		/// 	</see>
		/// of additional activities to place
		/// a the front of the list of choices, when shown to the user with a
		/// <see cref="ACTION_CHOOSER">ACTION_CHOOSER</see>
		/// .
		/// </summary>
		public const string EXTRA_INITIAL_INTENTS = "android.intent.extra.INITIAL_INTENTS";

		/// <summary>
		/// A
		/// <see cref="android.view.KeyEvent">android.view.KeyEvent</see>
		/// object containing the event that
		/// triggered the creation of the Intent it is in.
		/// </summary>
		public const string EXTRA_KEY_EVENT = "android.intent.extra.KEY_EVENT";

		/// <summary>
		/// Set to true in
		/// <see cref="ACTION_REQUEST_SHUTDOWN">ACTION_REQUEST_SHUTDOWN</see>
		/// to request confirmation from the user
		/// before shutting down.
		/// <hide></hide>
		/// </summary>
		public const string EXTRA_KEY_CONFIRM = "android.intent.extra.KEY_CONFIRM";

		/// <summary>
		/// Used as an boolean extra field in
		/// <see cref="ACTION_PACKAGE_REMOVED">ACTION_PACKAGE_REMOVED</see>
		/// or
		/// <see cref="ACTION_PACKAGE_CHANGED">ACTION_PACKAGE_CHANGED</see>
		/// intents to override the default action
		/// of restarting the application.
		/// </summary>
		public const string EXTRA_DONT_KILL_APP = "android.intent.extra.DONT_KILL_APP";

		/// <summary>
		/// A String holding the phone number originally entered in
		/// <see cref="ACTION_NEW_OUTGOING_CALL">ACTION_NEW_OUTGOING_CALL</see>
		/// , or the actual
		/// number to call in a
		/// <see cref="ACTION_CALL">ACTION_CALL</see>
		/// .
		/// </summary>
		public const string EXTRA_PHONE_NUMBER = "android.intent.extra.PHONE_NUMBER";

		/// <summary>
		/// Used as an int extra field in
		/// <see cref="ACTION_UID_REMOVED">ACTION_UID_REMOVED</see>
		/// intents to supply the uid the package had been assigned.  Also an optional
		/// extra in
		/// <see cref="ACTION_PACKAGE_REMOVED">ACTION_PACKAGE_REMOVED</see>
		/// or
		/// <see cref="ACTION_PACKAGE_CHANGED">ACTION_PACKAGE_CHANGED</see>
		/// for the same
		/// purpose.
		/// </summary>
		public const string EXTRA_UID = "android.intent.extra.UID";

		/// <hide>String array of package names.</hide>
		public const string EXTRA_PACKAGES = "android.intent.extra.PACKAGES";

		/// <summary>
		/// Used as a boolean extra field in
		/// <see cref="ACTION_PACKAGE_REMOVED">ACTION_PACKAGE_REMOVED</see>
		/// intents to indicate whether this represents a full uninstall (removing
		/// both the code and its data) or a partial uninstall (leaving its data,
		/// implying that this is an update).
		/// </summary>
		public const string EXTRA_DATA_REMOVED = "android.intent.extra.DATA_REMOVED";

		/// <summary>
		/// Used as a boolean extra field in
		/// <see cref="ACTION_PACKAGE_REMOVED">ACTION_PACKAGE_REMOVED</see>
		/// intents to indicate that this is a replacement of the package, so this
		/// broadcast will immediately be followed by an add broadcast for a
		/// different version of the same package.
		/// </summary>
		public const string EXTRA_REPLACING = "android.intent.extra.REPLACING";

		/// <summary>
		/// Used as an int extra field in
		/// <see cref="android.app.AlarmManager">android.app.AlarmManager</see>
		/// intents
		/// to tell the application being invoked how many pending alarms are being
		/// delievered with the intent.  For one-shot alarms this will always be 1.
		/// For recurring alarms, this might be greater than 1 if the device was
		/// asleep or powered off at the time an earlier alarm would have been
		/// delivered.
		/// </summary>
		public const string EXTRA_ALARM_COUNT = "android.intent.extra.ALARM_COUNT";

		/// <summary>
		/// Used as an int extra field in
		/// <see cref="ACTION_DOCK_EVENT">ACTION_DOCK_EVENT</see>
		/// intents to request the dock state.  Possible values are
		/// <see cref="EXTRA_DOCK_STATE_UNDOCKED">EXTRA_DOCK_STATE_UNDOCKED</see>
		/// ,
		/// <see cref="EXTRA_DOCK_STATE_DESK">EXTRA_DOCK_STATE_DESK</see>
		/// , or
		/// <see cref="EXTRA_DOCK_STATE_CAR">EXTRA_DOCK_STATE_CAR</see>
		/// , or
		/// <see cref="EXTRA_DOCK_STATE_LE_DESK">EXTRA_DOCK_STATE_LE_DESK</see>
		/// , or
		/// <see cref="EXTRA_DOCK_STATE_HE_DESK">EXTRA_DOCK_STATE_HE_DESK</see>
		/// .
		/// </summary>
		public const string EXTRA_DOCK_STATE = "android.intent.extra.DOCK_STATE";

		/// <summary>
		/// Used as an int value for
		/// <see cref="EXTRA_DOCK_STATE">EXTRA_DOCK_STATE</see>
		/// to represent that the phone is not in any dock.
		/// </summary>
		public const int EXTRA_DOCK_STATE_UNDOCKED = 0;

		/// <summary>
		/// Used as an int value for
		/// <see cref="EXTRA_DOCK_STATE">EXTRA_DOCK_STATE</see>
		/// to represent that the phone is in a desk dock.
		/// </summary>
		public const int EXTRA_DOCK_STATE_DESK = 1;

		/// <summary>
		/// Used as an int value for
		/// <see cref="EXTRA_DOCK_STATE">EXTRA_DOCK_STATE</see>
		/// to represent that the phone is in a car dock.
		/// </summary>
		public const int EXTRA_DOCK_STATE_CAR = 2;

		/// <summary>
		/// Used as an int value for
		/// <see cref="EXTRA_DOCK_STATE">EXTRA_DOCK_STATE</see>
		/// to represent that the phone is in a analog (low end) dock.
		/// </summary>
		public const int EXTRA_DOCK_STATE_LE_DESK = 3;

		/// <summary>
		/// Used as an int value for
		/// <see cref="EXTRA_DOCK_STATE">EXTRA_DOCK_STATE</see>
		/// to represent that the phone is in a digital (high end) dock.
		/// </summary>
		public const int EXTRA_DOCK_STATE_HE_DESK = 4;

		/// <summary>
		/// Boolean that can be supplied as meta-data with a dock activity, to
		/// indicate that the dock should take over the home key when it is active.
		/// </summary>
		/// <remarks>
		/// Boolean that can be supplied as meta-data with a dock activity, to
		/// indicate that the dock should take over the home key when it is active.
		/// </remarks>
		public const string METADATA_DOCK_HOME = "android.dock_home";

		/// <summary>
		/// Used as a parcelable extra field in
		/// <see cref="ACTION_APP_ERROR">ACTION_APP_ERROR</see>
		/// , containing
		/// the bug report.
		/// </summary>
		public const string EXTRA_BUG_REPORT = "android.intent.extra.BUG_REPORT";

		/// <summary>Used in the extra field in the remote intent.</summary>
		/// <remarks>
		/// Used in the extra field in the remote intent. It's astring token passed with the
		/// remote intent.
		/// </remarks>
		public const string EXTRA_REMOTE_INTENT_TOKEN = "android.intent.extra.remote_intent_token";

		[System.ObsoleteAttribute(@"See EXTRA_CHANGED_COMPONENT_NAME_LIST ; this field will contain only the first name in the list."
			)]
		public const string EXTRA_CHANGED_COMPONENT_NAME = "android.intent.extra.changed_component_name";

		/// <summary>
		/// This field is part of
		/// <see cref="ACTION_PACKAGE_CHANGED">ACTION_PACKAGE_CHANGED</see>
		/// ,
		/// and contains a string array of all of the components that have changed.
		/// </summary>
		public const string EXTRA_CHANGED_COMPONENT_NAME_LIST = "android.intent.extra.changed_component_name_list";

		/// <summary>
		/// This field is part of
		/// <see cref="ACTION_EXTERNAL_APPLICATIONS_AVAILABLE">ACTION_EXTERNAL_APPLICATIONS_AVAILABLE
		/// 	</see>
		/// ,
		/// <see cref="ACTION_EXTERNAL_APPLICATIONS_UNAVAILABLE">ACTION_EXTERNAL_APPLICATIONS_UNAVAILABLE
		/// 	</see>
		/// and contains a string array of all of the components that have changed.
		/// </summary>
		public const string EXTRA_CHANGED_PACKAGE_LIST = "android.intent.extra.changed_package_list";

		/// <summary>
		/// This field is part of
		/// <see cref="ACTION_EXTERNAL_APPLICATIONS_AVAILABLE">ACTION_EXTERNAL_APPLICATIONS_AVAILABLE
		/// 	</see>
		/// ,
		/// <see cref="ACTION_EXTERNAL_APPLICATIONS_UNAVAILABLE">ACTION_EXTERNAL_APPLICATIONS_UNAVAILABLE
		/// 	</see>
		/// and contains an integer array of uids of all of the components
		/// that have changed.
		/// </summary>
		public const string EXTRA_CHANGED_UID_LIST = "android.intent.extra.changed_uid_list";

		/// <hide>
		/// Magic extra system code can use when binding, to give a label for
		/// who it is that has bound to a service.  This is an integer giving
		/// a framework string resource that can be displayed to the user.
		/// </hide>
		public const string EXTRA_CLIENT_LABEL = "android.intent.extra.client_label";

		/// <hide>
		/// Magic extra system code can use when binding, to give a PendingIntent object
		/// that can be launched for the user to disable the system's use of this
		/// service.
		/// </hide>
		public const string EXTRA_CLIENT_INTENT = "android.intent.extra.client_intent";

		/// <summary>
		/// Used to indicate that a
		/// <see cref="ACTION_GET_CONTENT">ACTION_GET_CONTENT</see>
		/// intent should only return
		/// data that is on the local device.  This is a boolean extra; the default
		/// is false.  If true, an implementation of ACTION_GET_CONTENT should only allow
		/// the user to select media that is already on the device, not requiring it
		/// be downloaded from a remote service when opened.  Another way to look
		/// at it is that such content should generally have a "_data" column to the
		/// path of the content on local external storage.
		/// </summary>
		public const string EXTRA_LOCAL_ONLY = "android.intent.extra.LOCAL_ONLY";

		/// <summary>
		/// If set, the recipient of this Intent will be granted permission to
		/// perform read operations on the Uri in the Intent's data.
		/// </summary>
		/// <remarks>
		/// If set, the recipient of this Intent will be granted permission to
		/// perform read operations on the Uri in the Intent's data.
		/// </remarks>
		public const int FLAG_GRANT_READ_URI_PERMISSION = unchecked((int)(0x00000001));

		/// <summary>
		/// If set, the recipient of this Intent will be granted permission to
		/// perform write operations on the Uri in the Intent's data.
		/// </summary>
		/// <remarks>
		/// If set, the recipient of this Intent will be granted permission to
		/// perform write operations on the Uri in the Intent's data.
		/// </remarks>
		public const int FLAG_GRANT_WRITE_URI_PERMISSION = unchecked((int)(0x00000002));

		/// <summary>
		/// Can be set by the caller to indicate that this Intent is coming from
		/// a background operation, not from direct user interaction.
		/// </summary>
		/// <remarks>
		/// Can be set by the caller to indicate that this Intent is coming from
		/// a background operation, not from direct user interaction.
		/// </remarks>
		public const int FLAG_FROM_BACKGROUND = unchecked((int)(0x00000004));

		/// <summary>
		/// A flag you can enable for debugging: when set, log messages will be
		/// printed during the resolution of this intent to show you what has
		/// been found to create the final resolved list.
		/// </summary>
		/// <remarks>
		/// A flag you can enable for debugging: when set, log messages will be
		/// printed during the resolution of this intent to show you what has
		/// been found to create the final resolved list.
		/// </remarks>
		public const int FLAG_DEBUG_LOG_RESOLUTION = unchecked((int)(0x00000008));

		/// <summary>
		/// If set, this intent will not match any components in packages that
		/// are currently stopped.
		/// </summary>
		/// <remarks>
		/// If set, this intent will not match any components in packages that
		/// are currently stopped.  If this is not set, then the default behavior
		/// is to include such applications in the result.
		/// </remarks>
		public const int FLAG_EXCLUDE_STOPPED_PACKAGES = unchecked((int)(0x00000010));

		/// <summary>
		/// If set, this intent will always match any components in packages that
		/// are currently stopped.
		/// </summary>
		/// <remarks>
		/// If set, this intent will always match any components in packages that
		/// are currently stopped.  This is the default behavior when
		/// <see cref="FLAG_EXCLUDE_STOPPED_PACKAGES">FLAG_EXCLUDE_STOPPED_PACKAGES</see>
		/// is not set.  If both of these
		/// flags are set, this one wins (it allows overriding of exclude for
		/// places where the framework may automatically set the exclude flag).
		/// </remarks>
		public const int FLAG_INCLUDE_STOPPED_PACKAGES = unchecked((int)(0x00000020));

		/// <summary>If set, the new activity is not kept in the history stack.</summary>
		/// <remarks>
		/// If set, the new activity is not kept in the history stack.  As soon as
		/// the user navigates away from it, the activity is finished.  This may also
		/// be set with the
		/// <see cref="android.R.styleable.AndroidManifestActivity_noHistory">noHistory</see>
		/// attribute.
		/// </remarks>
		public const int FLAG_ACTIVITY_NO_HISTORY = unchecked((int)(0x40000000));

		/// <summary>
		/// If set, the activity will not be launched if it is already running
		/// at the top of the history stack.
		/// </summary>
		/// <remarks>
		/// If set, the activity will not be launched if it is already running
		/// at the top of the history stack.
		/// </remarks>
		public const int FLAG_ACTIVITY_SINGLE_TOP = unchecked((int)(0x20000000));

		/// <summary>
		/// If set, this activity will become the start of a new task on this
		/// history stack.
		/// </summary>
		/// <remarks>
		/// If set, this activity will become the start of a new task on this
		/// history stack.  A task (from the activity that started it to the
		/// next task activity) defines an atomic group of activities that the
		/// user can move to.  Tasks can be moved to the foreground and background;
		/// all of the activities inside of a particular task always remain in
		/// the same order.  See
		/// &lt;a href="
		/// <docRoot></docRoot>
		/// guide/topics/fundamentals/tasks-and-back-stack.html"&gt;Tasks and Back
		/// Stack</a> for more information about tasks.
		/// <p>This flag is generally used by activities that want
		/// to present a "launcher" style behavior: they give the user a list of
		/// separate things that can be done, which otherwise run completely
		/// independently of the activity launching them.
		/// <p>When using this flag, if a task is already running for the activity
		/// you are now starting, then a new activity will not be started; instead,
		/// the current task will simply be brought to the front of the screen with
		/// the state it was last in.  See
		/// <see cref="FLAG_ACTIVITY_MULTIPLE_TASK">FLAG_ACTIVITY_MULTIPLE_TASK</see>
		/// for a flag
		/// to disable this behavior.
		/// <p>This flag can not be used when the caller is requesting a result from
		/// the activity being launched.
		/// </remarks>
		public const int FLAG_ACTIVITY_NEW_TASK = unchecked((int)(0x10000000));

		/// <summary>
		/// <strong>Do not use this flag unless you are implementing your own
		/// top-level application launcher.</strong>  Used in conjunction with
		/// <see cref="FLAG_ACTIVITY_NEW_TASK">FLAG_ACTIVITY_NEW_TASK</see>
		/// to disable the
		/// behavior of bringing an existing task to the foreground.  When set,
		/// a new task is <em>always</em> started to host the Activity for the
		/// Intent, regardless of whether there is already an existing task running
		/// the same thing.
		/// <p><strong>Because the default system does not include graphical task management,
		/// you should not use this flag unless you provide some way for a user to
		/// return back to the tasks you have launched.</strong>
		/// <p>This flag is ignored if
		/// <see cref="FLAG_ACTIVITY_NEW_TASK">FLAG_ACTIVITY_NEW_TASK</see>
		/// is not set.
		/// <p>See
		/// &lt;a href="
		/// <docRoot></docRoot>
		/// guide/topics/fundamentals/tasks-and-back-stack.html"&gt;Tasks and Back
		/// Stack</a> for more information about tasks.
		/// </summary>
		public const int FLAG_ACTIVITY_MULTIPLE_TASK = unchecked((int)(0x08000000));

		/// <summary>
		/// If set, and the activity being launched is already running in the
		/// current task, then instead of launching a new instance of that activity,
		/// all of the other activities on top of it will be closed and this Intent
		/// will be delivered to the (now on top) old activity as a new Intent.
		/// </summary>
		/// <remarks>
		/// If set, and the activity being launched is already running in the
		/// current task, then instead of launching a new instance of that activity,
		/// all of the other activities on top of it will be closed and this Intent
		/// will be delivered to the (now on top) old activity as a new Intent.
		/// <p>For example, consider a task consisting of the activities: A, B, C, D.
		/// If D calls startActivity() with an Intent that resolves to the component
		/// of activity B, then C and D will be finished and B receive the given
		/// Intent, resulting in the stack now being: A, B.
		/// <p>The currently running instance of activity B in the above example will
		/// either receive the new intent you are starting here in its
		/// onNewIntent() method, or be itself finished and restarted with the
		/// new intent.  If it has declared its launch mode to be "multiple" (the
		/// default) and you have not set
		/// <see cref="FLAG_ACTIVITY_SINGLE_TOP">FLAG_ACTIVITY_SINGLE_TOP</see>
		/// in
		/// the same intent, then it will be finished and re-created; for all other
		/// launch modes or if
		/// <see cref="FLAG_ACTIVITY_SINGLE_TOP">FLAG_ACTIVITY_SINGLE_TOP</see>
		/// is set then this
		/// Intent will be delivered to the current instance's onNewIntent().
		/// <p>This launch mode can also be used to good effect in conjunction with
		/// <see cref="FLAG_ACTIVITY_NEW_TASK">FLAG_ACTIVITY_NEW_TASK</see>
		/// : if used to start the root activity
		/// of a task, it will bring any currently running instance of that task
		/// to the foreground, and then clear it to its root state.  This is
		/// especially useful, for example, when launching an activity from the
		/// notification manager.
		/// <p>See
		/// &lt;a href="
		/// <docRoot></docRoot>
		/// guide/topics/fundamentals/tasks-and-back-stack.html"&gt;Tasks and Back
		/// Stack</a> for more information about tasks.
		/// </remarks>
		public const int FLAG_ACTIVITY_CLEAR_TOP = unchecked((int)(0x04000000));

		/// <summary>
		/// If set and this intent is being used to launch a new activity from an
		/// existing one, then the reply target of the existing activity will be
		/// transfered to the new activity.
		/// </summary>
		/// <remarks>
		/// If set and this intent is being used to launch a new activity from an
		/// existing one, then the reply target of the existing activity will be
		/// transfered to the new activity.  This way the new activity can call
		/// <see cref="android.app.Activity.setResult(int)">android.app.Activity.setResult(int)
		/// 	</see>
		/// and have that result sent back to
		/// the reply target of the original activity.
		/// </remarks>
		public const int FLAG_ACTIVITY_FORWARD_RESULT = unchecked((int)(0x02000000));

		/// <summary>
		/// If set and this intent is being used to launch a new activity from an
		/// existing one, the current activity will not be counted as the top
		/// activity for deciding whether the new intent should be delivered to
		/// the top instead of starting a new one.
		/// </summary>
		/// <remarks>
		/// If set and this intent is being used to launch a new activity from an
		/// existing one, the current activity will not be counted as the top
		/// activity for deciding whether the new intent should be delivered to
		/// the top instead of starting a new one.  The previous activity will
		/// be used as the top, with the assumption being that the current activity
		/// will finish itself immediately.
		/// </remarks>
		public const int FLAG_ACTIVITY_PREVIOUS_IS_TOP = unchecked((int)(0x01000000));

		/// <summary>
		/// If set, the new activity is not kept in the list of recently launched
		/// activities.
		/// </summary>
		/// <remarks>
		/// If set, the new activity is not kept in the list of recently launched
		/// activities.
		/// </remarks>
		public const int FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS = unchecked((int)(0x00800000)
			);

		/// <summary>
		/// This flag is not normally set by application code, but set for you by
		/// the system as described in the
		/// <see cref="android.R.styleable.AndroidManifestActivity_launchMode">launchMode</see>
		/// documentation for the singleTask mode.
		/// </summary>
		public const int FLAG_ACTIVITY_BROUGHT_TO_FRONT = unchecked((int)(0x00400000));

		/// <summary>
		/// If set, and this activity is either being started in a new task or
		/// bringing to the top an existing task, then it will be launched as
		/// the front door of the task.
		/// </summary>
		/// <remarks>
		/// If set, and this activity is either being started in a new task or
		/// bringing to the top an existing task, then it will be launched as
		/// the front door of the task.  This will result in the application of
		/// any affinities needed to have that task in the proper state (either
		/// moving activities to or from it), or simply resetting that task to
		/// its initial state if needed.
		/// </remarks>
		public const int FLAG_ACTIVITY_RESET_TASK_IF_NEEDED = unchecked((int)(0x00200000)
			);

		/// <summary>
		/// This flag is not normally set by application code, but set for you by
		/// the system if this activity is being launched from history
		/// (longpress home key).
		/// </summary>
		/// <remarks>
		/// This flag is not normally set by application code, but set for you by
		/// the system if this activity is being launched from history
		/// (longpress home key).
		/// </remarks>
		public const int FLAG_ACTIVITY_LAUNCHED_FROM_HISTORY = unchecked((int)(0x00100000
			));

		/// <summary>
		/// If set, this marks a point in the task's activity stack that should
		/// be cleared when the task is reset.
		/// </summary>
		/// <remarks>
		/// If set, this marks a point in the task's activity stack that should
		/// be cleared when the task is reset.  That is, the next time the task
		/// is brought to the foreground with
		/// <see cref="FLAG_ACTIVITY_RESET_TASK_IF_NEEDED">FLAG_ACTIVITY_RESET_TASK_IF_NEEDED
		/// 	</see>
		/// (typically as a result of
		/// the user re-launching it from home), this activity and all on top of
		/// it will be finished so that the user does not return to them, but
		/// instead returns to whatever activity preceeded it.
		/// <p>This is useful for cases where you have a logical break in your
		/// application.  For example, an e-mail application may have a command
		/// to view an attachment, which launches an image view activity to
		/// display it.  This activity should be part of the e-mail application's
		/// task, since it is a part of the task the user is involved in.  However,
		/// if the user leaves that task, and later selects the e-mail app from
		/// home, we may like them to return to the conversation they were
		/// viewing, not the picture attachment, since that is confusing.  By
		/// setting this flag when launching the image viewer, that viewer and
		/// any activities it starts will be removed the next time the user returns
		/// to mail.
		/// </remarks>
		public const int FLAG_ACTIVITY_CLEAR_WHEN_TASK_RESET = unchecked((int)(0x00080000
			));

		/// <summary>
		/// If set, this flag will prevent the normal
		/// <see cref="android.app.Activity.onUserLeaveHint()">android.app.Activity.onUserLeaveHint()
		/// 	</see>
		/// callback from occurring on the current frontmost activity before it is
		/// paused as the newly-started activity is brought to the front.
		/// <p>Typically, an activity can rely on that callback to indicate that an
		/// explicit user action has caused their activity to be moved out of the
		/// foreground. The callback marks an appropriate point in the activity's
		/// lifecycle for it to dismiss any notifications that it intends to display
		/// "until the user has seen them," such as a blinking LED.
		/// <p>If an activity is ever started via any non-user-driven events such as
		/// phone-call receipt or an alarm handler, this flag should be passed to
		/// <see cref="Context.startActivity(Intent)">Context.startActivity</see>
		/// , ensuring that the pausing
		/// activity does not think the user has acknowledged its notification.
		/// </summary>
		public const int FLAG_ACTIVITY_NO_USER_ACTION = unchecked((int)(0x00040000));

		/// <summary>
		/// If set in an Intent passed to
		/// <see cref="Context.startActivity(Intent)">Context.startActivity()</see>
		/// ,
		/// this flag will cause the launched activity to be brought to the front of its
		/// task's history stack if it is already running.
		/// <p>For example, consider a task consisting of four activities: A, B, C, D.
		/// If D calls startActivity() with an Intent that resolves to the component
		/// of activity B, then B will be brought to the front of the history stack,
		/// with this resulting order:  A, C, D, B.
		/// This flag will be ignored if
		/// <see cref="FLAG_ACTIVITY_CLEAR_TOP">FLAG_ACTIVITY_CLEAR_TOP</see>
		/// is also
		/// specified.
		/// </summary>
		public const int FLAG_ACTIVITY_REORDER_TO_FRONT = 0X00020000;

		/// <summary>
		/// If set in an Intent passed to
		/// <see cref="Context.startActivity(Intent)">Context.startActivity()</see>
		/// ,
		/// this flag will prevent the system from applying an activity transition
		/// animation to go to the next activity state.  This doesn't mean an
		/// animation will never run -- if another activity change happens that doesn't
		/// specify this flag before the activity started here is displayed, then
		/// that transition will be used.  This flag can be put to good use
		/// when you are going to do a series of activity operations but the
		/// animation seen by the user shouldn't be driven by the first activity
		/// change but rather a later one.
		/// </summary>
		public const int FLAG_ACTIVITY_NO_ANIMATION = 0X00010000;

		/// <summary>
		/// If set in an Intent passed to
		/// <see cref="Context.startActivity(Intent)">Context.startActivity()</see>
		/// ,
		/// this flag will cause any existing task that would be associated with the
		/// activity to be cleared before the activity is started.  That is, the activity
		/// becomes the new root of an otherwise empty task, and any old activities
		/// are finished.  This can only be used in conjunction with
		/// <see cref="FLAG_ACTIVITY_NEW_TASK">FLAG_ACTIVITY_NEW_TASK</see>
		/// .
		/// </summary>
		public const int FLAG_ACTIVITY_CLEAR_TASK = 0X00008000;

		/// <summary>
		/// If set in an Intent passed to
		/// <see cref="Context.startActivity(Intent)">Context.startActivity()</see>
		/// ,
		/// this flag will cause a newly launching task to be placed on top of the current
		/// home activity task (if there is one).  That is, pressing back from the task
		/// will always return the user to home even if that was not the last activity they
		/// saw.   This can only be used in conjunction with
		/// <see cref="FLAG_ACTIVITY_NEW_TASK">FLAG_ACTIVITY_NEW_TASK</see>
		/// .
		/// </summary>
		public const int FLAG_ACTIVITY_TASK_ON_HOME = 0X00004000;

		/// <summary>
		/// If set, when sending a broadcast only registered receivers will be
		/// called -- no BroadcastReceiver components will be launched.
		/// </summary>
		/// <remarks>
		/// If set, when sending a broadcast only registered receivers will be
		/// called -- no BroadcastReceiver components will be launched.
		/// </remarks>
		public const int FLAG_RECEIVER_REGISTERED_ONLY = unchecked((int)(0x40000000));

		/// <summary>
		/// If set, when sending a broadcast the new broadcast will replace
		/// any existing pending broadcast that matches it.
		/// </summary>
		/// <remarks>
		/// If set, when sending a broadcast the new broadcast will replace
		/// any existing pending broadcast that matches it.  Matching is defined
		/// by
		/// <see cref="filterEquals(Intent)">Intent.filterEquals</see>
		/// returning
		/// true for the intents of the two broadcasts.  When a match is found,
		/// the new broadcast (and receivers associated with it) will replace the
		/// existing one in the pending broadcast list, remaining at the same
		/// position in the list.
		/// <p>This flag is most typically used with sticky broadcasts, which
		/// only care about delivering the most recent values of the broadcast
		/// to their receivers.
		/// </remarks>
		public const int FLAG_RECEIVER_REPLACE_PENDING = unchecked((int)(0x20000000));

		/// <summary>
		/// If set, when sending a broadcast <i>before boot has completed</i> only
		/// registered receivers will be called -- no BroadcastReceiver components
		/// will be launched.
		/// </summary>
		/// <remarks>
		/// If set, when sending a broadcast <i>before boot has completed</i> only
		/// registered receivers will be called -- no BroadcastReceiver components
		/// will be launched.  Sticky intent state will be recorded properly even
		/// if no receivers wind up being called.  If
		/// <see cref="FLAG_RECEIVER_REGISTERED_ONLY">FLAG_RECEIVER_REGISTERED_ONLY</see>
		/// is specified in the broadcast intent, this flag is unnecessary.
		/// <p>This flag is only for use by system sevices as a convenience to
		/// avoid having to implement a more complex mechanism around detection
		/// of boot completion.
		/// </remarks>
		/// <hide></hide>
		public const int FLAG_RECEIVER_REGISTERED_ONLY_BEFORE_BOOT = unchecked((int)(0x10000000
			));

		/// <summary>
		/// Set when this broadcast is for a boot upgrade, a special mode that
		/// allows the broadcast to be sent before the system is ready and launches
		/// the app process with no providers running in it.
		/// </summary>
		/// <remarks>
		/// Set when this broadcast is for a boot upgrade, a special mode that
		/// allows the broadcast to be sent before the system is ready and launches
		/// the app process with no providers running in it.
		/// </remarks>
		/// <hide></hide>
		public const int FLAG_RECEIVER_BOOT_UPGRADE = unchecked((int)(0x08000000));

		/// <hide>Flags that can't be changed with PendingIntent.</hide>
		public const int IMMUTABLE_FLAGS = FLAG_GRANT_READ_URI_PERMISSION | FLAG_GRANT_WRITE_URI_PERMISSION;

		/// <summary>
		/// Flag for use with
		/// <see cref="toUri(int)">toUri(int)</see>
		/// and
		/// <see cref="parseUri(string, int)">parseUri(string, int)</see>
		/// : the URI string
		/// always has the "intent:" scheme.  This syntax can be used when you want
		/// to later disambiguate between URIs that are intended to describe an
		/// Intent vs. all others that should be treated as raw URIs.  When used
		/// with
		/// <see cref="parseUri(string, int)">parseUri(string, int)</see>
		/// , any other scheme will result in a generic
		/// VIEW action for that raw URI.
		/// </summary>
		public const int URI_INTENT_SCHEME = 1 << 0;

		private string mAction;

		private System.Uri mData;

		private string mType;

		private string mPackage;

		private android.content.ComponentName mComponent;

		private int mFlags;

		private java.util.HashSet<string> mCategories;

		private android.os.Bundle mExtras;

		private android.graphics.Rect mSourceBounds;

		/// <summary>Create an empty intent.</summary>
		/// <remarks>Create an empty intent.</remarks>
		public Intent()
		{
		}

		/// <summary>Copy constructor.</summary>
		/// <remarks>Copy constructor.</remarks>
		public Intent(android.content.Intent o)
		{
			// ---------------------------------------------------------------------
			// ---------------------------------------------------------------------
			// Standard intent broadcast actions (see action variable).
			// *** NOTE: @todo(*) The following really should go into a more domain-specific
			// location; they are not general-purpose actions.
			//@SdkConstant(SdkConstantType.BROADCAST_INTENT_ACTION)
			// ---------------------------------------------------------------------
			// ---------------------------------------------------------------------
			// Standard intent categories (see addCategory()).
			// ---------------------------------------------------------------------
			// ---------------------------------------------------------------------
			// Standard extra data keys.
			// ---------------------------------------------------------------------
			// ---------------------------------------------------------------------
			// Intent flags (see mFlags variable).
			// ---------------------------------------------------------------------
			// ---------------------------------------------------------------------
			// toUri() and parseUri() options.
			// ---------------------------------------------------------------------
			// ---------------------------------------------------------------------
			this.mAction = o.mAction;
			this.mData = o.mData;
			this.mType = o.mType;
			this.mPackage = o.mPackage;
			this.mComponent = o.mComponent;
			this.mFlags = o.mFlags;
			if (o.mCategories != null)
			{
				this.mCategories = new java.util.HashSet<string>(o.mCategories);
			}
			if (o.mExtras != null)
			{
				this.mExtras = new android.os.Bundle(o.mExtras);
			}
			if (o.mSourceBounds != null)
			{
				this.mSourceBounds = new android.graphics.Rect(o.mSourceBounds);
			}
		}

		public virtual object clone()
		{
			return new android.content.Intent(this);
		}

		private Intent(android.content.Intent o, bool all)
		{
			this.mAction = o.mAction;
			this.mData = o.mData;
			this.mType = o.mType;
			this.mPackage = o.mPackage;
			this.mComponent = o.mComponent;
			if (o.mCategories != null)
			{
				this.mCategories = new java.util.HashSet<string>(o.mCategories);
			}
		}

		/// <summary>
		/// Make a clone of only the parts of the Intent that are relevant for
		/// filter matching: the action, data, type, component, and categories.
		/// </summary>
		/// <remarks>
		/// Make a clone of only the parts of the Intent that are relevant for
		/// filter matching: the action, data, type, component, and categories.
		/// </remarks>
		public virtual android.content.Intent cloneFilter()
		{
			return new android.content.Intent(this, false);
		}

		/// <summary>Create an intent with a given action.</summary>
		/// <remarks>
		/// Create an intent with a given action.  All other fields (data, type,
		/// class) are null.  Note that the action <em>must</em> be in a
		/// namespace because Intents are used globally in the system -- for
		/// example the system VIEW action is android.intent.action.VIEW; an
		/// application's custom action would be something like
		/// com.google.app.myapp.CUSTOM_ACTION.
		/// </remarks>
		/// <param name="action">The Intent action, such as ACTION_VIEW.</param>
		public Intent(string action)
		{
			setAction(action);
		}

		/// <summary>Create an intent with a given action and for a given data url.</summary>
		/// <remarks>
		/// Create an intent with a given action and for a given data url.  Note
		/// that the action <em>must</em> be in a namespace because Intents are
		/// used globally in the system -- for example the system VIEW action is
		/// android.intent.action.VIEW; an application's custom action would be
		/// something like com.google.app.myapp.CUSTOM_ACTION.
		/// <p><em>Note: scheme and host name matching in the Android framework is
		/// case-sensitive, unlike the formal RFC.  As a result,
		/// you should always ensure that you write your Uri with these elements
		/// using lower case letters, and normalize any Uris you receive from
		/// outside of Android to ensure the scheme and host is lower case.</em></p>
		/// </remarks>
		/// <param name="action">The Intent action, such as ACTION_VIEW.</param>
		/// <param name="uri">The Intent data URI.</param>
		public Intent(string action, System.Uri uri)
		{
			setAction(action);
			mData = uri;
		}

		/// <summary>Create an intent for a specific component.</summary>
		/// <remarks>
		/// Create an intent for a specific component.  All other fields (action, data,
		/// type, class) are null, though they can be modified later with explicit
		/// calls.  This provides a convenient way to create an intent that is
		/// intended to execute a hard-coded class name, rather than relying on the
		/// system to find an appropriate class for you; see
		/// <see cref="setComponent(ComponentName)">setComponent(ComponentName)</see>
		/// for more information on the repercussions of this.
		/// </remarks>
		/// <param name="packageContext">
		/// A Context of the application package implementing
		/// this class.
		/// </param>
		/// <param name="cls">The component class that is to be used for the intent.</param>
		/// <seealso cref="setClass(Context, System.Type{T})">setClass(Context, System.Type&lt;T&gt;)
		/// 	</seealso>
		/// <seealso cref="setComponent(ComponentName)">setComponent(ComponentName)</seealso>
		/// <seealso cref="Intent(string, System.Uri, Context, System.Type{T})">Intent(string, System.Uri, Context, System.Type&lt;T&gt;)
		/// 	</seealso>
		public Intent(android.content.Context packageContext, System.Type cls)
		{
			mComponent = new android.content.ComponentName(packageContext, cls);
		}

		/// <summary>Create an intent for a specific component with a specified action and data.
		/// 	</summary>
		/// <remarks>
		/// Create an intent for a specific component with a specified action and data.
		/// This is equivalent using
		/// <see cref="Intent(string, System.Uri)">Intent(string, System.Uri)</see>
		/// to
		/// construct the Intent and then calling
		/// <see cref="setClass(Context, System.Type{T})">setClass(Context, System.Type&lt;T&gt;)
		/// 	</see>
		/// to set its
		/// class.
		/// <p><em>Note: scheme and host name matching in the Android framework is
		/// case-sensitive, unlike the formal RFC.  As a result,
		/// you should always ensure that you write your Uri with these elements
		/// using lower case letters, and normalize any Uris you receive from
		/// outside of Android to ensure the scheme and host is lower case.</em></p>
		/// </remarks>
		/// <param name="action">The Intent action, such as ACTION_VIEW.</param>
		/// <param name="uri">The Intent data URI.</param>
		/// <param name="packageContext">
		/// A Context of the application package implementing
		/// this class.
		/// </param>
		/// <param name="cls">The component class that is to be used for the intent.</param>
		/// <seealso cref="Intent(string, System.Uri)">Intent(string, System.Uri)</seealso>
		/// <seealso cref="Intent(Context, System.Type{T})">Intent(Context, System.Type&lt;T&gt;)
		/// 	</seealso>
		/// <seealso cref="setClass(Context, System.Type{T})">setClass(Context, System.Type&lt;T&gt;)
		/// 	</seealso>
		/// <seealso cref="setComponent(ComponentName)">setComponent(ComponentName)</seealso>
		public Intent(string action, System.Uri uri, android.content.Context packageContext
			, System.Type cls)
		{
			setAction(action);
			mData = uri;
			mComponent = new android.content.ComponentName(packageContext, cls);
		}

		/// <summary>Create an intent to launch the main (root) activity of a task.</summary>
		/// <remarks>
		/// Create an intent to launch the main (root) activity of a task.  This
		/// is the Intent that is started when the application's is launched from
		/// Home.  For anything else that wants to launch an application in the
		/// same way, it is important that they use an Intent structured the same
		/// way, and can use this function to ensure this is the case.
		/// <p>The returned Intent has the given Activity component as its explicit
		/// component,
		/// <see cref="ACTION_MAIN">ACTION_MAIN</see>
		/// as its action, and includes the
		/// category
		/// <see cref="CATEGORY_LAUNCHER">CATEGORY_LAUNCHER</see>
		/// .  This does <em>not</em> have
		/// <see cref="FLAG_ACTIVITY_NEW_TASK">FLAG_ACTIVITY_NEW_TASK</see>
		/// set, though typically you will want
		/// to do that through
		/// <see cref="addFlags(int)">addFlags(int)</see>
		/// on the returned Intent.
		/// </remarks>
		/// <param name="mainActivity">
		/// The main activity component that this Intent will
		/// launch.
		/// </param>
		/// <returns>
		/// Returns a newly created Intent that can be used to launch the
		/// activity as a main application entry.
		/// </returns>
		/// <seealso cref="setClass(Context, System.Type{T})">setClass(Context, System.Type&lt;T&gt;)
		/// 	</seealso>
		/// <seealso cref="setComponent(ComponentName)">setComponent(ComponentName)</seealso>
		public static android.content.Intent makeMainActivity(android.content.ComponentName
			 mainActivity)
		{
			android.content.Intent intent = new android.content.Intent(ACTION_MAIN);
			intent.setComponent(mainActivity);
			intent.addCategory(CATEGORY_LAUNCHER);
			return intent;
		}

		/// <summary>
		/// Make an Intent that can be used to re-launch an application's task
		/// in its base state.
		/// </summary>
		/// <remarks>
		/// Make an Intent that can be used to re-launch an application's task
		/// in its base state.  This is like
		/// <see cref="makeMainActivity(ComponentName)">makeMainActivity(ComponentName)</see>
		/// ,
		/// but also sets the flags
		/// <see cref="FLAG_ACTIVITY_NEW_TASK">FLAG_ACTIVITY_NEW_TASK</see>
		/// and
		/// <see cref="FLAG_ACTIVITY_CLEAR_TASK">FLAG_ACTIVITY_CLEAR_TASK</see>
		/// .
		/// </remarks>
		/// <param name="mainActivity">
		/// The activity component that is the root of the
		/// task; this is the activity that has been published in the application's
		/// manifest as the main launcher icon.
		/// </param>
		/// <returns>
		/// Returns a newly created Intent that can be used to relaunch the
		/// activity's task in its root state.
		/// </returns>
		public static android.content.Intent makeRestartActivityTask(android.content.ComponentName
			 mainActivity)
		{
			android.content.Intent intent = makeMainActivity(mainActivity);
			intent.addFlags(android.content.Intent.FLAG_ACTIVITY_NEW_TASK | android.content.Intent
				.FLAG_ACTIVITY_CLEAR_TASK);
			return intent;
		}

		/// <summary>
		/// Call
		/// <see cref="parseUri(string, int)">parseUri(string, int)</see>
		/// with 0 flags.
		/// </summary>
		/// <exception cref="java.net.URISyntaxException"></exception>
		[System.ObsoleteAttribute(@"Use parseUri(string, int) instead.")]
		public static android.content.Intent getIntent(string uri)
		{
			return parseUri(uri, 0);
		}

		[Sharpen.Stub]
		public static android.content.Intent parseUri(string uri, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.Intent getIntentOld(string uri)
		{
			throw new System.NotImplementedException();
		}

		// Validate intent scheme for if requested.
		// simple case
		// old format Intent URI
		// new format
		// fetch data part, if present
		// loop over contents of Intent, all name=value;
		// action
		// categories
		// type
		// launch flags
		// package
		// component
		// scheme
		// source bounds
		// extra
		// create Bundle if it doesn't already exist
		// add EXTRA
		// move to the next item
		// fetch the key value
		// get type-value
		// create Bundle if it doesn't already exist
		// add item to bundle
		// By default, if no action is specified, then use VIEW.
		/// <summary>
		/// Retrieve the general action to be performed, such as
		/// <see cref="ACTION_VIEW">ACTION_VIEW</see>
		/// .  The action describes the general way the rest of
		/// the information in the intent should be interpreted -- most importantly,
		/// what to do with the data returned by
		/// <see cref="getData()">getData()</see>
		/// .
		/// </summary>
		/// <returns>The action of this intent or null if none is specified.</returns>
		/// <seealso cref="setAction(string)">setAction(string)</seealso>
		public virtual string getAction()
		{
			return mAction;
		}

		/// <summary>Retrieve data this intent is operating on.</summary>
		/// <remarks>
		/// Retrieve data this intent is operating on.  This URI specifies the name
		/// of the data; often it uses the content: scheme, specifying data in a
		/// content provider.  Other schemes may be handled by specific activities,
		/// such as http: by the web browser.
		/// </remarks>
		/// <returns>The URI of the data this intent is targeting or null.</returns>
		/// <seealso cref="getScheme()">getScheme()</seealso>
		/// <seealso cref="setData(System.Uri)">setData(System.Uri)</seealso>
		public virtual System.Uri getData()
		{
			return mData;
		}

		/// <summary>
		/// The same as
		/// <see cref="getData()">getData()</see>
		/// , but returns the URI as an encoded
		/// String.
		/// </summary>
		public virtual string getDataString()
		{
			return mData != null ? mData.ToString() : null;
		}

		/// <summary>Return the scheme portion of the intent's data.</summary>
		/// <remarks>
		/// Return the scheme portion of the intent's data.  If the data is null or
		/// does not include a scheme, null is returned.  Otherwise, the scheme
		/// prefix without the final ':' is returned, i.e. "http".
		/// <p>This is the same as calling getData().getScheme() (and checking for
		/// null data).
		/// </remarks>
		/// <returns>The scheme of this intent.</returns>
		/// <seealso cref="getData()">getData()</seealso>
		public virtual string getScheme()
		{
			return mData != null ? mData.Scheme : null;
		}

		/// <summary>Retrieve any explicit MIME type included in the intent.</summary>
		/// <remarks>
		/// Retrieve any explicit MIME type included in the intent.  This is usually
		/// null, as the type is determined by the intent data.
		/// </remarks>
		/// <returns>
		/// If a type was manually set, it is returned; else null is
		/// returned.
		/// </returns>
		/// <seealso cref="resolveType(ContentResolver)">resolveType(ContentResolver)</seealso>
		/// <seealso cref="setType(string)">setType(string)</seealso>
		public virtual string getType()
		{
			return mType;
		}

		/// <summary>Return the MIME data type of this intent.</summary>
		/// <remarks>
		/// Return the MIME data type of this intent.  If the type field is
		/// explicitly set, that is simply returned.  Otherwise, if the data is set,
		/// the type of that data is returned.  If neither fields are set, a null is
		/// returned.
		/// </remarks>
		/// <returns>The MIME type of this intent.</returns>
		/// <seealso cref="getType()">getType()</seealso>
		/// <seealso cref="resolveType(ContentResolver)">resolveType(ContentResolver)</seealso>
		public virtual string resolveType(android.content.Context context)
		{
			return resolveType(context.getContentResolver());
		}

		/// <summary>Return the MIME data type of this intent.</summary>
		/// <remarks>
		/// Return the MIME data type of this intent.  If the type field is
		/// explicitly set, that is simply returned.  Otherwise, if the data is set,
		/// the type of that data is returned.  If neither fields are set, a null is
		/// returned.
		/// </remarks>
		/// <param name="resolver">
		/// A ContentResolver that can be used to determine the MIME
		/// type of the intent's data.
		/// </param>
		/// <returns>The MIME type of this intent.</returns>
		/// <seealso cref="getType()">getType()</seealso>
		/// <seealso cref="resolveType(Context)">resolveType(Context)</seealso>
		public virtual string resolveType(android.content.ContentResolver resolver)
		{
			if (mType != null)
			{
				return mType;
			}
			if (mData != null)
			{
				if ("content".Equals(mData.Scheme))
				{
					return resolver.getType(mData);
				}
			}
			return null;
		}

		/// <summary>
		/// Return the MIME data type of this intent, only if it will be needed for
		/// intent resolution.
		/// </summary>
		/// <remarks>
		/// Return the MIME data type of this intent, only if it will be needed for
		/// intent resolution.  This is not generally useful for application code;
		/// it is used by the frameworks for communicating with back-end system
		/// services.
		/// </remarks>
		/// <param name="resolver">
		/// A ContentResolver that can be used to determine the MIME
		/// type of the intent's data.
		/// </param>
		/// <returns>
		/// The MIME type of this intent, or null if it is unknown or not
		/// needed.
		/// </returns>
		public virtual string resolveTypeIfNeeded(android.content.ContentResolver resolver
			)
		{
			if (mComponent != null)
			{
				return mType;
			}
			return resolveType(resolver);
		}

		/// <summary>Check if an category exists in the intent.</summary>
		/// <remarks>Check if an category exists in the intent.</remarks>
		/// <param name="category">The category to check.</param>
		/// <returns>boolean True if the intent contains the category, else false.</returns>
		/// <seealso cref="getCategories()">getCategories()</seealso>
		/// <seealso cref="addCategory(string)">addCategory(string)</seealso>
		public virtual bool hasCategory(string category)
		{
			return mCategories != null && mCategories.contains(category);
		}

		/// <summary>Return the set of all categories in the intent.</summary>
		/// <remarks>
		/// Return the set of all categories in the intent.  If there are no categories,
		/// returns NULL.
		/// </remarks>
		/// <returns>Set The set of categories you can examine.  Do not modify!</returns>
		/// <seealso cref="hasCategory(string)">hasCategory(string)</seealso>
		/// <seealso cref="addCategory(string)">addCategory(string)</seealso>
		public virtual java.util.Set<string> getCategories()
		{
			return mCategories;
		}

		/// <summary>
		/// Sets the ClassLoader that will be used when unmarshalling
		/// any Parcelable values from the extras of this Intent.
		/// </summary>
		/// <remarks>
		/// Sets the ClassLoader that will be used when unmarshalling
		/// any Parcelable values from the extras of this Intent.
		/// </remarks>
		/// <param name="loader">
		/// a ClassLoader, or null to use the default loader
		/// at the time of unmarshalling.
		/// </param>
		public virtual void setExtrasClassLoader(java.lang.ClassLoader loader)
		{
			if (mExtras != null)
			{
				mExtras.setClassLoader(loader);
			}
		}

		/// <summary>Returns true if an extra value is associated with the given name.</summary>
		/// <remarks>Returns true if an extra value is associated with the given name.</remarks>
		/// <param name="name">the extra's name</param>
		/// <returns>true if the given extra is present.</returns>
		public virtual bool hasExtra(string name)
		{
			return mExtras != null && mExtras.containsKey(name);
		}

		/// <summary>Returns true if the Intent's extras contain a parcelled file descriptor.
		/// 	</summary>
		/// <remarks>Returns true if the Intent's extras contain a parcelled file descriptor.
		/// 	</remarks>
		/// <returns>true if the Intent contains a parcelled file descriptor.</returns>
		public virtual bool hasFileDescriptors()
		{
			return mExtras != null && mExtras.hasFileDescriptors();
		}

		/// <hide></hide>
		public virtual void setAllowFds(bool allowFds)
		{
			if (mExtras != null)
			{
				mExtras.setAllowFds(allowFds);
			}
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if none was found.
		/// </returns>
		/// <hide></hide>
		[System.ObsoleteAttribute]
		public virtual object getExtra(string name)
		{
			return getExtra(name, null);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <param name="defaultValue">
		/// the value to be returned if no value of the desired
		/// type is stored with the given name.
		/// </param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or the default value if none was found.
		/// </returns>
		/// <seealso cref="putExtra(string, bool)">putExtra(string, bool)</seealso>
		public virtual bool getBooleanExtra(string name, bool defaultValue)
		{
			return mExtras == null ? defaultValue : mExtras.getBoolean(name, defaultValue);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <param name="defaultValue">
		/// the value to be returned if no value of the desired
		/// type is stored with the given name.
		/// </param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or the default value if none was found.
		/// </returns>
		/// <seealso cref="putExtra(string, byte)">putExtra(string, byte)</seealso>
		public virtual byte getByteExtra(string name, byte defaultValue)
		{
			return mExtras == null ? defaultValue : mExtras.getByte(name, defaultValue);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <param name="defaultValue">
		/// the value to be returned if no value of the desired
		/// type is stored with the given name.
		/// </param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or the default value if none was found.
		/// </returns>
		/// <seealso cref="putExtra(string, short)">putExtra(string, short)</seealso>
		public virtual short getShortExtra(string name, short defaultValue)
		{
			return mExtras == null ? defaultValue : mExtras.getShort(name, defaultValue);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <param name="defaultValue">
		/// the value to be returned if no value of the desired
		/// type is stored with the given name.
		/// </param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or the default value if none was found.
		/// </returns>
		/// <seealso cref="putExtra(string, char)">putExtra(string, char)</seealso>
		public virtual char getCharExtra(string name, char defaultValue)
		{
			return mExtras == null ? defaultValue : mExtras.getChar(name, defaultValue);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <param name="defaultValue">
		/// the value to be returned if no value of the desired
		/// type is stored with the given name.
		/// </param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or the default value if none was found.
		/// </returns>
		/// <seealso cref="putExtra(string, int)">putExtra(string, int)</seealso>
		public virtual int getIntExtra(string name, int defaultValue)
		{
			return mExtras == null ? defaultValue : mExtras.getInt(name, defaultValue);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <param name="defaultValue">
		/// the value to be returned if no value of the desired
		/// type is stored with the given name.
		/// </param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or the default value if none was found.
		/// </returns>
		/// <seealso cref="putExtra(string, long)">putExtra(string, long)</seealso>
		public virtual long getLongExtra(string name, long defaultValue)
		{
			return mExtras == null ? defaultValue : mExtras.getLong(name, defaultValue);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <param name="defaultValue">
		/// the value to be returned if no value of the desired
		/// type is stored with the given name.
		/// </param>
		/// <returns>
		/// the value of an item that previously added with putExtra(),
		/// or the default value if no such item is present
		/// </returns>
		/// <seealso cref="putExtra(string, float)">putExtra(string, float)</seealso>
		public virtual float getFloatExtra(string name, float defaultValue)
		{
			return mExtras == null ? defaultValue : mExtras.getFloat(name, defaultValue);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <param name="defaultValue">
		/// the value to be returned if no value of the desired
		/// type is stored with the given name.
		/// </param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or the default value if none was found.
		/// </returns>
		/// <seealso cref="putExtra(string, double)">putExtra(string, double)</seealso>
		public virtual double getDoubleExtra(string name, double defaultValue)
		{
			return mExtras == null ? defaultValue : mExtras.getDouble(name, defaultValue);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no String value was found.
		/// </returns>
		/// <seealso cref="putExtra(string, string)">putExtra(string, string)</seealso>
		public virtual string getStringExtra(string name)
		{
			return mExtras == null ? null : mExtras.getString(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no CharSequence value was found.
		/// </returns>
		/// <seealso cref="putExtra(string, java.lang.CharSequence)">putExtra(string, java.lang.CharSequence)
		/// 	</seealso>
		public virtual java.lang.CharSequence getCharSequenceExtra(string name)
		{
			return mExtras == null ? null : mExtras.getCharSequence(name);
		}

		[Sharpen.Stub]
		public virtual T getParcelableExtra<T>(string name) where T:android.os.Parcelable
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no Parcelable[] value was found.
		/// </returns>
		/// <seealso cref="putExtra(string, android.os.Parcelable[])">putExtra(string, android.os.Parcelable[])
		/// 	</seealso>
		public virtual android.os.Parcelable[] getParcelableArrayExtra(string name)
		{
			return mExtras == null ? null : mExtras.getParcelableArray(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no ArrayList<Parcelable> value was found.
		/// </returns>
		/// <seealso cref="putParcelableArrayListExtra(string, java.util.ArrayList{E})">putParcelableArrayListExtra(string, java.util.ArrayList&lt;E&gt;)
		/// 	</seealso>
		public virtual java.util.ArrayList<T> getParcelableArrayListExtra<T>(string name)
			 where T:android.os.Parcelable
		{
			return mExtras == null ? null : mExtras.getParcelableArrayList<T>(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no Serializable value was found.
		/// </returns>
		/// <seealso cref="putExtra(string, java.io.Serializable)">putExtra(string, java.io.Serializable)
		/// 	</seealso>
		public virtual java.io.Serializable getSerializableExtra(string name)
		{
			return mExtras == null ? null : mExtras.getSerializable(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no ArrayList<Integer> value was found.
		/// </returns>
		/// <seealso cref="putIntegerArrayListExtra(string, java.util.ArrayList{E})">putIntegerArrayListExtra(string, java.util.ArrayList&lt;E&gt;)
		/// 	</seealso>
		public virtual java.util.ArrayList<int> getIntegerArrayListExtra(string name)
		{
			return mExtras == null ? null : mExtras.getIntegerArrayList(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no ArrayList<String> value was found.
		/// </returns>
		/// <seealso cref="putStringArrayListExtra(string, java.util.ArrayList{E})">putStringArrayListExtra(string, java.util.ArrayList&lt;E&gt;)
		/// 	</seealso>
		public virtual java.util.ArrayList<string> getStringArrayListExtra(string name)
		{
			return mExtras == null ? null : mExtras.getStringArrayList(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no ArrayList<CharSequence> value was found.
		/// </returns>
		/// <seealso cref="putCharSequenceArrayListExtra(string, java.util.ArrayList{E})">putCharSequenceArrayListExtra(string, java.util.ArrayList&lt;E&gt;)
		/// 	</seealso>
		public virtual java.util.ArrayList<java.lang.CharSequence> getCharSequenceArrayListExtra
			(string name)
		{
			return mExtras == null ? null : mExtras.getCharSequenceArrayList(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no boolean array value was found.
		/// </returns>
		/// <seealso cref="putExtra(string, bool[])">putExtra(string, bool[])</seealso>
		public virtual bool[] getBooleanArrayExtra(string name)
		{
			return mExtras == null ? null : mExtras.getBooleanArray(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no byte array value was found.
		/// </returns>
		/// <seealso cref="putExtra(string, byte[])">putExtra(string, byte[])</seealso>
		public virtual byte[] getByteArrayExtra(string name)
		{
			return mExtras == null ? null : mExtras.getByteArray(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no short array value was found.
		/// </returns>
		/// <seealso cref="putExtra(string, short[])">putExtra(string, short[])</seealso>
		public virtual short[] getShortArrayExtra(string name)
		{
			return mExtras == null ? null : mExtras.getShortArray(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no char array value was found.
		/// </returns>
		/// <seealso cref="putExtra(string, char[])">putExtra(string, char[])</seealso>
		public virtual char[] getCharArrayExtra(string name)
		{
			return mExtras == null ? null : mExtras.getCharArray(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no int array value was found.
		/// </returns>
		/// <seealso cref="putExtra(string, int[])">putExtra(string, int[])</seealso>
		public virtual int[] getIntArrayExtra(string name)
		{
			return mExtras == null ? null : mExtras.getIntArray(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no long array value was found.
		/// </returns>
		/// <seealso cref="putExtra(string, long[])">putExtra(string, long[])</seealso>
		public virtual long[] getLongArrayExtra(string name)
		{
			return mExtras == null ? null : mExtras.getLongArray(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no float array value was found.
		/// </returns>
		/// <seealso cref="putExtra(string, float[])">putExtra(string, float[])</seealso>
		public virtual float[] getFloatArrayExtra(string name)
		{
			return mExtras == null ? null : mExtras.getFloatArray(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no double array value was found.
		/// </returns>
		/// <seealso cref="putExtra(string, double[])">putExtra(string, double[])</seealso>
		public virtual double[] getDoubleArrayExtra(string name)
		{
			return mExtras == null ? null : mExtras.getDoubleArray(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no String array value was found.
		/// </returns>
		/// <seealso cref="putExtra(string, string[])">putExtra(string, string[])</seealso>
		public virtual string[] getStringArrayExtra(string name)
		{
			return mExtras == null ? null : mExtras.getStringArray(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no CharSequence array value was found.
		/// </returns>
		/// <seealso cref="putExtra(string, java.lang.CharSequence[])">putExtra(string, java.lang.CharSequence[])
		/// 	</seealso>
		public virtual java.lang.CharSequence[] getCharSequenceArrayExtra(string name)
		{
			return mExtras == null ? null : mExtras.getCharSequenceArray(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no Bundle value was found.
		/// </returns>
		/// <seealso cref="putExtra(string, android.os.Bundle)">putExtra(string, android.os.Bundle)
		/// 	</seealso>
		public virtual android.os.Bundle getBundleExtra(string name)
		{
			return mExtras == null ? null : mExtras.getBundle(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or null if no IBinder value was found.
		/// </returns>
		/// <seealso cref="putExtra(string, android.os.IBinder)">putExtra(string, android.os.IBinder)
		/// 	</seealso>
		/// <hide></hide>
		[System.ObsoleteAttribute]
		public virtual android.os.IBinder getIBinderExtra(string name)
		{
			return mExtras == null ? null : mExtras.getIBinder(name);
		}

		/// <summary>Retrieve extended data from the intent.</summary>
		/// <remarks>Retrieve extended data from the intent.</remarks>
		/// <param name="name">The name of the desired item.</param>
		/// <param name="defaultValue">
		/// The default value to return in case no item is
		/// associated with the key 'name'
		/// </param>
		/// <returns>
		/// the value of an item that previously added with putExtra()
		/// or defaultValue if none was found.
		/// </returns>
		/// <seealso cref="putExtra(string, bool)">putExtra(string, bool)</seealso>
		/// <hide></hide>
		[System.ObsoleteAttribute]
		public virtual object getExtra(string name, object defaultValue)
		{
			object result = defaultValue;
			if (mExtras != null)
			{
				object result2 = mExtras.get(name);
				if (result2 != null)
				{
					result = result2;
				}
			}
			return result;
		}

		/// <summary>Retrieves a map of extended data from the intent.</summary>
		/// <remarks>Retrieves a map of extended data from the intent.</remarks>
		/// <returns>
		/// the map of all extras previously added with putExtra(),
		/// or null if none have been added.
		/// </returns>
		public virtual android.os.Bundle getExtras()
		{
			return (mExtras != null) ? new android.os.Bundle(mExtras) : null;
		}

		/// <summary>Retrieve any special flags associated with this intent.</summary>
		/// <remarks>
		/// Retrieve any special flags associated with this intent.  You will
		/// normally just set them with
		/// <see cref="setFlags(int)">setFlags(int)</see>
		/// and let the system
		/// take the appropriate action with them.
		/// </remarks>
		/// <returns>int The currently set flags.</returns>
		/// <seealso cref="setFlags(int)">setFlags(int)</seealso>
		public virtual int getFlags()
		{
			return mFlags;
		}

		/// <hide></hide>
		public virtual bool isExcludingStopped()
		{
			return (mFlags & (FLAG_EXCLUDE_STOPPED_PACKAGES | FLAG_INCLUDE_STOPPED_PACKAGES))
				 == FLAG_EXCLUDE_STOPPED_PACKAGES;
		}

		/// <summary>Retrieve the application package name this Intent is limited to.</summary>
		/// <remarks>
		/// Retrieve the application package name this Intent is limited to.  When
		/// resolving an Intent, if non-null this limits the resolution to only
		/// components in the given application package.
		/// </remarks>
		/// <returns>The name of the application package for the Intent.</returns>
		/// <seealso cref="resolveActivity(android.content.pm.PackageManager)">resolveActivity(android.content.pm.PackageManager)
		/// 	</seealso>
		/// <seealso cref="setPackage(string)">setPackage(string)</seealso>
		public virtual string getPackage()
		{
			return mPackage;
		}

		/// <summary>Retrieve the concrete component associated with the intent.</summary>
		/// <remarks>
		/// Retrieve the concrete component associated with the intent.  When receiving
		/// an intent, this is the component that was found to best handle it (that is,
		/// yourself) and will always be non-null; in all other cases it will be
		/// null unless explicitly set.
		/// </remarks>
		/// <returns>The name of the application component to handle the intent.</returns>
		/// <seealso cref="resolveActivity(android.content.pm.PackageManager)">resolveActivity(android.content.pm.PackageManager)
		/// 	</seealso>
		/// <seealso cref="setComponent(ComponentName)">setComponent(ComponentName)</seealso>
		public virtual android.content.ComponentName getComponent()
		{
			return mComponent;
		}

		/// <summary>Get the bounds of the sender of this intent, in screen coordinates.</summary>
		/// <remarks>
		/// Get the bounds of the sender of this intent, in screen coordinates.  This can be
		/// used as a hint to the receiver for animations and the like.  Null means that there
		/// is no source bounds.
		/// </remarks>
		public virtual android.graphics.Rect getSourceBounds()
		{
			return mSourceBounds;
		}

		/// <summary>Return the Activity component that should be used to handle this intent.
		/// 	</summary>
		/// <remarks>
		/// Return the Activity component that should be used to handle this intent.
		/// The appropriate component is determined based on the information in the
		/// intent, evaluated as follows:
		/// <p>If
		/// <see cref="getComponent()">getComponent()</see>
		/// returns an explicit class, that is returned
		/// without any further consideration.
		/// <p>The activity must handle the
		/// <see cref="CATEGORY_DEFAULT">CATEGORY_DEFAULT</see>
		/// Intent
		/// category to be considered.
		/// <p>If
		/// <see cref="getAction()">getAction()</see>
		/// is non-NULL, the activity must handle this
		/// action.
		/// <p>If
		/// <see cref="resolveType(Context)">resolveType(Context)</see>
		/// returns non-NULL, the activity must handle
		/// this type.
		/// <p>If
		/// <see cref="addCategory(string)">addCategory(string)</see>
		/// has added any categories, the activity must
		/// handle ALL of the categories specified.
		/// <p>If
		/// <see cref="getPackage()">getPackage()</see>
		/// is non-NULL, only activity components in
		/// that application package will be considered.
		/// <p>If there are no activities that satisfy all of these conditions, a
		/// null string is returned.
		/// <p>If multiple activities are found to satisfy the intent, the one with
		/// the highest priority will be used.  If there are multiple activities
		/// with the same priority, the system will either pick the best activity
		/// based on user preference, or resolve to a system class that will allow
		/// the user to pick an activity and forward from there.
		/// <p>This method is implemented simply by calling
		/// <see cref="android.content.pm.PackageManager.resolveActivity(Intent, int)">android.content.pm.PackageManager.resolveActivity(Intent, int)
		/// 	</see>
		/// with the "defaultOnly" parameter
		/// true.</p>
		/// <p> This API is called for you as part of starting an activity from an
		/// intent.  You do not normally need to call it yourself.</p>
		/// </remarks>
		/// <param name="pm">The package manager with which to resolve the Intent.</param>
		/// <returns>
		/// Name of the component implementing an activity that can
		/// display the intent.
		/// </returns>
		/// <seealso cref="setComponent(ComponentName)">setComponent(ComponentName)</seealso>
		/// <seealso cref="getComponent()">getComponent()</seealso>
		/// <seealso cref="resolveActivityInfo(android.content.pm.PackageManager, int)">resolveActivityInfo(android.content.pm.PackageManager, int)
		/// 	</seealso>
		public virtual android.content.ComponentName resolveActivity(android.content.pm.PackageManager
			 pm)
		{
			if (mComponent != null)
			{
				return mComponent;
			}
			android.content.pm.ResolveInfo info = pm.resolveActivity(this, android.content.pm.PackageManager
				.MATCH_DEFAULT_ONLY);
			if (info != null)
			{
				return new android.content.ComponentName(info.activityInfo.applicationInfo.packageName
					, info.activityInfo.name);
			}
			return null;
		}

		/// <summary>
		/// Resolve the Intent into an
		/// <see cref="android.content.pm.ActivityInfo">android.content.pm.ActivityInfo</see>
		/// describing the activity that should execute the intent.  Resolution
		/// follows the same rules as described for
		/// <see cref="resolveActivity(android.content.pm.PackageManager)">resolveActivity(android.content.pm.PackageManager)
		/// 	</see>
		/// , but
		/// you get back the completely information about the resolved activity
		/// instead of just its class name.
		/// </summary>
		/// <param name="pm">The package manager with which to resolve the Intent.</param>
		/// <param name="flags">
		/// Addition information to retrieve as per
		/// <see cref="android.content.pm.PackageManager.getActivityInfo(ComponentName, int)"
		/// 	>PackageManager.getActivityInfo()</see>
		/// .
		/// </param>
		/// <returns>PackageManager.ActivityInfo</returns>
		/// <seealso cref="resolveActivity(android.content.pm.PackageManager)">resolveActivity(android.content.pm.PackageManager)
		/// 	</seealso>
		public virtual android.content.pm.ActivityInfo resolveActivityInfo(android.content.pm.PackageManager
			 pm, int flags)
		{
			android.content.pm.ActivityInfo ai = null;
			if (mComponent != null)
			{
				try
				{
					ai = pm.getActivityInfo(mComponent, flags);
				}
				catch (android.content.pm.PackageManager.NameNotFoundException)
				{
				}
			}
			else
			{
				// ignore
				android.content.pm.ResolveInfo info = pm.resolveActivity(this, android.content.pm.PackageManager
					.MATCH_DEFAULT_ONLY | flags);
				if (info != null)
				{
					ai = info.activityInfo;
				}
			}
			return ai;
		}

		/// <summary>Set the general action to be performed.</summary>
		/// <remarks>Set the general action to be performed.</remarks>
		/// <param name="action">
		/// An action name, such as ACTION_VIEW.  Application-specific
		/// actions should be prefixed with the vendor's package name.
		/// </param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="getAction()">getAction()</seealso>
		public virtual android.content.Intent setAction(string action)
		{
			mAction = action != null ? string.Intern(action) : null;
			return this;
		}

		/// <summary>Set the data this intent is operating on.</summary>
		/// <remarks>
		/// Set the data this intent is operating on.  This method automatically
		/// clears any type that was previously set by
		/// <see cref="setType(string)">setType(string)</see>
		/// .
		/// <p><em>Note: scheme and host name matching in the Android framework is
		/// case-sensitive, unlike the formal RFC.  As a result,
		/// you should always ensure that you write your Uri with these elements
		/// using lower case letters, and normalize any Uris you receive from
		/// outside of Android to ensure the scheme and host is lower case.</em></p>
		/// </remarks>
		/// <param name="data">The URI of the data this intent is now targeting.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="getData()">getData()</seealso>
		/// <seealso cref="setType(string)">setType(string)</seealso>
		/// <seealso cref="setDataAndType(System.Uri, string)">setDataAndType(System.Uri, string)
		/// 	</seealso>
		public virtual android.content.Intent setData(System.Uri data)
		{
			mData = data;
			mType = null;
			return this;
		}

		/// <summary>Set an explicit MIME data type.</summary>
		/// <remarks>
		/// Set an explicit MIME data type.  This is used to create intents that
		/// only specify a type and not data, for example to indicate the type of
		/// data to return.  This method automatically clears any data that was
		/// previously set by
		/// <see cref="setData(System.Uri)">setData(System.Uri)</see>
		/// .
		/// <p><em>Note: MIME type matching in the Android framework is
		/// case-sensitive, unlike formal RFC MIME types.  As a result,
		/// you should always write your MIME types with lower case letters,
		/// and any MIME types you receive from outside of Android should be
		/// converted to lower case before supplying them here.</em></p>
		/// </remarks>
		/// <param name="type">The MIME type of the data being handled by this intent.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="getType()">getType()</seealso>
		/// <seealso cref="setData(System.Uri)">setData(System.Uri)</seealso>
		/// <seealso cref="setDataAndType(System.Uri, string)">setDataAndType(System.Uri, string)
		/// 	</seealso>
		public virtual android.content.Intent setType(string type)
		{
			mData = null;
			mType = type;
			return this;
		}

		/// <summary>
		/// (Usually optional) Set the data for the intent along with an explicit
		/// MIME data type.
		/// </summary>
		/// <remarks>
		/// (Usually optional) Set the data for the intent along with an explicit
		/// MIME data type.  This method should very rarely be used -- it allows you
		/// to override the MIME type that would ordinarily be inferred from the
		/// data with your own type given here.
		/// <p><em>Note: MIME type, Uri scheme, and host name matching in the
		/// Android framework is case-sensitive, unlike the formal RFC definitions.
		/// As a result, you should always write these elements with lower case letters,
		/// and normalize any MIME types or Uris you receive from
		/// outside of Android to ensure these elements are lower case before
		/// supplying them here.</em></p>
		/// </remarks>
		/// <param name="data">The URI of the data this intent is now targeting.</param>
		/// <param name="type">The MIME type of the data being handled by this intent.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="setData(System.Uri)">setData(System.Uri)</seealso>
		/// <seealso cref="setType(string)">setType(string)</seealso>
		public virtual android.content.Intent setDataAndType(System.Uri data, string type
			)
		{
			mData = data;
			mType = type;
			return this;
		}

		/// <summary>Add a new category to the intent.</summary>
		/// <remarks>
		/// Add a new category to the intent.  Categories provide additional detail
		/// about the action the intent is perform.  When resolving an intent, only
		/// activities that provide <em>all</em> of the requested categories will be
		/// used.
		/// </remarks>
		/// <param name="category">
		/// The desired category.  This can be either one of the
		/// predefined Intent categories, or a custom category in your own
		/// namespace.
		/// </param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="hasCategory(string)">hasCategory(string)</seealso>
		/// <seealso cref="removeCategory(string)">removeCategory(string)</seealso>
		public virtual android.content.Intent addCategory(string category)
		{
			if (mCategories == null)
			{
				mCategories = new java.util.HashSet<string>();
			}
			mCategories.add(string.Intern(category));
			return this;
		}

		[Sharpen.Stub]
		public virtual void removeCategory(string category)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The boolean data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getBooleanExtra(string, bool)">getBooleanExtra(string, bool)</seealso>
		public virtual android.content.Intent putExtra(string name, bool value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putBoolean(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The byte data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getByteExtra(string, byte)">getByteExtra(string, byte)</seealso>
		public virtual android.content.Intent putExtra(string name, byte value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putByte(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The char data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getCharExtra(string, char)">getCharExtra(string, char)</seealso>
		public virtual android.content.Intent putExtra(string name, char value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putChar(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The short data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getShortExtra(string, short)">getShortExtra(string, short)</seealso>
		public virtual android.content.Intent putExtra(string name, short value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putShort(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The integer data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getIntExtra(string, int)">getIntExtra(string, int)</seealso>
		public virtual android.content.Intent putExtra(string name, int value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putInt(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The long data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getLongExtra(string, long)">getLongExtra(string, long)</seealso>
		public virtual android.content.Intent putExtra(string name, long value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putLong(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The float data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getFloatExtra(string, float)">getFloatExtra(string, float)</seealso>
		public virtual android.content.Intent putExtra(string name, float value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putFloat(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The double data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getDoubleExtra(string, double)">getDoubleExtra(string, double)</seealso>
		public virtual android.content.Intent putExtra(string name, double value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putDouble(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The String data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getStringExtra(string)">getStringExtra(string)</seealso>
		public virtual android.content.Intent putExtra(string name, string value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putString(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The CharSequence data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getCharSequenceExtra(string)">getCharSequenceExtra(string)</seealso>
		public virtual android.content.Intent putExtra(string name, java.lang.CharSequence
			 value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putCharSequence(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The Parcelable data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getParcelableExtra{T}(string)">getParcelableExtra&lt;T&gt;(string)
		/// 	</seealso>
		public virtual android.content.Intent putExtra(string name, android.os.Parcelable
			 value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putParcelable(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The Parcelable[] data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getParcelableArrayExtra(string)">getParcelableArrayExtra(string)</seealso>
		public virtual android.content.Intent putExtra(string name, android.os.Parcelable
			[] value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putParcelableArray(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The ArrayList<Parcelable> data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getParcelableArrayListExtra{T}(string)">getParcelableArrayListExtra&lt;T&gt;(string)
		/// 	</seealso>
		public virtual android.content.Intent putParcelableArrayListExtra<_T0>(string name
			, java.util.ArrayList<_T0> value) where _T0:android.os.Parcelable
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putParcelableArrayList(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The ArrayList<Integer> data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getIntegerArrayListExtra(string)">getIntegerArrayListExtra(string)
		/// 	</seealso>
		public virtual android.content.Intent putIntegerArrayListExtra(string name, java.util.ArrayList
			<int> value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putIntegerArrayList(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The ArrayList<String> data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getStringArrayListExtra(string)">getStringArrayListExtra(string)</seealso>
		public virtual android.content.Intent putStringArrayListExtra(string name, java.util.ArrayList
			<string> value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putStringArrayList(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The ArrayList<CharSequence> data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getCharSequenceArrayListExtra(string)">getCharSequenceArrayListExtra(string)
		/// 	</seealso>
		public virtual android.content.Intent putCharSequenceArrayListExtra(string name, 
			java.util.ArrayList<java.lang.CharSequence> value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putCharSequenceArrayList(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The Serializable data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getSerializableExtra(string)">getSerializableExtra(string)</seealso>
		public virtual android.content.Intent putExtra(string name, java.io.Serializable 
			value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putSerializable(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The boolean array data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getBooleanArrayExtra(string)">getBooleanArrayExtra(string)</seealso>
		public virtual android.content.Intent putExtra(string name, bool[] value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putBooleanArray(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The byte array data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getByteArrayExtra(string)">getByteArrayExtra(string)</seealso>
		public virtual android.content.Intent putExtra(string name, byte[] value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putByteArray(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The short array data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getShortArrayExtra(string)">getShortArrayExtra(string)</seealso>
		public virtual android.content.Intent putExtra(string name, short[] value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putShortArray(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The char array data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getCharArrayExtra(string)">getCharArrayExtra(string)</seealso>
		public virtual android.content.Intent putExtra(string name, char[] value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putCharArray(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The int array data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getIntArrayExtra(string)">getIntArrayExtra(string)</seealso>
		public virtual android.content.Intent putExtra(string name, int[] value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putIntArray(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The byte array data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getLongArrayExtra(string)">getLongArrayExtra(string)</seealso>
		public virtual android.content.Intent putExtra(string name, long[] value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putLongArray(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The float array data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getFloatArrayExtra(string)">getFloatArrayExtra(string)</seealso>
		public virtual android.content.Intent putExtra(string name, float[] value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putFloatArray(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The double array data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getDoubleArrayExtra(string)">getDoubleArrayExtra(string)</seealso>
		public virtual android.content.Intent putExtra(string name, double[] value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putDoubleArray(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The String array data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getStringArrayExtra(string)">getStringArrayExtra(string)</seealso>
		public virtual android.content.Intent putExtra(string name, string[] value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putStringArray(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The CharSequence array data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getCharSequenceArrayExtra(string)">getCharSequenceArrayExtra(string)
		/// 	</seealso>
		public virtual android.content.Intent putExtra(string name, java.lang.CharSequence
			[] value)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putCharSequenceArray(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The Bundle data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getBundleExtra(string)">getBundleExtra(string)</seealso>
		public virtual android.content.Intent putExtra(string name, android.os.Bundle value
			)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putBundle(name, value);
			return this;
		}

		/// <summary>Add extended data to the intent.</summary>
		/// <remarks>
		/// Add extended data to the intent.  The name must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="name">The name of the extra data, with package prefix.</param>
		/// <param name="value">The IBinder data value.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="putExtras(Intent)">putExtras(Intent)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		/// <seealso cref="getIBinderExtra(string)">getIBinderExtra(string)</seealso>
		/// <hide></hide>
		[System.ObsoleteAttribute]
		public virtual android.content.Intent putExtra(string name, android.os.IBinder value
			)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putIBinder(name, value);
			return this;
		}

		/// <summary>Copy all extras in 'src' in to this intent.</summary>
		/// <remarks>Copy all extras in 'src' in to this intent.</remarks>
		/// <param name="src">Contains the extras to copy.</param>
		/// <seealso cref="putExtra(string, bool)">putExtra(string, bool)</seealso>
		public virtual android.content.Intent putExtras(android.content.Intent src)
		{
			if (src.mExtras != null)
			{
				if (mExtras == null)
				{
					mExtras = new android.os.Bundle(src.mExtras);
				}
				else
				{
					mExtras.putAll(src.mExtras);
				}
			}
			return this;
		}

		/// <summary>Add a set of extended data to the intent.</summary>
		/// <remarks>
		/// Add a set of extended data to the intent.  The keys must include a package
		/// prefix, for example the app com.android.contacts would use names
		/// like "com.android.contacts.ShowAll".
		/// </remarks>
		/// <param name="extras">The Bundle of extras to add to this intent.</param>
		/// <seealso cref="putExtra(string, bool)">putExtra(string, bool)</seealso>
		/// <seealso cref="removeExtra(string)">removeExtra(string)</seealso>
		public virtual android.content.Intent putExtras(android.os.Bundle extras)
		{
			if (mExtras == null)
			{
				mExtras = new android.os.Bundle();
			}
			mExtras.putAll(extras);
			return this;
		}

		/// <summary>
		/// Completely replace the extras in the Intent with the extras in the
		/// given Intent.
		/// </summary>
		/// <remarks>
		/// Completely replace the extras in the Intent with the extras in the
		/// given Intent.
		/// </remarks>
		/// <param name="src">
		/// The exact extras contained in this Intent are copied
		/// into the target intent, replacing any that were previously there.
		/// </param>
		public virtual android.content.Intent replaceExtras(android.content.Intent src)
		{
			mExtras = src.mExtras != null ? new android.os.Bundle(src.mExtras) : null;
			return this;
		}

		/// <summary>
		/// Completely replace the extras in the Intent with the given Bundle of
		/// extras.
		/// </summary>
		/// <remarks>
		/// Completely replace the extras in the Intent with the given Bundle of
		/// extras.
		/// </remarks>
		/// <param name="extras">
		/// The new set of extras in the Intent, or null to erase
		/// all extras.
		/// </param>
		public virtual android.content.Intent replaceExtras(android.os.Bundle extras)
		{
			mExtras = extras != null ? new android.os.Bundle(extras) : null;
			return this;
		}

		/// <summary>Remove extended data from the intent.</summary>
		/// <remarks>Remove extended data from the intent.</remarks>
		/// <seealso cref="putExtra(string, bool)">putExtra(string, bool)</seealso>
		public virtual void removeExtra(string name)
		{
			if (mExtras != null)
			{
				mExtras.remove(name);
				if (mExtras.size() == 0)
				{
					mExtras = null;
				}
			}
		}

		/// <summary>Set special flags controlling how this intent is handled.</summary>
		/// <remarks>
		/// Set special flags controlling how this intent is handled.  Most values
		/// here depend on the type of component being executed by the Intent,
		/// specifically the FLAG_ACTIVITY_* flags are all for use with
		/// <see cref="Context.startActivity(Intent)">Context.startActivity()</see>
		/// and the
		/// FLAG_RECEIVER_* flags are all for use with
		/// <see cref="Context.sendBroadcast(Intent)">Context.sendBroadcast()</see>
		/// .
		/// <p>See the
		/// &lt;a href="
		/// <docRoot></docRoot>
		/// guide/topics/fundamentals/tasks-and-back-stack.html"&gt;Tasks and Back
		/// Stack</a> documentation for important information on how some of these options impact
		/// the behavior of your application.
		/// </remarks>
		/// <param name="flags">The desired flags.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="getFlags()">getFlags()</seealso>
		/// <seealso cref="addFlags(int)">addFlags(int)</seealso>
		/// <seealso cref="FLAG_GRANT_READ_URI_PERMISSION">FLAG_GRANT_READ_URI_PERMISSION</seealso>
		/// <seealso cref="FLAG_GRANT_WRITE_URI_PERMISSION">FLAG_GRANT_WRITE_URI_PERMISSION</seealso>
		/// <seealso cref="FLAG_DEBUG_LOG_RESOLUTION">FLAG_DEBUG_LOG_RESOLUTION</seealso>
		/// <seealso cref="FLAG_FROM_BACKGROUND">FLAG_FROM_BACKGROUND</seealso>
		/// <seealso cref="FLAG_ACTIVITY_BROUGHT_TO_FRONT">FLAG_ACTIVITY_BROUGHT_TO_FRONT</seealso>
		/// <seealso cref="FLAG_ACTIVITY_CLEAR_TASK">FLAG_ACTIVITY_CLEAR_TASK</seealso>
		/// <seealso cref="FLAG_ACTIVITY_CLEAR_TOP">FLAG_ACTIVITY_CLEAR_TOP</seealso>
		/// <seealso cref="FLAG_ACTIVITY_CLEAR_WHEN_TASK_RESET">FLAG_ACTIVITY_CLEAR_WHEN_TASK_RESET
		/// 	</seealso>
		/// <seealso cref="FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS">FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS
		/// 	</seealso>
		/// <seealso cref="FLAG_ACTIVITY_FORWARD_RESULT">FLAG_ACTIVITY_FORWARD_RESULT</seealso>
		/// <seealso cref="FLAG_ACTIVITY_LAUNCHED_FROM_HISTORY">FLAG_ACTIVITY_LAUNCHED_FROM_HISTORY
		/// 	</seealso>
		/// <seealso cref="FLAG_ACTIVITY_MULTIPLE_TASK">FLAG_ACTIVITY_MULTIPLE_TASK</seealso>
		/// <seealso cref="FLAG_ACTIVITY_NEW_TASK">FLAG_ACTIVITY_NEW_TASK</seealso>
		/// <seealso cref="FLAG_ACTIVITY_NO_ANIMATION">FLAG_ACTIVITY_NO_ANIMATION</seealso>
		/// <seealso cref="FLAG_ACTIVITY_NO_HISTORY">FLAG_ACTIVITY_NO_HISTORY</seealso>
		/// <seealso cref="FLAG_ACTIVITY_NO_USER_ACTION">FLAG_ACTIVITY_NO_USER_ACTION</seealso>
		/// <seealso cref="FLAG_ACTIVITY_PREVIOUS_IS_TOP">FLAG_ACTIVITY_PREVIOUS_IS_TOP</seealso>
		/// <seealso cref="FLAG_ACTIVITY_RESET_TASK_IF_NEEDED">FLAG_ACTIVITY_RESET_TASK_IF_NEEDED
		/// 	</seealso>
		/// <seealso cref="FLAG_ACTIVITY_REORDER_TO_FRONT">FLAG_ACTIVITY_REORDER_TO_FRONT</seealso>
		/// <seealso cref="FLAG_ACTIVITY_SINGLE_TOP">FLAG_ACTIVITY_SINGLE_TOP</seealso>
		/// <seealso cref="FLAG_ACTIVITY_TASK_ON_HOME">FLAG_ACTIVITY_TASK_ON_HOME</seealso>
		/// <seealso cref="FLAG_RECEIVER_REGISTERED_ONLY">FLAG_RECEIVER_REGISTERED_ONLY</seealso>
		public virtual android.content.Intent setFlags(int flags)
		{
			mFlags = flags;
			return this;
		}

		/// <summary>
		/// Add additional flags to the intent (or with existing flags
		/// value).
		/// </summary>
		/// <remarks>
		/// Add additional flags to the intent (or with existing flags
		/// value).
		/// </remarks>
		/// <param name="flags">The new flags to set.</param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="setFlags(int)">setFlags(int)</seealso>
		public virtual android.content.Intent addFlags(int flags)
		{
			mFlags |= flags;
			return this;
		}

		/// <summary>
		/// (Usually optional) Set an explicit application package name that limits
		/// the components this Intent will resolve to.
		/// </summary>
		/// <remarks>
		/// (Usually optional) Set an explicit application package name that limits
		/// the components this Intent will resolve to.  If left to the default
		/// value of null, all components in all applications will considered.
		/// If non-null, the Intent can only match the components in the given
		/// application package.
		/// </remarks>
		/// <param name="packageName">
		/// The name of the application package to handle the
		/// intent, or null to allow any application package.
		/// </param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="getPackage()">getPackage()</seealso>
		/// <seealso cref="resolveActivity(android.content.pm.PackageManager)">resolveActivity(android.content.pm.PackageManager)
		/// 	</seealso>
		public virtual android.content.Intent setPackage(string packageName)
		{
			mPackage = packageName;
			return this;
		}

		/// <summary>(Usually optional) Explicitly set the component to handle the intent.</summary>
		/// <remarks>
		/// (Usually optional) Explicitly set the component to handle the intent.
		/// If left with the default value of null, the system will determine the
		/// appropriate class to use based on the other fields (action, data,
		/// type, categories) in the Intent.  If this class is defined, the
		/// specified class will always be used regardless of the other fields.  You
		/// should only set this value when you know you absolutely want a specific
		/// class to be used; otherwise it is better to let the system find the
		/// appropriate class so that you will respect the installed applications
		/// and user preferences.
		/// </remarks>
		/// <param name="component">
		/// The name of the application component to handle the
		/// intent, or null to let the system find one for you.
		/// </param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="setClass(Context, System.Type{T})">setClass(Context, System.Type&lt;T&gt;)
		/// 	</seealso>
		/// <seealso cref="setClassName(Context, string)">setClassName(Context, string)</seealso>
		/// <seealso cref="setClassName(string, string)">setClassName(string, string)</seealso>
		/// <seealso cref="getComponent()">getComponent()</seealso>
		/// <seealso cref="resolveActivity(android.content.pm.PackageManager)">resolveActivity(android.content.pm.PackageManager)
		/// 	</seealso>
		public virtual android.content.Intent setComponent(android.content.ComponentName 
			component)
		{
			mComponent = component;
			return this;
		}

		/// <summary>
		/// Convenience for calling
		/// <see cref="setComponent(ComponentName)">setComponent(ComponentName)</see>
		/// with an
		/// explicit class name.
		/// </summary>
		/// <param name="packageContext">
		/// A Context of the application package implementing
		/// this class.
		/// </param>
		/// <param name="className">
		/// The name of a class inside of the application package
		/// that will be used as the component for this Intent.
		/// </param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="setComponent(ComponentName)">setComponent(ComponentName)</seealso>
		/// <seealso cref="setClass(Context, System.Type{T})">setClass(Context, System.Type&lt;T&gt;)
		/// 	</seealso>
		public virtual android.content.Intent setClassName(android.content.Context packageContext
			, string className)
		{
			mComponent = new android.content.ComponentName(packageContext, className);
			return this;
		}

		/// <summary>
		/// Convenience for calling
		/// <see cref="setComponent(ComponentName)">setComponent(ComponentName)</see>
		/// with an
		/// explicit application package name and class name.
		/// </summary>
		/// <param name="packageName">
		/// The name of the package implementing the desired
		/// component.
		/// </param>
		/// <param name="className">
		/// The name of a class inside of the application package
		/// that will be used as the component for this Intent.
		/// </param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="setComponent(ComponentName)">setComponent(ComponentName)</seealso>
		/// <seealso cref="setClass(Context, System.Type{T})">setClass(Context, System.Type&lt;T&gt;)
		/// 	</seealso>
		public virtual android.content.Intent setClassName(string packageName, string className
			)
		{
			mComponent = new android.content.ComponentName(packageName, className);
			return this;
		}

		/// <summary>
		/// Convenience for calling
		/// <see cref="setComponent(ComponentName)">setComponent(ComponentName)</see>
		/// with the
		/// name returned by a
		/// <see cref="System.Type{T}">System.Type&lt;T&gt;</see>
		/// object.
		/// </summary>
		/// <param name="packageContext">
		/// A Context of the application package implementing
		/// this class.
		/// </param>
		/// <param name="cls">
		/// The class name to set, equivalent to
		/// <code>setClassName(context, cls.getName())</code>.
		/// </param>
		/// <returns>
		/// Returns the same Intent object, for chaining multiple calls
		/// into a single statement.
		/// </returns>
		/// <seealso cref="setComponent(ComponentName)">setComponent(ComponentName)</seealso>
		public virtual android.content.Intent setClass<_T0>(android.content.Context packageContext
			)
		{
			System.Type cls = typeof(_T0);
			mComponent = new android.content.ComponentName(packageContext, cls);
			return this;
		}

		/// <summary>Set the bounds of the sender of this intent, in screen coordinates.</summary>
		/// <remarks>
		/// Set the bounds of the sender of this intent, in screen coordinates.  This can be
		/// used as a hint to the receiver for animations and the like.  Null means that there
		/// is no source bounds.
		/// </remarks>
		public virtual void setSourceBounds(android.graphics.Rect r)
		{
			if (r != null)
			{
				mSourceBounds = new android.graphics.Rect(r);
			}
			else
			{
				mSourceBounds = null;
			}
		}

		/// <summary>
		/// Use with
		/// <see cref="fillIn(Intent, int)">fillIn(Intent, int)</see>
		/// to allow the current action value to be
		/// overwritten, even if it is already set.
		/// </summary>
		public const int FILL_IN_ACTION = 1 << 0;

		/// <summary>
		/// Use with
		/// <see cref="fillIn(Intent, int)">fillIn(Intent, int)</see>
		/// to allow the current data or type value
		/// overwritten, even if it is already set.
		/// </summary>
		public const int FILL_IN_DATA = 1 << 1;

		/// <summary>
		/// Use with
		/// <see cref="fillIn(Intent, int)">fillIn(Intent, int)</see>
		/// to allow the current categories to be
		/// overwritten, even if they are already set.
		/// </summary>
		public const int FILL_IN_CATEGORIES = 1 << 2;

		/// <summary>
		/// Use with
		/// <see cref="fillIn(Intent, int)">fillIn(Intent, int)</see>
		/// to allow the current component value to be
		/// overwritten, even if it is already set.
		/// </summary>
		public const int FILL_IN_COMPONENT = 1 << 3;

		/// <summary>
		/// Use with
		/// <see cref="fillIn(Intent, int)">fillIn(Intent, int)</see>
		/// to allow the current package value to be
		/// overwritten, even if it is already set.
		/// </summary>
		public const int FILL_IN_PACKAGE = 1 << 4;

		/// <summary>
		/// Use with
		/// <see cref="fillIn(Intent, int)">fillIn(Intent, int)</see>
		/// to allow the current package value to be
		/// overwritten, even if it is already set.
		/// </summary>
		public const int FILL_IN_SOURCE_BOUNDS = 1 << 5;

		/// <summary>
		/// Copy the contents of <var>other</var> in to this object, but only
		/// where fields are not defined by this object.
		/// </summary>
		/// <remarks>
		/// Copy the contents of <var>other</var> in to this object, but only
		/// where fields are not defined by this object.  For purposes of a field
		/// being defined, the following pieces of data in the Intent are
		/// considered to be separate fields:
		/// <ul>
		/// <li> action, as set by
		/// <see cref="setAction(string)">setAction(string)</see>
		/// .
		/// <li> data URI and MIME type, as set by
		/// <see cref="setData(System.Uri)">setData(System.Uri)</see>
		/// ,
		/// <see cref="setType(string)">setType(string)</see>
		/// , or
		/// <see cref="setDataAndType(System.Uri, string)">setDataAndType(System.Uri, string)
		/// 	</see>
		/// .
		/// <li> categories, as set by
		/// <see cref="addCategory(string)">addCategory(string)</see>
		/// .
		/// <li> package, as set by
		/// <see cref="setPackage(string)">setPackage(string)</see>
		/// .
		/// <li> component, as set by
		/// <see cref="setComponent(ComponentName)">setComponent(ComponentName)</see>
		/// or
		/// related methods.
		/// <li> source bounds, as set by
		/// <see cref="setSourceBounds(android.graphics.Rect)">setSourceBounds(android.graphics.Rect)
		/// 	</see>
		/// <li> each top-level name in the associated extras.
		/// </ul>
		/// <p>In addition, you can use the
		/// <see cref="FILL_IN_ACTION">FILL_IN_ACTION</see>
		/// ,
		/// <see cref="FILL_IN_DATA">FILL_IN_DATA</see>
		/// ,
		/// <see cref="FILL_IN_CATEGORIES">FILL_IN_CATEGORIES</see>
		/// ,
		/// <see cref="FILL_IN_PACKAGE">FILL_IN_PACKAGE</see>
		/// ,
		/// and
		/// <see cref="FILL_IN_COMPONENT">FILL_IN_COMPONENT</see>
		/// to override the restriction where the
		/// corresponding field will not be replaced if it is already set.
		/// <p>Note: The component field will only be copied if
		/// <see cref="FILL_IN_COMPONENT">FILL_IN_COMPONENT</see>
		/// is explicitly
		/// specified.
		/// <p>For example, consider Intent A with {data="foo", categories="bar"}
		/// and Intent B with {action="gotit", data-type="some/thing",
		/// categories="one","two"}.
		/// <p>Calling A.fillIn(B, Intent.FILL_IN_DATA) will result in A now
		/// containing: {action="gotit", data-type="some/thing",
		/// categories="bar"}.
		/// </remarks>
		/// <param name="other">
		/// Another Intent whose values are to be used to fill in
		/// the current one.
		/// </param>
		/// <param name="flags">Options to control which fields can be filled in.</param>
		/// <returns>
		/// Returns a bit mask of
		/// <see cref="FILL_IN_ACTION">FILL_IN_ACTION</see>
		/// ,
		/// <see cref="FILL_IN_DATA">FILL_IN_DATA</see>
		/// ,
		/// <see cref="FILL_IN_CATEGORIES">FILL_IN_CATEGORIES</see>
		/// ,
		/// <see cref="FILL_IN_PACKAGE">FILL_IN_PACKAGE</see>
		/// ,
		/// and
		/// <see cref="FILL_IN_COMPONENT">FILL_IN_COMPONENT</see>
		/// indicating which fields were changed.
		/// </returns>
		public virtual int fillIn(android.content.Intent other, int flags)
		{
			int changes = 0;
			if (other.mAction != null && (mAction == null || (flags & FILL_IN_ACTION) != 0))
			{
				mAction = other.mAction;
				changes |= FILL_IN_ACTION;
			}
			if ((other.mData != null || other.mType != null) && ((mData == null && mType == null
				) || (flags & FILL_IN_DATA) != 0))
			{
				mData = other.mData;
				mType = other.mType;
				changes |= FILL_IN_DATA;
			}
			if (other.mCategories != null && (mCategories == null || (flags & FILL_IN_CATEGORIES
				) != 0))
			{
				if (other.mCategories != null)
				{
					mCategories = new java.util.HashSet<string>(other.mCategories);
				}
				changes |= FILL_IN_CATEGORIES;
			}
			if (other.mPackage != null && (mPackage == null || (flags & FILL_IN_PACKAGE) != 0
				))
			{
				mPackage = other.mPackage;
				changes |= FILL_IN_PACKAGE;
			}
			// Component is special: it can -only- be set if explicitly allowed,
			// since otherwise the sender could force the intent somewhere the
			// originator didn't intend.
			if (other.mComponent != null && (flags & FILL_IN_COMPONENT) != 0)
			{
				mComponent = other.mComponent;
				changes |= FILL_IN_COMPONENT;
			}
			mFlags |= other.mFlags;
			if (other.mSourceBounds != null && (mSourceBounds == null || (flags & FILL_IN_SOURCE_BOUNDS
				) != 0))
			{
				mSourceBounds = new android.graphics.Rect(other.mSourceBounds);
				changes |= FILL_IN_SOURCE_BOUNDS;
			}
			if (mExtras == null)
			{
				if (other.mExtras != null)
				{
					mExtras = new android.os.Bundle(other.mExtras);
				}
			}
			else
			{
				if (other.mExtras != null)
				{
					try
					{
						android.os.Bundle newb = new android.os.Bundle(other.mExtras);
						newb.putAll(mExtras);
						mExtras = newb;
					}
					catch (java.lang.RuntimeException e)
					{
						// Modifying the extras can cause us to unparcel the contents
						// of the bundle, and if we do this in the system process that
						// may fail.  We really should handle this (i.e., the Bundle
						// impl shouldn't be on top of a plain map), but for now just
						// ignore it and keep the original contents. :(
						android.util.Log.w("Intent", "Failure filling in extras", e);
					}
				}
			}
			return changes;
		}

		/// <summary>
		/// Wrapper class holding an Intent and implementing comparisons on it for
		/// the purpose of filtering.
		/// </summary>
		/// <remarks>
		/// Wrapper class holding an Intent and implementing comparisons on it for
		/// the purpose of filtering.  The class implements its
		/// <see cref="Equals(object)">equals()</see>
		/// and
		/// <see cref="GetHashCode()">hashCode()</see>
		/// methods as
		/// simple calls to
		/// <see cref="Intent.filterEquals(Intent)">Intent.filterEquals(Intent)</see>
		/// filterEquals()} and
		/// <see cref="Intent.filterHashCode()">Intent.filterHashCode()</see>
		/// filterHashCode()}
		/// on the wrapped Intent.
		/// </remarks>
		public sealed class FilterComparison
		{
			private readonly android.content.Intent mIntent;

			private readonly int mHashCode;

			public FilterComparison(android.content.Intent intent)
			{
				mIntent = intent;
				mHashCode = intent.filterHashCode();
			}

			/// <summary>Return the Intent that this FilterComparison represents.</summary>
			/// <remarks>Return the Intent that this FilterComparison represents.</remarks>
			/// <returns>
			/// Returns the Intent held by the FilterComparison.  Do
			/// not modify!
			/// </returns>
			public android.content.Intent getIntent()
			{
				return mIntent;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object obj)
			{
				if (obj is android.content.Intent.FilterComparison)
				{
					android.content.Intent other = ((android.content.Intent.FilterComparison)obj).mIntent;
					return mIntent.filterEquals(other);
				}
				return false;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				return mHashCode;
			}
		}

		/// <summary>
		/// Determine if two intents are the same for the purposes of intent
		/// resolution (filtering).
		/// </summary>
		/// <remarks>
		/// Determine if two intents are the same for the purposes of intent
		/// resolution (filtering). That is, if their action, data, type,
		/// class, and categories are the same.  This does <em>not</em> compare
		/// any extra data included in the intents.
		/// </remarks>
		/// <param name="other">The other Intent to compare against.</param>
		/// <returns>
		/// Returns true if action, data, type, class, and categories
		/// are the same.
		/// </returns>
		public virtual bool filterEquals(android.content.Intent other)
		{
			if (other == null)
			{
				return false;
			}
			if (mAction != other.mAction)
			{
				if (mAction != null)
				{
					if (!mAction.Equals(other.mAction))
					{
						return false;
					}
				}
				else
				{
					if (!other.mAction.Equals(mAction))
					{
						return false;
					}
				}
			}
			if (mData != other.mData)
			{
				if (mData != null)
				{
					if (!mData.Equals(other.mData))
					{
						return false;
					}
				}
				else
				{
					if (!other.mData.Equals(mData))
					{
						return false;
					}
				}
			}
			if (mType != other.mType)
			{
				if (mType != null)
				{
					if (!mType.Equals(other.mType))
					{
						return false;
					}
				}
				else
				{
					if (!other.mType.Equals(mType))
					{
						return false;
					}
				}
			}
			if (mPackage != other.mPackage)
			{
				if (mPackage != null)
				{
					if (!mPackage.Equals(other.mPackage))
					{
						return false;
					}
				}
				else
				{
					if (!other.mPackage.Equals(mPackage))
					{
						return false;
					}
				}
			}
			if (mComponent != other.mComponent)
			{
				if (mComponent != null)
				{
					if (!mComponent.Equals(other.mComponent))
					{
						return false;
					}
				}
				else
				{
					if (!other.mComponent.Equals(mComponent))
					{
						return false;
					}
				}
			}
			if (mCategories != other.mCategories)
			{
				if (mCategories != null)
				{
					if (!mCategories.Equals(other.mCategories))
					{
						return false;
					}
				}
				else
				{
					if (!other.mCategories.Equals(mCategories))
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>Generate hash code that matches semantics of filterEquals().</summary>
		/// <remarks>Generate hash code that matches semantics of filterEquals().</remarks>
		/// <returns>
		/// Returns the hash value of the action, data, type, class, and
		/// categories.
		/// </returns>
		/// <seealso cref="filterEquals(Intent)">filterEquals(Intent)</seealso>
		public virtual int filterHashCode()
		{
			int code = 0;
			if (mAction != null)
			{
				code += mAction.GetHashCode();
			}
			if (mData != null)
			{
				code += mData.GetHashCode();
			}
			if (mType != null)
			{
				code += mType.GetHashCode();
			}
			if (mPackage != null)
			{
				code += mPackage.GetHashCode();
			}
			if (mComponent != null)
			{
				code += mComponent.GetHashCode();
			}
			if (mCategories != null)
			{
				code += mCategories.GetHashCode();
			}
			return code;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			java.lang.StringBuilder b = new java.lang.StringBuilder(128);
			b.append("Intent { ");
			toShortString(b, true, true, true);
			b.append(" }");
			return b.ToString();
		}

		/// <hide></hide>
		public virtual string toInsecureString()
		{
			java.lang.StringBuilder b = new java.lang.StringBuilder(128);
			b.append("Intent { ");
			toShortString(b, false, true, true);
			b.append(" }");
			return b.ToString();
		}

		/// <hide></hide>
		public virtual string toShortString(bool secure, bool comp, bool extras)
		{
			java.lang.StringBuilder b = new java.lang.StringBuilder(128);
			toShortString(b, secure, comp, extras);
			return b.ToString();
		}

		/// <hide></hide>
		public virtual void toShortString(java.lang.StringBuilder b, bool secure, bool comp
			, bool extras)
		{
			bool first = true;
			if (mAction != null)
			{
				b.append("act=").append(mAction);
				first = false;
			}
			if (mCategories != null)
			{
				if (!first)
				{
					b.append(' ');
				}
				first = false;
				b.append("cat=[");
				java.util.Iterator<string> i = mCategories.iterator();
				bool didone = false;
				while (i.hasNext())
				{
					if (didone)
					{
						b.append(",");
					}
					didone = true;
					b.append(i.next());
				}
				b.append("]");
			}
			if (mData != null)
			{
				if (!first)
				{
					b.append(' ');
				}
				first = false;
				b.append("dat=");
				if (secure)
				{
					b.append(Sharpen.Util.ToSafeString(mData));
				}
				else
				{
					b.append(mData);
				}
			}
			if (mType != null)
			{
				if (!first)
				{
					b.append(' ');
				}
				first = false;
				b.append("typ=").append(mType);
			}
			if (mFlags != 0)
			{
				if (!first)
				{
					b.append(' ');
				}
				first = false;
				b.append("flg=0x").append(Sharpen.Util.IntToHexString(mFlags));
			}
			if (mPackage != null)
			{
				if (!first)
				{
					b.append(' ');
				}
				first = false;
				b.append("pkg=").append(mPackage);
			}
			if (comp && mComponent != null)
			{
				if (!first)
				{
					b.append(' ');
				}
				first = false;
				b.append("cmp=").append(mComponent.flattenToShortString());
			}
			if (mSourceBounds != null)
			{
				if (!first)
				{
					b.append(' ');
				}
				first = false;
				b.append("bnds=").append(mSourceBounds.toShortString());
			}
			if (extras && mExtras != null)
			{
				if (!first)
				{
					b.append(' ');
				}
				first = false;
				b.append("(has extras)");
			}
		}

		/// <summary>
		/// Call
		/// <see cref="toUri(int)">toUri(int)</see>
		/// with 0 flags.
		/// </summary>
		[System.ObsoleteAttribute(@"Use toUri(int) instead.")]
		public virtual string toURI()
		{
			return toUri(0);
		}

		[Sharpen.Stub]
		public virtual string toUri(int flags)
		{
			throw new System.NotImplementedException();
		}

		// Valid scheme.
		// No scheme.
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return (mExtras != null) ? mExtras.describeContents() : 0;
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel @out, int flags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_5850 : android.os.ParcelableClass.Creator<android.content.Intent
			>
		{
			public _Creator_5850()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.Intent createFromParcel(android.os.Parcel @in)
			{
				return new android.content.Intent(@in);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.Intent[] newArray(int size)
			{
				return new android.content.Intent[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.Intent>
			 CREATOR = new _Creator_5850();

		/// <hide></hide>
		protected internal Intent(android.os.Parcel @in)
		{
			readFromParcel(@in);
		}

		[Sharpen.Stub]
		public virtual void readFromParcel(android.os.Parcel @in)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Parses the "intent" element (and its children) from XML and instantiates
		/// an Intent object.
		/// </summary>
		/// <remarks>
		/// Parses the "intent" element (and its children) from XML and instantiates
		/// an Intent object.  The given XML parser should be located at the tag
		/// where parsing should start (often named "intent"), from which the
		/// basic action, data, type, and package and class name will be
		/// retrieved.  The function will then parse in to any child elements,
		/// looking for <category android:name="xxx"> tags to add categories and
		/// <extra android:name="xxx" android:value="yyy"> to attach extra data
		/// to the intent.
		/// </remarks>
		/// <param name="resources">The Resources to use when inflating resources.</param>
		/// <param name="parser">The XML parser pointing at an "intent" tag.</param>
		/// <param name="attrs">
		/// The AttributeSet interface for retrieving extended
		/// attribute data at the current <var>parser</var> location.
		/// </param>
		/// <returns>An Intent object matching the XML data.</returns>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException">If there was an XML parsing error.
		/// 	</exception>
		/// <exception cref="System.IO.IOException">If there was an I/O error.</exception>
		public static android.content.Intent parseIntent(android.content.res.Resources resources
			, org.xmlpull.v1.XmlPullParser parser, android.util.AttributeSet attrs)
		{
			android.content.Intent intent = new android.content.Intent();
			android.content.res.TypedArray sa = resources.obtainAttributes(attrs, android.@internal.R
				.styleable.Intent);
			intent.setAction(sa.getString(android.@internal.R.styleable.Intent_action));
			string data = sa.getString(android.@internal.R.styleable.Intent_data);
			string mimeType = sa.getString(android.@internal.R.styleable.Intent_mimeType);
			intent.setDataAndType(data != null ? Sharpen.Util.ParseUri(data) : null, mimeType
				);
			string packageName = sa.getString(android.@internal.R.styleable.Intent_targetPackage
				);
			string className = sa.getString(android.@internal.R.styleable.Intent_targetClass);
			if (packageName != null && className != null)
			{
				intent.setComponent(new android.content.ComponentName(packageName, className));
			}
			sa.recycle();
			int outerDepth = parser.getDepth();
			int type;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 (type != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser.getDepth() > outerDepth
				))
			{
				if (type == org.xmlpull.v1.XmlPullParserClass.END_TAG || type == org.xmlpull.v1.XmlPullParserClass.TEXT)
				{
					continue;
				}
				string nodeName = parser.getName();
				if (nodeName.Equals("category"))
				{
					sa = resources.obtainAttributes(attrs, android.@internal.R.styleable.IntentCategory
						);
					string cat = sa.getString(android.@internal.R.styleable.IntentCategory_name);
					sa.recycle();
					if (cat != null)
					{
						intent.addCategory(cat);
					}
					android.util.@internal.XmlUtils.skipCurrentTag(parser);
				}
				else
				{
					if (nodeName.Equals("extra"))
					{
						if (intent.mExtras == null)
						{
							intent.mExtras = new android.os.Bundle();
						}
						resources.parseBundleExtra("extra", attrs, intent.mExtras);
						android.util.@internal.XmlUtils.skipCurrentTag(parser);
					}
					else
					{
						android.util.@internal.XmlUtils.skipCurrentTag(parser);
					}
				}
			}
			return intent;
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
