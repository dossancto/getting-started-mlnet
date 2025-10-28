using static SentimentModel.ConsoleApp.SentimentModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", (string prompt) =>
{

  var sampleData = new ModelInput()
  {
    Col0 = prompt,
  };

  IOrderedEnumerable<KeyValuePair<string, float>> sortedScoresWithLabel = PredictAllLabels(sampleData);

  var first = sortedScoresWithLabel.First();

  return new
  {
    prompt,
    result = first.Key is "0" ? "Negative" : "Positive",
    sortedScoresWithLabel
  };
})
.WithName("Consume model");

app.Run();

