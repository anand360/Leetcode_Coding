// https://www.justsoftwaresolutions.co.uk/threading/implementing-a-thread-safe-queue-using-condition-variables.html
// https://github.com/microsoft/referencesource/blob/5697c29004a34d80acdaf5742d7e699022c64ecd/mscorlib/system/collections/Concurrent/ConcurrentQueue.cs#L741
// https://docs.microsoft.com/en-us/dotnet/standard/threading/how-to-use-spinlock-for-low-level-synchronization

// template<typename Data>
// class concurrent_queue
// {
// private:
//     std::queue<Data> the_queue;
//     mutable boost::mutex the_mutex;
//     boost::condition_variable the_condition_variable;
// public:
//     void push(Data const& data)
//     {
//         boost::mutex::scoped_lock lock(the_mutex);
//         the_queue.push(data);
//         lock.unlock();
//         the_condition_variable.notify_one();
//     }

//     bool empty() const
//     {
//         boost::mutex::scoped_lock lock(the_mutex);
//         return the_queue.empty();
//     }

//     bool try_pop(Data& popped_value)
//     {
//         boost::mutex::scoped_lock lock(the_mutex);
//         if(the_queue.empty())
//         {
//             return false;
//         }

//         popped_value=the_queue.front();
//         the_queue.pop();
//         return true;
//     }

//     void wait_and_pop(Data& popped_value)
//     {
//         boost::mutex::scoped_lock lock(the_mutex);
//         while(the_queue.empty())
//         {
//             the_condition_variable.wait(lock);
//         }

//         popped_value=the_queue.front();
//         the_queue.pop();
//     }

// };


// *******************************************************************************

// #include <stdio.h> #include <pthread.h>

// template <class T>
// class ListNode
// {
// public:
//     T item;
//     ListNode<T> *next;
// };

// template <class T>
// class SyncQueue
// {
// public:
//     SyncQueue()
//     {
//         head = NULL;
//         tail = NULL;
//         size = 0;
//         pthread_mutex_init(&mutex, NULL);
//         pthread_cond_init(&cond, NULL);
//     }

//     bool enqueue(const T &item)
//     {
//         if (pthread_mutex_lock(&mutex) != 0)
//         {
//             perror("Error! Couldn't lock mutex.");
//             return false;
//         }

//         ListNode<T> *node = new ListNode<T>;
//         node->item = item;

//         if (size == 0)
//         {
//             head = tail = node;
//         }
//         else
//         {
//             tail->next = node;
//             tail = tail->next;
//         }
//         size++;

//         if (pthread_cond_broadcast(&cond) != 0)
//         {
//             perror("cond broadcast error.");
//             return false;
//         }
//         if (pthread_mutex_unlock(&mutex) != 0)
//         {
//             perror("couldn't unlock mutex.");
//             return false;
//         }
//         return true;
//     }

//     bool dequeue(T &ret_item)
//     {
//         pthread_mutex_lock(&mutex);

//         while (size < 1)
//         {
//             pthread_cond_wait(&cond, &mutex);
//         }

//         if (size == 0)
//             return false;

//         //printf("Queue size: %d\n", size); ret_item = head->item; ListNode<T> *t_node = head->next; delete head; head = t_node; size--;

//         pthread_mutex_unlock(&mutex);
//         return true;
//     }

//     int size;

// private:
//     ListNode<T> *head;
//     ListNode<T> *tail;
//     pthread_mutex_t mutex;
//     pthread_cond_t cond;
// };