using Sharpen;

namespace java.util
{
	/// <summary>
	/// <code>Stack</code>
	/// is a Last-In/First-Out(LIFO) data structure which represents a
	/// stack of objects. It enables users to pop to and push from the stack,
	/// including null objects. There is no limit to the size of the stack.
	/// </summary>
	[Sharpen.Sharpened]
	public static class Stack
	{
		internal const long serialVersionUID = 1224463164541339165L;
	}

	/// <summary>
	/// <code>Stack</code>
	/// is a Last-In/First-Out(LIFO) data structure which represents a
	/// stack of objects. It enables users to pop to and push from the stack,
	/// including null objects. There is no limit to the size of the stack.
	/// </summary>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class Stack<E> : java.util.Vector<E>
	{
		/// <summary>
		/// Constructs a stack with the default size of
		/// <code>Vector</code>
		/// .
		/// </summary>
		public Stack()
		{
		}

		/// <summary>Returns whether the stack is empty or not.</summary>
		/// <remarks>Returns whether the stack is empty or not.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the stack is empty,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public virtual bool empty()
		{
			return isEmpty();
		}

		/// <summary>Returns the element at the top of the stack without removing it.</summary>
		/// <remarks>Returns the element at the top of the stack without removing it.</remarks>
		/// <returns>the element at the top of the stack.</returns>
		/// <exception cref="EmptyStackException">if the stack is empty.</exception>
		/// <seealso cref="Stack{E}.pop()">Stack&lt;E&gt;.pop()</seealso>
		public virtual E peek()
		{
			lock (this)
			{
				try
				{
					return (E)elementData[elementCount - 1];
				}
				catch (System.IndexOutOfRangeException)
				{
					throw new java.util.EmptyStackException();
				}
			}
		}

		/// <summary>Returns the element at the top of the stack and removes it.</summary>
		/// <remarks>Returns the element at the top of the stack and removes it.</remarks>
		/// <returns>the element at the top of the stack.</returns>
		/// <exception cref="EmptyStackException">if the stack is empty.</exception>
		/// <seealso cref="Stack{E}.peek()">Stack&lt;E&gt;.peek()</seealso>
		/// <seealso cref="Stack{E}.push(object)">Stack&lt;E&gt;.push(object)</seealso>
		public virtual E pop()
		{
			lock (this)
			{
				if (elementCount == 0)
				{
					throw new java.util.EmptyStackException();
				}
				int index = --elementCount;
				E obj = (E)elementData[index];
				elementData[index] = null;
				modCount++;
				return obj;
			}
		}

		/// <summary>Pushes the specified object onto the top of the stack.</summary>
		/// <remarks>Pushes the specified object onto the top of the stack.</remarks>
		/// <param name="object">The object to be added on top of the stack.</param>
		/// <returns>the object argument.</returns>
		/// <seealso cref="Stack{E}.peek()">Stack&lt;E&gt;.peek()</seealso>
		/// <seealso cref="Stack{E}.pop()">Stack&lt;E&gt;.pop()</seealso>
		public virtual E push(E @object)
		{
			addElement(@object);
			return @object;
		}

		/// <summary>
		/// Returns the index of the first occurrence of the object, starting from
		/// the top of the stack.
		/// </summary>
		/// <remarks>
		/// Returns the index of the first occurrence of the object, starting from
		/// the top of the stack.
		/// </remarks>
		/// <returns>
		/// the index of the first occurrence of the object, assuming that
		/// the topmost object on the stack has a distance of one.
		/// </returns>
		/// <param name="o">the object to be searched.</param>
		public virtual int search(object o)
		{
			lock (this)
			{
				object[] dumpArray = elementData;
				int size_1 = elementCount;
				if (o != null)
				{
					{
						for (int i = size_1 - 1; i >= 0; i--)
						{
							if (o.Equals(dumpArray[i]))
							{
								return size_1 - i;
							}
						}
					}
				}
				else
				{
					{
						for (int i = size_1 - 1; i >= 0; i--)
						{
							if (dumpArray[i] == null)
							{
								return size_1 - i;
							}
						}
					}
				}
				return -1;
			}
		}
	}
}
