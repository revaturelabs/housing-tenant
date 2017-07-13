#!/bin/bash

# setup the dependencies for https support.
sudo apt-get update
sudo apt-get install -y \
  apt-transport-https \
  ca-certificates \
  curl \
  software-properties-common

# add docker to the repository.
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo apt-key add -
sudo add-apt-repository \
  "deb [arch=amd64] https://download.docker.com/linux/ubuntu \
  $(lsb_release -cs) \
  stable"

# install docker.
sudo apt-get update
sudo apt-get install -y docker-ce=17.06.0~ce-0~ubuntu

# allow docker for all users.
sudo groupadd docker
sudo usermod -aG docker $USER
sudo shutdown -r now
