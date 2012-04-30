using Sharpen;

namespace java.util
{
	/// <summary>A collection designed for holding elements prior to processing.</summary>
	/// <remarks>
	/// A collection designed for holding elements prior to processing.
	/// Besides basic
	/// <see cref="Collection{E}">Collection{E}</see>
	/// operations,
	/// queues provide additional insertion, extraction, and inspection
	/// operations.  Each of these methods exists in two forms: one throws
	/// an exception if the operation fails, the other returns a special
	/// value (either <tt>null</tt> or <tt>false</tt>, depending on the
	/// operation).  The latter form of the insert operation is designed
	/// specifically for use with capacity-restricted <tt>Queue</tt>
	/// implementations; in most implementations, insert operations cannot
	/// fail.
	/// <p>
	/// <table BORDER CELLPADDING=3 CELLSPACING=1>
	/// <tr>
	/// <td></td>
	/// <td ALIGN=CENTER><em>Throws exception</em></td>
	/// <td ALIGN=CENTER><em>Returns special value</em></td>
	/// </tr>
	/// <tr>
	/// <td><b>Insert</b></td>
	/// <td>
	/// <see cref="Queue{E}.add(object)">add(e)</see>
	/// </td>
	/// <td>
	/// <see cref="Queue{E}.offer(object)">offer(e)</see>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td><b>Remove</b></td>
	/// <td>
	/// <see cref="Queue{E}.remove()">remove()</see>
	/// </td>
	/// <td>
	/// <see cref="Queue{E}.poll()">poll()</see>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td><b>Examine</b></td>
	/// <td>
	/// <see cref="Queue{E}.element()">element()</see>
	/// </td>
	/// <td>
	/// <see cref="Queue{E}.peek()">peek()</see>
	/// </td>
	/// </tr>
	/// </table>
	/// <p>Queues typically, but do not necessarily, order elements in a
	/// FIFO (first-in-first-out) manner.  Among the exceptions are
	/// priority queues, which order elements according to a supplied
	/// comparator, or the elements' natural ordering, and LIFO queues (or
	/// stacks) which order the elements LIFO (last-in-first-out).
	/// Whatever the ordering used, the <em>head</em> of the queue is that
	/// element which would be removed by a call to
	/// <see cref="Queue{E}.remove()"></see>
	/// or
	/// <see cref="Queue{E}.poll()">Queue&lt;E&gt;.poll()</see>
	/// .  In a FIFO queue, all new elements are inserted at
	/// the <em> tail</em> of the queue. Other kinds of queues may use
	/// different placement rules.  Every <tt>Queue</tt> implementation
	/// must specify its ordering properties.
	/// <p>The
	/// <see cref="Queue{E}.offer(object)">offer</see>
	/// method inserts an element if possible,
	/// otherwise returning <tt>false</tt>.  This differs from the
	/// <see cref="Collection{E}.add(object)">Collection.add</see>
	/// method, which can fail to
	/// add an element only by throwing an unchecked exception.  The
	/// <tt>offer</tt> method is designed for use when failure is a normal,
	/// rather than exceptional occurrence, for example, in fixed-capacity
	/// (or &quot;bounded&quot;) queues.
	/// <p>The
	/// <see cref="Queue{E}.remove()">Queue&lt;E&gt;.remove()</see>
	/// and
	/// <see cref="Queue{E}.poll()">Queue&lt;E&gt;.poll()</see>
	/// methods remove and
	/// return the head of the queue.
	/// Exactly which element is removed from the queue is a
	/// function of the queue's ordering policy, which differs from
	/// implementation to implementation. The <tt>remove()</tt> and
	/// <tt>poll()</tt> methods differ only in their behavior when the
	/// queue is empty: the <tt>remove()</tt> method throws an exception,
	/// while the <tt>poll()</tt> method returns <tt>null</tt>.
	/// <p>The
	/// <see cref="Queue{E}.element()">Queue&lt;E&gt;.element()</see>
	/// and
	/// <see cref="Queue{E}.peek()">Queue&lt;E&gt;.peek()</see>
	/// methods return, but do
	/// not remove, the head of the queue.
	/// <p>The <tt>Queue</tt> interface does not define the <i>blocking queue
	/// methods</i>, which are common in concurrent programming.  These methods,
	/// which wait for elements to appear or for space to become available, are
	/// defined in the
	/// <see cref="java.util.concurrent.BlockingQueue{E}">java.util.concurrent.BlockingQueue&lt;E&gt;
	/// 	</see>
	/// interface, which
	/// extends this interface.
	/// <p><tt>Queue</tt> implementations generally do not allow insertion
	/// of <tt>null</tt> elements, although some implementations, such as
	/// <see cref="LinkedList{E}">LinkedList&lt;E&gt;</see>
	/// , do not prohibit insertion of <tt>null</tt>.
	/// Even in the implementations that permit it, <tt>null</tt> should
	/// not be inserted into a <tt>Queue</tt>, as <tt>null</tt> is also
	/// used as a special return value by the <tt>poll</tt> method to
	/// indicate that the queue contains no elements.
	/// <p><tt>Queue</tt> implementations generally do not define
	/// element-based versions of methods <tt>equals</tt> and
	/// <tt>hashCode</tt> but instead inherit the identity based versions
	/// from class <tt>Object</tt>, because element-based equality is not
	/// always well-defined for queues with the same elements but different
	/// ordering properties.
	/// </remarks>
	/// <seealso cref="Collection{E}">Collection&lt;E&gt;</seealso>
	/// <seealso cref="LinkedList{E}">LinkedList&lt;E&gt;</seealso>
	/// <seealso cref="PriorityQueue{E}">PriorityQueue&lt;E&gt;</seealso>
	/// <seealso cref="java.util.concurrent.LinkedBlockingQueue{E}">java.util.concurrent.LinkedBlockingQueue&lt;E&gt;
	/// 	</seealso>
	/// <seealso cref="java.util.concurrent.BlockingQueue{E}">java.util.concurrent.BlockingQueue&lt;E&gt;
	/// 	</seealso>
	/// <seealso cref="java.util.concurrent.ArrayBlockingQueue{E}">java.util.concurrent.ArrayBlockingQueue&lt;E&gt;
	/// 	</seealso>
	/// <seealso cref="java.util.concurrent.LinkedBlockingQueue{E}">java.util.concurrent.LinkedBlockingQueue&lt;E&gt;
	/// 	</seealso>
	/// <seealso cref="java.util.concurrent.PriorityBlockingQueue{E}">java.util.concurrent.PriorityBlockingQueue&lt;E&gt;
	/// 	</seealso>
	/// <since>1.5</since>
	/// <author>Doug Lea</author>
	/// <?></?>
	[Sharpen.Sharpened]
	public interface Queue<E> : java.util.Collection<E>
	{
		// BEGIN android-note
		// removed link to collections framework docs
		// END android-note
		/// <summary>
		/// Inserts the specified element into this queue if it is possible to do so
		/// immediately without violating capacity restrictions, returning
		/// <tt>true</tt> upon success and throwing an <tt>IllegalStateException</tt>
		/// if no space is currently available.
		/// </summary>
		/// <remarks>
		/// Inserts the specified element into this queue if it is possible to do so
		/// immediately without violating capacity restrictions, returning
		/// <tt>true</tt> upon success and throwing an <tt>IllegalStateException</tt>
		/// if no space is currently available.
		/// </remarks>
		/// <param name="e">the element to add</param>
		/// <returns>
		/// <tt>true</tt> (as specified by
		/// <see cref="Collection{E}.add(object)">Collection&lt;E&gt;.add(object)</see>
		/// )
		/// </returns>
		/// <exception cref="System.InvalidOperationException">
		/// if the element cannot be added at this
		/// time due to capacity restrictions
		/// </exception>
		/// <exception cref="System.InvalidCastException">
		/// if the class of the specified element
		/// prevents it from being added to this queue
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the specified element is null and
		/// this queue does not permit null elements
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if some property of this element
		/// prevents it from being added to this queue
		/// </exception>
		bool add(E e);

