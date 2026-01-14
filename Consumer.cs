namespace InMemoryProducerConsumer
{
    public class Consumer
    {
        private readonly BoundedBuffer<int> buffer;
        private readonly int id;

        public Consumer(int id, BoundedBuffer<int> buffer)
        {
            this.id = id;
            this.buffer = buffer;
        }

        public void Start()
        {
            while(true)
            {
                int item = buffer.Consume();
                Console.WriteLine($"Consumer task with id: {id}");
                Thread.Sleep(500);
            }
        }
    }
}