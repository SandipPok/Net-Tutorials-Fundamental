## MultiThreading

### Inter Thread Communication in C#

#### Methods of Monitor Class for Interthread Communication in C#

| Method | Return Type | Description | Parameters |
|--|--|--|--|
|**`public static bool Wait(Object obj)`**|Returns boolean value|It makes thread to wait for other thread to complete its work on the same object.|Obj refers to object on which to wait.|
|**`public static void Pulse(object obj`**|Return `null`|Notifies a thread in the waiting queue of a change in the locked object's state|`obj` specifies the object a thread is waiting for.|
|**`public static void PulseAll(object obj)`**|Return `null`|Release the lock over the object|`obj` specifies the object that sends the pulse.|

**`Note:`** The Calling of Wait(), Pulse(), PulseAll() method is only possible from within the synchronized context i.e. from within a synchronized block with a lock.