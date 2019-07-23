namespace A8
{
    internal class Packet
    {
        public int index;
        public long arrivalTime;
        public long processTime;
        public Packet(int index,long arr,long pro)
        {
            this.index = index;
            arrivalTime = arr;
            processTime = pro;
        }
    }
}