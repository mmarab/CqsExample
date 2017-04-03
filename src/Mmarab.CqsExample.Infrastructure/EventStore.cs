using System;
using System.Collections.Generic;
using Mmarab.CqsExample.DomainModels;
using Mmarab.CqsExample.DomainModels.Exceptions;
using System.Linq;
using System.Threading.Tasks;

namespace Mmarab.CqsExample.Infrastructure
{
    public class EventStore : IEventStore
    {
        private List<Event> _inMemoryEventStore = new List<Event>();

        private readonly Dictionary<Guid, List<EventDescriptor>> _current = new Dictionary<Guid, List<EventDescriptor>>();
        private struct EventDescriptor
        {

            public readonly Event EventData;
            public readonly Guid Id;
            public readonly int Version;

            public EventDescriptor(Guid id, Event eventData, int version)
            {
                EventData = eventData;
                Version = version;
                Id = id;
            }
        }

        public async Task<List<Event>> GetEventsForAggregate(Guid aggregateId)
        {
            if (!_current.TryGetValue(aggregateId, out List<EventDescriptor> eventDescriptors))
            {
                throw new AggregateNotFoundException();
            }

            return await Task.Run( () =>  eventDescriptors.Select(desc => desc.EventData).ToList());
        }        

        public async Task SaveEvents(Guid aggregateId, IEnumerable<Event> events, int? expectedVersion)
        {
            if (!_current.TryGetValue(aggregateId, out List<EventDescriptor> eventDescriptors))
            {
                eventDescriptors = new List<EventDescriptor>();
                _current.Add(aggregateId, eventDescriptors);
            }
            else if (expectedVersion != null && eventDescriptors[eventDescriptors.Count - 1].Version != expectedVersion)
            {
                throw new ConcurrencyException();
            }

            var i = eventDescriptors.Count == 0 ? -1 : eventDescriptors[eventDescriptors.Count - 1].Version;
            foreach (var @event in events)
            {
                i++;
                @event.Version = i;
                eventDescriptors.Add(new EventDescriptor(aggregateId, @event, i));
                _inMemoryEventStore.Add(@event);
            }
        }
    }
}
