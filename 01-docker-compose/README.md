# Docker compose based Kafka playground

## Start the broker

Start the broker in detached mode.

```sh
docker compose up -d broker init
```

After a few seconds, the broker container is running and healthy.

```text
NAME             IMAGE                 COMMAND                  SERVICE   CREATED          STATUS                    PORTS
kafka-broker-1   apache/kafka:latest   "/__cacert_entrypoin…"   broker    40 minutes ago   Up 42 seconds (healthy)   0.0.0.0:32769->9092/tcp, [::]:32769->9092/tcp
```

## Start the shell based producer/consumer

Start the services using docker compose

```sh
docker compose up producer_sh consumer_sh
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

Use CTRL+c to stop it.

## Start the shell based perf demo

Start the test

```sh
docker compose up producer_perf_sh consumer_perf_sh
```

This start a single run of the test and exit once finished

```text
 ✔ Container kafka-broker-1            Running
 ✔ Container kafka-producer_perf_sh-1  Recreated
Attaching to consumer_perf_sh-1, producer_perf_sh-1
producer_perf_sh-1  | + cd /opt/kafka/bin/
producer_perf_sh-1  | + echo bootstrap.servers=kafka-broker-1:9092
producer_perf_sh-1  | + ./kafka-producer-perf-test.sh --producer.config /tmp/producer.properties --topic test-topic --num-records 1000000 --throughput 1000000 --record-size 500
consumer_perf_sh-1  | + cd /opt/kafka/bin/
consumer_perf_sh-1  | + sleep 2
consumer_perf_sh-1  | + ./kafka-consumer-perf-test.sh --bootstrap-server kafka-broker-1:9092 --topic test-topic --messages 1000000
consumer_perf_sh-1  | start.time, end.time, data.consumed.in.MB, MB.sec, data.consumed.in.nMsg, nMsg.sec, rebalance.time.ms, fetch.time.ms, fetch.MB.sec, fetch.nMsg.sec
producer_perf_sh-1  | 721953 records sent, 144390.6 records/sec (68.85 MB/sec), 422.2 ms avg latency, 1059.0 ms max latency.
producer_perf_sh-1  | 1000000 records sent, 172592.3 records/sec (82.30 MB/sec), 352.92 ms avg latency, 1059.00 ms max latency, 284 ms 50th, 875 ms 95th, 1038 ms 99th, 1057 ms 99.9th.
producer_perf_sh-1 exited with code 0
consumer_perf_sh-1  | 2025-09-26 17:44:37:720, 2025-09-26 17:44:42:136, 476.8389, 107.9798, 1000041, 226458.5598, 3242, 1174, 406.1660, 851823.6797
consumer_perf_sh-1 exited with code 0
```

## Starting the Python based demo

Start the services using docker compose

```sh
docker compose up producer_py consumer_py
```

After a fews second you should see the logs from the producer and the consumer

```text
consumer_py-1  | Starting Python Consumer for test-topic on kafka-broker-1:9092
producer_py-1  | Starting Python Producer for test-topic on kafka-broker-1:9092
consumer_py-1  | ConsumerRecord(topic='test-topic', partition=0, leader_epoch=0, offset=0, timestamp=1758963801693, timestamp_type=0, key=None, value=b'Test message at 2025-09-27 09:03:21', headers=[], checksum=None, serialized_key_size=-1, serialized_value_size=35, serialized_header_size=-1)
consumer_py-1  | ConsumerRecord(topic='test-topic', partition=0, leader_epoch=0, offset=1, timestamp=1758963804702, timestamp_type=0, key=None, value=b'Test message at 2025-09-27 09:03:24', headers=[], checksum=None, serialized_key_size=-1, serialized_value_size=35, serialized_header_size=-1)
```

Use CTRL+c to stop it.

## Clean up

Removes the container with the down command:

```sh
docker compose down
```