		/// <summary>
		/// Inserts the specified element into this queue if it is possible to do
		/// so immediately without violating capacity restrictions.
		/// </summary>
		/// <remarks>
		/// Inserts the specified element into this queue if it is possible to do
		/// so immediately without violating capacity restrictions.
		/// When using a capacity-restricted queue, this method is generally
		/// preferable to
		/// <see cref="Queue{E}.add(object)">Queue&lt;E&gt;.add(object)</see>
		/// , which can fail to insert an element only
		/// by throwing an exception.
		/// </remarks>
		/// <param name="e">the element to add</param>
		/// <returns>
		/// <tt>true</tt> if the element was added to this queue, else
		/// <tt>false</tt>
		/// </returns>
		/// <exception cref="System.InvalidCastException">
		/// if the class of the specified element
		/// prevents it from being added to this queue
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if the specified element is null and
		/// this queue does not permit null elements
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if some property of this element
		/// prevents it from being added to this queue
		/// </exception>
		bool offer(E e);

		/// <summary>Retrieves and removes the head of this queue.</summary>
		/// <remarks>
		/// Retrieves and removes the head of this queue.  This method differs
		/// from
		/// <see cref="Queue{E}.poll()">poll</see>
		/// only in that it throws an exception if this
		/// queue is empty.
		/// </remarks>
		/// <returns>the head of this queue</returns>
		/// <exception cref="NoSuchElementException">if this queue is empty</exception>
		E remove();

		/// <summary>
		/// Retrieves and removes the head of this queue,
		/// or returns <tt>null</tt> if this queue is empty.
		/// </summary>
		/// <remarks>
		/// Retrieves and removes the head of this queue,
		/// or returns <tt>null</tt> if this queue is empty.
		/// </remarks>
		/// <returns>the head of this queue, or <tt>null</tt> if this queue is empty</returns>
		E poll();

		/// <summary>Retrieves, but does not remove, the head of this queue.</summary>
		/// <remarks>
		/// Retrieves, but does not remove, the head of this queue.  This method
		/// differs from
		/// <see cref="Queue{E}.peek()">peek</see>
		/// only in that it throws an exception
		/// if this queue is empty.
		/// </remarks>
		/// <returns>the head of this queue</returns>
		/// <exception cref="NoSuchElementException">if this queue is empty</exception>
		E element();

		/// <summary>
		/// Retrieves, but does not remove, the head of this queue,
		/// or returns <tt>null</tt> if this queue is empty.
		/// </summary>
		/// <remarks>
		/// Retrieves, but does not remove, the head of this queue,
		/// or returns <tt>null</tt> if this queue is empty.
		/// </remarks>
		/// <returns>the head of this queue, or <tt>null</tt> if this queue is empty</returns>
		E peek();
	}
}
