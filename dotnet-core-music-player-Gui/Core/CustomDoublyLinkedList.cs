namespace dotnet_core_music_player_Gui.Core
{
    public class CustomDoublyLinkedList<T>
    {
        private Node<T>? head;
        private Node<T>? tail;
        private int nodeCount;

        public Node<T>? First => head;
        public Node<T>? Last => tail;
        public CustomDoublyLinkedList()
        {
            head = null;
            tail = null;
            nodeCount = 0;
        }

        // ------------------ Add operations ------------------
        public void AddFront(T value)
        {
            var newNode = new Node<T>(value);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                var oldHead = head;
                newNode.Next = oldHead;
                oldHead.Prev = newNode;
                head = newNode;
            }
            nodeCount++;
        }

        public void AddBack(T value)
        {
            var newNode = new Node<T>(value);
            if (tail == null)
            {
                head = tail = newNode;
            }
            else
            {
                var oldTail = tail;
                newNode.Prev = oldTail;
                oldTail.Next = newNode;
                tail = newNode;
            }
            nodeCount++;
        }

        // ------------------ Update operation ------------------
        public bool Update(T oldValue, T newValue)
        {
            var current = head;
            while (current != null)
            {
                // Use EqualityComparer for safe null handling
                if (EqualityComparer<T>.Default.Equals(current.Data, oldValue))
                {
                    current.Data = newValue;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        // ------------------ Find operation ------------------
        public bool Find(T value)
        {
            var current = head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, value))
                    return true;
                current = current.Next;
            }
            return false;
        }

        // ------------------ Delete operations ------------------
        public void DeleteFirst()
        {
            if (head == null)
                throw new InvalidOperationException("List is empty, cannot delete first node");

            if (head == tail)
            {
                head = tail = null;
            }
            else
            {
                var newHead = head.Next;
                if (newHead == null)
                    throw new InvalidOperationException("Internal error: head.Next is null when list size > 1");

                newHead.Prev = null;
                head = newHead;
            }
            nodeCount--;
        }

        public void DeleteLast()
        {
            if (tail == null)
                throw new InvalidOperationException("List is empty, cannot delete last node");

            if (head == tail)
            {
                head = tail = null;
            }
            else
            {
                var newTail = tail.Prev;
                if (newTail == null)
                    throw new InvalidOperationException("Internal error: tail.Prev is null when list size > 1");

                newTail.Next = null;
                tail = newTail;
            }
            nodeCount--;
        }

        public bool DeleteByValue(T value)
        {
            var current = head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, value))
                {
                    if (current.Prev != null)
                        current.Prev.Next = current.Next;
                    else
                        head = current.Next;

                    if (current.Next != null)
                        current.Next.Prev = current.Prev;
                    else
                        tail = current.Prev;

                    nodeCount--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        // ------------------ Utility operations ------------------
        public void DisplayForward()
        {
            var current = head;
            while (current != null)
            {
                Console.Write(current.Data + " <-> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        public void DisplayBackward()
        {
            var current = tail;
            while (current != null)
            {
                Console.Write(current.Data + " <-> ");
                current = current.Prev;
            }
            Console.WriteLine("null");
        }

        public int Size() => nodeCount;

        public bool IsEmpty() => head == null;

        public void Clear()
        {
            head = null;
            tail = null;
            nodeCount = 0;
        }

        public CustomDoublyLinkedList<T> Copy()
        {
            var newList = new CustomDoublyLinkedList<T>();
            var current = head;
            while (current != null)
            {
                newList.AddBack(current.Data);
                current = current.Next;
            }
            return newList;
        }
    }
}