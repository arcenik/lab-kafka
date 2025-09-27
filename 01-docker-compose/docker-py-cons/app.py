#! /usr/bin/env python3

from kafka import KafkaConsumer
from pprint import pprint as pp
import os, sys

running = True

################################################################################
################################################################################
def main():

  SERVER=os.getenv("SERVER")+":9092"
  TOPIC=os.getenv("TOPIC")

  print(f"Starting Python Consumer for {TOPIC} on {SERVER}")
  sys.stdout.flush()

  consumer = KafkaConsumer(TOPIC, bootstrap_servers=SERVER)

  for msg in consumer:
    pp(msg)
    sys.stdout.flush()

################################################################################
################################################################################
if "__main__" == __name__:
  main()
