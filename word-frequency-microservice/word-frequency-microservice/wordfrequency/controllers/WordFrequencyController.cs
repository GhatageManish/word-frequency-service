using CLOOPS.NATS.Attributes;
using CLOOPS.NATS.Meta;
using NATS.Client.Core;
using wordfrequency.schema.Messages;
using wordfrequency.services;

namespace wordfrequency.controllers;

public class WordFrequencyController
{
    private readonly WordFrequencyService _service;

    public WordFrequencyController(WordFrequencyService service)
    {
        _service = service;
    }

    [NatsConsumer(_subject: "word.frequency")]
    public Task<NatsAck> Handle(NatsMsg<WordFrequencyRequest> msg, CancellationToken ct = default)
    {
        var request = msg.Data;

        if (request == null)
            throw new ArgumentException("Request body is null");

        var response = _service.Process(request.Text, request.TopN);

        return Task.FromResult(new NatsAck(_isAck: true, _reply: response));
    }
    
}