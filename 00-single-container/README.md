# Single container lab

From https://hub.docker.com/r/apache/kafka

Start a Kafka broker:

```sh
docker run -d --name broker apache/kafka:latest
```

Open a shell in the broker container:

```sh
docker exec -ti --workdir /opt/kafka/bin/ broker bash
```

A topic is a logical grouping of events in Kafka. From inside the container, create a topic called test-topic:

```sh
./kafka-topics.sh --bootstrap-server localhost:9092 --create --topic test-topic
```

Write two string events into the test-topic topic using the console producer that ships with Kafka:

```sh
./kafka-console-producer.sh --bootstrap-server localhost:9092 --topic test-topic
```

This command will wait for input at a > prompt. Enter hello, press Enter, then world, and press Enter again. Enter Ctrl+C to exit the console producer.

Now read the events in the test-topic topic from the beginning of the log:

```sh
./kafka-console-consumer.sh --bootstrap-server localhost:9092 --topic test-topic --from-beginning
```

You will see the two strings that you previously produced:

```text
hello
world
```

The consumer will continue to run until you exit out of it by entering Ctrl+C.

When you are finished, stop and remove the container by running the following command on your host machine:

```sh
docker rm -f broker
```
