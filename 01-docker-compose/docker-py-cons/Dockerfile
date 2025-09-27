FROM python:3-trixie

ENV SERVER="kafka-broker-1"
ENV TOPIC="test-topic"

ADD requirements.txt app.py /root
WORKDIR /root

RUN set -xe -o pipefail ;\
  pip install -r requirements.txt

CMD [ "python", "app.py" ]
