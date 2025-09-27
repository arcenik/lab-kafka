#! /usr/bin/env python3

from kafka import KafkaProducer
from datetime import datetime
from pprint import pprint as pp
import os, sys, time

running = True

################################################################################
################################################################################
def main():

  SERVER=os.getenv("SERVER")+":9092"
  TOPIC=os.getenv("TOPIC")

  print(f"Starting Python Producer for {TOPIC} on {SERVER}")
  sys.stdout.flush()

  producer = KafkaProducer(bootstrap_servers=SERVER)
  while True:
    now = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    producer.send(TOPIC, bytes(f"Test message from Python at {now}",encoding='utf8'))
    producer.flush()
    time.sleep(3)

################################################################################
################################################################################
if "__main__" == __name__:
  main()
