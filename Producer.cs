namespace InMemoryProducerConsumer
{
    public class Producer
    {
        private readonly BoundedBuffer<int> buffer;
        private readonly int id;

        public Producer(int id, BoundedBuffer<int> buffer)
        {
            this.id = id;
            this.buffer = buffer;
        }

        public void Start()
        {
            int id = 0;
            while(true)
            {
                buffer.Produce(id);
                Console.WriteLine($"Produced task with id: {id}");
                id++;
                Thread.Sleep(500);
            }
        }
    }
}