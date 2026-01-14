namespace InMemoryProducerConsumer
{
    public class Program
    {
        public static void Main()
        {
            var buffer = new BoundedBuffer<int>(5);

            var producer1 = new Producer(1, buffer);
            var producer2 = new Producer(2, buffer);
            var consumer1 = new Consumer(1, buffer);
            var consumer2 = new Consumer(2, buffer);

            new Thread(producer1.Start).Start();
            new Thread(producer2.Start).Start();
            new Thread(consumer1.Start).Start();
            new Thread(consumer2.Start).Start();
        }
    }
}