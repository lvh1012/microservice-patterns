﻿using Confluent.Kafka;
using CQRS.Library.BorrowingHistoryService.EventHandling;
using CQRS.Library.BorrowingHistoryService.Infrastructure.Data;
using EventBus;
using EventBus.Abstractions;
using System.Text.Json;

namespace CQRS.Library.BorrowingHistoryService.Bootstraping;
public static class ApplicationServiceExtensions
{
    public static IHostApplicationBuilder AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.AddServiceDefaults();
        builder.Services.AddOpenApi();
        builder.AddNpgsqlDbContext<BorrowingHistoryDbContext>("cqrs-borrowing-history-db");
        builder.Services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });
        builder.AddEventConsumer();

        return builder;
    }

    private static IHostApplicationBuilder AddEventConsumer(this IHostApplicationBuilder builder)
    {
        builder.AddKafkaMessageEnvelopConsumer("cqrs-library");
        builder.Services.AddSingleton(new EventHandlingWorkerOptions());
        builder.Services.AddSingleton<IIntegrationEventFactory, IntegrationEventFactory<BookCreatedIntegrationEvent>>();
        builder.Services.AddHostedService<EventHandlingService>();
        return builder;
    }
}

