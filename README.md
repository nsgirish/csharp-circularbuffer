# dotnet-csharp-circularbuffer

## Summary:
CircularBuffer class written in CSharp which can be used to buffer data streams like a message queue or topic which sends huge volume of data with a very short time limit.  For example lets take a scenario of listening to messages from a kafka topic and per second a huge number of messages are coming. In those scenarios a regular collection object used to process data would run quickly out of memory. The CircularBuffer class can be used in those scenarios to throttle and stream the messages after processing them

##Usage

```csharp
//init circular buffer
CircularBuffer<FeedInfo> buffer = new CircularBuffer<FeedInfo>(20);
  
//assuming have received a FeedInfo object from a data stream such as a message topic
bool isAdded = buffer.CheckAndAddItem(info,x => x!= null && x.Id = info.Id && x.Signature == info.Signature);

//cleanup circular buffer
if(buffer != null)
{
  buffer.Dispose();
  buffer = null;
}
```
