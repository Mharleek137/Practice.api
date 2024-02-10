using System.Data;
using Practice.api.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
const string EndpointName = "GetData";
var group = app.MapGroup("/datas");
List<Data> datas = new ()
{
    new Data()
    {
        Id = 1,
        Age = 23,
        Name = "Iremide",
        Gender = "M"
    },
     new Data()
    {
        Id = 2,
        Age = 24,
        Name = "dan",
        Gender = "M"
    },
     new Data()
    {
        Id = 3,
        Age = 25,
        Name = "Ikm",
        Gender = "M"
    },
     new Data()
    {
        Id = 4,
        Age = 25,
        Name = "Richard",
        Gender = "M"
    }
};
group.MapGet("/", () => datas);
group.MapGet("/{id}", (int id) => 
{
    Data? data = datas.Find(data => data.Id == id);
    if(datas is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(data);
}).WithName(EndpointName);
group.MapPost("/datas", (Data data) => 
{
    data.Id = datas.Max(data => data.Id) +1;
    datas.Add(data);
    return Results.CreatedAtRoute(EndpointName, new{id = data.Id});
});
group.MapPut("/datas", (int id, Data updateddata) => 
{
    Data? existingdata = datas.Find(data => data.Id == id);
     if(existingdata is null)
    {
        return Results.NotFound();
    }
    existingdata.Id = updateddata.Id;
    existingdata.Age = updateddata.Age;
    existingdata.Name = updateddata.Name;
    existingdata.Gender = updateddata.Gender;
    return Results.NoContent();
});
app.Run();
