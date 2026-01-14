namespace InMemoryProducerConsumer
{
    public class BoundedBuffer<T>
    {
        private readonly T[] buffer;
        private int head;
        private int tail;
        private int count;
        private readonly object lockObj = new object();

        public BoundedBuffer(int capacity)
        {
            buffer = new T[capacity];
        }

        public void Produce(T item)
        {
            lock (lockObj)
            {
                while(count == buffer.Length)
                    Monitor.Wait(lockObj);
                buffer[tail] = item;
                tail = (tail + 1) % buffer.Length;
                count++;
                Monitor.PulseAll(lockObj);
            }
        }

        public T Consume()
        {
            lock (lockObj)
            {
                while(count == 0)
                    Monitor.Wait(lockObj);
                T item = buffer[head];
                head = (head + 1) % buffer.Length;
                count--;
                Monitor.PulseAll(lockObj);
                return item;
            }
        }
    }
}