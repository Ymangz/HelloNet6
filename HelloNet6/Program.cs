using System.Text.Encodings.Web;
using System.Text.Unicode;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HelloNet6;
using HelloNet6.Filters;
using HelloNet6.JsonConverters;
using Microsoft.AspNetCore.Mvc;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up!");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers(cfg =>
    {
        cfg.Filters.Add<ExceptionHandlerFilter>();
        cfg.Filters.Add<ResultWrapperFilter>();
    })
    .AddJsonOptions(cfg =>
    {
        cfg.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
        cfg.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
    })
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            //自定义参数校验返回
            var result = new JsonResult(context.ModelState);
            return result;
        };
    });
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContextPool<>();

builder.Host.UseSerilog();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(
    b => { b.RegisterModule<DefaultModuleRegister>(); }
);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();