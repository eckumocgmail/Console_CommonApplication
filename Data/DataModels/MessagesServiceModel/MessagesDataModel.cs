﻿using Microsoft.EntityFrameworkCore;

public sealed class MessagesDataModel: BaseDbContext, IMessagesDataModel
{
    public MessagesDataModel()
    {
    }

    public MessagesDataModel(DbContextOptions options) : base(options)
    {
    }

    public DbSet<MessageProtocol> MessageProtocols { get; set; }
    public DbSet<MessageProperty> MessageProperties { get; set; }
    public DbSet<MessageAttribute> MessageAttributes { get; set; }
    public DbSet<ValidationModel> ValidationModels { get; set; }
    public DbSet<BusinessResource> BusinessResources { get; set; }
    public DbSet<BusinessFunction> BusinessFunctions { get; set; }
    public DbSet<BusinessProcess> BusinessProcess { get; set; }

    protected override void InitDbSets()
    {
        
    }
}