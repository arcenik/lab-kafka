# Shell script based Kafka demo

## How to run

Start the stack using docker compose

```sh
docker compose up
```

After a fews second you should see the logs from the producer and the consumer

```text
producer_sh-1  | + true
producer_sh-1  | + ./kafka-console-producer.sh --bootstrap-server kafka-broker-1:9092 --topic test-topic
producer_sh-1  | ++ date
producer_sh-1  | + echo 'Test message at Fri Sep 26 15:14:33 UTC 2025'
consumer_sh-1  | Test message at Fri Sep 26 15:14:33 UTC 2025
producer_sh-1  | + sleep 3
```

## Stop the demo

Simply use CTRL+c
It take a few seconds to stop and output something like this:

```text
broker-1       | [2025-09-26 15:15:57,947] INFO [MetadataLoader id=1] closed event queue. (org.apache.kafka.queue.KafkaEventQueue)
broker-1       | [2025-09-26 15:15:57,947] INFO [SnapshotGenerator id=1] closed event queue. (org.apache.kafka.queue.KafkaEventQueue)
broker-1       | [2025-09-26 15:15:57,947] INFO Metrics scheduler closed (org.apache.kafka.common.metrics.Metrics)
broker-1       | [2025-09-26 15:15:57,947] INFO Closing reporter org.apache.kafka.common.metrics.JmxReporter (org.apache.kafka.common.metrics.Metrics)
broker-1       | [2025-09-26 15:15:57,947] INFO Metrics reporters closed (org.apache.kafka.common.metrics.Metrics)
broker-1       | [2025-09-26 15:15:57,948] INFO App info kafka.server for 1 unregistered (org.apache.kafka.common.utils.AppInfoParser)
broker-1       | [2025-09-26 15:15:57,948] INFO App info kafka.server for 1 unregistered (org.apache.kafka.common.utils.AppInfoParser)
 Container kafka-broker-1  Stopped
broker-1 exited with code 143
```

## Clean up

Removes the container with the down command:

```sh
docker compose down
```
