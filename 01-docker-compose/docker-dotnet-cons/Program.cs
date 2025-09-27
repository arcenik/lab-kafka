using Confluent.Kafka;
using System;
using System.Collections;
using DotNetEnv;

Env.Load();

Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
Console.WriteLine(Environment.GetEnvironmentVariable("PATH"));
foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
{
  Console.WriteLine($"{de.Key} = {de.Value}");
}
Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

string server = Environment.GetEnvironmentVariable("SERVER");
// string kafkaConnection = $"{server}:9092";
// string topic = Environment.GetEnvironmentVariable("TOPIC");
string kafkaConnection = "kafka-broker-1:9092";
string topic = "test-topic";


Console.WriteLine("Starting .Net Consumer on topic " + topic + " with server " + kafkaConnection);

Consumer consumer = new Consumer(kafkaConnection);
consumer.ReceiveMessages(topic);
