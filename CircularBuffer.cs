 public class CircularBuffer<T>
 {
     private T[] buffer;
     private int _start;
     private int _end;
     private int _count;
     private readonly int _capacity;
     public CircularBuffer(int capacity)
     {
         
         _capacity = capacity;
         buffer = new T[capacity];
     }

     public T Read()
     {
         if (_count == 0)
                throw new InvalidOperationException("Buffer is empty");
         T value = buffer[_start];
         _count--;
         _start = (_start+1)%_capacity;
         return value;
     }

     public void Write(T value)
     {
         if (_count == _capacity)
         {
             throw new InvalidOperationException("Buffer is full");
         }
         buffer[_end] = value;
         _end = (_end + 1)%_capacity;
         _count++;
     }

     public void Overwrite(T value)
     {
         if (_count == _capacity)
         {
             buffer[_end] = value;
             _end = (_end + 1) % _capacity;
             _start = (_start + 1) % _capacity;
         }
         else
         {
             Write(value);
         }
     }

     public void Clear()
     {
         _start =0;
         _end =0;
         _count =0;
         Array.Clear(buffer, 0, buffer.Length);
     }
 }
