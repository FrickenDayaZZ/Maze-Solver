using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visualtrees
{
    public class PriorityQueue<T>
    {
        int rearPointer = 0;
        int frontPoninter = 0;
        QueueNode<T>[] queue;

        public PriorityQueue(int size)
        {
            queue = new QueueNode<T>[size];
        }

        public void Enqueue(T data, int priority = 0)
        {
            QueueNode<T> enqueueNode = new QueueNode<T>(data, priority);
            for (int i = 0; i < queue.Length; i++)
            {
                if (enqueueNode.priority < queue[i].priority)
                {
                    queue[i] = enqueueNode;
                }
            }
        }

        public T Dequeue()
        {
            QueueNode<T> first = queue[0];
            for (int i = 0; i < queue.Length; i++)
            {
                if (first.priority < queue[i].priority)
                {
                    first = queue[i];
                }
            }
            queue
        }
    }

    class QueueNode<T>
    {
        public T data;
        public int priority;

        public QueueNode(T data, int priority = 0)
        {
            this.data = data;
            this.priority = priority;
        }
    }
}
